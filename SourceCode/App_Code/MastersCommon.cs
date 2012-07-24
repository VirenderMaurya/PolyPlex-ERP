using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MastersCommon
/// </summary>
public class MastersCommon
{
    Common cs = new Common();
    Connection con = new Connection();

    public MastersCommon()
    {

    }



    public DataTable getTableData(string tablename)
    {
        DataTable dt = cs.executeSqlQry("select * from " + tablename);
        return dt;

    }

}