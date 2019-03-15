using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample.Entities.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Idcategory { get; set; }
        public int Type { get; set; }
    }
}
