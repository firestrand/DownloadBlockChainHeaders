using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadBlockChainHeaders
{
    public class BlockHeader
    {
        public string hash { get; set; } //"hash":"00000000000000000790ec59fe9f006a95b610120ed6ab6ce0fcd190240a8a21",
        public uint ver { get; set; } //"ver":2,
        public string prev_block { get; set; } //"prev_block":"0000000000000000148469b72ed6ac7f53d4eb88298e932d9136a2f8d0958774",
        public string mrkl_root { get; set; } //"mrkl_root":"17db49aa849bdfca931dffde80f0d707377a4f27cb5a74c535c085b816c29e13",
        public uint time { get; set; } //"time":1423796705,
        public uint bits { get; set; } //"bits":404274055,
        public uint nonce { get; set; } //"nonce":2482359827,
    }
}
