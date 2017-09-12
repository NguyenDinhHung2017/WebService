using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Models;

namespace UnitTest
{
    [TestClass]
    public class XmlToJsonServiceTest
    {
        [DataTestMethod]
        [DataRow("<foo>bar</foo>", "{\"foo\":\"bar\"}")]
        [DataRow("<foo>hello</bar>", "Bad Xml format")]
        [DataRow("<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>", "{\"TRANS\":{\"HPAY\":{\"ID\":\"103\",\"STATUS\":\"3\",\"EXTRA\":{\"IS3DS\":\"0\",\"AUTH\":\"031183\"},\"INT_MSG\":null,\"MLABEL\":\"501767XXXXXX6700\",\"MTOKEN\":\"project01\"}}}")]
        public void GivenXmlString_WhenUsingConvertService_ThenBeOk(string xml, string json)
        {
            //Given

            //When
            Logger.Info($"Test XmlToJsonService with xml = {xml}");
            var result = XmlToJsonService.XmlToJson(xml);
            //Then

            Assert.AreEqual(result, json);
        }



        
    }
}
