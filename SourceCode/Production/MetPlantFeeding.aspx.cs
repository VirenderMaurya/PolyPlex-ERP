using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Sales_PerformaInvoice : System.Web.UI.Page
{
    #region***************************************Variables***************************************

    Common_mst objCommon_mst = new Common_mst();
    Common_Message objcommonmessage = new Common_Message();
    Prod_MetPlantFeeding objProd_MetPlantFeeding = new Prod_MetPlantFeeding();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();    
    string FlagInsertUpdate;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Met Plant Feeding";

            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);            

            #region Bind Masters

            BindSearchList();
            Get_All_Prod_Line_Mst();

            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Intermediate Table Data

            Get_Prod_MET_Plant_Feeding_Intermediate_AllRecords();

            #endregion  

            txtDate.Attributes.Add("style", "background:lightgray"); 
            txtDate.Attributes.Add("readonly", "true");           
                              
        }

        ImageButton btnAdd = (ImageButton)Master.FindControl("btnAdd");
        btnAdd.CausesValidation = false;
        btnAdd.Click += new ImageClickEventHandler(btnAdd_Click);

        ImageButton imgbtnSearch = (ImageButton)Master.FindControl("imgbtnSearch");
        imgbtnSearch.CausesValidation = false;
        imgbtnSearch.Click += new ImageClickEventHandler(imgbtnSearch_Click);        
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        if (ddlSearch.SelectedValue != "0")
        {
            Get_Prod_MET_Plant_Feeding_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearch.Text.Trim());
            lSearchList.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void btnSearchlist_Click(object sender, EventArgs e)
    {
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        Get_Prod_MET_Plant_Feeding_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvMetallizerGridAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvMetallizerGridAll = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvMetallizerGridAll.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvMetallizerGridAll.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidMetallizerId.Value = Convert.ToString(e.CommandArgument);
                HidMetallizerIntermId.Value = "";

                #region Fill Whole Form

                Get_JumboIssueToRecycle_BothTable(Convert.ToInt32(HidMetallizerId.Value), "Main");

                #endregion
            }
        }
        catch { }
    }

    protected void gvMetallizerGridAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMetallizerGridAll.PageIndex = e.NewPageIndex;
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        Get_Prod_MET_Plant_Feeding_AllRecords(ddlSearch.SelectedValue.ToString(), txtSearchList.Text.Trim());
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void gvMetallizerGridInterm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvMetallizerGridInterm = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvMetallizerGridInterm.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvMetallizerGridInterm.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidMetallizerId.Value = "";
                HidMetallizerIntermId.Value = Convert.ToString(e.CommandArgument);

                #region Fill Whole Form From Selected Intermediate Row

                Get_JumboIssueToRecycle_BothTable(Convert.ToInt32(HidMetallizerIntermId.Value), "Intermediate");

                #endregion
            }
        }
        catch { }
    }

    protected void gvMetallizerGridInterm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvMetallizerGridInterm.PageIndex = e.NewPageIndex;
            Get_Prod_MET_Plant_Feeding_Intermediate_AllRecords();
        }
        catch { }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            #region Insert/Update Records Of MainDetailsTab

            if (HidMetallizerId.Value == "")
            {
                objProd_MetPlantFeeding.AutoID = 0;
            }
            else
            {
                objProd_MetPlantFeeding.AutoID = Convert.ToInt32(HidMetallizerId.Value);
            }
            if (HidMetallizerIntermId.Value == "")
            {
                objProd_MetPlantFeeding.IntermediateAutoID = 0;
            }
            else
            {
                objProd_MetPlantFeeding.IntermediateAutoID = Convert.ToInt32(HidMetallizerIntermId.Value);
            }
            if (txtDate.Text.Trim() != "")
            {
                objProd_MetPlantFeeding.Date = DateTime.ParseExact(txtDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                objProd_MetPlantFeeding.Date = "";
            }
            objProd_MetPlantFeeding.Line = Convert.ToInt32(ddlLine.SelectedValue);
            if (txtAluminiumWire.Text.Trim() != "")
            {
                objProd_MetPlantFeeding.Aluminimum_Wire_Consump_KG = Convert.ToDouble(txtAluminiumWire.Text.Trim());
            }
            else
            {
                objProd_MetPlantFeeding.Aluminimum_Wire_Consump_KG = 0;
            }
            if (txtBoatsConsumption.Text.Trim() != "")
            {
                objProd_MetPlantFeeding.Boats_Consump = Convert.ToInt32(txtBoatsConsumption.Text.Trim());
            }
            else
            {
                objProd_MetPlantFeeding.Boats_Consump = 0;
            }
            objProd_MetPlantFeeding.Remarks = txtRemarks.Text.Trim();
            objProd_MetPlantFeeding.ActiveStatus = true;
            objProd_MetPlantFeeding.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
            objProd_MetPlantFeeding.LastModifiedBy = Convert.ToInt32(Session["UserId"].ToString());


            #endregion

            FlagInsertUpdate = objProd_MetPlantFeeding.InsertAndUpdate_In_Prod_MET_Plant_Feeding();
            if (FlagInsertUpdate == "YES")
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);

                #region Clear All records after save
                Clear();
                #region Intermediate Table Data

                Get_Prod_MET_Plant_Feeding_Intermediate_AllRecords();

                #endregion

                DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
                ddlSearch.SelectedValue = "0";
                TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
                txtSearch.Text = "";

                #endregion
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                return;
            }
            FlagInsertUpdate = "";
        }
        catch
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
        }
    }

    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdProdMetPlantFeeding = ConfigurationManager.AppSettings["FormIdProdMetPlantFeeding"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdProdMetPlantFeeding);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
                ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
        catch { }
    }    

    protected void Get_All_Prod_Line_Mst()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_All_Prod_Line_Mst();
            ddlLine.DataTextField = "LineCode";
            ddlLine.DataValueField = "AutoId";
            ddlLine.DataSource = colRCommontype;
            ddlLine.DataBind();
            ddlLine.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch { }
    }

    private void Clear()
    {
        try
        {
            HidMetallizerId.Value = "";
            HidMetallizerIntermId.Value = "";
            txtDate.Text = DateTime.Now.ToString(objCommon_mst.DateFormat);
            ddlLine.SelectedValue = "";
            txtAluminiumWire.Text = "";
            txtBoatsConsumption.Text = "";
            txtRemarks.Text = "";
        }
        catch { }
    }

    #endregion    

    #region Function to fill Intermediate And Main List Grid

    private void Get_Prod_MET_Plant_Feeding_Intermediate_AllRecords()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_MetPlantFeeding.Get_Prod_MET_Plant_Feeding_Intermediate_AllRecords();
            if (dt.Rows.Count > 0)
            {
                gvMetallizerGridInterm.DataSource = dt;
                gvMetallizerGridInterm.AllowPaging = true;
                gvMetallizerGridInterm.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvMetallizerGridInterm.AllowPaging = false;
                gvMetallizerGridInterm.DataSource = "";
                gvMetallizerGridInterm.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    private void Get_Prod_MET_Plant_Feeding_AllRecords(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_MetPlantFeeding.Get_Prod_MET_Plant_Feeding_AllRecords(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvMetallizerGridAll.DataSource = dt;
                gvMetallizerGridAll.AllowPaging = true;
                gvMetallizerGridAll.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvMetallizerGridAll.AllowPaging = false;
                gvMetallizerGridAll.DataSource = "";
                gvMetallizerGridAll.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }
    }

    #endregion

    protected void Get_JumboIssueToRecycle_BothTable(int AutoId, string SearchType)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objProd_MetPlantFeeding.Get_Prod_MET_Plant_Feeding_BothTable(AutoId, SearchType);
            if (dt.Rows.Count > 0)
            {
                if (SearchType == "Main")
                {
                    HidMetallizerId.Value = dt.Rows[0]["AutoId"].ToString();
                }
                else if (SearchType == "Intermediate")
                {
                    HidMetallizerId.Value = "";
                }
                txtDate.Text = dt.Rows[0]["Date"].ToString();
                ddlLine.SelectedValue = dt.Rows[0]["Line"].ToString();
                txtAluminiumWire.Text = dt.Rows[0]["Aluminimum_Wire_Consump_KG"].ToString();
                txtBoatsConsumption.Text = dt.Rows[0]["Boats_Consump"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            }
        }
        catch (Exception ex) { }
    }

    #endregion




    

    
    

    
}