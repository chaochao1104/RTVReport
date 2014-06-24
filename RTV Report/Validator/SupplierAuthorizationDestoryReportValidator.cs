using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RTV_Report.Domain.Model;
using RTV_Report.Model;
using RTV_Report.UI;
using RTV_Report.Utils;

namespace RTV_Report.Validator
{
    public class SupplierAuthorizationDestoryReportValidator : IValidator
    {
        private IList<ClaimOrder> _claimOrders;

        private IList<SupplierAuthorizationDestory> _supplierAuthorizationDestories; 

        public SupplierAuthorizationDestoryReportValidator(IList<ClaimOrder> claimOrder, IList<SupplierAuthorizationDestory> supplierAuthorizationDestories)
        {
            _claimOrders = claimOrder;
            _supplierAuthorizationDestories = supplierAuthorizationDestories;
        }

        public IList<string> Validate()
        {
            IList<string> errorMsgs = new List<string>();
            foreach (SupplierAuthorizationDestory supplierAuthorizationDestory in _supplierAuthorizationDestories)
            {
                for (int i = 0; i < _claimOrders.Count; i++)
                {
                    if (supplierAuthorizationDestory.claimNo == _claimOrders[i].claimNo && 
                        supplierAuthorizationDestory.supplierNo == _claimOrders[i].supplierNo && 
                        supplierAuthorizationDestory.decidedDate.Equals(_claimOrders[i].decidedDate) && 
                        supplierAuthorizationDestory.claimAmount.Equals(_claimOrders[i].claimAmount))
                    {
                        if (DateTimeUtils.IsEmpty(_claimOrders[i].destoryInformDate))
                        {
                            errorMsgs.Add(String.Format("Error-004: ��{0}������֪ͨ���ڲ���Ϊ�ա�����ţ�{1}��", i + 1 + 1, _claimOrders[i].claimNo));
                        }
                    }
                }
            }
            
            return errorMsgs;
        }

        public string ErrorName
        {
            get { return "��Ӧ����Ȩ���ٱ�������֪ͨ����û�и���������֪ͨ�����С�"; }
        }
    }
}
