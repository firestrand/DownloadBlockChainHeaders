using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;

namespace DownloadBlockChainHeaders
{
    class Program
    {
        static void Main(string[] args)
        {

            var webClient = new WebClient();
            var uriRoot = "https://blockexplorer.com/rawblock/";
            var hash = "00000000000000001399e1e0da85c23d2f1dfabd5db4d826ee926898c9567d5b";
            var first = webClient.DownloadString(uriRoot + hash);

            using (var textWriter = File.AppendText("blockHeaders.csv"))
            {
                var csv = new CsvWriter(textWriter) { Configuration = { HasHeaderRecord = true } };
                var headerObject = JsonConvert.DeserializeObject<BlockHeader>(first);
                //textWriter.WriteLine("hash,ver,prev_block,mrkl_root,time,bits,nonce");
                //csv.WriteHeader<BlockHeader>();
                csv.WriteRecord(headerObject);
                Console.WriteLine(headerObject.hash);
                while (headerObject.prev_block != "0000000000000000000000000000000000000000000000000000000000000000")
                {
                    try
                    {
                        headerObject =
                            JsonConvert.DeserializeObject<BlockHeader>(
                                webClient.DownloadString(uriRoot + headerObject.prev_block));
                        csv.WriteRecord(headerObject);
                        textWriter.FlushAsync();
                        Console.WriteLine(headerObject.hash);
                        Thread.Sleep(200);
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }
}
