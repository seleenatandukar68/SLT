using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLT.Models
{
    public class IndexData
    {
        public IEnumerable<Bag> BagList { get; set; }
        public List<Color> ColorList { get; set; }
        public List<Category> CategoryList { get; set; }
        public IEnumerable<BagsColors> BagsColorsList { get; set; }
    }
}