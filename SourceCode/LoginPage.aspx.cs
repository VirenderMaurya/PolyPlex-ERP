using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LoginPage : System.Web.UI.Page
{
    
    #region***************************************Variables***************************************
        
    Login_mst objLogin_mst = new Login_mst();
    Common_mst objCommon_mst = new Common_mst();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            form1.DefaultButton = BtnLogin.ClientID;
            txtLoginID.Focus();
            lbl_msg.Text = "";
            if (Request.QueryString.HasKeys())
            {
                if (Request.QueryString["Msg"] != null)
                {
                    lbl_msg.Text = "Session expired. Please login again.";
                }
                else
                {
                    lbl_msg.Text = "";
                }
            }
            BtnOpen.Attributes.Add("style", "display:none");            
            BtnOpen_Click(sender, e);
            getEnvironment();
            getLocation();
            txtLoginID.Attributes.Add("onblur ", "RefreshPage()");      
        }
        else
        {            
            getUserLocation();
            txtPassword.Focus();
            ModelPopupExtShow.Show();                       
        }        
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        if (txtLoginID.Text.Trim() != "")
        {
            if (txtPassword.Text.Trim() != "")
            {

                DataTable dt = new DataTable();
                dt = objLogin_mst.Get_LoginCredentials(txtLoginID.Text.Trim(), txtPassword.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                    Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                    Session["Environment"] = ddlEnvironment.SelectedItem.ToString();
                    Session["Location"] = ddlLocation.SelectedValue.ToString();
                    Session["LocationName"] = ddlLocation.SelectedItem.ToString();
                    Response.Redirect("HomePage.aspx", false);
                }
                else
                {
                    lbl_msg.Text = "Either LoginId or password is wrong.";
                    txtPassword.ReadOnly = false;
                    ModelPopupExtShow.Show();
                }                
            }
            else
            {
                lbl_msg.Text = "Enter the password.";
                txtPassword.ReadOnly = false;
                txtPassword.Focus();
                ModelPopupExtShow.Show();
            }
        }
        else
        {
            lbl_msg.Text = "Enter the login id.";
            txtLoginID.Focus();
            ModelPopupExtShow.Show();
        }        
    }

    protected void BtnOpen_Click(object sender, EventArgs e)
    {
        ModelPopupExtShow.Show();
        txtLoginID.Focus();
    }

    #endregion

    #region***************************************Methods***************************************

    private void getEnvironment()
    {       
        try
        {
            colRCommontype = objCommon_mst.Get_All_Environment_Master();
            ddlEnvironment.DataTextField = "environmentname";
            ddlEnvironment.DataValueField = "environmentid";
            ddlEnvironment.DataSource = colRCommontype;
            ddlEnvironment.DataBind();
            ddlEnvironment.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch { }
    }

    private void getLocation()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Location_Master();
            ddlLocation.DataTextField = "LocationName";
            ddlLocation.DataValueField = "LocationID";           
            ddlLocation.DataSource = colRCommontype;
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch { }
    }

    private void getUserLocation()
    {       

        try
        {
            DataTable dt = new DataTable();
            dt = objCommon_mst.Get_UserLocation(txtLoginID.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                ddlLocation.SelectedValue = dt.Rows[0]["LocationID"].ToString();
                txtLoginID.Focus();               
            }
            else
            {
                ddlLocation.SelectedValue = "0";
                txtLoginID.Focus();
            }
        }
        catch{ }
    }    

    protected void lnkbtnForgotPassword_Click(object sender, EventArgs e)
    {
        ModelPopupExtShow.Show();
    }

    #endregion

}