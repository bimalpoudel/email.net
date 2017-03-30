using configs;
using configs.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace configs
{
    public class configurations
    {
        public string fromName
        {
            get
            {
                return this.read("fromName");
            }

            private set { }
        }

        public string fromEmail
        {
            get
            {
                return this.read("fromEmail");
            }

            private set { }
        }

        public string toName
        {
            get
            {
                return this.read("toName");
            }

            private set { }
        }

        public string toEmail
        {
            get
            {
                return this.read("toEmail");
            }

            private set { }
        }

        public string username
        {
            get
            {
                return this.read("username");
            }

            private set { }
        }

        public string password
        {
            get
            {
                return this.read("password");
            }

            private set { }
        }

        public string hostname
        {
            get
            {
                return this.read("hostname");
            }

            private set { }
        }

        public int portnumber
        {
            get
            {
                return Convert.ToInt32(this.read("portnumber"));
            }

            private set { }
        }

        /**
         * @see http://stackoverflow.com/questions/4939508/get-value-of-c-sharp-dynamic-property-via-string
         */
        private string read(string index)
        {
            configs.Properties.emailssettings settings = new configs.Properties.emailssettings();
            //string value = settings.GetType().GetProperty(index).GetValue(settings, null).ToString();
            // string value = settings.to; // .GetType(); // .GetProperty(index);

            string value = "";
            Type type = typeof(emailssettings);
            //type.GetProperties();
            PropertyInfo pi = type.GetProperty(index); //  (settings, null);
            if (null != pi)
            {
                object v = pi.GetValue(settings, null);
                value = v.ToString();
            }

            //var type = settings.GetType();
            // # var type = settings.GetNamesAndTypesAndValues();
            // # var property = type.GetProperty(index);
            // # var v = property.GetValue(settings, null);
            // # string value = v.ToString();

            // foreach (PropertyInfo propertyInfo in ))
            // {
            //     Console.WriteLine("{0} [type = {1}] [value = {2}]",
            //       propertyInfo.Name,
            //       propertyInfo.PropertyType,
            //       propertyInfo.GetValue(this, null));
            // }

            return value;
        }
    }
}
