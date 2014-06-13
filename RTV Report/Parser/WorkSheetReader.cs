using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Infragistics.Documents.Excel;
using RTV_Report.Utils;

namespace RTV_Report.Parser
{
    class WorkSheetReader : IEnumerable
    {
//        private IDictionary<string, int> cellTitleIndexDict = new Dictionary<string, int>();
//
//        private IList<string> cellIndexTitleDict = new List<string>(); 
//
        private Worksheet worksheet;

        private ContentRowEnumerator contentRowEnumerator;

        public WorkSheetReader(Worksheet worksheet)
        {
            this.worksheet = worksheet;
            contentRowEnumerator = new ContentRowEnumerator(worksheet.Rows);
        }

        public IEnumerator GetEnumerator()
        {
            return contentRowEnumerator;
        }
    }
}
