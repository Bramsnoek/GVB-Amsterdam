using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCT4Rails
{
    public partial class FrmTrackData : Form
    {
        public Track Track { get; private set; }

        public FrmTrackData(Track track)
        {
            InitializeComponent();
            Track = track;
            lblTrack.Text = "Spoor " + Track.TrackNumber;
            txtNote.Text = Track.Note;
            if (Track.Enabled) { radClear.Checked = true; radBlocked.Checked = false; }
            else { radBlocked.Checked = true; radClear.Checked = false; }
            btnSave.Enabled = false;
            foreach(Sector sector in Track.Sectors)
            {
                if (sector.ListedTram != null && Track.Enabled)
                {
                    radBlocked.Enabled = false;
                    radClear.Enabled = false;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (radClear.Checked) { Track.Enabled = true; }
            else { Track.Enabled = false; }
            Track.Note = txtNote.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radClear_CheckedChanged(object sender, EventArgs e)
        {
            checkAndSave();
        }
        private void radBlocked_CheckedChanged(object sender, EventArgs e)
        {
            checkAndSave();
        }
        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            checkAndSave();
        }

        private void checkAndSave()
        {
            if ((radClear.Checked != Track.Enabled) || (txtNote.Text != Track.Note))
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
    }
}
