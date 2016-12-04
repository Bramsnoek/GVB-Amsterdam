using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4Rails
{
    public partial class UCRepairOverview : UserControl
    {
        public TramHandler TramHandler { get; set; }

        private List<NotPeriodicActivity> activities;
        public UCRepairOverview(List<NotPeriodicActivity> activities)
        {
            InitializeComponent();
            this.activities = activities;

            UpdateTable(activities);
        }

        public void UpdateTable(List<NotPeriodicActivity> activities)
        {
            livReparatie.Items.Clear();
            foreach (NotPeriodicActivity repairing in activities)
            {
                if (repairing.ActivityType == Activity.Type.Reparation && dtpvoor.Value > repairing.Date && dtpna.Value < repairing.Date)
                {
                    ListViewItem lvi = new ListViewItem(Convert.ToString(repairing.Tram.Number));
                    lvi.SubItems.Add(Convert.ToString(repairing.Date));
                    lvi.SubItems.Add(repairing.WorkNote);
                    lvi.SubItems.Add(repairing.PerformedBy.Username);
                    livReparatie.Items.Add(lvi);
                }
            }
        }

        private void dtpvoor_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable(activities);
        }

        private void dtpna_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable(activities);
        }

        private void livReparatie_DoubleClick(object sender, EventArgs e)
        {
            foreach (NotPeriodicActivity act in activities)
            {
                if (act.Tram.Number == Convert.ToInt32(livReparatie.SelectedItems[0].SubItems[0].Text))
                {
                    TramHandler(this, act.Tram, HandlerStatus.Show, 2);
                    break;
                }
            }
        }
    }
}
