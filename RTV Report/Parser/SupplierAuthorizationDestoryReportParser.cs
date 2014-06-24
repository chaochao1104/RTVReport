using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Infragistics.Documents.Excel;
using RTV_Report.Domain.Model;
using RTV_Report.Model;
using RTV_Report.Utils;

namespace RTV_Report.Parser
{
    class SupplierAuthorizationDestoryReportParser
    {
        public static List<SupplierAuthorizationDestory> ParseXLSX(string filePath)
        {
            List<SupplierAuthorizationDestory> supplierAuthorizationDestories = new List<SupplierAuthorizationDestory>();

            if (!PreCheck(filePath))
            {
                return supplierAuthorizationDestories;
            }

            Worksheet worksheet = Workbook.Load(filePath).Worksheets[0];
            WorkSheetReader reader = new WorkSheetReader(worksheet);

            string columnName = string.Empty;
            int rowNo = 2;
            foreach (IDictionary<string, object> aRow in reader)
            {
                SupplierAuthorizationDestory supplierAuthorizationDestory = new SupplierAuthorizationDestory();
                try
                {
                    object value;
                    columnName = "索赔号";
                    if (null != (value = aRow[columnName]))
                    {
                        supplierAuthorizationDestory.claimNo = value.ToString();
                    }

                    columnName = "供应商号";
                    if (null != (value = aRow[columnName]))
                    {
                        supplierAuthorizationDestory.supplierNo = value.ToString();
                    }

//                    if (null != (value = aRow["通知时间"]))
//                    {
//                        supplierAuthorizationDestory.destoryInformDate = DateTime.FromOADate((double)value);
//                    }

                    columnName = "定案日期";
                    if (null != (value = aRow[columnName]))
                    {
                        supplierAuthorizationDestory.decidedDate = DateTime.FromOADate((double)value);
                    }

                    columnName = "金额";
                    if (null != (value = aRow[columnName]))
                    {
                        Double.TryParse(value.ToString(), out supplierAuthorizationDestory.claimAmount);
                    }

                    rowNo++;
                    supplierAuthorizationDestories.Add(supplierAuthorizationDestory);
                }
                catch(InvalidCastException e)
                {
                    MessageBox.Show(String.Format("第{0}行，列[{1}]的格式错误！", rowNo, columnName));
                    return new List<SupplierAuthorizationDestory>();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "\n需要：\n'索赔号', '供应商号', '通知时间', '定案日期', '金额'。 " + "\n\n\n实际为：\n" + StringUtils.Join(", ", aRow.Keys), "文件格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<SupplierAuthorizationDestory>();
                }
                
            }

            return supplierAuthorizationDestories;
        }

        private static bool PreCheck(string filePath)
        {
            return StringUtils.NotEmpty(filePath) &&
                StringUtils.EndsWithIgnoreCase(filePath, ".xlsx");
        }
    }
}
