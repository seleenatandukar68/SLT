using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLT.ViewModel
{
    public class BagDTO
    {
        public int BagId { get; set; }
        public string BagBrand { get; set; }
        public byte[] FileContent { get; set; }
    }
}