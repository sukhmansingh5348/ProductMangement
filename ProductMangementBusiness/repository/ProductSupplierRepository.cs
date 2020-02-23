using ProductManagementModel.Model;
using ProductMangementBusiness.interfaces;
using ProductMangementBusiness.vmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.repository
{
   public class ProductSupplierRepository: IProductSupplierRepository
    {
        ProductManagementEntities _db = new ProductManagementEntities();
        public List<ProductSupplierVMModel> ProductSupplierLists()
        {
            var list = new List<ProductSupplierVMModel>();
            list = (from a in _db.ProductSuppliers
                    join b in _db.Products on a.ProductID equals b.ID
                    join c in _db.Suppliers on a.SupplierID equals c.ID
                    select new ProductSupplierVMModel
                    {
                        ID = a.ID,
                        ProductID = a.ProductID,
                        SupplierID = a.SupplierID,
                        ProductName= b.Name,
                        SupplierName = c.Name
                    }).ToList();
            return list;
        }
        public List<ProductSupplierVMModel> GetProductSupplierByID(int id)
        {
            var record = (from a in _db.ProductSuppliers
                          where a.ID == id
                          select new ProductSupplierVMModel
                          {
                              ID = a.ID,
                              ProductID = a.ProductID,
                              SupplierID = a.SupplierID,
                          }).ToList();
            return record;
        }
        public ProductSupplierVMModel AddAndUpdateProductSupplier(ProductSupplierVMModel vmModel)
        {
            if (vmModel.ID > 0)
            {
                var record = _db.ProductSuppliers.Where(x => x.ID == vmModel.ID).FirstOrDefault();
                record.ProductID = vmModel.ProductID;
                record.SupplierID = vmModel.SupplierID;

                _db.SaveChanges();

            }
            else
            {
                ProductSupplier _supplier = new ProductSupplier();
                _supplier.ProductID = vmModel.ProductID;
                _supplier.SupplierID = vmModel.SupplierID;
                _db.ProductSuppliers.Add(_supplier);
                _db.SaveChanges();
                vmModel.ID = _supplier.ID;
            }
            return vmModel;
        }
        public bool DeleteProductSupplier(int id)
        {
            bool isDeleted = false;
            var record = _db.ProductSuppliers.Where(x => x.ID == id).FirstOrDefault();
            _db.ProductSuppliers.Remove(record);
            _db.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }
    }
}
