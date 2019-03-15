using AutofacExample.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample.Services
{
    public class UnitOfWork : IDisposable
    {
        
        public readonly DBKategoriProductEntities Context = new DBKategoriProductEntities();
       
        private BaseRepository<tb_Product> _productRepository;
        private BaseRepository<tb_Category> _categoryRepository;

       
        public BaseRepository<tb_Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new BaseRepository<tb_Product>(Context);
                return _productRepository;
            }
        }
        public BaseRepository<tb_Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new BaseRepository<tb_Category>(Context);
                return _categoryRepository;
            }
        }

      

        public void Save()
        {
            Context.SaveChanges();
        }
       

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
    }
}
