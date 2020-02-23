using ProductMangementBusiness.vmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementBusiness.interfaces
{
    public interface IUserRepository
    {
        bool LoginUser(UserVMModel model);
    }
}
