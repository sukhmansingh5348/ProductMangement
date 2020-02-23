using ProductMangementBusiness.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProductManagementModel.Model;
using ProductMangementBusiness.vmModel;

namespace ProductMangementBusiness.repository
{
    public class UserRepository: IUserRepository
    {
        ProductManagementEntities _db = new ProductManagementEntities();
        public bool LoginUser(UserVMModel model)
        {
            bool isLogin = false;
            try
            {
                var record = (from a in _db.Users
                              where a.Name == model.Name && a.Password == model.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}
