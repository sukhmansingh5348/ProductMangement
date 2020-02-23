using ProductManagementModel.Model;
using ProductMangementBusiness.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.repository
{
    public class SupplierRepository: ISupplierRepository
    {
        ProductManagementEntities _db = new ProductManagementEntities();
        public List<SupplierVMModel> SupplierLists()
        {
            var list = new List<SupplierVMModel>();
            list = (from a in _db.Suppliers
                    select new SupplierVMModel
                    {
                        ID = a.ID,
                        Name = a.Name,
                        PhoneNumber = a.PhoneNumber,
                    }).ToList();
            return list;
        }
        public List<SupplierVMModel> GetSupplierByID(int id)
        {
            var record = (from a in _db.Suppliers
                          where a.ID == id
                          select new SupplierVMModel
                          {
                              ID = a.ID,
                              Name = a.Name,
                              PhoneNumber = a.PhoneNumber
                          }).ToList();
            return record;
        }
        public SupplierVMModel AddAndUpdateSupplier(SupplierVMModel vmModel)
        {
            if (vmModel.ID > 0)
            {
                var record = _db.Suppliers.Where(x => x.ID == vmModel.ID).FirstOrDefault();
                record.Name = vmModel.Name;
                record.PhoneNumber = vmModel.PhoneNumber;
              
                _db.SaveChanges();

            }
            else
            {
                Supplier _supplier = new Supplier();
                _supplier.Name = vmModel.Name;
                _supplier.PhoneNumber = vmModel.PhoneNumber;
                _db.Suppliers.Add(_supplier);
                _db.SaveChanges();
                vmModel.ID = _supplier.ID;
            }
            return vmModel;
        }
        public bool DeleteSupplier(int id)
        {
            bool isDeleted = false;
            var record = _db.Suppliers.Where(x => x.ID == id).FirstOrDefault();
            _db.Suppliers.Remove(record);
            _db.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }
    }
}
