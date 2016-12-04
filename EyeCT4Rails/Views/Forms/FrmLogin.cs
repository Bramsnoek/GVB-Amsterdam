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
	public partial class FrmLogin : Form	
	{
		public User CurrentUser { get; set; }

		private ValidateUser validateuser;
		
		public FrmLogin()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
            try
            {
                OracleDatabase.IpAdress = txtIPAdres.Text;
                validateuser = new ValidateUser();
                CurrentUser = validateuser.Login(txtUsername.Text, txtPassword.Text);
                if (CurrentUser != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Het wachtwoord of gebruikersnaam is niet correct", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Drie pogingen zijn overschreven, probeer het over een half uur opnieuw!", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Het wachtwoord of gebruikersnaam is niet correct", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Het wachtwoord of gebruikersnaam is niet correct", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FrmLogin_Load(object sender, EventArgs e)
		{
#if (DEBUG)
			txtUsername.Text = "Bram";
			txtPassword.Text = "Bram123";
#endif
		}

    }
}
