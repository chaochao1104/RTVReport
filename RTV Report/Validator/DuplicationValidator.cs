using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RTV_Report.Model;
using RTV_Report.Utils;

namespace RTV_Report.Validator
{
    class ClaimOrderComparer : IEqualityComparer<ClaimOrder>
    {

        public bool Equals(ClaimOrder x, ClaimOrder y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null && y == null)
            {
                return true;
            }

            if (x == null)
            {
                return false;
            }
        
            return x.claimNo.Equals(y.claimNo) 
                && x.decidedDate.Equals(y.decidedDate)
                && x.claimAmount.Equals(y.claimAmount);

            
        }

        public int GetHashCode(ClaimOrder obj)
        {
            return obj.claimNo.GetHashCode();
        }
    }

    public class DuplicationValidator : IValidator
    {
        private IList<ClaimOrder> _claimOrders;

        public DuplicationValidator(IList<ClaimOrder> claimOrders)
        {
            _claimOrders = claimOrders;
        }
    
        public IList<string> Validate()
        {
            Dictionary<ClaimOrder, IList<int>> groupBy3Keys = 
                new Dictionary<ClaimOrder, IList<int>>(new ClaimOrderComparer());

            for (int i = 0; i < _claimOrders.Count; i++)
            {
                if (!groupBy3Keys.ContainsKey(_claimOrders[i]))
                {
                    IList<int> indice = new List<int>();
                    indice.Add(i);
                    groupBy3Keys[_claimOrders[i]] = indice;
                }
                else
                {
                    groupBy3Keys[_claimOrders[i]].Add(i);
                }
            }

            IList<string> ret = new List<string>();
            foreach (KeyValuePair<ClaimOrder, IList<int>> duplicatedRowIndice in groupBy3Keys)
            {
                if (duplicatedRowIndice.Value.Count > 1)
                {
                    string errorMsg = "第{0}行不符合唯一性约束。索赔号：{1}。";
                    string[] indiceStr = new string[duplicatedRowIndice.Value.Count];
                    for (int i = 0; i < indiceStr.Length; i++)
                    {
                        indiceStr[i] = (duplicatedRowIndice.Value[i] + 1 + 1).ToString();
                    }

                    ret.Add(String.Format(errorMsg, StringUtils.Join(", ", indiceStr), duplicatedRowIndice.Key));
                }
            }

            return ret;
        }

        public string ErrorName
        {
            get { return "Err-001: 重复条目。"; }
        }
    }
}
