using ProductManagementModel.Model;
using ProductMangementBusiness.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.repository
{
    public class ProductRepository: IProductRepository
    {
        ProductManagementEntities _db = new ProductManagementEntities();
        public List<ProductVMModel> ProductLists()
        {
            var list = new List<ProductVMModel>();
            list = (from a in _db.Products
                    select new ProductVMModel
                    {
                        ID = a.ID,
                        Name = a.Name,
                        Price = a.Price,
                        Quantity = a.Quantity,
                        Code = a.Code,
                    }).ToList();
            return list;
        }
        public List<ProductVMModel> GetProductByID(int id)
        {
            var record = (from a in _db.Products
                          where a.ID == id
                          select new ProductVMModel
                          {
                              ID = a.ID,
                              Name = a.Name,
                              Price = a.Price,
                              Quantity = a.Quantity,
                              Code = a.Code
                          }).ToList();
            return record;
        }
        public ProductVMModel AddAndUpdateProduct(ProductVMModel vmModel)
        {
            if (vmModel.ID > 0)
            {
                var record = _db.Products.Where(x => x.ID == vmModel.ID).FirstOrDefault();
                record.Name = vmModel.Name;
                record.Price = vmModel.Price;
                record.Quantity = vmModel.Quantity;
                record.Code = vmModel.Code;
                _db.SaveChanges();

            }
            else
            {
                Product _product = new Product();
                _product.Name = vmModel.Name;
                _product.Price = vmModel.Price;
                _product.Quantity = vmModel.Quantity;
                _product.Code = vmModel.Code;
                _db.Products.Add(_product);
                _db.SaveChanges();
                vmModel.ID = _product.ID;
            }
            return vmModel;
        }
        public bool DeleteProduct(int id)
        {
            bool isDeleted = false;
            var record = _db.Products.Where(x => x.ID == id).FirstOrDefault();
            _db.Products.Remove(record);
            _db.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }
    }
}
