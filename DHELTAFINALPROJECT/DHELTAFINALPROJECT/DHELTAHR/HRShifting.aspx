﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DHELTAHR/HumanResource.Master" AutoEventWireup="true" CodeBehind="HRShifting.aspx.cs" Inherits="DHELTAFINALPROJECT.DHELTAHR.WebForm4" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="content">
        <div class="mainContent">
            <div class="shifting">
                <div class="heading">
                    <h4>Employee Shift:</h4>
                </div>
                <hr />
                
                <div class="mainBody">
                    <asp:GridView ID="gvEmployee" runat="server"  
                        CssClass="table table-striped table-bordered table-condensed" Width="60%" 
                        onselectedindexchanged="gvEmployee_SelectedIndexChanged" 
                        onrowdatabound="gvEmployee_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chckbxShift" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <div class="shiftingSchedule">
                        <h4>Current Shift of the Employee:</h4>
                        <div class="shiftInfo">
                            <p class="shiftfield">Time In: 
                                <asp:Label ID="lblTimeIn" runat="server" Text=""></asp:Label></p>
                            <p class="shiftfield">Time Out: 
                                <asp:Label ID="lblTimeOut" runat="server" Text=""></asp:Label></p>
                            <p class="shiftfield">Date From: 
                                <asp:Label ID="lblDateFrom" runat="server" Text=""></asp:Label></p>
                            <p class="shiftfield">Date To: 
                                <asp:Label ID="lblDateTo" runat="server" Text=""></asp:Label></p>
                            <br />
                            <a data-toggle="modal" href="#filterModal">Change Shift</a>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="filterModal" tabindex="-1" role="dialog" aria-labelledby="filterModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Modify Shift</h4>
              </div>
              <div class="modal-body">
                <div class="changeshift">
                <p class="shiftfield">Shift: &nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:DropDownList ID="cmbShift" runat="server" class="ddl">
                    </asp:DropDownList></p>
                <p class="shiftfield">Date From: &nbsp
                    <asp:TextBox ID="txtDateFrom" runat="server" TextMode="Date"></asp:TextBox></p>
                <p class="shiftfield">Date To: &nbsp&nbsp&nbsp&nbsp
                    <asp:TextBox ID="txtDateTo" runat="server" TextMode="Date"></asp:TextBox></p>

                </div>
                  
              </div>
              <div class="modal-footer">
                  <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" 
                    onclick="btnSubmit_Click"/>
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" class="btn btn-default" data-dismiss="modal" />
                
              </div>
            </div><!-- /.modal-content -->
          </div><!-- /.modal-dialog -->
        </div><!-- /.modal -->

</asp:Content>
