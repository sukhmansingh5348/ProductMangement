using ProductMangementBusiness.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.repository
{
    public class ProductVMModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
