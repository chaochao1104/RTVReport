using System;

namespace RTV_Report.Model
{
    public class ClaimOrder
    {
        public int oid;

        public string rtv;

        public string claimNo;

        public string storeNo;

        public string lotNo;

        public string supplierNo;

        public string supplierName;

        public string dept;

        public double qty;

        public double pcs;

        public double claimAmount;

        public string claimReason;

        public DateTime decidedDate;

        public DateTime arriveRTVDate;

        public DateTime informDate;

        public double informDays;

        public DateTime withdrawDate;

        public DateTime gateOutDate;

        public string gateOutType;

        public DateTime destoryInformDate;

        public string destoryType;

        public DateTime informDateIfOver50Days;

        public DateTime creationDate;
    }
}
