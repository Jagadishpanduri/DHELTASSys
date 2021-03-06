﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DHELTASSys.modules;
using DHELTASSys.DataHandling;

namespace DHELTAFINALPROJECT.DHELTAVP
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        DHELTASSysDataHandling dataHandling = new DHELTASSysDataHandling();
        BenefitsModuleBL benefits = new BenefitsModuleBL();
        int userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect(@"~/index.aspx");
            }
            else
            {
                userSession = int.Parse(Session["EmployeeID"].ToString());
                if (Session["Position"].ToString() == "Vice President")
                {
                    benefits.Emp_id = userSession;
                    DataTable dtBenefits = benefits.ViewBenefits();
                    dtBenefits.Columns.Remove("ID");
                    gvBenefit.DataSource = dtBenefits;
                    gvBenefit.DataBind();
                    if (!IsPostBack)
                    {
                        DataTable dtPosition = dataHandling.SelectAllPosition();
                        cmbPositionFilter.DataSource = dtPosition;
                        cmbPositionFilter.DataTextField = "position_name";
                        cmbPositionFilter.DataValueField = "position_name";
                        cmbPositionFilter.DataBind();

                        cmbPositionFilter.Items.Insert(0, new ListItem("All Position", "All"));
                        for (int i = 0; i < dtPosition.Rows.Count; i++)
                        {
                            cmbPositionFilter.Items.Insert(i + 1, new ListItem(dtPosition.Rows[i]["position_name"].ToString()));
                        }
                        cmbPositionFilter.DataBind();
                    }
                }
            }
        }

        protected void cmbPositionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            benefits.Emp_id = userSession;
            if (cmbPositionFilter.SelectedValue == "All")
            {
                DataTable dtBenefits = benefits.ViewBenefits();
                dtBenefits.Columns.Remove("ID");
                gvBenefit.DataSource = dtBenefits;
                gvBenefit.DataBind();
            }
            else
            {
                benefits.Position_name = cmbPositionFilter.Text;
                DataTable dtPositionBenefits = benefits.ViewPositionBenefits();
                if (dtPositionBenefits.Rows.Count >= 1)
                {
                    dtPositionBenefits.Columns.Remove("ID");
                    gvBenefit.DataSource = dtPositionBenefits;
                    gvBenefit.DataBind();
                    gvBenefit.Visible = true;
                }
                else
                {
                    gvBenefit.Visible = false;
                }
            }
        }
    }
}