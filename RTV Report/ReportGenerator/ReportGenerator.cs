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
            Worksheet worksheet = workbook.Worksheets.Add("����");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;
            titleRow.Cells[titleCellidx++].Value = "��������";
            titleRow.Cells[titleCellidx++].Value = "���";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "�����";
            titleRow.Cells[titleCellidx++].Value = "��Ӧ�̺�";
            titleRow.Cells[titleCellidx++].Value = "��Ӧ������";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "��������";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "���";
            titleRow.Cells[titleCellidx++].Value = "����ԭ��";
            titleRow.Cells[titleCellidx].Value = "֪ͨ����";

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
            Worksheet worksheet = workbook.Worksheets.Add("����");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;
            titleRow.Cells[titleCellidx++].Value = "RTV";
            titleRow.Cells[titleCellidx++].Value = "��Ӧ�̺�";
            titleRow.Cells[titleCellidx++].Value = "��Ӧ������";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "���";
            titleRow.Cells[titleCellidx++].Value = "�����";
            titleRow.Cells[titleCellidx].Value = "����";
            

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
            Worksheet worksheet = workbook.Worksheets.Add("����");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;
            titleRow.Cells[titleCellidx++].Value = "RTV";
            titleRow.Cells[titleCellidx++].Value = "��HRTV�ֿ�����";
            titleRow.Cells[titleCellidx++].Value = "���";
//            titleRow.Cells[titleCellidx++].Value = "����";
//            titleRow.Cells[titleCellidx++].Value = "���";
            titleRow.Cells[titleCellidx++].Value = "�����";
            titleRow.Cells[titleCellidx++].Value = "��Ӧ�̺�";
            titleRow.Cells[titleCellidx++].Value = "��Ӧ������";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "��������";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "����";
            titleRow.Cells[titleCellidx++].Value = "���";
            titleRow.Cells[titleCellidx++].Value = "����ԭ��";
            titleRow.Cells[titleCellidx].Value = "֪ͨ����";

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
            Worksheet worksheet = workbook.Worksheets.Add("����");

            WorksheetRow titleRow = worksheet.Rows[0];
            int titleCellidx = 0;

            titleRow.Cells[titleCellidx++].Value = "�����";
            titleRow.Cells[titleCellidx++].Value = "��Ӧ�̺�";
            titleRow.Cells[titleCellidx++].Value = "��������";
            titleRow.Cells[titleCellidx++].Value = "֪ͨ����";
            titleRow.Cells[titleCellidx++].Value = "������ȡ��";
            titleRow.Cells[titleCellidx++].Value = "֪ͨ����";
            titleRow.Cells[titleCellidx].Value = "�������õ�����";            

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
