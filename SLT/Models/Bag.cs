using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLT.Models
{
    public class Bag
    {
        public int BagId { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        public string BagBrand { get; set; }
        [Required]
        [Display(Name = "Cost Price")]
        public float Cost { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public float sellCost { get; set; }
        [NotMapped]
        
        [DataType(DataType.Upload)]
        [Display(Name = "Select File")]
        public HttpPostedFileBase[] files { get; set; }


        public int CategoryId { get; set; } // many to one with category
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }


        public virtual ICollection<BagsColors> BagsColors { get; set; } // many to many with colors 


        [NotMapped]
        [Display(Name = "Colors")]
        public List<Color> ColorList { get; set; }

        [NotMapped]
        [Display(Name = "Bag Category")]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [Display(Name = "Bag Picture")]
        public virtual ICollection<Picture> BagsPictures { get; set; }

        

    }
}