using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Infragistics.Documents.Excel;
using RTV_Report.Domain.DAO;
using RTV_Report.Domain.Model;
using RTV_Report.Model;
using RTV_Report.Parser;
using RTV_Report.Utils;
using RTV_Report.Validator;

namespace RTV_Report.UI
{
    public partial class Main : Form
    {
        public const string XLSX_FILTER = "All files|*.xlsx";

        private readonly DateTime Deadline = new DateTime(2014, 7, 30);

        private IList<SupplierAuthorizationDestory> _supplierAuthorizationDestories =
            new List<SupplierAuthorizationDestory>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            statusLabel.ForeColor = Color.Red;
        }

        private void ChangeStatusLabelColor()
        {
            statusLabel.ForeColor = Color.FromArgb(new Random().Next());
        }

        private string StatusLabelText
        {
            set
            {
                statusLabel.IsLink = false;
                statusLabel.Tag = string.Empty;
                statusLabel.Click -= statusLabel_Click;
                statusLabel.Text = value;
            }

            get { return statusLabel.Text; }
        }

        private void SetStatusLabelLinkText(string linkText, string linkTo)
        {
            statusLabel.IsLink = true;
            statusLabel.LinkBehavior = LinkBehavior.SystemDefault;
            statusLabel.Tag = linkTo;
            statusLabel.Text = linkText;
            statusLabel.Click -= statusLabel_Click;
            statusLabel.Click += statusLabel_Click;
        }

        //System.Diagnostics.Process.Start("explorer.exe", "C:\\Users\\sunal4\\Desktop\\RTV");

        private bool IsImporting()
        {
            return bgwFileParser.IsBusy || bgwImporter.IsBusy;
        }

        private void StartStatusProcessBar()
        {
            statusProcessBar.Visible = true;
        }

        private void PauseStatusProcessBar()
        {
            statusProcessBar.Visible = false;
        }

        private enum ImportReportType
        {
            ClaimOrderReport,
            SupplierAuthorizationDestoryReport
        }

