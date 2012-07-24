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
            lblPageHeader.Text = "Entity Configuration";

            lnkBtnCustomerType.Attributes.Add("onclick", "return openpopup('Sales/CustomerTypeMaster.aspx');");
            lnkBtnFilmType.Attributes.Add("onclick", "return openpopup('Sales/FilmTypeMaster.aspx');");
            lnkBtnCountry.Attributes.Add("onclick", "return openpopup('Procurement/CountryMaster.aspx');");
            lnkBtnSalesType.Attributes.Add("onclick", "return openpopup('Sales/SalesTypeMaster.aspx');");
            lnkBtnPaymentTerms.Attributes.Add("onclick", "return openpopup('Sales/MasterPaymentTerms.aspx');");
            lnkBtnFinalDestination.Attributes.Add("onclick", "return openpopup('Sales/MasterFinalDestination.aspx');");
            lnkBtnSalesArea.Attributes.Add("onclick", "return openpopup('Sales/SalesAreaMaster.aspx');");
            lnkBtnRegion.Attributes.Add("onclick", "return openpopup('Sales/RegionMaster.aspx');");
        }            
    }
    
    #endregion  
    
}