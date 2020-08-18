using SLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SLT.Interface
{
    interface IBagRepository
    {
        List<SelectListItem> GetCategories();
        List<Bag> GetBags();
        List<Color> GetColors();

        Bag AddBag(Bag newBag);
        Bag GetBagById(int? id);

        void UpdateBag(Bag uptBag);
    }
}
