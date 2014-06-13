using System.Windows.Forms;

namespace RTV_Report.UI
{
    public partial class InformDateOver50DaysReportCriteriaDialog : Form
    {
        public InformDateOver50DaysReportCriteriaDialog()
        {
            InitializeComponent();
        }

        public int InformDaysUpperLimit
        {
            get { return (int) numInformDaysUpperLimit.Value; }
        }
    }
}