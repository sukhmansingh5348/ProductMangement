using ProductMangementBusiness.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.vmModel
{
   public class ProductSupplierVMModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
    }
}
