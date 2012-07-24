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
    PackingListCreation objPackingListCreation = new PackingListCreation();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();

    string OrderNo, PalletType, SearchValueofList,FlagInsertUpdate;
    static string MasterPageType;
    int SalesOrderId;    
    bool CheckValue,CheckGridValue;
    bool CheckPackCreation, CheckRollsAval;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblInfo.Text = "";
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Packing List";

            #region Bind Masters

            BindSearchList();

            #endregion            

            #region Get PackingCreation Structure

            Get_PackingCreation_Structure();

            #endregion

            #region Blank Grid

            gvSOLineItems.DataSource = "";
            gvSOLineItems.DataBind();
            GVRollsAvailable.DataSource = "";
            GVRollsAvailable.DataBind();
            GVConsolidatedPallet.DataSource = "";
            GVConsolidatedPallet.DataBind();

            #endregion

            txtInvoiceNo.Attributes.Add("readonly", "true");
            txtSalesOrderNo.Attributes.Add("readonly", "true");
            txtCustomerCode.Attributes.Add("readonly", "true");
            txtSearch.Attributes.Add("readonly", "true");
            ImgBtnSaveRolls.Enabled = false;
            ImgBtnSaveRolls.ImageUrl = "../Images/btnSaveRollsGrey.png";
            ImgBtnSave.Enabled = false;
            ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";

            #region Change Color of Readonly Fields

            txtSearch.Attributes.Add("style", "background:lightgray");            
            txtInvoiceNo.Attributes.Add("style", "background:lightgray");
            txtSalesOrderNo.Attributes.Add("style", "background:lightgray");
            txtCustomerCode.Attributes.Add("style", "background:lightgray");
            //txtCustomerName.Attributes.Add("style", "background:lightgray");

            #endregion           
            
            ImgBtnSaveRolls.Attributes.Add("onclick", "return TestCheckBox();");
            ImgBtnCancelRolls.Attributes.Add("onclick", "return ResetCheckBox();");            
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
        ClearForm();
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        ddlSearch.SelectedValue = "0";
        txtSearch.Text = "";
    }

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchValueofList = "";
        MasterPageType = "Master";
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");        

        if (ddlSearch.SelectedValue != "0")
        {           
            if (txtSearch.Text.Trim() != "")
            {
                txtSearchFromPopup.Text = "";
                SearchValueofList = txtSearch.Text.Trim();
            }
            else if (txtSearchFromPopup.Text.Trim() != "")
            {
                txtSearch.Text = "";
                SearchValueofList = txtSearchFromPopup.Text.Trim();
            }
            lPopUpHeader.Text = ddlSearch.SelectedItem.ToString();
            lSearch.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            BindPopUpData(ddlSearch.SelectedValue.ToString(), SearchValueofList);
            txtSearch.Focus();
            ModalPopupExtender1.Show();            
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        MasterPageType = "Page";
        txtSearchFromPopup.Text = "";

        if (ddlSearch.SelectedValue != "0")
        {
            BindPopUpData(ddlSearch.SelectedValue.ToString(), "");
            lPopUpHeader.Text = ddlSearch.SelectedItem.ToString();
            lSearch.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
            ModalPopupExtender1.Show();
        }
        else
        {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.SelectValue, 125, 300);
        }
    }    

    protected void btnSearchInPopUp_Click(object sender, EventArgs e)
    {        
        string DDLValue = "";
        if (MasterPageType == "Master")
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DDLValue = ddlSearch.SelectedValue.ToString();
        }
        else if (MasterPageType == "Page")
        {
            DDLValue = this.ddlSearch.SelectedValue.ToString();
        }
        BindPopUpData(DDLValue, txtSearchFromPopup.Text.Trim());
        txtSearchFromPopup.Focus();
        ModalPopupExtender1.Show();
        
    }    

    protected void GVRollsAvailable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            for (int i = 0; i < GVRollsAvailable.Columns.Count; i++)
            {                
                e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
            }

            e.Row.Cells[10].Style.Add("display", "none");
            e.Row.Cells[11].Style.Add("display", "none");
            e.Row.Cells[12].Style.Add("display", "none");
            e.Row.Cells[13].Style.Add("display", "none");
            e.Row.Cells[14].Style.Add("display", "none");

            System.Web.UI.WebControls.GridView gvLineItems = (System.Web.UI.WebControls.GridView)sender;
            GridViewRow Gi;
            Gi = e.Row;
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkItem = new CheckBox();
                chkItem = (CheckBox)e.Row.FindControl("chkItem");
                chkItem.Attributes.Add("onClick", "CheckGridRecords()");                
            }
        }
        catch {}
    }

    protected void gvSOInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvSOInvoice = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvSOInvoice.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvSOInvoice.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                HidInvoiceId.Value = Convert.ToString(e.CommandArgument);
                if (ddlSearch.SelectedValue.ToString() == "Customer")
                {
                    txtSearch.Text = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[3].Text;
                }
                else if (ddlSearch.SelectedValue.ToString() == "InvoiceNo")
                {
                    txtSearch.Text = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[1].Text;
                }
                else if (ddlSearch.SelectedValue.ToString() == "OrderNo")
                {
                    txtSearch.Text = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[2].Text;
                }

                HidSalesOrderId.Value = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[4].Text;
                HidCustomerId.Value = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[5].Text;

                txtSalesOrderNo.Text = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[2].Text;
                txtInvoiceNo.Text = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[1].Text;
                txtCustomerCode.Text = gvSOInvoice.Rows[gvSOInvoice.SelectedIndex].Cells[3].Text;

                BindSOLineItemGrid(Convert.ToInt32(HidSalesOrderId.Value));
                BindRollsAvailableForSOInGrid(Convert.ToInt32(HidSalesOrderId.Value));
                Get_PackingCreation_Tran_For_OrderNo(Convert.ToInt32(HidSalesOrderId.Value));

                if (CheckRollsAval == true && CheckPackCreation == true)
                {
                    lblInfo.Text = objcommonmessage.PackingCreated;
                }
                else
                {
                    lblInfo.Text = "";
                }               
            }
        }
        catch { }
    }

    protected void GVConsolidatedPallet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[5].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvSOInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                for (int i = 0; i < gvSOInvoice.Columns.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("Id", "R" + e.Row.RowIndex.ToString() + "C" + i.ToString());
                }
            }
            catch { }

            e.Row.Cells[4].Style.Add("display", "none");
            e.Row.Cells[5].Style.Add("display", "none");
        }
        catch { }
    }

    protected void gvSOInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string DDLValue = "";
        SearchValueofList = "";
        gvSOInvoice.PageIndex = e.NewPageIndex;
        if (MasterPageType == "Master")
        {
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            DDLValue = ddlSearch.SelectedValue.ToString();
            lSearch.Text = "Search By " + ddlSearch.SelectedItem.ToString() + ": ";
        }
        else if (MasterPageType == "Page")
        {
            DDLValue = this.ddlSearch.SelectedValue.ToString();
            lSearch.Text = "Search By " + this.ddlSearch.SelectedItem.ToString() + ": ";
        }

        if (DDLValue != "0")
        {
            if (txtSearch.Text.Trim() != "")
            {
                txtSearchFromPopup.Text = "";
                SearchValueofList = txtSearch.Text.Trim();
            }
            else if (txtSearchFromPopup.Text.Trim() != "")
            {
                txtSearch.Text = "";
                SearchValueofList = txtSearchFromPopup.Text.Trim();
            }
            BindPopUpData(DDLValue, SearchValueofList);
            txtSearch.Focus();
            ModalPopupExtender1.Show();
        }
    }

    protected void GVConsolidatedPallet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            BindRollsAvailableForSOInGrid(Convert.ToString(e.CommandArgument));
            HidPalletNo.Value = Convert.ToString(e.CommandArgument);
            lAllotedLI.Text = "Alloted Line Items.";
            ModalPopupExtender2.Show();
        }
        catch { }
    }

    protected void gvAllotedLineItemsForPacking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAllotedLineItemsForPacking.PageIndex = e.NewPageIndex;
        BindRollsAvailableForSOInGrid(HidPalletNo.Value);
        ModalPopupExtender2.Show();
    }

    protected void ImgBtnSaveRolls_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable DtRollsAvailableForSOInGrid = (DataTable)ViewState["DtRollsAvailableForSOInGrid"];
            DataTable DtRollsAvailableForSOInGridForCheckCol = (DataTable)ViewState["DtRollsAvailableForSOInGridForCheckCol"];

            DataTable DtPackingCreation = (DataTable)ViewState["DtPackingCreation"];
            DataRow objdrPackingCreation;
            objdrPackingCreation = DtPackingCreation.NewRow();

            int PalletNo = RandomNumber(100000000, 999999999);

            for (int i = 0; i < GVRollsAvailable.Rows.Count; i++)
            {
                CheckBox checkbox = (CheckBox)GVRollsAvailable.Rows[i].Cells[0].FindControl("chkItem");
                if (checkbox.Checked == true)
                {
                    OrderNo = GVRollsAvailable.Rows[i].Cells[1].Text;
                    SalesOrderId = Convert.ToInt32(GVRollsAvailable.Rows[i].Cells[11].Text);
                    ViewState["NoOfItems"] = Convert.ToInt32(ViewState["NoOfItems"]) + 1;
                    ViewState["GrossWeight"] = Convert.ToDouble(ViewState["GrossWeight"]) + Convert.ToDouble(GVRollsAvailable.Rows[i].Cells[9].Text);
                    PalletType = GVRollsAvailable.Rows[i].Cells[4].Text;

                    DataRow objdrRollsAvailableForSOInGrid;
                    objdrRollsAvailableForSOInGrid = DtRollsAvailableForSOInGridForCheckCol.NewRow();

                    objdrRollsAvailableForSOInGrid["SalesOrder"] = GVRollsAvailable.Rows[i].Cells[1].Text;
                    objdrRollsAvailableForSOInGrid["InvoiceNo"] = GVRollsAvailable.Rows[i].Cells[2].Text;
                    objdrRollsAvailableForSOInGrid["RollNo"] = GVRollsAvailable.Rows[i].Cells[3].Text;
                    objdrRollsAvailableForSOInGrid["SubFilmTypeId"] = GVRollsAvailable.Rows[i].Cells[13].Text;
                    objdrRollsAvailableForSOInGrid["Micron"] = GVRollsAvailable.Rows[i].Cells[5].Text;
                    objdrRollsAvailableForSOInGrid["Core"] = GVRollsAvailable.Rows[i].Cells[6].Text;
                    objdrRollsAvailableForSOInGrid["Width"] = GVRollsAvailable.Rows[i].Cells[7].Text;
                    objdrRollsAvailableForSOInGrid["Length"] = GVRollsAvailable.Rows[i].Cells[8].Text;
                    objdrRollsAvailableForSOInGrid["Weight"] = GVRollsAvailable.Rows[i].Cells[9].Text;
                    objdrRollsAvailableForSOInGrid["InventoryId"] = GVRollsAvailable.Rows[i].Cells[10].Text;
                    objdrRollsAvailableForSOInGrid["SalesOrderId"] = GVRollsAvailable.Rows[i].Cells[11].Text;
                    objdrRollsAvailableForSOInGrid["Invoiceid"] = GVRollsAvailable.Rows[i].Cells[12].Text;
                    objdrRollsAvailableForSOInGrid["PalletNo"] = Convert.ToString(PalletNo);

                    DtRollsAvailableForSOInGridForCheckCol.Rows.Add(objdrRollsAvailableForSOInGrid);
                    DtRollsAvailableForSOInGridForCheckCol.AcceptChanges();
                    CheckValue = true;

                    if (DtRollsAvailableForSOInGrid.Rows.Count > 0)
                    {
                        DtRollsAvailableForSOInGrid = RemoveRow(GVRollsAvailable.Rows[i], DtRollsAvailableForSOInGrid);
                    }
                }
                else
                {
                    DataRow objdrRollsAvailableForSOInGrid;
                    objdrRollsAvailableForSOInGrid = DtRollsAvailableForSOInGrid.NewRow();

                    if (DtRollsAvailableForSOInGrid.Rows.Count == 0 || DtRollsAvailableForSOInGrid.Rows.Count > 0)
                    {
                        for (int j = 0; j < DtRollsAvailableForSOInGrid.Rows.Count; j++)
                        {
                            if (GVRollsAvailable.Rows[i].Cells[10].Text == DtRollsAvailableForSOInGrid.Rows[j]["InventoryId"].ToString())
                            {
                                CheckGridValue = true;
                                break;
                            }
                        }
                        if (CheckGridValue == false)
                        {
                            objdrRollsAvailableForSOInGrid["SalesOrder"] = GVRollsAvailable.Rows[i].Cells[1].Text;
                            objdrRollsAvailableForSOInGrid["InvoiceNo"] = GVRollsAvailable.Rows[i].Cells[2].Text;
                            objdrRollsAvailableForSOInGrid["RollNo"] = GVRollsAvailable.Rows[i].Cells[3].Text;
                            objdrRollsAvailableForSOInGrid["Type"] = GVRollsAvailable.Rows[i].Cells[4].Text;
                            objdrRollsAvailableForSOInGrid["Micron"] = GVRollsAvailable.Rows[i].Cells[5].Text;
                            objdrRollsAvailableForSOInGrid["Core"] = GVRollsAvailable.Rows[i].Cells[6].Text;
                            objdrRollsAvailableForSOInGrid["Width"] = GVRollsAvailable.Rows[i].Cells[7].Text;
                            objdrRollsAvailableForSOInGrid["Length"] = GVRollsAvailable.Rows[i].Cells[8].Text;
                            objdrRollsAvailableForSOInGrid["Weight"] = GVRollsAvailable.Rows[i].Cells[9].Text;
                            objdrRollsAvailableForSOInGrid["InventoryId"] = GVRollsAvailable.Rows[i].Cells[10].Text;
                            objdrRollsAvailableForSOInGrid["SalesOrderId"] = GVRollsAvailable.Rows[i].Cells[11].Text;
                            objdrRollsAvailableForSOInGrid["Invoiceid"] = GVRollsAvailable.Rows[i].Cells[12].Text;
                            objdrRollsAvailableForSOInGrid["PalletNo"] = "";

                            DtRollsAvailableForSOInGrid.Rows.Add(objdrRollsAvailableForSOInGrid);
                            DtRollsAvailableForSOInGrid.AcceptChanges();

                        }
                    }
                }
            }

            ViewState["DtRollsAvailableForSOInGrid"] = DtRollsAvailableForSOInGrid;
            ViewState["DtRollsAvailableForSOInGridForCheckCol"] = DtRollsAvailableForSOInGridForCheckCol;

            if (CheckValue == true)
            {
                if (DtPackingCreation.Rows.Count == 0)
                {
                    objdrPackingCreation["PalletNo"] = PalletNo;
                    objdrPackingCreation["SalesOrderId"] = SalesOrderId;
                    objdrPackingCreation["SalesOrder"] = OrderNo;
                    objdrPackingCreation["NoOfItems"] = ViewState["NoOfItems"].ToString();
                    objdrPackingCreation["GrossWeight"] = ViewState["GrossWeight"].ToString();
                    objdrPackingCreation["PalletType"] = PalletType;
                    DtPackingCreation.Rows.Add(objdrPackingCreation);
                }
                else if (ViewState["DtPackingCreation"] != null)
                {
                    DtPackingCreation = (DataTable)ViewState["DtPackingCreation"];
                    objdrPackingCreation["PalletNo"] = PalletNo;
                    objdrPackingCreation["SalesOrderId"] = SalesOrderId;
                    objdrPackingCreation["SalesOrder"] = OrderNo;
                    objdrPackingCreation["NoOfItems"] = ViewState["NoOfItems"].ToString();
                    objdrPackingCreation["GrossWeight"] = ViewState["GrossWeight"].ToString();
                    objdrPackingCreation["PalletType"] = PalletType;
                    DtPackingCreation.Rows.Add(objdrPackingCreation);
                }
                ViewState["DtPackingCreation"] = DtPackingCreation;
                GVConsolidatedPallet.DataSource = DtPackingCreation;
                GVConsolidatedPallet.DataBind();

                ViewState["NoOfItems"] = null;
                ViewState["GrossWeight"] = null;
            }

            if (DtRollsAvailableForSOInGrid.Rows.Count > 0)
            {
                ImgBtnSaveRolls.Enabled = true;
                ImgBtnSaveRolls.ImageUrl = "../Images/btn_saveRolls.png";
                GVRollsAvailable.DataSource = DtRollsAvailableForSOInGrid;
                GVRollsAvailable.DataBind();
            }
            else
            {
                ImgBtnSaveRolls.Enabled = false;
                ImgBtnSaveRolls.ImageUrl = "../Images/btnSaveRollsGrey.png";
                GVRollsAvailable.DataSource = "";
                GVRollsAvailable.DataBind();
            }

        }
        catch { }
    }   

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable DtPackingCreation = (DataTable)ViewState["DtPackingCreation"];
            if (DtPackingCreation.Rows.Count > 0)
            {
                #region Insert in Role Allocation Deallocation for Packing Creation

                objPackingListCreation.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objPackingListCreation.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString()); 

                objPackingListCreation.dtLineItems = new DataTable();
                objPackingListCreation.dtLineItems = objPackingListCreation.Get_PackingCreationGridStructure();
                DataRow objdrDetailsLineItems;

                objPackingListCreation.dtToUpdateRADForPacking = new DataTable();
                objPackingListCreation.dtToUpdateRADForPacking = objPackingListCreation.Get_InventoryIdStructure();
                DataRow objdrUpdateRADForPacking;
                
                foreach (DataRow objdrPackingCreation in DtPackingCreation.Rows)
                {
                    if (objdrPackingCreation["CreatedBy"].ToString() == "")
                    {
                        try
                        {
                            objdrDetailsLineItems = objPackingListCreation.dtLineItems.NewRow();
                            objdrDetailsLineItems["PackingCreationID"] = 0;
                            objdrDetailsLineItems["PalletNo"] = objdrPackingCreation["PalletNo"].ToString();
                            objdrDetailsLineItems["SalesOrderId"] = Convert.ToInt32(objdrPackingCreation["SalesOrderId"]);
                            objdrDetailsLineItems["NoOfItems"] = Convert.ToInt32(objdrPackingCreation["NoOfItems"]);
                            objdrDetailsLineItems["GrossWeight"] = Convert.ToDouble(objdrPackingCreation["GrossWeight"]);
                            objdrDetailsLineItems["ActiveStatus"] = Convert.ToBoolean(1);
                            objPackingListCreation.dtLineItems.Rows.Add(objdrDetailsLineItems);
                            objPackingListCreation.dtLineItems.AcceptChanges();
                        }
                        catch
                        {
                            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                            return;
                        }
                    }
                }
                #region Update in Role Allocation Deallocation for Packing Creation

                DataTable dtRoleAllocation = (DataTable)ViewState["DtRollsAvailableForSOInGridForCheckCol"];
                if (dtRoleAllocation.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow objdrRoleAllocation in dtRoleAllocation.Rows)
                        {
                            objdrUpdateRADForPacking = objPackingListCreation.dtToUpdateRADForPacking.NewRow();
                            objdrUpdateRADForPacking["InventoryId"] = objdrRoleAllocation["InventoryId"].ToString();
                            objdrUpdateRADForPacking["PalletNo"] = objdrRoleAllocation["PalletNo"].ToString();
                            objPackingListCreation.dtToUpdateRADForPacking.Rows.Add(objdrUpdateRADForPacking);
                            objPackingListCreation.dtToUpdateRADForPacking.AcceptChanges();
                        }
                    }
                    catch {
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                        return;
                    }
                }

                #endregion
                FlagInsertUpdate = objPackingListCreation.InsertUpdate_In_Sal_PackingCreation_Tran();
                if (FlagInsertUpdate == "0")
                {
                    ClearForm();
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                }
                else
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                    return;
                }
                FlagInsertUpdate = "";
                #endregion
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.FillPalletInf, 125, 300);
            }
        }
        catch {
            MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
            return;
        }
    }    

    #endregion

    #region***************************************Functions***************************************

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdPackingListCreation = ConfigurationManager.AppSettings["FormIdPackingListCreation"].ToString();
            
            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdPackingListCreation);

            ddlSearch.DataTextField = "Options";
            this.ddlSearch.DataTextField = "Options";

            ddlSearch.DataValueField = "Value";
            this.ddlSearch.DataValueField = "Value";

            ddlSearch.DataSource = dt;
            this.ddlSearch.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();
                ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
                this.ddlSearch.DataBind();
                this.ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
            }            
        }
        catch (Exception ex) { }
    }

    private void BindSOLineItemGrid(int SalesOrderId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objPackingListCreation.Get_SODeatilsBySOId(SalesOrderId);
            if (dt.Rows.Count > 0)
            {
                gvSOLineItems.DataSource = dt;
                gvSOLineItems.DataBind();
            }
            else
            {                
                gvSOLineItems.DataSource = "";
                gvSOLineItems.DataBind();
            }
        }
        catch { }
    }

    private void BindRollsAvailableForSOInGrid(int SalesOrderId)
    {
        try
        {
            DataTable DtRollsAvailableForSOInGrid = new DataTable();

            DtRollsAvailableForSOInGrid = objPackingListCreation.Get_RollsAvailableForSOInGrid(SalesOrderId);
            if (DtRollsAvailableForSOInGrid.Rows.Count > 0)
            {
                GVRollsAvailable.DataSource = DtRollsAvailableForSOInGrid;
                GVRollsAvailable.DataBind();
                CheckRollsAval = false;
                ImgBtnSaveRolls.Enabled = true;
                ImgBtnSaveRolls.ImageUrl = "../Images/btn_saveRolls.png";
                ImgBtnSave.Enabled = true;
                ImgBtnSave.ImageUrl = "../Images/btnSave.png";
            }
            else
            {
                GVRollsAvailable.DataSource = "";
                GVRollsAvailable.DataBind();
                ImgBtnSaveRolls.Enabled = false;
                ImgBtnSaveRolls.ImageUrl = "../Images/btnSaveRollsGrey.png";
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
                CheckRollsAval = true;
            }
            DtRollsAvailableForSOInGrid.Clear();
            ViewState["DtRollsAvailableForSOInGrid"] = DtRollsAvailableForSOInGrid;
            ViewState["DtRollsAvailableForSOInGridForCheckCol"] = DtRollsAvailableForSOInGrid;
        }
        catch { }
    }

    private void BindRollsAvailableForSOInGrid(string PalletNo)
    {
        try
        {
            DataTable dt = new DataTable();

            dt = objPackingListCreation.Get_AllotedLineItemsForPacking(PalletNo);
            if (dt.Rows.Count > 0)
            {
                gvAllotedLineItemsForPacking.DataSource = dt;
                lAllotedNoCount.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
                gvAllotedLineItemsForPacking.DataBind();                
            }
            dt = null;
        }
        catch { }
    }

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    protected void Get_PackingCreation_Structure()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objPackingListCreation.Get_PackingCreation_Tran_For_OrderId(0);
            ViewState["DtPackingCreation"] = dt;
        }
        catch{ }
    }

    protected void Get_PackingCreation_Tran_For_OrderNo(int SalesOrderId)
    {
        try
        {
            DataTable DtPackingCreation = new DataTable();
            DtPackingCreation = objPackingListCreation.Get_PackingCreation_Tran_For_OrderId(SalesOrderId);
            ViewState["DtPackingCreation"] = DtPackingCreation;

            GVConsolidatedPallet.DataSource = DtPackingCreation;
            GVConsolidatedPallet.DataBind();
            if (DtPackingCreation.Rows.Count > 0)
            {
                CheckPackCreation = true;
            }
            else
            {
                CheckPackCreation = false;
            }
        }
        catch { }
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("InventoryId = '" + gvRow.Cells[10].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }

    private void BindPopUpData(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objPackingListCreation.Get_GetSalesOrderByInvoiceId(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvSOInvoice.DataSource = dt;
                gvSOInvoice.AllowPaging = true;
                gvSOInvoice.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvSOInvoice.AllowPaging = false;
                gvSOInvoice.DataSource = "";
                gvSOInvoice.DataBind();
                
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
        }


    }

    private void ClearForm()
    {
        try
        {
            gvSOLineItems.DataSource = "";
            gvSOLineItems.DataBind();

            GVRollsAvailable.DataSource = "";
            GVRollsAvailable.DataBind();

            GVConsolidatedPallet.DataSource = "";
            GVConsolidatedPallet.DataBind();           

            HidCheckValue.Value = "";
            ddlSearch.SelectedValue = "0";
            txtSearch.Text = "";
            txtInvoiceNo.Text = "";
            txtSalesOrderNo.Text = "";
            txtCustomerCode.Text = "";
            HidSalesOrderId.Value = "";

            ViewState["DtRollsAvailableForSOInGrid"] = null;
            ViewState["DtRollsAvailableForSOInGridForCheckCol"] = null;
            ViewState["DtPackingCreation"] = null;
            Get_PackingCreation_Structure();
        }
        catch { }
    }

    #endregion    

    
}