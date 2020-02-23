using ProductMangementBusiness.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.interfaces
{
    public interface ISupplierRepository
    {
        List<SupplierVMModel> SupplierLists();
        List<SupplierVMModel> GetSupplierByID(int id);
        SupplierVMModel AddAndUpdateSupplier(SupplierVMModel vmModel);
        bool DeleteSupplier(int id);
    }
}
