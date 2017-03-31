using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business;
using configs;
using System.IO;

namespace business.tests
{
    [TestClass()]
    public class emailsTests
    {
        [TestMethod()]
        [TestCategory("Send Email")]
        public void sendTestWithoutAttachment()
        {
            /**
             * The SMTP server requires a secure connection or the client was not authenticated.
             */
            tester be = new tester();
            bool sent = be.sendTestEmail();

            Assert.IsTrue(sent);
        }

        [TestMethod()]
        [TestCategory("Send Email")]
        public void sendTestWithAttachment()
        {
            /**
             * The SMTP server requires a secure connection or the client was not authenticated.
             */
            tester be = new tester();
            bool sent = be.sendTestEmailWithAttachment();

            Assert.IsTrue(sent);
        }

        [TestMethod()]
        [TestCategory("Send Email")]
        public void sendTestWithCustomization()
        {
            /**
             * The SMTP server requires a secure connection or the client was not authenticated.
             */
            configurations ec = new configurations();
            string to = ec.toEmail;
            string subject = "Tests";
            string htmlTemplate = "Hi <strong>{0}</stong>, this is a test.";
            string body = string.Format(htmlTemplate, "", "", "");

            email be = new email();
            be.SMTPConfigurations();
            be.attach("d:\\profile.png");
            be.attach("d:\\report.txt");
            be.attach("d:\\non-existing.png");
            bool sent = be.send(to, subject, body);

            Assert.IsTrue(sent);
        }

        [TestMethod()]
        [TestCategory("Send Email")]
        public void sendWithNormalSMTP()
        {
            /**
             * Configure to send emails using normal smtp server
             */
            Assert.IsTrue(true);
        }
    }
}