using ProductMangementBusiness.interfaces;
using ProductMangementBusiness.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductMangement
{
    public partial class Supplier : System.Web.UI.Page
    {
        ISupplierRepository iSupplierRepository = new SupplierRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            SupplierVMModel vmModel = new SupplierVMModel();
            vmModel.Name = Name.Text;
            vmModel.PhoneNumber = PhoneNumber.Text;
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iSupplierRepository.AddAndUpdateSupplier(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Supplier.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //EmployeeModel vmModel = new EmployeeModel();
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //vmModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iSupplierRepository.GetSupplierByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    PhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    Submit.Text = "Update";

                }
                else
                {
                    Submit.Text = "Save";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                bool result = iSupplierRepository.DeleteSupplier(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iSupplierRepository.SupplierLists();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supplier.aspx");
        }
    }
}