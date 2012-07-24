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

public class Home
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    #endregion

    #region Properties

    #endregion

    #region Public Methods

    public Home()
	{ }

    public DataTable Get_ModuleAndSubmoduleByUserId(string UserId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_ModuleAndSubmoduleByUserId";
        objSqlCommand.Parameters.AddWithValue("@UserId", UserId);        

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_SubmoduleFormURLByModuleAndUserId(string ModuleName, string UserId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_SubmoduleFormURLByModuleAndUserId";
        objSqlCommand.Parameters.AddWithValue("@ModuleName", ModuleName);
        objSqlCommand.Parameters.AddWithValue("@UserId", UserId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}