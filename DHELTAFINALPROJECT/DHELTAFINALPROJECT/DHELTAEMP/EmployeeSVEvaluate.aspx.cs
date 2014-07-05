﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DHELTASSys.DataHandling;
using DHELTASSYS.DataAccess;
using DHELTASSys.modules;
using DHELTASSys.AuditTrail;

namespace DHELTASSYSMEGABYTE
{
    public partial class EmployeeSVEvaluate : System.Web.UI.Page
    {
        DHELTASSysDataHandling dth = new DHELTASSysDataHandling();
        int userSession;
        string userPosition;
        int year;
        DataTable dtEvalStatSV;
        DataTable dtEvaluationStatusSupervisor_PerEmployee;

        EvaluationModuleBL evalSupervisor = new EvaluationModuleBL();
        DHELTASSysAuditTrail auditTrail = new DHELTASSysAuditTrail();
        RadioButtonList rbtn = new RadioButtonList();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (DateTime.Now.Day >= 25 && DateTime.Now.Day <= 31 && 
            //    DateTime.Now.Month == 3 || DateTime.Now.Month == 6 || 
            //    DateTime.Now.Month == 9 || DateTime.Now.Month == 12)
            //{
                if (Session["EmployeeID"] != null)
                {
                    if (Session["Position"].ToString() == "Employee")
                    {
                        userSession = int.Parse(Session["EmployeeID"].ToString());
                        userPosition = Session["Position"].ToString();
                        evalSupervisor.Emp_evaluating_id = userSession;
                        gvSVEvaluate.DataSource = evalSupervisor.ViewEvaluateSupervisors();
                        gvSVEvaluate.DataBind();

                        if (DateTime.Now.Month <= 03)
                        {
                            evalSupervisor.Eval_quarter = "First";
                        }
                        else if (DateTime.Now.Month >= 03 && DateTime.Now.Month <= 06)
                        {
                            evalSupervisor.Eval_quarter = "Second";
                        }
                        else if (DateTime.Now.Month >= 06 && DateTime.Now.Month <= 09)
                        {
                            evalSupervisor.Eval_quarter = "Third";
                        }
                        else
                        {
                            evalSupervisor.Eval_quarter = "Fourth";
                        }
                        year = int.Parse(DateTime.Now.Year.ToString());
                        evalSupervisor.Eval_year = year;
                    }
                    else if (Session["Position"].ToString() == "Vice President")
                    {
                        Response.Redirect("VPMainPage.aspx");
                    }
                    else if (Session["Position"].ToString() == "HR Manager")
                    {
                        Response.Redirect("HRMainPage.aspx");
                    }
                    else if (Session["Position"].ToString() == "Supervisor")
                    {
                        Response.Redirect("SVMainPage.aspx");
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            //}
            //else
            //{
            //    Response.Write("<script>alert('Hindi pa sched ng evaluation. Atat ka masyado. Wag kang excited.')</script>");
            //}           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (gvSVEvaluate.SelectedRow == null)
            {
                Response.Write("<script>alert('No selected supervisor to evaluate.')</script>");
            }
            else
            {
                evalSupervisor.Emp_evaluated_id = int.Parse(gvSVEvaluate.SelectedRow.Cells[0].Text);
                dtEvaluationStatusSupervisor_PerEmployee = evalSupervisor.ViewEvaluationStatusSupervisor_PerEmployee();
                if (dtEvaluationStatusSupervisor_PerEmployee.Rows.Count != 0)
                {
                    Response.Write("<script>alert('The selected supervisor has already been evaluated.')</script>");
                }
                else
                {
                    evalSupervisor.Emp_evaluating_id = userSession;
                    evalSupervisor.Emp_evaluated_id = int.Parse(gvSVEvaluate.SelectedRow.Cells[0].Text);
                    dtEvalStatSV = evalSupervisor.ViewEvalStatAnswers();
                    Session.Add("Evaluated_EmployeeID", gvSVEvaluate.SelectedRow.Cells[0].Text);
                    Response.Redirect("EmployeeSVEvalForm.aspx");
                }
            } 
        }

        protected void gvSVEvaluate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvSVEvaluate, "Select$" + e.Row.RowIndex);
        }

       
    }
}