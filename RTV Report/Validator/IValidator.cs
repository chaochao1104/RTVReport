using System;
using System.Collections.Generic;
using System.Text;
using RTV_Report.Model;

namespace RTV_Report.Validator
{
    public interface IValidator
    {
        IList<string> Validate();

        string ErrorName { get; }
    }
}
