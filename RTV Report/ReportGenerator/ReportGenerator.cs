using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Infragistics.Documents.Excel;
using RTV_Report.Model;

namespace RTV_Report.Exporter
{
    static class ReportGenerator
    {
        public static Workbook GenerateOver10000YuanOver14DaysReport(IList<ClaimOrder> claimOrders)
        {
            Workbook workbook = new Workbook(WorkbookFormat.Excel2007);
            Worksheet worksheet = workbook.Worksheets.Add("报表");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;
            titleRow.Cells[titleCellidx++].Value = "传真日期";
            titleRow.Cells[titleCellidx++].Value = "店号";
            titleRow.Cells[titleCellidx++].Value = "批次";
            titleRow.Cells[titleCellidx++].Value = "索赔号";
            titleRow.Cells[titleCellidx++].Value = "供应商号";
            titleRow.Cells[titleCellidx++].Value = "供应商名称";
            titleRow.Cells[titleCellidx++].Value = "部门";
            titleRow.Cells[titleCellidx++].Value = "定案日期";
            titleRow.Cells[titleCellidx++].Value = "箱数";
            titleRow.Cells[titleCellidx++].Value = "件数";
            titleRow.Cells[titleCellidx++].Value = "金额";
            titleRow.Cells[titleCellidx++].Value = "索赔原因";
            titleRow.Cells[titleCellidx].Value = "通知日期";

            titleRow.CellFormat.FillPattern = FillPatternStyle.Solid;
            titleRow.CellFormat.FillPatternForegroundColor = Color.AntiqueWhite;
                       
            int contentRowIdx = 1;
            foreach (ClaimOrder claimOrder in claimOrders)
            {
                WorksheetRow contentRow = worksheet.Rows[contentRowIdx++];
                int contentCellIdx = 0;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.informDate;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.storeNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.lotNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.supplierNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.supplierName;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.dept;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.decidedDate;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.qty;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.pcs;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimAmount;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimReason;
                contentRow.Cells[contentCellIdx].Value = claimOrder.informDays;
            }
                       
            
            return workbook;
        }

        public static Workbook GenerateInformDaysBetweenReport(IList<ClaimOrder> claimOrders)
        {
            Workbook workbook = new Workbook(WorkbookFormat.Excel2007);
            Worksheet worksheet = workbook.Worksheets.Add("报表");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;
            titleRow.Cells[titleCellidx++].Value = "RTV";
            titleRow.Cells[titleCellidx++].Value = "供应商号";
            titleRow.Cells[titleCellidx++].Value = "供应商名称";
            titleRow.Cells[titleCellidx++].Value = "部门";
            titleRow.Cells[titleCellidx++].Value = "金额";
            titleRow.Cells[titleCellidx++].Value = "索赔号";
            titleRow.Cells[titleCellidx].Value = "天数";
            

            titleRow.CellFormat.FillPattern = FillPatternStyle.Solid;
            titleRow.CellFormat.FillPatternForegroundColor = Color.AntiqueWhite;
                       
            int contentRowIdx = 1;
            foreach (ClaimOrder claimOrder in claimOrders)
            {
                WorksheetRow contentRow = worksheet.Rows[contentRowIdx++];
                int contentCellIdx = 0;

                contentRow.Cells[contentCellIdx++].Value = claimOrder.rtv;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.supplierNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.supplierName;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.dept;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimAmount;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimNo;
                contentRow.Cells[contentCellIdx].Value = claimOrder.informDays;
            }
            
            return workbook;
        }

        public static Workbook Generate64DaysDestoryReport(IList<ClaimOrder> claimOrders)
        {
            Workbook workbook = new Workbook(WorkbookFormat.Excel2007);
            Worksheet worksheet = workbook.Worksheets.Add("报表");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;
            titleRow.Cells[titleCellidx++].Value = "RTV";
            titleRow.Cells[titleCellidx++].Value = "到HRTV仓库日期";
            titleRow.Cells[titleCellidx++].Value = "店号";
//            titleRow.Cells[titleCellidx++].Value = "批次";
//            titleRow.Cells[titleCellidx++].Value = "序号";
            titleRow.Cells[titleCellidx++].Value = "索赔号";
            titleRow.Cells[titleCellidx++].Value = "供应商号";
            titleRow.Cells[titleCellidx++].Value = "供应商名称";
            titleRow.Cells[titleCellidx++].Value = "部门";
            titleRow.Cells[titleCellidx++].Value = "定案日期";
            titleRow.Cells[titleCellidx++].Value = "箱数";
            titleRow.Cells[titleCellidx++].Value = "件数";
            titleRow.Cells[titleCellidx++].Value = "金额";
            titleRow.Cells[titleCellidx++].Value = "索赔原因";
            titleRow.Cells[titleCellidx].Value = "通知天数";

            titleRow.CellFormat.FillPattern = FillPatternStyle.Solid;
            titleRow.CellFormat.FillPatternForegroundColor = Color.AntiqueWhite;

            int contentRowIdx = 1;
            foreach (ClaimOrder claimOrder in claimOrders)
            {
                WorksheetRow contentRow = worksheet.Rows[contentRowIdx++];
                int contentCellIdx = 0;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.rtv;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.arriveRTVDate;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.storeNo;
//                contentRow.Cells[contentCellIdx++].Value = claimOrder.lotNo;
//                contentRow.Cells[contentCellIdx++].Value = 0;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.supplierNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.supplierName;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.dept;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.decidedDate;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.qty;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.pcs;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimAmount;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimReason;
                contentRow.Cells[contentCellIdx].Value = claimOrder.informDays;
            }

            return workbook;
        }

        public static Workbook GenerateOver14DaysReport(IDictionary<ClaimOrder, double> claimOrders)
        {
            Workbook workbook = new Workbook(WorkbookFormat.Excel2007);
            Worksheet worksheet = workbook.Worksheets.Add("报表");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;

            titleRow.Cells[titleCellidx++].Value = "索赔号";
            titleRow.Cells[titleCellidx++].Value = "供应商号";
            titleRow.Cells[titleCellidx++].Value = "定案日期";
            titleRow.Cells[titleCellidx++].Value = "通知日期";
            titleRow.Cells[titleCellidx++].Value = "到期提取日";
            titleRow.Cells[titleCellidx++].Value = "通知天数";
            titleRow.Cells[titleCellidx].Value = "需核算费用的天数";            

            titleRow.CellFormat.FillPattern = FillPatternStyle.Solid;
            titleRow.CellFormat.FillPatternForegroundColor = Color.AntiqueWhite;

            int contentRowIdx = 1;
            foreach (ClaimOrder claimOrder in claimOrders.Keys)
            {
                WorksheetRow contentRow = worksheet.Rows[contentRowIdx++];
                int contentCellIdx = 0;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.claimNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.supplierNo;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.decidedDate;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.informDate;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.withdrawDate;
                contentRow.Cells[contentCellIdx++].Value = claimOrder.informDays;
                contentRow.Cells[contentCellIdx].Value = claimOrders[claimOrder];
            }

            return workbook;
        }



    }
}
