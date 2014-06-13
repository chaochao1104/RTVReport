using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Infragistics.Documents.Excel;
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

            foreach (IDictionary<string, object> aRow in reader)
            {
                try
                {

                    ClaimOrder claimOrder = new ClaimOrder();

                    object value;
                    if (null != (value = aRow[ClaimOrderTitleConstants.RTV]))
                    {
                        claimOrder.rtv = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.WMT_CLAIM_NO]))
                    {
                        claimOrder.claimNo = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.STORE_NO]))
                    {
                        claimOrder.storeNo = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.LOT_NO]))
                    {
                        claimOrder.lotNo = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.SUPPLIER_NO]))
                    {
                        claimOrder.supplierNo = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.SUPPLIER_NAME]))
                    {
                        claimOrder.supplierName = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.DEPT]))
                    {
                        claimOrder.dept = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.QTY]))
                    {
                        Double.TryParse(value.ToString(), out claimOrder.qty);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.PCS]))
                    {
                        Double.TryParse(value.ToString(), out claimOrder.pcs);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.CLAIM_AMOUNT]))
                    {
                        Double.TryParse(value.ToString(), out claimOrder.claimAmount);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.CLAIM_REASON]))
                    {
                        claimOrder.claimReason = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.DECIDED_DATE]))
                    {
                        claimOrder.decidedDate = DateTime.FromOADate((double) value);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.ARRIVE_RTV_DATE]))
                    {
                        claimOrder.arriveRTVDate = DateTime.FromOADate((double) value);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.INFORM_DATE]))
                    {
                        claimOrder.informDate = DateTime.FromOADate((double) value);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.WITHDRAW_DATE]))
                    {
                        claimOrder.withdrawDate = DateTime.FromOADate((double) value);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.GATEOUT_DATE]))
                    {
                        claimOrder.gateOutDate = DateTime.FromOADate((double) value);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.GATEOUT_TYPE]))
                    {
                        claimOrder.gateOutType = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.DESTORY_INFORM_DATE]))
                    {
                        claimOrder.destoryInformDate = DateTime.FromOADate((double) value);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.DESTORY_TYPE]))
                    {
                        claimOrder.destoryType = value.ToString();
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.INFORM_DATE_IF_OVER_50_DAYS]))
                    {
                        claimOrder.informDateIfOver50Days = DateTime.FromOADate((double) value);
                    }

                    if (null != (value = aRow[ClaimOrderTitleConstants.INFORM_DAYS]))
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
                    claimOrders.Add(claimOrder);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message + "\n" + StringUtils.Join(",", aRow.Keys), "文件格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
