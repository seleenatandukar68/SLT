using SLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interface
{
    public interface IColorsRepository
    {
        IEnumerable<Color> GetColors();
    }
}
