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
    public partial class FrmAddTrack : Form
    {
        //the track that will be returned with the dialog
        //null by default.
        public Track Track { get; set; }

        private List<Track> tracks;
        private User userLoggedIn;
        private ErrorProvider error = new ErrorProvider();

        public FrmAddTrack(User userLoggedIn, List<Track> tracks)
        {
            this.tracks = tracks;
			if(!Permission.Check(userLoggedIn, Permission.Permissions.CanAddTracks))
            {
                this.DialogResult = DialogResult.Cancel;
            }
            InitializeComponent();
            this.userLoggedIn = userLoggedIn;
        }

		/// <summary>
		///     Check if all fields are filled in.
		/// </summary>
		/// <returns>
		///     Bool : true if passed
		/// </returns>
		private bool checkFields()
        {
            error.Clear();
			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanAddTracks))
            {
                error.SetError(txtSpoorNummer, "U bent niet bevoegd om een nieuwe track toe te voegen.");
                return false;
            }

            if (txtSpoorNummer.Text.Length < 1)
            {
                error.SetError(txtSpoorNummer, "Gelieve een spoor nummer in te voeren.");
                return false;
            }

            int spoorNummer;
            if(!int.TryParse(txtSpoorNummer.Text, out spoorNummer))
            {
                error.SetError(txtSpoorNummer, "Een spoor nummer kan alleen een getal zijn.");
                return false;
            }

            if(checkExistingTrackNumber(spoorNummer))
            {
                error.SetError(txtSpoorNummer, "Een spoor nummer mag nog niet bestaan.");
                return false;
            }

            List<Sector> sectors = new List<Sector>();
            Track = new Track(
                0,
                spoorNummer,
                txtNotitie.Text,
                radActive.Checked
            );
            for(int i = 0; i < nudSectoren.Value; i++)
            {
                sectors.Add(new Sector(0, Track));
            }
            Track.Sectors = sectors;
            return true;
        }

        private bool checkExistingTrackNumber(int number)
        {
            foreach(Track track in tracks)
            {
                if(track.TrackNumber == number)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Save the new track.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
