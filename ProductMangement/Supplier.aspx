﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="ProductMangement.Supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
           
            <div class="form-group">
                <label for="exampleInputName">Name <span style="color: red;">*</span></label>
                <asp:TextBox ID="Name" class="form-control" runat="server" placeholder="Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Save" runat="server" ControlToValidate="Name" ErrorMessage="Please enter name" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputPhoneNumber">Phone Number</label>
                <asp:TextBox ID="PhoneNumber" class="form-control" runat="server" placeholder="Phone Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Save" ControlToValidate="PhoneNumber" ErrorMessage="Please enter phone number" ForeColor="#993333"></asp:RequiredFieldValidator>
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
                                Name
                           
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("Name") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
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
