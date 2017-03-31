using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using configs;
using System.IO;

namespace business
{
    public class email
    {
        protected configurations ec;
        protected MailAddress fromAddress;
        protected SmtpClient smtp;
        protected List<Attachment> attachments;

        public email()
        {
            ec = new configurations();
            this.attachments = new List<Attachment>();

            string password = ec.password;
            int portNumber = Convert.ToInt32(ec.portnumber);
            fromAddress = new MailAddress(ec.fromEmail, ec.fromName);
            this.smtp = new SmtpClient
            {
                Host = ec.hostname,
                Port = portNumber,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, password)
            };
        }

        public void SMTPConfigurations()
        {
            // configure email sender with user parameters
        }

 

        public bool send(string to, string subject, string body)
        {
            bool success = false;
            MailAddress toAddress = new MailAddress(ec.toEmail, ec.toName);

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            })
            {
               // string filename = "d:\\testr.7z";
               // if (this.attachableFile(filename))
               // {
               //     /**
               //      * @see https://msdn.microsoft.com/en-us/library/system.net.mime.contenttype.mediatype(v=vs.110).aspx
               //      */
               //     message.Attachments.Add(new Attachment(filename));
               // }

                foreach(Attachment attachment in this.attachments)
                {
                    /**
                    * @see https://msdn.microsoft.com/en-us/library/system.net.mime.contenttype.mediatype(v=vs.110).aspx
                    * @see http://stackoverflow.com/questions/527214/how-do-i-add-an-attachment-to-an-email-using-system-net-mail
                    */
                    message.Attachments.Add(attachment);
                }

                smtp.Send(message);

                success = true;
            }

            return success;
        }

        protected bool attachableFile(string filename)
        {
            /**
             * @see http://stackoverflow.com/questions/1395205/better-way-to-check-if-a-path-is-a-file-or-a-directory
             */
            bool isDir = true;
            bool isFile = File.Exists(filename);

            if (isFile)
            {
                FileAttributes attr = File.GetAttributes(filename);
                isDir = attr.HasFlag(FileAttributes.Directory);
            }

            return isFile && !isDir;
        }

        public bool attach(string filename)
        {
            bool isAttachable = this.attachableFile(filename);
            if(isAttachable)
            {
                /**
                 * System.NullReferenceException
                 * Additional information: Object reference not set to an instance of an object.
                 */
                Attachment attachment = new Attachment(filename);
                this.attachments.Add(attachment);
            }

            return isAttachable;
        }
    }
}
