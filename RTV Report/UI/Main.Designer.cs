namespace RTV_Report.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClaimOrderReport = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierAuthorizationDestoryReport = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSameSuppOver14Days = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInformDaysOver50 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDestoryOver64Days = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInformDaysOver14 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearOutOfDateData = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.gridResult = new System.Windows.Forms.DataGridView();
            this.RTV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaimNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaimAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaimReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DecidedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArriveRTVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WithdrawDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GateOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GateOutType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestoryInformDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestoryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformDateIfOver50Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProcessBar = new System.Windows.Forms.ToolStripProgressBar();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.txtSuppilerNo = new System.Windows.Forms.TextBox();
            this.lblClaimNo = new System.Windows.Forms.Label();
            this.lblSupplierNo = new System.Windows.Forms.Label();
            this.bgwImporter = new System.ComponentModel.BackgroundWorker();
            this.bgwFileParser = new System.ComponentModel.BackgroundWorker();
            this.bgwValidator = new System.ComponentModel.BackgroundWorker();
            this.timerActivation = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.gbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuItemEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClaimOrderReport,
            this.supplierAuthorizationDestoryReport});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.importToolStripMenuItem.Text = "导入";
            // 
            // menuItemClaimOrderReport
            // 
            this.menuItemClaimOrderReport.Name = "menuItemClaimOrderReport";
            this.menuItemClaimOrderReport.Size = new System.Drawing.Size(182, 22);
            this.menuItemClaimOrderReport.Text = "索赔货物状况报告";
            this.menuItemClaimOrderReport.Click += new System.EventHandler(this.menuItemClaimOrderReport_Click);
            // 
            // supplierAuthorizationDestoryReport
            // 
            this.supplierAuthorizationDestoryReport.Name = "supplierAuthorizationDestoryReport";
            this.supplierAuthorizationDestoryReport.Size = new System.Drawing.Size(182, 22);
            this.supplierAuthorizationDestoryReport.Text = "供应商授权销毁报告";
            this.supplierAuthorizationDestoryReport.Click += new System.EventHandler(this.supplierAuthorizationDestoryReport_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSameSuppOver14Days,
            this.menuItemInformDaysOver50,
            this.menuItemDestoryOver64Days,
            this.menuItemInformDaysOver14});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exportToolStripMenuItem.Text = "导出";
            // 
            // menuItemSameSuppOver14Days
            // 
            this.menuItemSameSuppOver14Days.Name = "menuItemSameSuppOver14Days";
            this.menuItemSameSuppOver14Days.Size = new System.Drawing.Size(248, 22);
            this.menuItemSameSuppOver14Days.Text = "同一供应商超14天超10000元报告";
            this.menuItemSameSuppOver14Days.Click += new System.EventHandler(this.menuItemSameSuppOver14Days_Click);
            // 
            // menuItemInformDaysOver50
            // 
            this.menuItemInformDaysOver50.Name = "menuItemInformDaysOver50";
            this.menuItemInformDaysOver50.Size = new System.Drawing.Size(248, 22);
            this.menuItemInformDaysOver50.Text = "超50天通知日期报告";
            this.menuItemInformDaysOver50.Click += new System.EventHandler(this.menuItemInformDaysOver50_Click);
            // 
            // menuItemDestoryOver64Days
            // 
            this.menuItemDestoryOver64Days.Name = "menuItemDestoryOver64Days";
            this.menuItemDestoryOver64Days.Size = new System.Drawing.Size(248, 22);
            this.menuItemDestoryOver64Days.Text = "64天销毁报告";
            this.menuItemDestoryOver64Days.Click += new System.EventHandler(this.menuItemDestoryOver64Days_Click);
            // 
            // menuItemInformDaysOver14
            // 
            this.menuItemInformDaysOver14.Name = "menuItemInformDaysOver14";
            this.menuItemInformDaysOver14.Size = new System.Drawing.Size(248, 22);
            this.menuItemInformDaysOver14.Text = "通知天数超14天报告";
            this.menuItemInformDaysOver14.Click += new System.EventHandler(this.menuItemInformDaysOver14_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClearOutOfDateData});
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(43, 20);
            this.menuItemEdit.Text = "编辑";
            // 
            // menuItemClearOutOfDateData
            // 
            this.menuItemClearOutOfDateData.Name = "menuItemClearOutOfDateData";
            this.menuItemClearOutOfDateData.Size = new System.Drawing.Size(146, 22);
            this.menuItemClearOutOfDateData.Text = "清空过期数据";
            this.menuItemClearOutOfDateData.Click += new System.EventHandler(this.menuItemClearOutOfDateData_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.AllowDrop = true;
            this.pnlSearch.Controls.Add(this.gbResult);
            this.pnlSearch.Controls.Add(this.gbSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(0, 24);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSearch.Size = new System.Drawing.Size(866, 538);
            this.pnlSearch.TabIndex = 2;
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.gridResult);
            this.gbResult.Controls.Add(this.statusStrip);
            this.gbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResult.Location = new System.Drawing.Point(5, 65);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(856, 468);
            this.gbResult.TabIndex = 8;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "结果";
            // 
            // gridResult
            // 
            this.gridResult.AllowUserToAddRows = false;
            this.gridResult.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RTV,
            this.ClaimNo,
            this.LotNo,
            this.SupplierNo,
            this.SupplierName,
            this.Dept,
            this.Qty,
            this.Pcs,
            this.ClaimAmount,
            this.ClaimReason,
            this.DecidedDate,
            this.ArriveRTVDate,
            this.InformDate,
            this.InformDays,
            this.WithdrawDate,
            this.GateOutDate,
            this.GateOutType,
            this.DestoryInformDate,
            this.DestoryType,
            this.InformDateIfOver50Days,
            this.CreationDate});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridResult.DefaultCellStyle = dataGridViewCellStyle14;
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.Location = new System.Drawing.Point(3, 16);
            this.gridResult.Name = "gridResult";
            this.gridResult.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gridResult.RowHeadersVisible = false;
            this.gridResult.Size = new System.Drawing.Size(850, 427);
            this.gridResult.TabIndex = 7;
            // 
            // RTV
            // 
            this.RTV.HeaderText = "RTV";
            this.RTV.Name = "RTV";
            this.RTV.ReadOnly = true;
            // 
            // ClaimNo
            // 
            this.ClaimNo.HeaderText = "WMT索赔号";
            this.ClaimNo.Name = "ClaimNo";
            this.ClaimNo.ReadOnly = true;
            // 
            // LotNo
            // 
            this.LotNo.HeaderText = "批次号";
            this.LotNo.Name = "LotNo";
            this.LotNo.ReadOnly = true;
            // 
            // SupplierNo
            // 
            this.SupplierNo.HeaderText = "供应商号";
            this.SupplierNo.Name = "SupplierNo";
            this.SupplierNo.ReadOnly = true;
            // 
            // SupplierName
            // 
            this.SupplierName.HeaderText = "供应商名称";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // Dept
            // 
            this.Dept.HeaderText = "部门";
            this.Dept.Name = "Dept";
            this.Dept.ReadOnly = true;
            // 
            // Qty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle2;
            this.Qty.HeaderText = "箱数";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Pcs
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Pcs.DefaultCellStyle = dataGridViewCellStyle3;
            this.Pcs.HeaderText = "件数";
            this.Pcs.Name = "Pcs";
            this.Pcs.ReadOnly = true;
            // 
            // ClaimAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.ClaimAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ClaimAmount.HeaderText = "索赔金额";
            this.ClaimAmount.Name = "ClaimAmount";
            this.ClaimAmount.ReadOnly = true;
            // 
            // ClaimReason
            // 
            this.ClaimReason.HeaderText = "索赔原因";
            this.ClaimReason.Name = "ClaimReason";
            this.ClaimReason.ReadOnly = true;
            // 
            // DecidedDate
            // 
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.DecidedDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.DecidedDate.HeaderText = "定案日期";
            this.DecidedDate.Name = "DecidedDate";
            this.DecidedDate.ReadOnly = true;
            // 
            // ArriveRTVDate
            // 
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.ArriveRTVDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.ArriveRTVDate.HeaderText = "到RTV日期";
            this.ArriveRTVDate.Name = "ArriveRTVDate";
            this.ArriveRTVDate.ReadOnly = true;
            // 
            // InformDate
            // 
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.InformDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.InformDate.HeaderText = "通知日期";
            this.InformDate.Name = "InformDate";
            this.InformDate.ReadOnly = true;
            // 
            // InformDays
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.InformDays.DefaultCellStyle = dataGridViewCellStyle8;
            this.InformDays.HeaderText = "通知天数";
            this.InformDays.Name = "InformDays";
            this.InformDays.ReadOnly = true;
            // 
            // WithdrawDate
            // 
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.WithdrawDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.WithdrawDate.HeaderText = "到期提取日";
            this.WithdrawDate.Name = "WithdrawDate";
            this.WithdrawDate.ReadOnly = true;
            // 
            // GateOutDate
            // 
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.GateOutDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.GateOutDate.HeaderText = "出仓日期";
            this.GateOutDate.Name = "GateOutDate";
            this.GateOutDate.ReadOnly = true;
            // 
            // GateOutType
            // 
            this.GateOutType.HeaderText = "出仓类别";
            this.GateOutType.Name = "GateOutType";
            this.GateOutType.ReadOnly = true;
            // 
            // DestoryInformDate
            // 
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.DestoryInformDate.DefaultCellStyle = dataGridViewCellStyle11;
            this.DestoryInformDate.HeaderText = "销毁通知日期";
            this.DestoryInformDate.Name = "DestoryInformDate";
            this.DestoryInformDate.ReadOnly = true;
            // 
            // DestoryType
            // 
            this.DestoryType.HeaderText = "销毁类别";
            this.DestoryType.Name = "DestoryType";
            this.DestoryType.ReadOnly = true;
            // 
            // InformDateIfOver50Days
            // 
            dataGridViewCellStyle12.Format = "d";
            dataGridViewCellStyle12.NullValue = null;
            this.InformDateIfOver50Days.DefaultCellStyle = dataGridViewCellStyle12;
            this.InformDateIfOver50Days.HeaderText = "超50天通知日期";
            this.InformDateIfOver50Days.Name = "InformDateIfOver50Days";
            this.InformDateIfOver50Days.ReadOnly = true;
            // 
            // CreationDate
            // 
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.CreationDate.DefaultCellStyle = dataGridViewCellStyle13;
            this.CreationDate.HeaderText = "导入日期";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusProcessBar});
            this.statusStrip.Location = new System.Drawing.Point(3, 443);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(850, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(835, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "就绪";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusProcessBar
            // 
            this.statusProcessBar.Name = "statusProcessBar";
            this.statusProcessBar.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.statusProcessBar.Size = new System.Drawing.Size(80, 16);
            this.statusProcessBar.Step = 5;
            this.statusProcessBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.statusProcessBar.Visible = false;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtClaimNo);
            this.gbSearch.Controls.Add(this.txtSuppilerNo);
            this.gbSearch.Controls.Add(this.lblClaimNo);
            this.gbSearch.Controls.Add(this.lblSupplierNo);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(5, 5);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(856, 60);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "查询";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(444, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.Location = new System.Drawing.Point(276, 19);
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(100, 20);
            this.txtClaimNo.TabIndex = 9;
            // 
            // txtSuppilerNo
            // 
            this.txtSuppilerNo.Location = new System.Drawing.Point(82, 19);
            this.txtSuppilerNo.Name = "txtSuppilerNo";
            this.txtSuppilerNo.Size = new System.Drawing.Size(100, 20);
            this.txtSuppilerNo.TabIndex = 8;
            // 
            // lblClaimNo
            // 
            this.lblClaimNo.AutoSize = true;
            this.lblClaimNo.Location = new System.Drawing.Point(215, 22);
            this.lblClaimNo.Name = "lblClaimNo";
            this.lblClaimNo.Size = new System.Drawing.Size(55, 13);
            this.lblClaimNo.TabIndex = 7;
            this.lblClaimNo.Text = "索赔号：";
            // 
            // lblSupplierNo
            // 
            this.lblSupplierNo.AutoSize = true;
            this.lblSupplierNo.Location = new System.Drawing.Point(9, 22);
            this.lblSupplierNo.Name = "lblSupplierNo";
            this.lblSupplierNo.Size = new System.Drawing.Size(67, 13);
            this.lblSupplierNo.TabIndex = 6;
            this.lblSupplierNo.Text = "供应商号：";
            // 
            // bgwImporter
            // 
            this.bgwImporter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwImporter_DoWork);
            this.bgwImporter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwImporter_RunWorkerCompleted);
            // 
            // bgwFileParser
            // 
            this.bgwFileParser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFileParser_DoWork);
            this.bgwFileParser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwFileParser_RunWorkerCompleted);
            // 
            // bgwValidator
            // 
            this.bgwValidator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwValidator_DoWork);
            this.bgwValidator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwValidator_RunWorkerCompleted);
            // 
            // timerActivation
            // 
            this.timerActivation.Enabled = true;
            this.timerActivation.Interval = 10000;
            this.timerActivation.Tick += new System.EventHandler(this.timerActivation_Tick);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(866, 562);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RTV Report";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.TextBox txtSuppilerNo;
        private System.Windows.Forms.Label lblClaimNo;
        private System.Windows.Forms.Label lblSupplierNo;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.DataGridView gridResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn RTV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn DecidedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArriveRTVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InformDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InformDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithdrawDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn GateOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn GateOutType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestoryInformDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestoryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn InformDateIfOver50Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.ToolStripMenuItem menuItemSameSuppOver14Days;
        private System.Windows.Forms.ToolStripMenuItem menuItemInformDaysOver50;
        private System.Windows.Forms.ToolStripMenuItem menuItemDestoryOver64Days;
        private System.Windows.Forms.ToolStripMenuItem menuItemInformDaysOver14;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearOutOfDateData;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar statusProcessBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.ComponentModel.BackgroundWorker bgwImporter;
        private System.ComponentModel.BackgroundWorker bgwFileParser;
        private System.ComponentModel.BackgroundWorker bgwValidator;
        private System.Windows.Forms.ToolStripMenuItem menuItemClaimOrderReport;
        private System.Windows.Forms.ToolStripMenuItem supplierAuthorizationDestoryReport;
        private System.Windows.Forms.Timer timerActivation;
    }
}