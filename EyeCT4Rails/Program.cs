using System;
using System.Windows.Forms;

namespace EyeCT4Rails
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			DialogResult reLogin = DialogResult.Retry;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			while (reLogin == DialogResult.Retry)
			{
				FrmLogin frmLogin = new FrmLogin();
				if (frmLogin.ShowDialog() == DialogResult.OK)
				{
					FrmMain frmMain = new FrmMain(frmLogin.CurrentUser);
					Application.Run(frmMain);
					reLogin = frmMain.DialogResult;
				}
				else
				{
					reLogin = DialogResult.OK;
				}
			}
		}
	}
}
