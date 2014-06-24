using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Infragistics.Documents.Excel;
using RTV_Report.Domain.Model;
using RTV_Report.Model;
using RTV_Report.Utils;

namespace RTV_Report.Parser
{
    class ClaimOrderParser
    {
        public static List<ClaimOrder> ParseXLSX(string filePath)
        {
            List<ClaimOrder> claimOrders = new List<ClaimOrder>();

            if (!PreCheck(filePath))
            {
                return claimOrders;
            }

            Worksheet worksheet = Workbook.Load(filePath).Worksheets[0];
            WorkSheetReader reader = new WorkSheetReader(worksheet);

            int rowNo = 2;
            string columnName = string.Empty;
            foreach (IDictionary<string, object> aRow in reader)
            {
                try
                {

                    ClaimOrder claimOrder = new ClaimOrder();

                    object value;
                    columnName = ClaimOrderTitleConstants.RTV;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.rtv = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.WMT_CLAIM_NO;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.claimNo = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.STORE_NO;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.storeNo = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.LOT_NO;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.lotNo = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.SUPPLIER_NO;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.supplierNo = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.SUPPLIER_NAME;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.supplierName = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.DEPT;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.dept = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.QTY;
                    if (null != (value = aRow[columnName]))
                    {
                        Double.TryParse(value.ToString(), out claimOrder.qty);
                    }

                    columnName = ClaimOrderTitleConstants.PCS;
                    if (null != (value = aRow[columnName]))
                    {
                        Double.TryParse(value.ToString(), out claimOrder.pcs);
                    }

                    columnName = ClaimOrderTitleConstants.CLAIM_AMOUNT;
                    if (null != (value = aRow[columnName]))
                    {
                        Double.TryParse(value.ToString(), out claimOrder.claimAmount);
                    }

                    columnName = ClaimOrderTitleConstants.CLAIM_REASON;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.claimReason = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.DECIDED_DATE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.decidedDate = DateTime.FromOADate((double) value);
                    }

                    columnName = ClaimOrderTitleConstants.ARRIVE_RTV_DATE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.arriveRTVDate = DateTime.FromOADate((double) value);
                    }

                    columnName = ClaimOrderTitleConstants.INFORM_DATE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.informDate = DateTime.FromOADate((double) value);
                    }

                    columnName = ClaimOrderTitleConstants.WITHDRAW_DATE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.withdrawDate = DateTime.FromOADate((double) value);
                    }

                    columnName = ClaimOrderTitleConstants.GATEOUT_DATE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.gateOutDate = DateTime.FromOADate((double) value);
                    }

                    columnName = ClaimOrderTitleConstants.GATEOUT_TYPE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.gateOutType = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.DESTORY_INFORM_DATE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.destoryInformDate = DateTime.FromOADate((double) value);
                    }

                    columnName = ClaimOrderTitleConstants.DESTORY_TYPE;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.destoryType = value.ToString();
                    }

                    columnName = ClaimOrderTitleConstants.INFORM_DATE_IF_OVER_50_DAYS;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.informDateIfOver50Days = DateTime.FromOADate((double) value);
                    }

                    columnName = ClaimOrderTitleConstants.INFORM_DAYS;
                    if (null != (value = aRow[columnName]))
                    {
                        claimOrder.informDays = (double)value;
                    }
//                    //cause there is bug of fragistics to calculate the value of this cell having a formula
//                    if (DateTimeUtils.IsEmpty(claimOrder.informDate))
//                    {
//                        claimOrder.informDays = 0;
//                    }
//                    else
//                    {
//                        if (DateTimeUtils.IsEmpty(claimOrder.gateOutDate) &&
//                            !DateTimeUtils.IsEmpty(claimOrder.destoryInformDate))
//                        {
//                            claimOrder.informDays = claimOrder.destoryInformDate.Subtract(claimOrder.informDate).Days;
//                        }
//                        else if (!DateTimeUtils.IsEmpty(claimOrder.gateOutDate) &&
//                                 DateTimeUtils.IsEmpty(claimOrder.destoryInformDate))
//                        {
//                            claimOrder.informDays = claimOrder.gateOutDate.Subtract(claimOrder.informDate).Days;
//                        }
//                        else if (!DateTimeUtils.IsEmpty(claimOrder.gateOutDate) &&
//                                 !DateTimeUtils.IsEmpty(claimOrder.destoryInformDate))
//                        {
//                            DateTime min = claimOrder.gateOutDate.CompareTo(claimOrder.destoryInformDate) < 0
//                                               ? claimOrder.gateOutDate
//                                               : claimOrder.destoryInformDate;
//                            claimOrder.informDays = min.Subtract(claimOrder.informDate).Days;
//                        }
//                        else
//                        {
//                            claimOrder.informDays = DateTime.Today.Subtract(claimOrder.informDate).Days;
//                        }
//                    }
                    rowNo++;
                    claimOrders.Add(claimOrder);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show(String.Format("第{0}行，列[{1}]的格式错误！", rowNo, columnName));
                    return new List<ClaimOrder>();          
                }
                catch(Exception e)
                {
                    string[] required = new string[] { 
                        ClaimOrderTitleConstants.RTV, 
                        ClaimOrderTitleConstants.WMT_CLAIM_NO,
                        ClaimOrderTitleConstants.STORE_NO,
                        ClaimOrderTitleConstants.LOT_NO,
                        ClaimOrderTitleConstants.SUPPLIER_NO,
                        ClaimOrderTitleConstants.SUPPLIER_NAME,
                        ClaimOrderTitleConstants.QTY,
                        ClaimOrderTitleConstants.PCS,
                        ClaimOrderTitleConstants.CLAIM_AMOUNT,
                        ClaimOrderTitleConstants.CLAIM_REASON,
                        ClaimOrderTitleConstants.DECIDED_DATE,
                        ClaimOrderTitleConstants.ARRIVE_RTV_DATE,
                        ClaimOrderTitleConstants.INFORM_DATE,
                        ClaimOrderTitleConstants.WITHDRAW_DATE,
                        ClaimOrderTitleConstants.GATEOUT_DATE,
                        ClaimOrderTitleConstants.GATEOUT_TYPE,
                        ClaimOrderTitleConstants.DESTORY_INFORM_DATE,
                        ClaimOrderTitleConstants.DESTORY_TYPE,
                        ClaimOrderTitleConstants.INFORM_DATE_IF_OVER_50_DAYS,
                        ClaimOrderTitleConstants.INFORM_DAYS
                    };
                    MessageBox.Show(e.Message + "\n需要：\n" + StringUtils.Join(", ", required) + "\n\n\n实际：\n" + StringUtils.Join(", ", aRow.Keys), "文件格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<ClaimOrder>();
                }
            }

            return claimOrders;
        }

        private static bool PreCheck(string filePath)
        {
            return StringUtils.NotEmpty(filePath) && 
                StringUtils.EndsWithIgnoreCase(filePath, ".xlsx");
        }

    }
}
