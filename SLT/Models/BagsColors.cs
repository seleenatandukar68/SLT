using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLT.Models
{
    public class BagsColors
    {
        
        public int BagId { get; set; }
        public int ColorId { get; set; }

        public int Quantity { get; set; }
        public Bag Bag { get; set; }
        public Color Color { get; set; }
    }
}