using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;



namespace Qars.Util
{
    public class Mail
    {
        private MailMessage message;
        private SmtpClient client;

        public Mail()
        {
            message =  new MailMessage();
            client = new SmtpClient("smtp.gmail.com", 587);

            message.From = new MailAddress("qarsproject@gmail.com", "Qars");
            message.Bcc.Add(new MailAddress("qarsproject@gmail.com"));

            client.Credentials = new NetworkCredential("qarsproject@gmail.com","Quintor1");
            client.EnableSsl = true;

        }

        public void addTo(string email){
            message.To.Add(new MailAddress(email));
        }

        public void addSubject(string subject){
            message.Subject = subject;
        }

        public void addBody(string body)
        {
            message.Body = body;
        }

        public void sendEmail(){
            this.client.Send(message);
        }
         
    }
}