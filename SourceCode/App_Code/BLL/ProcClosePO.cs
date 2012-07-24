using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ProcClosePO
/// </summary>
public class ProcClosePO
{
    Common cs = new Common();
	public ProcClosePO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable posearch()
    {
        string sql = "select * from  View_POHeader";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public DataTable getDetailData(int poid)
    {

        string sql = @"Select [LineItem]
      ,[PRNumber]
      ,[MaterialCode]
      ,[POQuantity]
      ,[UOM]
      ,[Price]
      ,[Amount]
      ,[Plant]
      ,[CostCenter]
      ,[PRPrice]
      ,[PRDLVDate]
      ,[ValuationType]
      ,[ProjectCode]
      ,[SubProjectCode]
      ,[BudgetCode]
      ,[SubBudgetCode]
      ,[MaterialDescription]
      ,[Discount]
      ,[AbsPercent]
      ,[OtherCost]
      ,[PackLine]
      ,[POItemText]
      ,[LeadTime]
      ,[DelivryQuantity]
      ,[MaterialCodeName] from View_PODetails where PONumber='" + poid + "'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public bool UpdateRelese(int id, bool isRelease, string Releaseby)
    {
        try
        {
            string sql = "update Inv_Glb_POHeader set POClose='" + isRelease + "', POCloseBy='" + Releaseby + "' ,POCloseDate='" + DateTime.Now + "'";
            cs.executeSimpleQry(sql);
            return true;
        }
        catch
        {
            return false;
        }
    }
}