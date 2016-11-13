using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SensorMonitoring.SL.DI
{
    public class ConfigParser
    {
        private string path;
        public ConfigParser(string path)
        {
            this.path = path;
        }

        // query example 'dal.baseAddress'
        public string Find(string query)
        {
            if (query == null) { return null; }

            string[] parts = query.Split('.');
            if (parts.Length == 0) { return null; }

            XDocument doc = XDocument.Load(path);

            XElement elem = doc.Root;
            foreach (string part in parts)
            {
                elem = elem.Elements().First(e => e.Name == part);
            }

            return elem.Value.Trim().Replace("\n", "").Replace(" ", ""); ;
        }
    }
}