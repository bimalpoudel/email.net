using configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace business
{
    public class tester: email
    {
        /**
  * Test sending an email
  */
        public bool sendTestEmail()
        {
            bool success = false;
            MailAddress toAddress = new MailAddress(ec.toEmail, ec.toName);

            string subject = "Subject";
            string body = "Body";

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                string filename = "d:\testr.7z";
                if (this.attachableFile(filename))
                {
                    message.Attachments.Add(new Attachment(filename));
                }
                smtp.Send(message);

                success = true;
            }

            return success;
        }

        /**
         * Test sending an email with attachment
         */
        public bool sendTestEmailWithAttachment()
        {
            bool success = false;
            configurations ec = new configurations();

            MailAddress fromAddress = new MailAddress(ec.fromEmail, ec.fromName);
            MailAddress toAddress = new MailAddress(ec.toEmail, ec.toName);

            string password = ec.password;
            string subject = "Subject";
            string body = "Body";
            int portNumber = Convert.ToInt32(ec.portnumber);

            SmtpClient smtp = new SmtpClient
            {
                Host = ec.hostname,
                Port = portNumber,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, password)
            };

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                string filename = "d:\test.7z";
                if (this.attachableFile(filename))
                {
                    message.Attachments.Add(new Attachment(filename));
                }
                smtp.Send(message);

                success = true;
            }

            return success;
        }
    }
}
