using SLT.Models;
using SLT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;

namespace SLT.Interface
{
   public interface IBagRepository
    {
        IEnumerable<SelectListItem> GetCategories();
        IEnumerable<Bag> GetBags();
        IEnumerable<Color> GetColors();

        IEnumerable<BagDTO> GetGroupedBags();

        Bag AddBag(Bag newBag);
        Bag GetBagById(int? id);

        void UpdateBag(Bag uptBag);
        void UpdatePic(Picture uptPic);
        string DeletePic(int id);

        Bag Delete(int? id);
        void DeleteConfirmed(int? id);
        void Save();
    }
}
