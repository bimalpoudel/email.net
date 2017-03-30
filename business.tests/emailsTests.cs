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
            email be = new email();
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
            email be = new email();
            bool sent = be.sendTestEmailWithAttachment();

            Assert.IsTrue(sent);
        }
    }
}