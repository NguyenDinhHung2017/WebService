using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebService.Models
{
    public class XmlToJsonService
    {
        public static string XmlToJson (string xml)
        {
            ConfigureLog4Net.ConfigLog4Net("log4net.config");
            Logger.Info($"Convert xml = {xml}");
            var doc = new XmlDocument();
            
            try
            {
                doc.LoadXml(xml);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR_XmlToJson: " + ex.Message, ex);
                return "Bad Xml format";
            }

            var json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);

            return json;
        }
    }
}