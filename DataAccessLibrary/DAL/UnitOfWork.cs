using SLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLT.DAL
{
    public class UnitOfWork: IDisposable
    {
        private SLTDbContext context = new SLTDbContext();
        private GenericRepository<Bag> bagRepository;
        private GenericRepository<Category> categoryRepository;


        public GenericRepository<Bag> BagRepository
        {
            get
            {

                if (this.bagRepository == null)
                {
                    this.bagRepository = new GenericRepository<Bag>(context);
                }
                return bagRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}