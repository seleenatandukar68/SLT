using DataAccessLibrary.Interface;
using SLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLT.DAL
{
    public class ColorsRepository : IColorsRepository
    {

        private SLTDbContext SLTDbContext;

        public ColorsRepository(SLTDbContext context)
        {
            this.SLTDbContext = context;
        }
        public IEnumerable<Color> GetColors()
        {
            return SLTDbContext.Colors;
        }
    }
}