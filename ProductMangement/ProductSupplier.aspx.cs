using ProductMangementBusiness.interfaces;
using ProductMangementBusiness.repository;
using ProductMangementBusiness.vmModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductMangement
{
    public partial class ProductSupplier : System.Web.UI.Page
    {
        IProductSupplierRepository iProductSupplierRepository = new ProductSupplierRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                bindProductList();
                bindSupplierList();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            ProductSupplierVMModel vmModel = new ProductSupplierVMModel();
            vmModel.SupplierID = Convert.ToInt32(SupplierID.Text);
            vmModel.ProductID = Convert.ToInt32(ProductID.Text);
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iProductSupplierRepository.AddAndUpdateProductSupplier(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("ProductSupplier.aspx");
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
                var lst = iProductSupplierRepository.GetProductSupplierByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    SupplierID.Text = dt.Rows[0]["SupplierID"].ToString();
                    ProductID.Text = dt.Rows[0]["ProductID"].ToString();
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
                bool result = iProductSupplierRepository.DeleteProductSupplier(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iProductSupplierRepository.ProductSupplierLists();
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
        protected void bindSupplierList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            ISupplierRepository repository = new SupplierRepository();
            var lst = repository.SupplierLists().Select(x => new { x.Name, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                SupplierID.DataSource = dt;
                SupplierID.DataTextField = "Name";
                SupplierID.DataValueField = "ID";
                SupplierID.DataBind();

            }
            else
            {
                SupplierID.DataBind();
            }
        }
        protected void bindProductList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            IProductRepository repository = new ProductRepository();
            var lst = repository.ProductLists().Select(x => new { x.Name, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                ProductID.DataSource = dt;
                ProductID.DataTextField = "Name";
                ProductID.DataValueField = "ID";
                ProductID.DataBind();

            }
            else
            {
                ProductID.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductSupplier.aspx");
        }
    }
}