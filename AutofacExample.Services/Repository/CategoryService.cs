using AutofacExample.DataAccessLayer.Entity;
using AutofacExample.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample.Services.Repository
{
    public class CategoryService : ICategoryService
    {
        readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable<tb_Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }
    }
}
