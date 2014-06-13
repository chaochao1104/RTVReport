using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RTV_Report.Domain.DAO;
using RTV_Report.Model;
using RTV_Report.Utils;

namespace RTV_Report.Validator
{
    public class DestoryDateValidator : IValidator
    {
        private IList<ClaimOrder> _claimOrders;

        public DestoryDateValidator(IList<ClaimOrder> claimOrders)
        {
            _claimOrders = claimOrders;
        }

        public IList<string> Validate()
        {
            ClaimOrderDao claimOrderDao = new ClaimOrderDao();
            IList<ClaimOrder> yesterdayOver64DaysDestoryReport =
                claimOrderDao.Find64DaysDestory(ClaimOrderDao.Day.Yesterday);           

            IList<string> errorMsgs = new List<string>();
            foreach (ClaimOrder yesterdayOver64DaysClaimOrder in yesterdayOver64DaysDestoryReport)
            {
                for (int i = 0; i < _claimOrders.Count; i++)
                {
                    if (yesterdayOver64DaysClaimOrder.claimNo == _claimOrders[i].claimNo)
                    {
                        if (DateTimeUtils.IsEmpty(_claimOrders[i].destoryInformDate))
                        {
                            errorMsgs.Add(
                                String.Format("第{0}行销毁通知日期不能为空。索赔号：{1}",
                                              (i + 1 /*excel header*/+ 1 /*zero-based*/), _claimOrders[i].claimNo));
                        }
                    }
                }
            }

            return errorMsgs;
        }

        public string ErrorName
        {
            get { return "Error-003: 销毁日期为空。"; }
        }
    }
}
