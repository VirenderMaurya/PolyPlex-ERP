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


public class Login_mst
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    #endregion

    #region Properties

    #endregion

    #region Public Methods

    public Login_mst()
	{}

    public DataTable Get_LoginCredentials(string LoginId,string Password)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_LoginCredentials";
        objSqlCommand.Parameters.AddWithValue("@LoginId", LoginId);
        objSqlCommand.Parameters.AddWithValue("@Password", Password);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}