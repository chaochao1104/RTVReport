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
                            errorMsgs.Add(String.Format("Error-004: 第{0}行销毁通知日期不能为空。索赔号：{1}。", i + 1 + 1, _claimOrders[i].claimNo));
                        }
                    }
                }
            }
            
            return errorMsgs;
        }

        public string ErrorName
        {
            get { return "供应商授权销毁报告销毁通知日期没有更新在销毁通知日期中。"; }
        }
    }
}
