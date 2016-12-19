using System;
using System.Net;
using System.Threading;

namespace SensorEmulate
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Console.WriteLine("Please enter sensor id:");
            string sensorId = Console.ReadLine();
            int t;
            while (!Int32.TryParse(sensorId, out t))
            {
                Console.WriteLine("Id should be int value!");
                sensorId = Console.ReadLine();
            }

            while (true)
            {
                string val = Math.Round(rand.NextDouble(), 2).ToString().Replace(',','.');

                // Адрес ресурса, к которому выполняется запрос
                string url = "http://localhost:17995/api/sensorreading/add_value?value=" + val  + "&sensorId=" + sensorId;

                // Создаём объект WebClient
                using (var webClient = new WebClient())
                {
                    try
                    {
                        // Выполняем запрос по адресу и получаем ответ в виде строки
                        var response = webClient.DownloadString(url);
                    }
                    catch { }
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
