using System;
using System.Collections.Generic;
using System.Text;
using RTV_Report.Domain.DAO;
using RTV_Report.Model;
using RTV_Report.Utils;

namespace RTV_Report.Validator
{
    class ClaimOrderUK
    {
        public string claimNo;

        public DateTime decidedDate;

        public double claimAmount;
    }

    internal class ClaimOrderUKEqualityComparer : IEqualityComparer<ClaimOrderUK>
    {
        public bool Equals(ClaimOrderUK x, ClaimOrderUK y)
        {
            if (x == y) return true;

            if (x == null) return false;

            return x.claimNo.Equals(y.claimNo) &&
                   x.decidedDate.Equals(y.decidedDate) &&
                   x.claimAmount.Equals(y.claimAmount);
        }

        public int GetHashCode(ClaimOrderUK obj)
        {
            return obj.claimNo.GetHashCode();
        }
    }

    public class SameClaimNoHasSameDateValidator : IValidator
    {
        private IList<ClaimOrder> _claimOrders;

        public SameClaimNoHasSameDateValidator(IList<ClaimOrder> claimOrders)
        {
            _claimOrders = claimOrders;
        }

        public IList<string> Validate()
        {
            ClaimOrderDao claimOrderDao = new ClaimOrderDao();

            Dictionary<ClaimOrderUK, ClaimOrder> yesterdayClaimOrders = 
                new Dictionary<ClaimOrderUK, ClaimOrder>(new ClaimOrderUKEqualityComparer());
            foreach (ClaimOrder yesterdayClaimOrder in claimOrderDao.FindYesterdaysClaimOrders())
            {
                ClaimOrderUK uk = new ClaimOrderUK();
                uk.claimNo = yesterdayClaimOrder.claimNo;
                uk.decidedDate = yesterdayClaimOrder.decidedDate;
                uk.claimAmount = yesterdayClaimOrder.claimAmount;

                yesterdayClaimOrders[uk] = yesterdayClaimOrder;
            }

            IList<string> errorStrs = new List<string>();
            for (int i = 0; i < _claimOrders.Count; i++)
            {
                ClaimOrder todayClaimOrder =_claimOrders[i];
                ClaimOrderUK uk = new ClaimOrderUK();
                uk.claimNo = todayClaimOrder.claimNo;
                uk.decidedDate = todayClaimOrder.decidedDate;
                uk.claimAmount = todayClaimOrder.claimAmount;

                if (yesterdayClaimOrders.ContainsKey(uk))
                {
                    ClaimOrder yesterdayClaimOrder = yesterdayClaimOrders[uk];

                    string errorStr = string.Empty;
                    if (yesterdayClaimOrder.gateOutDate.Equals(todayClaimOrder.gateOutDate) == false)
                    {
                        if (!DateTimeUtils.IsEmpty(yesterdayClaimOrder.gateOutDate))
                        {
                            errorStr = String.Format("��{0}��������ǰһ��ĳ������ڲ���������ţ�{1}��", (i + 1/*zero base*/ + 1/*excel header*/), yesterdayClaimOrder.claimNo);
                        }
                    }

                    if (yesterdayClaimOrder.informDate.Equals(todayClaimOrder.informDate) == false)
                    {
                        if (!DateTimeUtils.IsEmpty(yesterdayClaimOrder.informDate))
                        {
                            errorStr = String.Format("��{0}��������ǰһ���֪ͨ���ڲ���������ţ�{1}��", (i + 1/*zero base*/ + 1/*excel header*/), yesterdayClaimOrder.claimNo);
                        }
                    }

                    if (!string.IsNullOrEmpty(errorStr))
                    {
                        errorStrs.Add(errorStr);
                    }
                    
                }
            }

            return errorStrs;
        }

        public string ErrorName
        {
            get { return "Err-002: ͬһ�����ͬһ��������ͬһ�������в�ͬ��֪ͨ����/�������ڡ�"; }
        }
    }
}
