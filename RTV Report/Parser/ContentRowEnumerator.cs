using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Infragistics.Documents.Excel;
using RTV_Report.Utils;

namespace RTV_Report.Parser
{
    class ContentRowEnumerator : IEnumerator<IDictionary<string, object>>
    {
        private WorksheetRowCollection rows;

        private string[] cellIndexTitleDict; 

        private int index = 0;

        private WorksheetRow currentWorksheetRow;

        public ContentRowEnumerator(WorksheetRowCollection rows)
        {
            this.rows = rows;
            InitDictionary();
        }

        private void InitDictionary()
        {
            WorksheetRow titleRow = rows[0];
            IList<string> cellIndexTitleDictTemp = new List<string>(); 

            int idx = 0;
            while (true)
            {
                object value = titleRow.Cells[idx++].Value;
                if (value == null || StringUtils.IsEmpty(value.ToString()))
                {
                    break;
                }

                cellIndexTitleDictTemp.Add(value.ToString().Trim());
            }

            cellIndexTitleDict = new string[cellIndexTitleDictTemp.Count];
            cellIndexTitleDictTemp.CopyTo(cellIndexTitleDict, 0);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            currentWorksheetRow = rows[++index];
            for (int i = 0; i < cellIndexTitleDict.Length; i++)
            {
                if (currentWorksheetRow.Cells[i].Value != null)
                {
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            //not -1 because the first content row's index is 1
            index = 0;
        }

        public IDictionary<string, object> Current
        {
            get 
            {
                IDictionary<string, object> currentRow = new Dictionary<string, object>();
          
                for (int cellIdx = 0; cellIdx < cellIndexTitleDict.Length; cellIdx++)
                {
                    object value = currentWorksheetRow.Cells[cellIdx].Value;
                    currentRow[cellIndexTitleDict[cellIdx]] = value;
                }

                return currentRow;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
