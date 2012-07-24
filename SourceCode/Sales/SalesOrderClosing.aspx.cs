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
    SalesOrder_Trans objSalesOrder_Trans = new SalesOrder_Trans();
    SalesOrderClosing objSalesOrderClosing = new SalesOrderClosing();
    BLLCollection<SalesOrder_Trans> objBllcollection = new BLLCollection<SalesOrder_Trans>();
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();    
    int FlagInsert;
    string str, SearchValueofList;
    static string MasterPageType;
    double totalWeight;
    int totalItems = 0;
    double Width, Length;

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Sales Order Closing";           

            #region Bind Masters

            BindSOTypeMaster();
            BindSearchList();

            #endregion

            #region Bind Blank Grid

            Get_SalesOrderLineItemDetailForOrderClosing(0,1,"",false);           
           
            #endregion

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch"); 
            TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
            txtSearch.Text = "";

            #region Change Color of Readonly Fields
           
            txtOrderDate.Attributes.Add("style", "background:lightgray");
            txtPIOrderNo.Attributes.Add("style", "background:lightgray");
            txtCustomerOrderNo.Attributes.Add("style", "background:lightgray");
            txtCustomerName.Attributes.Add("style", "background:lightgray");           

            #endregion            

            ImgBtnSave.Enabled = false;
            ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";

            txtOrderDate.Attributes.Add("readonly", "true");
            txtPIOrderNo.Attributes.Add("readonly", "true");
            txtCustomerOrderNo.Attributes.Add("readonly", "true");
            txtCustomerName.Attributes.Add("readonly", "true");           
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
        DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
        TextBox txtSearch = (TextBox)Master.FindControl("txtSearch");
        txtSearchList.Text = "";

        if (ddlSearch.SelectedValue != "0")
        {
            if (ddlSearch.SelectedValue.ToString() == "ClosedPI")
            {
                BindAllClosedOrderGrid("1", txtSearch.Text.Trim());
                lSearchList.Text = "Search By Proforma Invoice No.: ";
            }
            else if (ddlSearch.SelectedValue.ToString() == "ClosedSO")
            {
                BindAllClosedOrderGrid("2", txtSearch.Text.Trim());
                lSearchList.Text = "Search By Sales Order No.: ";
            }            
            
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
        if (ddlSearch.SelectedValue.ToString() == "ClosedPI")
        {
            BindAllClosedOrderGrid("1", txtSearchList.Text.Trim());
        }
        else if (ddlSearch.SelectedValue.ToString() == "ClosedSO")
        {
            BindAllClosedOrderGrid("2", txtSearchList.Text.Trim());
        }

        
        txtSearchList.Focus();
        ModalPopupExtender1.Show();
    }

    protected void ddlSearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtPISONo.Text = "";
            txtOrderDate.Text = "";
            txtPIOrderNo.Text = "";
            chkConfirmed.Checked = false;
            txtCustomerOrderNo.Text = "";
            txtCustomerName.Text = "";
            txtReason.Text = "";
            gvOrderLineDetails.DataSource = "";
            gvOrderLineDetails.DataBind();

            if (ddlSearchType.SelectedValue == "1")
            {
                LPISONo.Text = "Proforma Invoice No.";
                lPIOrderNo.Text = "Sales Order No.";
            }
            else if (ddlSearchType.SelectedValue == "2")
            {
                LPISONo.Text = "Sales Order No.";
                lPIOrderNo.Text = "Proforma Invoice No.";
            }
        }
        catch { }
    }

    protected void imgbtnSearchInForm_Click(object sender, ImageClickEventArgs e)
    {
        Get_SalesOrderLineItemDetailForOrderClosing(Convert.ToInt32(ddlOrderType.SelectedValue.ToString()),
                Convert.ToInt32(ddlSearchType.SelectedValue.ToString()), txtPISONo.Text.Trim(),true);

        DataTable dt = (DataTable)ViewState["SalesOrderClosing"];
        if (dt.Rows.Count == 0)
        {
            lblInfo.Text = objcommonmessage.SalesOrderClosed;
            ImgBtnSave.Enabled = false;
            ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
        }
        else
        {
            lblInfo.Text = "";
            ImgBtnSave.Enabled = true;
            ImgBtnSave.ImageUrl = "../Images/btnSave.png";
        }
    }

    protected void gvOrderLineDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[0].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
                e.Row.Cells[12].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvClosedOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[2].Style.Add("display", "none");
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[10].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
            }
        }
        catch { }
    }

    protected void gvClosedOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView gvClosedOrder = (GridView)sender;
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            gvClosedOrder.SelectedIndex = row.RowIndex;

            if (e.CommandName == "select")
            {
                foreach (GridViewRow oldrow in gvClosedOrder.Rows)
                {
                    ImageButton imgbutton = (ImageButton)oldrow.FindControl("ImageButton1");
                    imgbutton.ImageUrl = "~/Images/chkbxuncheck.png";
                }
                ImageButton img = (ImageButton)row.FindControl("ImageButton1");
                img.ImageUrl = "~/Images/chkbxcheck.png";

                ddlOrderType.SelectedValue = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[1].Text;
                ddlSearchType.SelectedValue = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[2].Text;
                txtPISONo.Text = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[3].Text;
                txtOrderDate.Text = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[4].Text;
                txtPIOrderNo.Text = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[8].Text;
                if (gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[9].Text == "True")
                {
                    chkConfirmed.Checked = true;
                }
                else
                {
                    chkConfirmed.Checked = false;
                }
                txtCustomerOrderNo.Text = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[5].Text;
                txtReason.Text = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[10].Text;
                txtCustomerName.Text = gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[7].Text;                

                Get_SalesOrderLineItemDetailForOrderClosing(Convert.ToInt32(gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[1].Text),
                Convert.ToInt32(gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[2].Text), gvClosedOrder.Rows[gvClosedOrder.SelectedIndex].Cells[3].Text,false);

                DataTable dt = (DataTable)ViewState["SalesOrderClosing"];
                lblInfo.Text = objcommonmessage.SalesOrderClosed;
                ImgBtnSave.Enabled = false;
                ImgBtnSave.ImageUrl = "../Images/btnSaveGrey.png";
            }
        }
        catch { }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["SalesOrderClosing"];
            bool CheckRollsAvailable = CheckAllocatedRollsToOrderNo(Convert.ToInt32 (HidPISOId.Value));
            if (CheckRollsAvailable == false)
            {
                try
                {
                    objSalesOrderClosing.OrderTypeId = Convert.ToInt32(ddlOrderType.SelectedValue);
                    objSalesOrderClosing.SearchTypeId = Convert.ToInt32(ddlSearchType.SelectedValue);
                    objSalesOrderClosing.PISONo = txtPISONo.Text.Trim();
                    objSalesOrderClosing.OrderDate = DateTime.ParseExact(txtOrderDate.Text.Trim(), objCommon_mst.DateFormat, System.Globalization.CultureInfo.InvariantCulture).ToString();
                    objSalesOrderClosing.PIOrderNo = txtPIOrderNo.Text.Trim();
                    if (chkConfirmed.Checked == true)
                    {
                        objSalesOrderClosing.Confirmed = true;
                    }
                    else
                    {
                        objSalesOrderClosing.Confirmed = false;
                    }
                    objSalesOrderClosing.CustomerOrderNo = txtCustomerOrderNo.Text.Trim();
                    objSalesOrderClosing.CustomerId = Convert.ToInt32(HidCustomerId.Value);
                    objSalesOrderClosing.Reason = txtReason.Text.Trim();
                    objSalesOrderClosing.ActiveStatus = Convert.ToBoolean(1);
                    objSalesOrderClosing.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                    objSalesOrderClosing.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                    FlagInsert = objSalesOrderClosing.InsertInSalesOrderClosing();
                    if (FlagInsert == -1)
                    {
                        ClearForm();
                        MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordSaved, 125, 300);
                    }
                }
                catch
                {
                    MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RecordNotSaved, 125, 300);
                    return;
                }                
            }
            else
            {
                MyMessageBoxInfo.Show(MyMessageBox.MessageType.Info, objcommonmessage.RollsAllocated, 125, 300);
            }
        }
        catch { }
    }

    #endregion

    #region***************************************Functions***************************************
       

    protected void BindSearchList()
    {
        try
        {
            DataTable dt = new DataTable();
            string FormIdSalesOrderClosing = ConfigurationManager.AppSettings["FormIdSalesOrderClosing"].ToString();

            DropDownList ddlSearch = (DropDownList)Master.FindControl("ddlSearch");
            dt = objCommon_mst.Get_SearchCriteria(FormIdSalesOrderClosing);

            ddlSearch.DataTextField = "Options";
            ddlSearch.DataValueField = "Value";
            ddlSearch.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ddlSearch.DataBind();                
            }
            ddlSearch.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch { }
    }

    protected void BindSOTypeMaster()
    {
        try
        {
            colRCommontype = objCommon_mst.Get_AllPIType();
            ddlOrderType.DataTextField = "PerfInvTypeName";
            ddlOrderType.DataValueField = "PerfInvTypeID";
            ddlOrderType.DataSource = colRCommontype;
            ddlOrderType.DataBind();
            ddlOrderType.Items.Insert(0, new ListItem("-Select-", ""));
        }
        catch (Exception ex) { }        
    }
    
    public void ClearForm()
    {
        ddlOrderType.SelectedValue = "";
        ddlSearchType.SelectedValue = "";
        txtPISONo.Text = "";
        txtOrderDate.Text = "";
        txtPIOrderNo.Text = "";
        chkConfirmed.Checked = false;
        txtCustomerOrderNo.Text = "";
        txtCustomerName.Text = "";
        txtReason.Text = "";
        gvOrderLineDetails.DataSource = "";
        gvOrderLineDetails.DataBind();
        ViewState["SalesOrderClosing"] = null;
    }

    private void Get_SalesOrderLineItemDetailForOrderClosing(int OrderType, int SearchType, string PISONo, bool ActiveStatus)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSalesOrderClosing.Get_SalesOrderLineItemDetailForOrderClosing(OrderType, SearchType, PISONo, ActiveStatus);
            ViewState["SalesOrderClosing"] = dt;
            gvOrderLineDetails.DataSource = dt;           
            gvOrderLineDetails.DataBind();
            
            FillHeaderDetails(dt);
        }
        catch (Exception ex) { }
    }

    public void FillHeaderDetails(DataTable dt)
    {
        try
        {
            if (dt.Rows.Count > 0)
            {
                txtOrderDate.Text = dt.Rows[0]["OrderDate"].ToString();
                txtPIOrderNo.Text = dt.Rows[0]["PINo"].ToString();
                if (dt.Rows[0]["Confirmed"].ToString() == "True")
                {
                    chkConfirmed.Checked = true;
                }
                else
                {
                    chkConfirmed.Checked = false;
                }
                txtCustomerOrderNo.Text = dt.Rows[0]["CustomerOrderNo"].ToString();
                HidCustomerId.Value = dt.Rows[0]["Customer"].ToString();
                txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                HidPISOId.Value = dt.Rows[0]["PISOId"].ToString();
            }            
        }
        catch { }
    }

    private bool CheckAllocatedRollsToOrderNo(int OrderNo)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSalesOrderClosing.CheckAllocatedRollsToOrderNo(OrderNo);
            if (dt.Rows.Count > 0)
            {
                return true;
            }          
        }
        catch (Exception ex) {
            return false;
        }
        return false;
    }

    private void BindAllClosedOrderGrid(string ddlSearchValue, string txtSearchValue)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objSalesOrderClosing.Get_AllClosedPIAndSO(ddlSearchValue, txtSearchValue);
            if (dt.Rows.Count > 0)
            {
                gvClosedOrder.DataSource = dt;
                gvClosedOrder.AllowPaging = true;
                gvClosedOrder.DataBind();
                lblTotalRecords.Text = objcommonmessage.TotalRecord + dt.Rows.Count.ToString();
            }
            else
            {
                lblTotalRecords.Text = objcommonmessage.NoRecordFound;
                gvClosedOrder.AllowPaging = false;
                gvClosedOrder.DataSource = "";
                gvClosedOrder.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblTotalRecords.Text = objcommonmessage.NoRecordFound + ex.Message;
            gvClosedOrder.AllowPaging = false;
            gvClosedOrder.DataSource = "";
            gvClosedOrder.DataBind();
        }
    }

    #endregion

    
}