using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SLT.Models
{
    public class Picture
    {
        
        
        public int PicId { get; set; }
        public int BagId { get; set; }
        //public int ColorId { get; set; }
        [Required]        
        [Display(Name = "Select Picture")]
        public string FileName { get; set; }
        public string Extension { get; set; }
        public byte[] FileContent { get; set; }

        public virtual Bag Bag { get; set; }
    }
}