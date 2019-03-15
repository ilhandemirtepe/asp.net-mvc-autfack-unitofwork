using AutofacExample.DataAccessLayer.Entity;
using AutofacExample.Entities.Model;
using AutofacExample.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample.Services.Repository
{
    public class ProductServices : IProductService
    {
        readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<tb_Product> GetAll()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public int Addnew(ProductModel model)
        {
            if (model.Id == 0)// add new
            {
                var add = new tb_Product
                {
                    Name = model.Name,
                    Code = model.Code,
                    IdCategory = model.Idcategory

                };
                _unitOfWork.ProductRepository.Insert(add);
                return 1;
            }
            else //edit
            {
                var edit = _unitOfWork.ProductRepository.Get(p => p.Id == model.Id);
                edit.Name = model.Name;
                edit.Code = model.Code;
                _unitOfWork.ProductRepository.Update(edit);
                return 2;
            }
        }

        public void Delete(int id)
        {
            var delobj = _unitOfWork.ProductRepository.Get(p => p.Id == id);
            _unitOfWork.ProductRepository.Delete(delobj);
        }

        public bool CheckCode(string code)
        {
            var check = _unitOfWork.ProductRepository.Get(p => p.Code.Equals(code));
            if (check != null)
                return true;
            return false;
        }
    }
}
