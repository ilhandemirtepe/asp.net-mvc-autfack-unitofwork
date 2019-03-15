using AutofacExample.DataAccessLayer.Entity;
using AutofacExample.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample.Services.IRepository
{
  public   interface IProductService
    {
        IEnumerable<tb_Product> GetAll();
        int Addnew(ProductModel model);
        void Delete(int id);
        bool CheckCode(string code);
    }
}
