﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRCompanyBenefit.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="sidemenu">
    <div class="menulist">
        <ul class="menu">
        <li class="sidebar"><u>Other Things You Can Do:</u></li>
            <li class="sidebarmenu">
                <asp:HyperLink ID="lnkAccess" runat="server" href="HRAddEmployeeBenefit.aspx">Employee Benefit</asp:HyperLink>
            </li>

            <li class="sidebarmenu">
                 <a data-toggle="modal" href="#filterModal" class="benefit">Add Benefit</a>
            </li>
        </ul>
    </div>
</div>

<div class="containerFluid">
    <div class="mainContainer">
        <div class="greetings">
            <h4>View Benefits For: 
                <asp:DropDownList ID="cmbPositionFilter" runat="server" AutoPostBack="True" 
                    class="ddl" 
                    onselectedindexchanged="cmbPositionFilter_SelectedIndexChanged">
                </asp:DropDownList>
            </h4>
            
            <hr />
            <div class="benefit">
                <asp:GridView ID="gvBenefit" runat="server" CssClass="table table-striped table-bordered table-condensed">
                </asp:GridView>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="filterModal" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Add Benefit</h4>
              </div>
              <div class="modal-body">
                <div class="addBenefit">
                    <p class="benefitinfo">For Position:&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:DropDownList ID="dpPosition" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </p>
                    <p class="benefitinfo">Benefit Type:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                       <asp:TextBox ID="txtBenefitType" runat="server"></asp:TextBox></p>
                     <p class="benefitinfo">Benefit Information:&nbsp&nbsp
                       <asp:TextBox ID="txtBenefitInfo" runat="server"></asp:TextBox></p>
                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" 
                onclick="btnSubmit_Click"/>
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
              </div>
          </div>
        </div>
    </div>

</asp:Content>
