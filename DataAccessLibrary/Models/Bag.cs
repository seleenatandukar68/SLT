using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SLT.Models
{
    public class Bag
    {      
        public Bag() { }
        public int BagId { get; set; }
        [Required(ErrorMessage = "Brand Name is required.")]
        [Display(Name = "Brand Name")]
        public string BagBrand { get; set; }
        [Required(ErrorMessage = "Cost Price is required.")]
        [Display(Name = "Cost Price")]
        public float Cost { get; set; }
        [Required(ErrorMessage = "Selling Price is required.")]
        [Display(Name = "Selling Price")]
        public float sellCost { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [NotMapped]
        
        [DataType(DataType.Upload)]
        [Display(Name = "Select File")]
        public HttpPostedFileBase[] files { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int SelectedCountryId { get; set; }
        public int CategoryId { get; set; } // many to one with category
        [ForeignKey("CategoryId")]
       
        public virtual Category Category { get; set; }
        public virtual ICollection<BagsColors> BagsColors { get; set; } // many to many with colors 


        [NotMapped]
        [Display(Name = "Colors")]
        [Required (ErrorMessage = "Color is required")]
       
        public List<Color> ColorList { get; set; }

        [NotMapped]
        [Display(Name = "Bag Category")]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [Display(Name = "Bag Picture")]
        public virtual ICollection<Picture> BagsPictures { get; set; }

        [NotMapped]
        public Picture thumbPic { get; set; }

        public IEnumerable<ValidationResult> ValidationResults (ValidationContext validationContext)
        {
            int count = 0;
            foreach (var item in ColorList)
            {
                if (item.isChecked == true)
                {
                    count = count + 1; 
                }
            }

            if (count == 0)
            {
                yield return new ValidationResult("Check atlease one color", new[] { "ColorList" });

            }

        }
       

    }
}