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
	public partial class FrmManageUsers : Form
	{
		public List<User> EditedUsers { get; set; }

		private List<User> users;
		private List<Group> groups;
		private User userLoggedIn;
		private User selectedUser;

		public FrmManageUsers(User userLoggedIn, List<User> users, List<Group> groups)
		{
			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanViewUsermanagement))
			{
				this.DialogResult = DialogResult.Cancel;
			}
			InitializeComponent();

			EditedUsers = new List<User>();
			this.users = users;
			this.groups = groups;
			this.userLoggedIn = userLoggedIn;

			UpdateLV();
		}

		private void FrmManageUsers_FormClosed(object sender, FormClosedEventArgs e)
		{
			DialogResult = EditedUsers.Count > 0 ? DialogResult.OK : DialogResult.Cancel;
		}

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanCreateUsers))
			{
				MessageBox.Show("U bent niet bevoegd om users aan te maken", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			FrmCreateUser createUser = new FrmCreateUser(userLoggedIn, users, groups);


			if (createUser.ShowDialog() == DialogResult.OK)
			{
				EditedUsers.Add(createUser.User);
				users.Add(createUser.User);
			}
		}

		private void btnResetPassword_Click(object sender, EventArgs e)
		{
			if (checkPasswordFields())
			{
				Encryption encryption = new Encryption();
				selectedUser.PasswordChanged = true;
				selectedUser.Password = encryption.Encrypt(txtPassword.Text, "EyeCT4Railssbfrms" + selectedUser.Username);
				EditedUsers.Add(selectedUser);
			}
		}
		private bool checkPasswordFields()
		{
			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanEditUser))
			{
				MessageBox.Show("U bent niet bevoegd om een user aan te passen", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (txtPassword.Text != txtPasswordConfirm.Text)
			{
				MessageBox.Show("De opgegeven wachtwoorden komen niet overeen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (txtPassword.Text.Length < 4)
			{
				MessageBox.Show("Het wachtwoord moet ten minste 4 tekens lang zijn!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

		private bool checkEditFields()
		{
			if (!Permission.Check(userLoggedIn, Permission.Permissions.CanEditUser) || !Permission.Check(userLoggedIn, Permission.Permissions.CanEditGroups))
			{
				MessageBox.Show("U bent niet bevoegd om een gebruiker aan te passen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (txtFullName.Text.Length < 7)
			{
				MessageBox.Show("De naam moet ten minste 7 tekens lang zijn!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			try {
				if (txtFullName.Text.Split(' ')[1] != null)
				{
				}
			}
			catch(IndexOutOfRangeException)
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

		private void btnEditUser_Click(object sender, EventArgs e)
		{
			if (selectedUser != null && checkEditFields())
			{
				selectedUser.FirstName = txtFullName.Text.Split(' ')[0];
				selectedUser.LastName = txtFullName.Text.Split(' ')[1];
				selectedUser.Username = txtUsername.Text;
				selectedUser.Email = txtEmail.Text;
				selectedUser.Group = groups.Find(x => x.ID == comGroup.SelectedIndex);

				EditedUsers.Add(selectedUser);
			}
		}

		private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (livUsers.SelectedItems.Count == 0)
				return;

			ListViewItem item = livUsers.SelectedItems[0];
			string username = item.SubItems[1].Text;

			selectedUser = users.Find(x => x.Username == username);

			txtEmail.Enabled = (selectedUser != null) ? true : false;
			txtFullName.Enabled = (selectedUser != null) ? true : false;
			txtPassword.Enabled = (selectedUser != null) ? true : false;
			txtPasswordConfirm.Enabled = (selectedUser != null) ? true : false;
			txtUsername.Enabled = (selectedUser != null) ? true : false;
			btnEditUser.Enabled = (selectedUser != null) ? true : false;
			btnResetPassword.Enabled = (selectedUser != null) ? true : false;
			comGroup.Enabled = (selectedUser != null) ? true : false;

			txtEmail.Text = (selectedUser != null) ? selectedUser.Email : string.Empty;
			txtFullName.Text = (selectedUser != null) ? selectedUser.FirstName + " " + selectedUser.LastName : string.Empty;
			txtUsername.Text = (selectedUser != null) ? selectedUser.Username : string.Empty;
			comGroup.SelectedIndex = (selectedUser != null) ? groups.IndexOf(selectedUser.Group) : 0;
		}


		private void UpdateLV()
		{
			foreach (Group group in this.groups)
			{
				if (this.groups.IndexOf(group) == 0)
				{
					comGroup.Text = group.ToString();
				}
				comGroup.Items.Add(group.ToString());
			}
			foreach (User u in users)
			{
				livUsers.Items.Add(new ListViewItem(new string[] {
							u.ToString(),
							u.Username,
							u.Email,
							u.Group.ToString()
						}));
			}
		}
	}
}
