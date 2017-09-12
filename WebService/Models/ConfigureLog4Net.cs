using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class ConfigureLog4Net
    {
        public static void ConfigLog4Net(string configFileName)
        {
            //var folder = @"C:\Users\hung\Documents\visual studio 2017\Projects\WebService\WebService\";
            var folder = System.Environment.CurrentDirectory;
            var path = Path.Combine(folder, configFileName);
            var logConfig = new FileInfo(path);
            if (!logConfig.Exists) throw new InvalidOperationException("Not found log4net config path : " + path);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(logConfig);
        }
    }
}