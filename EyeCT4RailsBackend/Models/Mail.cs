using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4RailsBackend
{
	public class Mail
	{
		private readonly string mailAddress = "no-reply@gvb.local";
		private readonly string mailPassword = "P@ssw0rd";

		private string message;
		private string subject;

		public Mail(string message, string subject)
		{
			this.message = message;
			this.subject = subject;
		}
		public void Send<T>(T source)
		{
			try
			{
				using (MailMessage m = new MailMessage())
				{
					SmtpClient smtpServer = new SmtpClient("192.168.0.2")
					{
						Port = 25,
						UseDefaultCredentials = false,
						Credentials = new System.Net.NetworkCredential(mailAddress, mailPassword),
						EnableSsl = false
					};

					m.From = new MailAddress(mailAddress);

					if(source is List<User>)
					{
						List<User> users = source as List<User>;
						foreach (User u in users)
						{
							m.To.Add(u.Email);
						}
					}
					else if(source is User)
					{
						User user = source as User;
						m.To.Add(user.Email);
					}
					m.Subject = subject;
					m.Body = message;

					smtpServer.Send(m);
				}
			}
			catch (SmtpException e)
			{
				Console.WriteLine(e.Message);
				throw new Exception("Failed to send an email!");
			}
		}
	}
}
