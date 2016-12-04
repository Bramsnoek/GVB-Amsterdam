using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EyeCT4Rails
{
    public partial class FrmCreateUser : Form
    {
		public User User { get; set; }

		private List<Group> groups;
		private List<User> users;
        private User userLoggedIn;

        public FrmCreateUser(User userLoggedIn, List<User> users, List<Group> groups = null)
        {
			this.users = users;
			this.userLoggedIn = userLoggedIn;
			this.groups = groups;

			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanCreateUsers))
            {
                this.DialogResult = DialogResult.Cancel;
            }
			InitializeComponent();

            foreach(Group g in this.groups)
            {
                if (this.groups.IndexOf(g) == 0)
                {
                    comGroup.Text = g.ToString();
                }
                comGroup.Items.Add(g.ToString());
            }
        }

        private bool checkFields()
		{
			comGroup.SelectedIndex = comGroup.SelectedIndex == -1 ? 0 : comGroup.SelectedIndex;

			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanEditUser) || !Permission.Check(userLoggedIn, Permission.Permissions.CanEditGroups))
			{
				MessageBox.Show("U bent niet bevoegd om een gebruiker aan te passen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (txtFirstName.Text.Length < 7)
			{
				MessageBox.Show("De naam moet ten minste 7 tekens lang zijn!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (txtFirstName.Text.IndexOf(" ") == txtFirstName.Text.Length - 1 || txtFirstName.Text.IndexOf(" ") == -1)
			{
				MessageBox.Show("Gelieve een voor en achternaam in te vullen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (txtUsername.Text.Length < 3)
			{
				MessageBox.Show("De gebruikersnaam moet ten minste 3 tekens lang zijn!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
		{
			User u = users.Find(x => x.Username == txtUsername.Text);

			if (u != null)
			{
				MessageBox.Show("De gebruikersnaam bestaat al!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (checkFields())
            {
                Encryption encryption = new Encryption();
                User = new User(
                        0,
                        txtUsername.Text,
                        txtFirstName.Text,
                        txtLastName.Text,
                        encryption.Encrypt(txtPassword.Text, "EyeCT4Railssbfrms" + txtUsername.Text),
                        txtEmail.Text,
                        new Group(
                            comGroup.SelectedIndex + 1,
                            groups[comGroup.SelectedIndex].ToString(),
                            0
                        )
                );
                this.DialogResult = DialogResult.OK;
            }
        }

		private void FrmCreateUser_Load(object sender, EventArgs e)
		{

		}
	}
}
