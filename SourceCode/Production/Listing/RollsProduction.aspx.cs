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
    BLLCollection<Common_mst> colRCommontype = new BLLCollection<Common_mst>();

    #endregion

    #region***************************************Events***************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHeader = (Label)Master.FindControl("lbl_PageHeader");
            lblPageHeader.Text = "Rolls Production List";           

            #region Bind Masters
            

            #endregion          

            #region Change Color of Readonly Fields

            txtFromDate.Attributes.Add("style", "background:lightgray");           
            txtToDate.Attributes.Add("style", "background:lightgray");
            txtMachineCode.Attributes.Add("style", "background:lightgray");
            txtShift.Attributes.Add("style", "background:lightgray");

            #endregion           
            
            txtFromDate.Attributes.Add("readonly", "true");
            txtToDate.Attributes.Add("readonly", "true");
            txtMachineCode.Attributes.Add("readonly", "true");
            txtShift.Attributes.Add("readonly", "true");
        }            
    }
    
    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master    

    #endregion

    #region Other Functions
    
    public void ClearForm()
    {
        txtFromDate.Text = "";
        txtToDate.Text = "";        
        txtMachineCode.Text = "";
        txtShift.Text = "";
    }    

    #endregion

    #endregion    
    
}