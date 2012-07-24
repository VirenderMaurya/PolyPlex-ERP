using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomePage : System.Web.UI.Page
{
    #region***************************************Variables***************************************

    Home objHome = new Home();
    DynControl obj = new DynControl();

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] == null)
            {
                try
                {
                    Response.Redirect("../SessionExpired.aspx", false);
                }
                catch { }
            }
            else
            {
                div_in_trans.Visible = false;
                div_in_formpri.Visible = false;
                div_in_reports.Visible = false;
                div_in_query.Visible = false;
                div_in_listing.Visible = false;
                div_in_myusermanagement.Visible = false;
                div_in_master.Visible = false;
                div_in_admin.Visible = false;
                AccordionPane1.Visible = false;
                AccordionPane2.Visible = false;
                AccordionPane3.Visible = false;
                AccordionPane4.Visible = false;
                AccordionPane5.Visible = false;

                if (Session["Environment"] != null && Session["LocationName"] != null && Session["UserName"] != null && Session["UserID"] != null)
                {
                    if (Session["Environment"].ToString() == "-Select-")
                    {
                        lbl_Environment.Visible = false;
                    }
                    else
                    {
                        lbl_Environment.Visible = true;
                        lbl_Environment.Text ="Environment: "+ Session["Environment"].ToString();
                    }
                    lbl_location.Text = Session["LocationName"].ToString();
                    lblName.Text = Session["UserName"].ToString();
                    HidUserId.Value = Session["UserID"].ToString();
                }
                else
                {
                    Response.Redirect("../SessionExpired.aspx", false);
                }

                #region Get Module and SubModule by User

                DataTable dt = new DataTable();
                dt = objHome.Get_ModuleAndSubmoduleByUserId(HidUserId.Value);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        putInMenu(dt.Rows[i]["SubModuleName"].ToString(), dt.Rows[i]["ModuleName"].ToString());
                    }
                }
                #endregion
            }            
        }
        catch { }
    }

    protected void lnk_sales_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_sub_header.Text = "Sales Authorization";
            DataTable dt = GetSubmoduleFormURLByModuleAndUserId("Sales");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel pnl = getpanel(dt.Rows[i]["SubModuleName"].ToString());
                    obj.CreatesubMenu(ref pnl, dt.Rows[i]["FormURL"].ToString(), dt.Rows[i]["SubModuleName"].ToString(), dt.Rows[i]["formname"].ToString());
                }
            }
            if (dt == null)
            {
                Response.Redirect("../SessionExpired.aspx", false);
            }
        }
        catch { }
    }

    protected void lnk_FA_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_sub_header.Text = "Financial Accounting";
            DataTable dt = GetSubmoduleFormURLByModuleAndUserId("Financial Accounting");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel pnl = getpanel(dt.Rows[i]["SubModuleName"].ToString());
                    obj.CreatesubMenu(ref pnl, dt.Rows[i]["FormURL"].ToString(), dt.Rows[i]["SubModuleName"].ToString(), dt.Rows[i]["formname"].ToString());
                }
            }
            if (dt == null)
            {
                Response.Redirect("../SessionExpired.aspx", false);
            }
        }
        catch { }
    }

    protected void lnk_procurement_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_sub_header.Text = "Procurement";
            DataTable dt = GetSubmoduleFormURLByModuleAndUserId("Procurement");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel pnl = getpanel(dt.Rows[i]["SubModuleName"].ToString());
                    obj.CreatesubMenu(ref pnl, dt.Rows[i]["FormURL"].ToString(), dt.Rows[i]["SubModuleName"].ToString(), dt.Rows[i]["formname"].ToString());
                }
            }
            if (dt == null)
            {
                Response.Redirect("../SessionExpired.aspx", false);
            }
        }
        catch { }
    }

    protected void lnk_production_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_sub_header.Text = "Production";
            DataTable dt = GetSubmoduleFormURLByModuleAndUserId("Production");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel pnl = getpanel(dt.Rows[i]["SubModuleName"].ToString());
                    obj.CreatesubMenu(ref pnl, dt.Rows[i]["FormURL"].ToString(), dt.Rows[i]["SubModuleName"].ToString(), dt.Rows[i]["formname"].ToString());
                }
            }
            if (dt == null)
            {
                Response.Redirect("../SessionExpired.aspx", false);
            }
        }
        catch { }
    }

    protected void lnk_admin_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_sub_header.Text = "Admin";
            DataTable dt = GetSubmoduleFormURLByModuleAndUserId("Admin");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel pnl = getpanel(dt.Rows[i]["SubModuleName"].ToString());
                    obj.CreatesubMenu(ref pnl, dt.Rows[i]["FormURL"].ToString(), dt.Rows[i]["SubModuleName"].ToString(), dt.Rows[i]["formname"].ToString());
                }
            }
            if (dt == null)
            {
                Response.Redirect("../SessionExpired.aspx", false);
            }
        }
        catch { }
    }    

    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("LoginPage.aspx");

    }

    #endregion

    #region***************************************Methods***************************************

    private DataTable GetSubmoduleFormURLByModuleAndUserId(string ModuleName)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objHome.Get_SubmoduleFormURLByModuleAndUserId(ModuleName, HidUserId.Value);
            return dt;
        }
        catch
        {
            return dt = null;
        }
    }

    public void putInMenu(string moduleType, string header)
    {
        try
        {
            if (header == "Sales")
            {
                obj.CreateMenu(ref Pnl_sales, moduleType, header);
                AccordionPane1.Visible = true;
            }
            if (header == "Procurement")
            {
                obj.CreateMenu(ref Pnl_procuremnt, moduleType, header);
                AccordionPane3.Visible = true;
            }
            if (header == "Financial Accounting")
            {
                obj.CreateMenu(ref Pnl_Finan, moduleType, header);
                AccordionPane2.Visible = true;
            }
            if (header == "Production")
            {
                obj.CreateMenu(ref Pnl_production, moduleType, header);
                AccordionPane4.Visible = true;
            }
            if (header == "Admin")
            {
                obj.CreateMenu(ref Pnl_admin, moduleType, header);
                AccordionPane5.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }

    }

    protected Panel getpanel(string ModuleType)
    {
        if (ModuleType == "Transaction")
        {
            div_in_trans.Visible = true;
            return pnl_in_trans;
        }
        if (ModuleType == "Form Print")
        {
            div_in_formpri.Visible = true;
            return pnl_in_formpri;
        }
        if (ModuleType == "Reports")
        {
            div_in_reports.Visible = true;
            return pnl_in_reports;
        }
        if (ModuleType == "Query")
        {
            div_in_query.Visible = true;
            return pnl_in_query;
        }
        if (ModuleType == "Listing")
        {
            div_in_listing.Visible = true;
            return pnl_in_listing;
        }
        if (ModuleType == "My User Management")
        {
            div_in_myusermanagement.Visible = true;
            return pnl_in_myusermanagement;
        }
        if (ModuleType == "Master")
        {
            div_in_master.Visible = true;
            return pnl_in_master;
        }
        if (ModuleType == "Entity Configuration")
        {
            div_in_admin.Visible = true;
            return pnl_in_admin;
        }        
        return null;
    }

    #endregion
}