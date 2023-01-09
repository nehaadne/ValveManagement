using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ValveManagement.Common.Services
{
    public class SendNotification
    {
        public SendNotification()
        {

        }

        public void SendFCMNotificationToAndroid(string FCMId, string Message, string Title, long NotificationId, int NotificationType, string ImagePath)
        {
            try
            {
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                //var serverKey = "AIzaSyB-o3tcSbotdiLaKg1oeSAyPFB9rIyz9zE";
                var serverKey = "AAAA-bn1n8I:APA91bE9tDk9fCyaoeALUdX_JQe7FwCnGiGgwynfcqBjCQo40SvzNLx1ZaLVywhYCnTCuGAEXQBuH4h7-e9brC86AECEvA7FByxY-nmbxINz_JORwZk3DtDmhVYCQSJMrjDqrqQYvujx";
                //  var serverKey = "AAAA-bn1n8I:APA91bE9tDk9fCyaoeALUdX_JQe7FwCnGiGgwynfcqBjCQo40SvzNLx1ZaLVywhYCnTCuGAEXQBuH4h7-e9brC86AECEvA7FByxY-nmbxINz_JORwZk3DtDmhVYCQSJMrjDqrqQYvujx";

                var senderId = "1072566738882";
                var deviceId = "";
               

                if (FCMId != "")
                {                  

                    // List<string> registration_ids = DeviceId.Split(',').ToList();

                    deviceId = FCMId;
                    //foreach (string registration_id in registration_ids)
                    //{
                    deviceId = "\"" + deviceId + "\"";
                    // }
                    // deviceId = deviceId.Remove(deviceId.Length - 1, 1);

                    string jsonNotificationFormat = "{\"data\": { \"Message\": " + "\"" + Message + "\" ,\"NotificationType\": " + "\"" + NotificationType + "\" ,\"ImagePath\": " + "\"" + ImagePath + "\" ,\"Title\": " + "\"" + Title + "\" ,\"NotificationId\": " + NotificationId.ToString() + "},\"registration_ids\":[" + deviceId + "]}";

                    Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    tRequest.ContentLength = byteArray.Length;
                    tRequest.ContentType = "application/json";

                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);

                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String responseFromFirebaseServer = tReader.ReadToEnd();
                                    // Context.Response.Write(responseFromFirebaseServer);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void SendFCMNotificationToIOS(string FCMId, string Message, string Title, long NotificationId, int NotificationType, string ImagePath)
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var serverKey = "AAAA-bn1n8I:APA91bE9tDk9fCyaoeALUdX_JQe7FwCnGiGgwynfcqBjCQo40SvzNLx1ZaLVywhYCnTCuGAEXQBuH4h7-e9brC86AECEvA7FByxY-nmbxINz_JORwZk3DtDmhVYCQSJMrjDqrqQYvujx";
            var senderId = "1072566738882";
            //var serverKey = "AIzaSyAkC0jE1T8DUOt0KraQ4bEIXOYoCvukxPk";
            //var senderId = "1096428342282";
            var deviceId = "";         

                   


            deviceId = deviceId + "\"" + FCMId + "\",";

            deviceId = deviceId.Remove(deviceId.Length - 1, 1);

            string jsonNotificationFormat = "{\"notification\": { \"NotificationType\" : " + "\"" + NotificationType + "\",\"body\": " + "\"" + Title + "\" ,\"Image_Path\": " + "\"" + ImagePath + "\",\"NotificationId\": " + "\"" + NotificationId + "\"" + "},\"registration_ids\":[" + deviceId + "]}";
                       

            Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentLength = byteArray.Length;
            tRequest.ContentType = "application/json";


            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String responseFromFirebaseServer = tReader.ReadToEnd();                         


                        }
                    }

                }
            }

        }

    }
}
