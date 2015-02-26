using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DownloadBlockChainHeaders
{
    class Program
    {
        static void Main(string[] args)
        {

            var webClient = new WebClient();
            var uriRoot = "https://blockexplorer.com/rawblock/";
            var hash = "00000000000000000790ec59fe9f006a95b610120ed6ab6ce0fcd190240a8a21";
            var first = webClient.DownloadString(uriRoot + hash);//Last as of 2015/02/2015

            var headerObject = JsonConvert.DeserializeObject<BlockHeader>(first);
            Console.WriteLine(headerObject.hash);
            for (int i = 0; i < 10; i++)
            {
                headerObject = JsonConvert.DeserializeObject<BlockHeader>(webClient.DownloadString(uriRoot + headerObject.prev_block));
                Console.WriteLine(headerObject.hash);
            }
            Console.ReadKey();
        }
    }
}
