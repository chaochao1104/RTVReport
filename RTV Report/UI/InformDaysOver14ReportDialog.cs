using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RTV_Report.UI
{
    public partial class InformDaysOver14ReportDialog : Form
    {
        public InformDaysOver14ReportDialog()
        {
            InitializeComponent();
        }

        public DateTime LastAccountDate
        {
            get { return this.dpAccountDate.SelectionStart; }
        }

    }
}