        private void menuItemClaimOrderReport_Click(object sender, EventArgs e)
        {
            if (IsImporting())
            {
                return;
            }

            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = XLSX_FILTER;
            diag.Multiselect = false;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                StartStatusProcessBar();
                StatusLabelText = "开始解析文件...";
                ChangeStatusLabelColor();
                bgwFileParser.RunWorkerAsync(new object[] {diag.FileName, ImportReportType.ClaimOrderReport});
            }
        }

        private void supplierAuthorizationDestoryReport_Click(object sender, EventArgs e)
        {
            if (IsImporting())
            {
                return;
            }

            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = XLSX_FILTER;
            diag.Multiselect = false;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                StartStatusProcessBar();
                StatusLabelText = "开始解析文件...";
                ChangeStatusLabelColor();
                bgwFileParser.RunWorkerAsync(new object[]
                                                 {diag.FileName, ImportReportType.SupplierAuthorizationDestoryReport});
            }
        }

        private void bgwFileParser_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportReportType reportType = (ImportReportType) ((object[]) e.Argument)[1];

            switch (reportType)
            {
                case ImportReportType.ClaimOrderReport :
                    List<ClaimOrder> claimOrders = new List<ClaimOrder>();
                    try
                    {
                        claimOrders = ClaimOrderParser.ParseXLSX((string) ((object[]) e.Argument)[0]);
                        e.Result = new object[] {claimOrders, ImportReportType.ClaimOrderReport};
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("文件被其他程序占用。\n" + ex.Message, "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ImportReportType.SupplierAuthorizationDestoryReport :
                    List<SupplierAuthorizationDestory> supplierAuthorizationDestories =
                        new List<SupplierAuthorizationDestory>();
                    try
                    {
                        supplierAuthorizationDestories =
                            SupplierAuthorizationDestoryReportParser.ParseXLSX((string) ((object[]) e.Argument)[0]);
                        e.Result = new object[] { supplierAuthorizationDestories, ImportReportType.SupplierAuthorizationDestoryReport };
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("文件被其他程序占用。" + ex.Message, "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }

        }

        private void bgwFileParser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                PauseStatusProcessBar();
                return;
            }
                
            
            ImportReportType reportType = (ImportReportType) ((object[]) e.Result)[1];

            switch (reportType)
            {
                case ImportReportType.ClaimOrderReport :
                    List<ClaimOrder> claimOrders = (List<ClaimOrder>)((object[])e.Result)[0];
                    StatusLabelText =
                        String.Format("文件读取成功(共{0}条)，正在进行校验...", claimOrders.Count);
                    ChangeStatusLabelColor();
                    bgwValidator.RunWorkerAsync(claimOrders);
                    break;
                case ImportReportType.SupplierAuthorizationDestoryReport :
                    _supplierAuthorizationDestories = (List<SupplierAuthorizationDestory>) ((object[])e.Result)[0];
                    StatusLabelText =
                        String.Format("文件读取成功(共{0}条)。", _supplierAuthorizationDestories.Count);
                    ChangeStatusLabelColor();
                    PauseStatusProcessBar();
                    break;
            }

        }

        private void bgwValidator_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ClaimOrder> claimOrders = (List<ClaimOrder>) e.Argument;
            IList<IValidator> validators = new List<IValidator>();
            validators.Add(new DuplicationValidator(claimOrders));
            validators.Add(new SameClaimNoHasSameDateValidator(claimOrders));
            validators.Add(new DestoryDateValidator(claimOrders));
            validators.Add(new SupplierAuthorizationDestoryReportValidator(claimOrders, _supplierAuthorizationDestories));

            string formatedError = string.Empty;
            int errorCount = 0;
            foreach (IValidator validator in validators)
            {
                IList<string> errorMsgs = validator.Validate();
                if (errorMsgs.Count > 0)
                {
                    errorCount += errorMsgs.Count;
                    formatedError += validator.ErrorName + "\n\n";
                    foreach (string errorMsg in errorMsgs)
                    {
                        formatedError += errorMsg + "\n";
                    }

                    formatedError += "\n\n\n";
                }
            }

            object[] result = new object[3];
            result[0] = errorCount;
            result[1] = formatedError;
            result[2] = claimOrders;
            e.Result = result;
        }

        private void bgwValidator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int errorCount = (int) ((object[]) e.Result)[0];
            string labelText = String.Format("校验完成， 共发现{0}个错误。", errorCount);

            if (errorCount == 0)
            {
                StatusLabelText = labelText + "开始保存...";
                ChangeStatusLabelColor();
                object[] args = new object[2];
                args[0] = ((object[]) e.Result)[2];
                args[1] = 0;
                bgwImporter.RunWorkerAsync(args);
            }
            else
            {
                StatusLabelText = labelText + "无法保存！";
                ChangeStatusLabelColor();
                string errorMsg = (string) ((object[]) e.Result)[1];
                MessageBox.Show(errorMsg, "无法通过校验", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PauseStatusProcessBar();
            }

        }

        private void bgwImporter_DoWork(object sender, DoWorkEventArgs e)
        {
            const int BulkCount = 100;

            ClaimOrderDao claimOrderDao = new ClaimOrderDao();
            int progress = (int)((object[]) e.Argument)[1];
            List<ClaimOrder> claimOrders = (List<ClaimOrder>) ((object[]) e.Argument)[0];
            int actualBulkCount = Math.Min(BulkCount, claimOrders.Count - progress);
            
            claimOrderDao.Save(claimOrders.GetRange(progress, actualBulkCount));
            progress += actualBulkCount;
            object[] results = new object[2];
            results[0] = claimOrders;
            results[1] = progress;

            e.Result = results;
        }

        private void bgwImporter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int progress = (int)((object[]) e.Result)[1];
            List<ClaimOrder> claimOrders = (List<ClaimOrder>)((object[])e.Result)[0];
            if (progress >= claimOrders.Count)
            {
                StatusLabelText =
                String.Format("保存成功(共{0}条)！", progress);
                ChangeStatusLabelColor();
                PauseStatusProcessBar();
            } else
            {
                StatusLabelText = String.Format("正在保存({0}/{1})...", progress, claimOrders.Count);
                bgwImporter.RunWorkerAsync(e.Result);
            }
            
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {
            ToolStripLabel toolStripLabel1 = (ToolStripLabel) sender;

            System.Diagnostics.Process.Start("explorer.exe", toolStripLabel1.Tag.ToString());
            toolStripLabel1.LinkVisited = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsImporting())
            {
                return;
            }

            string supplierNo = txtSuppilerNo.Text;
            string claimNo = txtClaimNo.Text;

            ClaimOrderDao claimOrderDao = new ClaimOrderDao();
            IList<ClaimOrder> claimOrders = claimOrderDao.Find(supplierNo, claimNo);

            RefillResultGrid(claimOrders);
        }

        private void RefillResultGrid(IList<ClaimOrder> claimOrders)
        {
            gridResult.Rows.Clear();

            foreach (ClaimOrder claimOrder in claimOrders)
            {
                gridResult.Rows.Add();
                DataGridViewRow newRow = gridResult.Rows[gridResult.RowCount - 1];

                newRow.Cells["RTV"].Value = claimOrder.rtv;
                newRow.Cells["ClaimNo"].Value = claimOrder.claimNo;
                newRow.Cells["LotNo"].Value = claimOrder.lotNo;
                newRow.Cells["SupplierNo"].Value = claimOrder.supplierNo;
                newRow.Cells["SupplierName"].Value = claimOrder.supplierName;
                newRow.Cells["Dept"].Value = claimOrder.dept;
                newRow.Cells["Qty"].Value = claimOrder.qty;
                newRow.Cells["Pcs"].Value = claimOrder.pcs;
                newRow.Cells["ClaimAmount"].Value = claimOrder.claimAmount;
                newRow.Cells["ClaimReason"].Value = claimOrder.claimReason;
                newRow.Cells["DecidedDate"].Value = DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.decidedDate);
                newRow.Cells["DecidedDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                newRow.Cells["ArriveRTVDate"].Value = DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.arriveRTVDate);
                newRow.Cells["ArriveRTVDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                newRow.Cells["InformDate"].Value = DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.informDate);
                newRow.Cells["InformDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                newRow.Cells["InformDays"].Value = claimOrder.informDays;
                newRow.Cells["WithdrawDate"].Value = DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.withdrawDate);
                newRow.Cells["WithdrawDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                newRow.Cells["GateOutDate"].Value = DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.gateOutDate);
                newRow.Cells["GateOutDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                newRow.Cells["GateOutType"].Value = claimOrder.gateOutType;
                newRow.Cells["DestoryInformDate"].Value =
                    DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.destoryInformDate);
                newRow.Cells["DestoryInformDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                newRow.Cells["DestoryType"].Value = claimOrder.destoryType;
                newRow.Cells["InformDateIfOver50Days"].Value =
                    DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.informDateIfOver50Days);
                newRow.Cells["InformDateIfOver50Days"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                newRow.Cells["CreationDate"].Value = DateTimeUtils.ToShortStringEmptyIfMin(claimOrder.creationDate);
                newRow.Cells["CreationDate"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            gridResult.AutoResizeColumns();

            StatusLabelText = String.Format("共找到{0}条。", claimOrders.Count);
            ChangeStatusLabelColor();
        }

        private void menuItemClearOutOfDateData_Click(object sender, EventArgs e)
        {
            ClaimOrderDao claimOrderDao = new ClaimOrderDao();
            int deletedCnt = claimOrderDao.DeleteCreationDayBefore(DateTime.Today);

            StatusLabelText = String.Format("成功删除{0}条数据！", deletedCnt);
            ChangeStatusLabelColor();
        }

        private void menuItemSameSuppOver14Days_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDiag = new SaveFileDialog();
            saveDiag.Filter = XLSX_FILTER;

            if (saveDiag.ShowDialog() == DialogResult.OK)
            {
                ClaimOrderDao claimOrderDao = new ClaimOrderDao();
                IList<ClaimOrder> claimOrders = claimOrderDao.FindOver10000YuanOver14DaysGroupBySupplier();
                Workbook workbook = Exporter.ReportGenerator.GenerateOver10000YuanOver14DaysReport(claimOrders);

                try
                {
                    workbook.Save(saveDiag.FileName);
                    SetStatusLabelLinkText("导出成功！ 点击打开： " + saveDiag.FileName, saveDiag.FileName);
                }
                catch (IOException)
                {
                    MessageBox.Show("文件被其他程序占用。", "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void menuItemInformDaysOver50_Click(object sender, EventArgs e)
        {
            InformDateOver50DaysReportCriteriaDialog criteriaDialog = new InformDateOver50DaysReportCriteriaDialog();
            if (criteriaDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveDiag = new SaveFileDialog();
                saveDiag.Filter = XLSX_FILTER;

                if (saveDiag.ShowDialog() == DialogResult.OK)
                {
                    ClaimOrderDao claimOrderDao = new ClaimOrderDao();
                    IList<ClaimOrder> claimOrders =
                        claimOrderDao.FindInformDaysBetween(50, criteriaDialog.InformDaysUpperLimit);
                    Workbook workbook = Exporter.ReportGenerator.GenerateInformDaysBetweenReport(claimOrders);

                    try
                    {
                        workbook.Save(saveDiag.FileName);
                        SetStatusLabelLinkText("导出成功！ 点击打开： " + saveDiag.FileName, saveDiag.FileName);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("文件被其他程序占用。", "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private void menuItemDestoryOver64Days_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDiag = new SaveFileDialog();
            saveDiag.Filter = XLSX_FILTER;

            if (saveDiag.ShowDialog() == DialogResult.OK)
            {
                ClaimOrderDao claimOrderDao = new ClaimOrderDao();
                IList<ClaimOrder> claimOrders = claimOrderDao.Find64DaysDestory(ClaimOrderDao.Day.Today);
                Workbook workbook = Exporter.ReportGenerator.Generate64DaysDestoryReport(claimOrders);

                try
                {
                    workbook.Save(saveDiag.FileName);
                    SetStatusLabelLinkText("导出成功！ 点击打开： " + saveDiag.FileName, saveDiag.FileName);
                }
                catch (IOException)
                {
                    MessageBox.Show("文件被其他程序占用。", "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void menuItemInformDaysOver14_Click(object sender, EventArgs e)
        {
            InformDaysOver14ReportDialog informDaysOver14ReportDialog = new InformDaysOver14ReportDialog();
            if (informDaysOver14ReportDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveDiag = new SaveFileDialog();
                saveDiag.Filter = XLSX_FILTER;

                if (saveDiag.ShowDialog() == DialogResult.OK)
                {
                    ClaimOrderDao claimOrderDao = new ClaimOrderDao();
                    IDictionary<ClaimOrder, double> claimOrders =
                        claimOrderDao.FindInformDaysOver14(informDaysOver14ReportDialog.LastAccountDate.Date);
                    Workbook workbook = Exporter.ReportGenerator.GenerateOver14DaysReport(claimOrders);

                    try
                    {
                        workbook.Save(saveDiag.FileName);
                        SetStatusLabelLinkText("导出成功！ 点击打开： " + saveDiag.FileName, saveDiag.FileName);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("文件被其他程序占用。", "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void timerActivation_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.CompareTo(Deadline) > 0)
            {
                MessageBox.Show("产品过期！", "过期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
    }
}