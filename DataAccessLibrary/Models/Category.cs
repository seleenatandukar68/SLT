using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLT.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CatName { get; set; }

        public virtual ICollection<Bag> Bags { get; set; }
    }
}