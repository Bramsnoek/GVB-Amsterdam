using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeCT4RailsBackend;

namespace EyeCT4RailsPasswordGenerator
{
	public partial class FrmMain : Form
	{
		private Encryption encryption = new Encryption();
		private string passPhrase = "EyeCT4Railssbfrms";

		public FrmMain()
		{
			InitializeComponent();
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{

		}

		private void btnConvertToPlain_Click(object sender, EventArgs e)
		{
			txtPlainText.Text = encryption.Decrypt(txtPassword.Text, passPhrase + txtUserName.Text);
		}

		private void btnConvertToPassword_Click(object sender, EventArgs e)
		{
			txtPassword.Text = encryption.Encrypt(txtPlainText.Text, passPhrase + txtUserName.Text);
		}
	}
}
