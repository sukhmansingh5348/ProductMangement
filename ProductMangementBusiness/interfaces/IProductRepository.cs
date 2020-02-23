using ProductMangementBusiness.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.interfaces
{
    public interface IProductRepository
    {
        List<ProductVMModel> ProductLists();
        List<ProductVMModel> GetProductByID(int id);
        ProductVMModel AddAndUpdateProduct(ProductVMModel vmModel);
        bool DeleteProduct(int id);
    }
}
