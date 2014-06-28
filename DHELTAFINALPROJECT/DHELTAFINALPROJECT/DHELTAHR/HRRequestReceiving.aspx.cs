﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;

using DHELTASSys.Modules;
using DHELTASSYS.DataAccess;

namespace DHELTAFINALPROJECT.DHELTAHR
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        TransferModuleBL transfer = new TransferModuleBL();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmpRequest.Visible = false;
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {

                if (Session["Position"].ToString() != "HR Manager")
                {
                    Response.Redirect(@"~/404.aspx");
                }
                else
                {
                    userSession = int.Parse(Session["EmployeeID"].ToString());
                    if (!IsPostBack)
                    {
                        transfer.CompanyID = int.Parse(Session["CompanyID"].ToString());
                        gvEmployee.DataSource = transfer.ViewAllReceivingEmployee();
                        gvEmployee.DataBind();
                        btnSubmit.Visible = true;
                        dpApproval.Visible = true;

                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvEmployee.Rows.Count; i++)
            {
                CheckBox chkTransferRequest = (CheckBox)gvEmployee.Rows[i].Cells[0].FindControl("chckbxTransfer");
                if (chkTransferRequest.Checked)
                {

                    if (dpApproval.SelectedItem.Text == "Approve")
                    {
                        transfer.HrManagerDecision = dpApproval.SelectedValue.ToString();
                        transfer.TransfreReceivingID = int.Parse(gvEmployee.Rows[i].Cells[1].Text);
                        transfer.UpdateHRApprove();
                        transfer.AddTransferRecieve();
                    }
                    else
                    {
                        transfer.HrManagerDecision = dpApproval.SelectedValue.ToString();
                        transfer.TransfreReceivingID = int.Parse(gvEmployee.Rows[i].Cells[1].Text);
                        transfer.UpdateHRReceiving();
                        transfer.AddTransferRecieve();
                    }
                }
            }
            Response.Redirect("HRRequestReceiving.aspx");
        }
    }
}