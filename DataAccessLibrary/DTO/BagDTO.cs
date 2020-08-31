using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLT.DTO
{
    public class BagDTO
    {
         public int BagId { get; set; }
        public byte[] FileContent{ get; set; }
        public string BagBrand { get; set; }
    }
}
