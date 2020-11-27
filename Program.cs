using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;

namespace text
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data
            {
                datas = "",
            };
            String line;
            System.IO.StreamReader file = new System.IO.StreamReader("yourtext.txt");
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = ""
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(config);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                Task.Run(async () =>
                {
                    SetResponse response = await client.SetTaskAsync("Test/" + line, data);
                    Data result = response.ResultAs<Data>();
                }).GetAwaiter().GetResult();
            }
            file.Close();
            Console.ReadLine();
        }


    }

}
