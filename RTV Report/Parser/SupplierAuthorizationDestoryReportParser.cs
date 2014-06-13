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

            foreach (IDictionary<string, object> aRow in reader)
            {
                SupplierAuthorizationDestory supplierAuthorizationDestory = new SupplierAuthorizationDestory();
                try
                {
                    object value;
                    if (null != (value = aRow["索赔号"]))
                    {
                        supplierAuthorizationDestory.claimNo = value.ToString();
                    }

                    if (null != (value = aRow["供应商号"]))
                    {
                        supplierAuthorizationDestory.supplierNo = value.ToString();
                    }

                    if (null != (value = aRow["通知时间"]))
                    {
                        supplierAuthorizationDestory.destoryInformDate = DateTime.FromOADate((double)value);
                    }

                    supplierAuthorizationDestories.Add(supplierAuthorizationDestory);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "\n" + StringUtils.Join(",", aRow.Keys), "文件格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
