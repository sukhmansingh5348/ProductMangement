using ProductMangementBusiness.vmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.interfaces
{
    public interface IProductSupplierRepository
    {
        List<ProductSupplierVMModel> ProductSupplierLists();
        List<ProductSupplierVMModel> GetProductSupplierByID(int id);
        ProductSupplierVMModel AddAndUpdateProductSupplier(ProductSupplierVMModel vmModel);
        bool DeleteProductSupplier(int id);
    }
}
