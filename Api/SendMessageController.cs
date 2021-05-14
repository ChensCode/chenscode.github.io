using WebSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WebSite.Api {
	public class SendMessageController : ApiController {
		[Route("api/SendMessage")]
		[HttpPost]
		public void POST(TouchData data) {
			Task.Run(() => {
				try {
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
					SmtpClient client = new SmtpClient("smtp.office365.com", 587);
					client.EnableSsl = true;
					client.Credentials = new NetworkCredential("hsinchen@chenscode.com.tw", "Ji35j04fu06");

					MailAddress from = new MailAddress("hsinchen@chenscode.com.tw", "web touch");
					MailAddress to = new MailAddress("hsinchen@chenscode.com.tw");
					MailMessage message = new MailMessage(from, to);
					message.Subject = data.Subject;
					message.Body = $"{data.Msg}\r\n\r\nfrom:{data.Name}\r\nemail:{data.Email}";
					client.SendMailAsync(message);
				} catch (Exception e) {
					
				}
			});
		}

		[Route("api/Test")]
		[HttpGet]
		public bool Test() {
			return true;
        }

		private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true;
		}
	}
}
