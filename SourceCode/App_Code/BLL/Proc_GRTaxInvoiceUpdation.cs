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
using System.Data.SqlClient;

public class Proc_GRTaxInvoiceUpdation
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields    

    private int _AutoId;
    private string _TaxInvoiceDate;
    private string _DueDate;
    private int _ModifiedBy;

    #endregion

    #region Properties

    public int AutoId
    {
        get { return _AutoId; }
        set { _AutoId = value; }
    }
    public string TaxInvoiceDate
    {
        get { return _TaxInvoiceDate; }
        set { _TaxInvoiceDate = value; }
    }
    public string DueDate
    {
        get { return _DueDate; }
        set { _DueDate = value; }
    }
    public int ModifiedBy
    {
        get { return _ModifiedBy; }
        set { _ModifiedBy = value; }
    }   

    #endregion

    #region Public Methods

    public Proc_GRTaxInvoiceUpdation()
    { }

    public DataTable FillAllGRNo(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllGRNoForTaxInvoiceUpdate";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable BindAllTaxInvoiceUpdatedList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllUpdatedGRNoByTaxInvoiceUpdate";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public string Update_In_Proc_GoodsReceiptByTaxInvoiceUpdation()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_In_Proc_GoodsReceiptByTaxInvoiceUpdation(this);
    }

    #endregion	
}