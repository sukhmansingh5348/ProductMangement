<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductSupplier.aspx.cs" Inherits="ProductMangement.ProductSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <label for="exampleInputProduct">Product <span style="color: red;">*</span></label>
                <asp:DropDownList ID="ProductID" AppendDataBoundItems="true" class="form-control" runat="server">
                    <asp:ListItem>------ Choose Product ------</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClassName" ValidationGroup="Save" runat="server" ControlToValidate="ProductID" ErrorMessage="Please choose product " ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputSupplier">Supplier <span style="color: red;">*</span></label>
                <asp:DropDownList ID="SupplierID" AppendDataBoundItems="true" class="form-control" runat="server">
                    <asp:ListItem>------ Choose Supplier ------</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Save" runat="server" ControlToValidate="SupplierID" ErrorMessage="Please choose department " ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-primary" Text="Submit" OnClick="Submit_Click" />
            <asp:Button ID="Reset" runat="server" class="btn btn-danger" Text="Reset" OnClick="Reset_Click" />
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-12">
                <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover"
                    AutoGenerateColumns="false" EmptyDataText="No Record Found" DataKeyNames="ID"
                    AllowPaging="false" PageSize="10" OnRowCommand="grd_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Product
                           
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("ProductName") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

        </div>
    </div>
</asp:Content>
