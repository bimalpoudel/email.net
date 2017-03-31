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
    public class attachmentsTests
    {
        [TestMethod()]
        [TestCategory("Attachment Test")]
        public void attachmentDoesNotExistTest()
        {
            string filename = "d:\\non-existing.zip";

            email ea = new email();
            bool attachable = ea.attach(filename);

            Assert.IsFalse(attachable);
        }

        [TestMethod()]
        [TestCategory("Attachment Test")]
        public void attachmentExistsTest()
        {
            string filename = "d:\\existing.zip";

            email ea = new email();
            bool attachable = ea.attach(filename);

            Assert.IsTrue(attachable);
        }
    }
}