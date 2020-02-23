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
    public partial class Product : System.Web.UI.Page
    {
        IProductRepository iProductRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            ProductVMModel vmModel = new ProductVMModel();
            vmModel.Name = Name.Text;
            vmModel.Code = Code.Text;
            vmModel.Quantity = Convert.ToInt32(Quantity.Text);
            vmModel.Price = Convert.ToDecimal(Price.Text);
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iProductRepository.AddAndUpdateProduct(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Product.aspx");
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
                var lst = iProductRepository.GetProductByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    Code.Text = dt.Rows[0]["Code"].ToString();
                    Quantity.Text = dt.Rows[0]["Quantity"].ToString();
                    Price.Text = dt.Rows[0]["Price"].ToString();
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
                bool result = iProductRepository.DeleteProduct(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iProductRepository.ProductLists();
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
            Response.Redirect("Product.aspx");
        }
    }
}