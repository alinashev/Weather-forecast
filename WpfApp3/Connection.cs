using System.IO;
using System.Net;
using System.Text.Json;

namespace WpfApp3
{
    public class Connection
    {
        private Root myDeserializedClass;
        private const string KEY = "e34cfb0ab5424f979f7cf4473d629fe0";
        
        public void Connect(string city)
        {
            WebRequest request = WebRequest.Create(
                "https://api.weatherbit.io/v2.0/current?city=" + city + "&key=" + KEY);
            WebResponse response = request.GetResponse();
            
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        myDeserializedClass = JsonSerializer.Deserialize<Root>(line);
                    }
                }
            }
        }

        public Root getRoot()
        {
            return myDeserializedClass;
        }
    }
}