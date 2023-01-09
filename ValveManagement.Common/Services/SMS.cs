using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ValveManagement.Common.Services
{
    public class SMS
    {       

        public SMS()
        { 
            
        }               
        public void SMSHorizon(string mobNo, string msg, string tid)
        {
            ////sms horizon new api 24Dec2015
            string sUserID = "abhay";
            string sApikey = "ReiYUV6O5mcERhZITWbw";
            string sNumber = mobNo;
            //string sSenderid = "MINING";
            string sSenderid = "STPLPN";
            string sMessage = string.Concat(msg, "\n- Shaurya Tech");
            string sType = "txt";

            string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + sNumber + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "&tid=" + tid + "";

            string sResponse = GetResponse(sURL);
            string text = sResponse;
        }
        public void SMSHorizon_Unicode(string mobNo, string msg)
        {
            ////sms horizon new api 24Dec2015
            string sUserID = "abhay";
            string sApikey = "ReiYUV6O5mcERhZITWbw";
            string sNumber = mobNo;
            //string sSenderid = "MINING";
            string sSenderid = "STPLIT";
            string sMessage = string.Concat(msg, "\n- Shaurya Tech");
            string sType = "uni";

            string sURL = "http://smshorizon.co.in/api/sendsms.php?user=" + sUserID + "&apikey=" + sApikey + "&mobile=" + sNumber + "&senderid=" + sSenderid + "&message=" + sMessage + "&type=" + sType + "";
            string sResponse = GetResponse(sURL);
            string text = sResponse;
        }
        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL); request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                return "";
            }
        }      

    }
}
