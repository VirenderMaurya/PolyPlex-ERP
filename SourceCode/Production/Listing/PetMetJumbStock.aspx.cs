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
            lblPageHeader.Text = "PET/MET Jumbo Stock List";           

            #region Bind Masters
            

            #endregion          
                      
            txtDate.Attributes.Add("style", "background:lightgray");  
            txtDate.Attributes.Add("readonly", "true");            
        }            
    }
    
    #endregion

    #region***************************************Functions***************************************

    # region Function to Fill Master    

    #endregion

    #region Other Functions
    
    public void ClearForm()
    {
        txtDate.Text = "";        
        HidJumboId.Value = "";             
    }    

    #endregion

    #endregion    
    
}