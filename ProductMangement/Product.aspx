﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ProductMangement.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <label for="exampleInputName">Name <span style="color: red;">*</span></label>
                <asp:TextBox ID="Name" class="form-control" runat="server" placeholder=" Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNumber" ValidationGroup="Save" runat="server" ControlToValidate="Name" ErrorMessage="Please enter name" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class=" col-md-12">
            <div class="form-group">
                <label for="exampleInputPrice">Code <span style="color: red;">*</span></label>
                <asp:TextBox ID="Code" class="form-control" runat="server" placeholder="Code"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" runat="server" ControlToValidate="Code" ErrorMessage="Please enter code" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class=" col-md-12">
            <div class="form-group">
                <label for="exampleInputQuantity">Quantity <span style="color: red;">*</span></label>
                <asp:TextBox ID="Quantity" class="form-control" runat="server" placeholder="Quantity"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" runat="server" ControlToValidate="Quantity" ErrorMessage="Please enter quantity" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <label for="exampleInputPrice">Price <span style="color: red;">*</span></label>
                <asp:TextBox ID="Price" class="form-control" runat="server" placeholder="Price"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Save" runat="server" ControlToValidate="Price" ErrorMessage="Please enter price" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class=" col-md-6">
            <asp:Button ID="Submit" class="btn btn-primary" ValidationGroup="Save" runat="server" Text="Submit" OnClick="Submit_Click" />
            <asp:Button ID="Reset" class="btn btn-danger" runat="server" Text="Reset" OnClick="Reset_Click" />
        </div>
    </div>
    <br />
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
                            Name
                           
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("Name") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Code" HeaderText="Code" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
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
