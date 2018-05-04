using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SimpleWifi;
using System.Threading.Tasks;

namespace ReconnectToInternet
{
    class Program
    {
        private static Wifi wifi;

        static void Main(string[] args)
        {
            while (true)
            {
                if (!CheckForInternetConnection())
                {
                    wifi = new Wifi();

                    wifi.Disconnect();

                    Connect();

                    System.Threading.Thread.Sleep(5000);
                }

                System.Threading.Thread.Sleep(500);
            }
        }

        static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private static void Connect()
        {
            var accessPoints = wifi.GetAccessPoints();

            AccessPoint selectedAP = accessPoints.Where(ap => ap.Name == "INSERT SSID (e.g. BT-WIFI-1234567)").ToList()[0];
            
            AuthRequest authRequest = new AuthRequest(selectedAP);

            selectedAP.ConnectAsync(authRequest, false, OnConnectedComplete);
        }

        private static void OnConnectedComplete(bool success)
        {
            Console.WriteLine("\nOnConnectedComplete, success: {0}", success);
        }
    }


}
