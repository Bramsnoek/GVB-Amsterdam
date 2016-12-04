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
    public partial class UCCleaningOverview : UserControl
    {
        public TramHandler TramHandler { get; set; }

        private List<NotPeriodicActivity> activities;
        public UCCleaningOverview(List<NotPeriodicActivity> activities)
        {
            InitializeComponent();
            this.activities = activities;

            UpdateTable(activities);
        }

        public void UpdateTable(List<NotPeriodicActivity> activities)
        {
            livSchoonmaak.Items.Clear();
            foreach (NotPeriodicActivity cleaning in activities)
            {

                if (cleaning.ActivityType == Activity.Type.Cleaning && dtpvoor.Value > cleaning.Date && dtpna.Value < cleaning.Date)
                {
                    ListViewItem lvi = new ListViewItem(Convert.ToString(cleaning.Tram.Number));
                    lvi.SubItems.Add(Convert.ToString(cleaning.Date));
                    lvi.SubItems.Add(cleaning.WorkNote);
                    lvi.SubItems.Add(cleaning.PerformedBy.Username);
                    livSchoonmaak.Items.Add(lvi);
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

        private void livSchoonmaak_DoubleClick(object sender, EventArgs e)
        {
            foreach (NotPeriodicActivity act in activities)
            {
                if (act.Tram.Number == Convert.ToInt32(livSchoonmaak.SelectedItems[0].SubItems[0].Text))
                {
                    TramHandler(this, act.Tram, HandlerStatus.Show, 1);
                    break;
                }
            }
        }
    }
}
