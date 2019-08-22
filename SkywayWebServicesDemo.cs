using System;
using RestSharp;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace OLSPayments.Skyway
{
    class SkywayWebServicesDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Skyway!");
            Console.WriteLine();
            
             var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var configuration = builder.Build();

                if (String.IsNullOrEmpty(configuration["skywayURL"])){
                    Console.Error.WriteLine("Invalid skywayURL in appsettings.json"); 
                    Environment.Exit(-1);
                }

            String uri = "/fsd/J.01-A";

            DateTime now =  DateTime.Now;
            String timestamp = now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            String contentType = "application/json";
            String accepts = "application/json; version=3";
            String accessId = configuration["accessId"];
            String accessKey = configuration["accessKey"];

            var client = new RestClient(configuration["skywayURL"]); 
            var request = new RestRequest(uri);

            Console.WriteLine("Sending Request to: " + configuration["skywayURL"] + uri );

            var hmac = Encode(String.Concat(timestamp,contentType,accepts,uri),Encoding.ASCII.GetBytes(accessKey));
            var signature = String.Concat("InComm ",Convert.ToBase64String(Encoding.ASCII.GetBytes(accessId)),":",Convert.ToBase64String(hmac));

            request.AddHeader("X-InComm-DateTime", timestamp);
            request.AddHeader("Content-Type", contentType);
            request.AddHeader("Accept", accepts);
            request.AddHeader("Accept-Language", "en");
            request.AddHeader("Authorization", signature);
            
            request.AddJsonBody( //RestSharp's AddJsonBody() will Serialize this .NET Object into JSON
                new 
                {
                application_type = "0", 
                platform = "W",
                sigcap_model = "V",
                register_version = "3062",
                message_version = "03",
                shift_number = "24456",
                merchant_number = "0001",
                store_number = "99999",
                register_number = "001",
                pos_capability = "6",
                country_code = "USA",
                currency_code = "USD",
                timezone_differential = "-0600",
                encryption_indicator = "1",
                transaction_sequence_number = "2103",
                card_id_source = "A",
                account_entry_mode = "T",
                magnetic_strip_info = "4111111111111111",
                amount = "000000001234",
                additional_amount = "0",
                tender_attempt_indicator = "1",
                unique_id_scheme = "S",
                sender_unique_id = "000000000000079454120278678665"
                });

            Console.WriteLine();

            Console.WriteLine ("Request");
            Console.WriteLine ("********************************************");
            
                var sb = new StringBuilder();
                foreach(var param in request.Parameters)
                {
                    if (String.IsNullOrEmpty((param.Name)))
                    {
                        sb.AppendFormat("{0}{1}\r\n", param.Name, PrettyFormatJson(JsonConvert.SerializeObject(param.Value))); //Convert and Pretty Print JSON Request Body
                    } else {
                        sb.AppendFormat("{0}: {1}\r\n", param.Name, param.Value);
                    }
                }
                Console.WriteLine(sb.ToString());
                
            var response = client.Post(request);
            var content = response.Content;

            Console.WriteLine ("Response");
            Console.WriteLine ("********************************************");
            
                Console.WriteLine(PrettyFormatJson(content.ToString()));
        }
       private static byte[]  Encode(string input, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            return myhmacsha1.ComputeHash(byteArray);
        }
        private static string PrettyFormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

    }
}
