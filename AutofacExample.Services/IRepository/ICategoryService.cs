using AutofacExample.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample.Services.IRepository
{
    public interface ICategoryService
    {
        IEnumerable<tb_Category> GetAll();
    }
}
