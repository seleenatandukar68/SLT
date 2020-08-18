using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLT.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }

        public bool isChecked { get; set; }
        public virtual ICollection<BagsColors> BagsColors { get; set; }

    }
}