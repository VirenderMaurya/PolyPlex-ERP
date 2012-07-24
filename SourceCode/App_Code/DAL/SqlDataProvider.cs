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
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;


public partial class SqlDataProvider
{
    string logmessage = "";
    SqlTransaction sqltran;
    SqlCommand cmd;
    string IsSaved;

    #region Procedure Get All Master Records

    private const string Sp_Get_PIType_Master = "Sp_Get_PIType_Master";
    private const string Sp_Get_AllDeliveryToType_Master = "Sp_Get_AllDeliveryToType_Master";
    private const string Sp_Get_Glb_FinalDestination_Master = "Sp_Get_Glb_FinalDestination_Master";
    private const string Sp_Get_Glb_Logistic_Master = "Sp_Get_Glb_Logistic_Master";
    private const string Sp_GetCertificate = "Sp_GetCertificate";
    private const string Sp_GetUnitofSale = "Sp_GetUnitofSale";
    private const string Sp_GetAllDeliveryTolerance = "Sp_GetAllDeliveryTolerance";
    private const string Sp_GetAllCurrency = "Sp_GetAllCurrency";
    private const string Sp_GetAllPaymode = "Sp_GetAllPaymode";
    private const string Sp_PackingStandard = "Sp_PackingStandard";
    private const string Sp_GetFilmType = "Sp_GetFilmType";
    private const string Sp_GetFinancialYear = "Sp_GetFinancialYear";
    private const string Sp_GetType = "Sp_GetType";
    private const string Sp_GetStickerType = "Sp_GetStickerType";
    private const string Sp_GetAllLocation = "Sp_GetAllLocation";
    private const string Sp_GetAllEnvironment = "Sp_GetAllEnvironment";
    private const string Sp_Get_SalesArea_Mst = "Sp_Get_SalesArea_Mst";
    private const string Sp_Get_Salesorganization_Master = "Sp_Get_Salesorganization_Master";
    private const string Sp_Get_DistributionChannel_Mst = "Sp_Get_DistributionChannel_Mst";
    private const string Sp_Get_SubFilmType_Mst = "Sp_Get_SubFilmType_Mst";
    private const string Sp_Get_Thickness_Mst = "Sp_Get_Thickness_Mst";

    private const string Sp_Get_Prod_Line_Mst = "Sp_Get_Prod_Line_Mst";
    private const string Sp_Get_Prod_Shift_Mst = "Sp_Get_Prod_Shift_Mst";
    private const string Sp_Get_Prod_Grade_Mst = "Sp_Get_Prod_Grade_Mst";
    private const string Sp_Get_Prod_Polrised_Mst = "Sp_Get_Prod_Polrised_Mst";
    private const string Sp_Get_FA_Glb_VendorMaster_Mst = "Sp_Get_FA_Glb_VendorMaster_Mst";

    private const string Sp_Get_All_Prod_Area_Mst = "Sp_Get_All_Prod_Area_Mst";
    private const string Sp_Get_All_Prod_Dept_Mst = "Sp_Get_All_Prod_Dept_Mst";
    private const string Sp_Get_All_Prod_Machine_Mst = "Sp_Get_All_Prod_Machine_Mst";
    private const string Sp_Get_All_Prod_SubMachine_Mst = "Sp_Get_All_Prod_SubMachine_Mst";
    private const string Sp_Get_All_Prod_KKType_Mst = "Sp_Get_All_Prod_KKType_Mst";
    private const string Sp_Get_All_Prod_Problem_Mst = "Sp_Get_All_Prod_Problem_Mst";

    private const string Sp_Get_All_Prod_Process_Mst = "Sp_Get_All_Prod_Process_Mst";
    private const string Sp_Get_All_Prod_Batch_Mst = "Sp_Get_All_Prod_Batch_Mst";
    private const string Sp_Get_All_Prod_StorageLocation_Mst = "Sp_Get_All_Prod_StorageLocation_Mst";
    private const string Sp_Get_All_Proc_VendorBatch_Mst = "Sp_Get_All_Proc_VendorBatch_Mst";

    #endregion

    #region Procedure Insert Records
       
    private const string SP_Insert_In_Sal_Glb_MaterialReturnNote_Tran = "SP_Insert_In_Sal_Glb_MaterialReturnNote_Tran";
    private const string Sp_InsertInRollsInternalTransfer = "Sp_InsertInRollsInternalTransfer";
    private const string Sp_InsertInSalesOrderClosing = "Sp_InsertInSalesOrderClosing";
    private const string SP_InsertUpadte_In_FA_Glb_CreditDebitNoteForm_Trans = "SP_InsertUpadte_In_FA_Glb_CreditDebitNoteForm_Trans";
    private const string Sp_InsertIn_Sal_Glb_StockLotRollReservation_Tran = "Sp_InsertIn_Sal_Glb_StockLotRollReservation_Tran";
    private const string Sp_InsertIn_Prod_Glb_RollReservation_Tran = "Sp_InsertIn_Prod_Glb_RollReservation_Tran";

    #endregion    

    #region Procedure Delete Records
    
    private const string SP_Delete_In_Sal_PackingCreation_Tran_For_OrderNo = "SP_Delete_In_Sal_PackingCreation_Tran_For_OrderNo";

    #endregion

    public SqlDataProvider()
    {

    }

    #region***************Get All Functions************

    #region*******************CallMaster Functions********************

    #region Common Master

    public BLLCollection<Common_mst> Get_AllPIType_mst()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_PIType_Master, new object[] { }, new GenerateCollectionFromReader(PIType_mst));
    }

    public BLLCollection<Common_mst> Get_AllDeliveryToType()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_AllDeliveryToType_Master, new object[] { }, new GenerateCollectionFromReader(DeliveryTo_mst));
    }

    public BLLCollection<Common_mst> Get_AllFinalDestination()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Glb_FinalDestination_Master, new object[] { }, new GenerateCollectionFromReader(FinalDestination_mst));
    }

    public BLLCollection<Common_mst> Get_All_Glb_Logistic_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Glb_Logistic_Master, new object[] { }, new GenerateCollectionFromReader(Glb_Logistic_mst));
    }

    public BLLCollection<Common_mst> Get_All_Certificate_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetCertificate, new object[] { }, new GenerateCollectionFromReader(Get_All_Certificate_Master));
    }

    public BLLCollection<Common_mst> Get_All_UnitOfSale_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetUnitofSale, new object[] { }, new GenerateCollectionFromReader(Get_All_UnitOfSale_Master));
    }

    public BLLCollection<Common_mst> Get_All_DeliveryTolerance_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetAllDeliveryTolerance, new object[] { }, new GenerateCollectionFromReader(Get_All_DeliveryTolerance_Master));
    }

    public BLLCollection<Common_mst> Get_All_Currency_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetAllCurrency, new object[] { }, new GenerateCollectionFromReader(Get_All_Currency_Master));
    }

    public BLLCollection<Common_mst> Get_All_Paymode_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetAllPaymode, new object[] { }, new GenerateCollectionFromReader(Get_All_Paymode_Master));
    }

    public BLLCollection<Common_mst> Get_All_PackingStandard_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_PackingStandard, new object[] { }, new GenerateCollectionFromReader(Get_All_PackingStandard_Master));
    }

    public BLLCollection<Common_mst> Get_All_FilmType_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetFilmType, new object[] { }, new GenerateCollectionFromReader(Get_All_FilmType_Master));
    }

    public BLLCollection<Common_mst> Get_All_Location_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetAllLocation, new object[] { }, new GenerateCollectionFromReader(Get_All_Location_Master));
    }

    public BLLCollection<Common_mst> Get_All_Environment_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetAllEnvironment, new object[] { }, new GenerateCollectionFromReader(Get_All_Environment_Master));
    }

    public BLLCollection<Common_mst> Get_StickerType()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_GetStickerType, new object[] { }, new GenerateCollectionFromReader(GenerateStickerType_Master));
    }

    public BLLCollection<Common_mst> Get_All_SalesArea_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_SalesArea_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_SalesArea_Master));
    }

    public BLLCollection<Common_mst> Get_All_Salesorganization_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Salesorganization_Master, new object[] { }, new GenerateCollectionFromReader(Get_All_Salesorganization_Master));
    }

    public BLLCollection<Common_mst> Get_All_Distribution_Master()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_DistributionChannel_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_Distribution_Master));
    }

    public BLLCollection<Common_mst> Get_All_SubFilmType_Mst()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_SubFilmType_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_SubFilmType_Mst));
    }

    public BLLCollection<Common_mst> Get_All_Thickness_Mst()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Thickness_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_Thickness_Mst));
    }

    public BLLCollection<Common_mst> Get_All_Prod_Line_Mst()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Prod_Line_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_Prod_Line_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_Shift_Mst()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Prod_Shift_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_Prod_Shift_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_Grade_Mst()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Prod_Grade_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_Prod_Grade_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_Polrised_Mst()
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_Prod_Polrised_Mst, new object[] { }, new GenerateCollectionFromReader(Get_All_Prod_Polrised_Mst));
    }
    public BLLCollection<Common_mst> Get_All_FA_Glb_VendorMaster_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_FA_Glb_VendorMaster_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_FA_Glb_VendorMaster_Mst));
    }

    public BLLCollection<Common_mst> Get_All_Prod_Area_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_Area_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_Area_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_Dept_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_Dept_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_Dept_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_Machine_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_Machine_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_Machine_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_SubMachine_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_SubMachine_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_SubMachine_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_KKType_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_KKType_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_KKType_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_Problem_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_Problem_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_Problem_Mst));
    }

    public BLLCollection<Common_mst> Get_All_Prod_Process_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_Process_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_Process_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_Batch_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_Batch_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_Batch_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Prod_StorageLocation_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Prod_StorageLocation_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Prod_StorageLocation_Mst));
    }
    public BLLCollection<Common_mst> Get_All_Proc_VendorBatch_Mst(string SearchText)
    {
        return (BLLCollection<Common_mst>)ExecuteReader(Sp_Get_All_Proc_VendorBatch_Mst, new object[] { SearchText }, new GenerateCollectionFromReader(Get_All_Proc_VendorBatch_Mst));
    }
    #endregion    

    #endregion

    #region******************Fill Masters******************

    #region Fill Common Master

    public CollectionBase PIType_mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.PerfInvTypeName = (string)returnData["PerfInvTypeName"];
            obj.PerfInvTypeID = Convert.ToInt32(returnData["PerfInvTypeID"].ToString());

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase DeliveryTo_mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.DeliveryToName = (string)returnData["DeliveryToName"];
            obj.DeliveryToID = Convert.ToInt32(returnData["DeliveryToID"].ToString());

            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase FinalDestination_mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.FinalDestinationName = (string)returnData["FinalDestCity"];
            obj.FinalDestinationID = Convert.ToInt32(returnData["FinalDestinationID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Glb_Logistic_mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.LogisticName = (string)returnData["LogisticName"];
            obj.LogisticID = Convert.ToInt32(returnData["LogisticID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Certificate_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.CertificateName = (string)returnData["CertificateName"];
            obj.CertificateID = Convert.ToInt32(returnData["CertificateID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_UnitOfSale_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.UnitSaleName = (string)returnData["UnitSaleName"];
            obj.UnitSaleID = Convert.ToInt32(returnData["UnitSaleID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_DeliveryTolerance_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.DeliveryToleranceName = (string)returnData["DeliveryToleranceName"];
            obj.DeliveryToleranceID = Convert.ToInt32(returnData["DeliveryToleranceID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Currency_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.CurrencyCode = (string)returnData["CurrencyCode"];
            obj.CurrencyID = Convert.ToInt32(returnData["CurrencyID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Paymode_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.PaymodeName = (string)returnData["PaymodeName"];
            obj.PayModeID = Convert.ToInt32(returnData["PayModeID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_PackingStandard_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.PackingStandardName = (string)returnData["PackingStandardName"];
            obj.PackingStandardID = Convert.ToInt32(returnData["PackingStandardID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_FilmType_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.FilmTypeName = (string)returnData["FilmTypeName"];
            obj.FilmTypeID = Convert.ToInt32(returnData["FilmTypeID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Location_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.LocationName = (string)returnData["LocationName"];
            obj.LocationID = Convert.ToInt32(returnData["LocationID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Environment_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.EnvironmentName = (string)returnData["name"];
            obj.Environmentid = Convert.ToInt32(returnData["environmentid"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase GenerateStickerType_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.StickerTypeName = (string)returnData["StickerTypeName"];
            obj.StickerTypeID = Convert.ToInt32(returnData["StickerTypeID"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_SalesArea_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.SalesAreaCode = (string)returnData["SalesAreaCode"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Salesorganization_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.SalesOrgCode = (string)returnData["SalesOrgCode"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Distribution_Master(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.Code = (string)returnData["Code"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_SubFilmType_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.SubFilmTypeName = (string)returnData["SubFilmTypeName"];
            obj.SubFilmTypeId = Convert.ToInt32(returnData["SubFilmTypeId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Thickness_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.Thickness = (string)returnData["Thickness"];
            obj.ThicknessId = Convert.ToInt32(returnData["ThicknessId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Line_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.LineCode = (string)returnData["LineCode"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Shift_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.ShiftCode = (string)returnData["ShiftCode"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Grade_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.GradeCode = (string)returnData["GradeCode"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Polrised_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.PolCode = (string)returnData["PolCode"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_FA_Glb_VendorMaster_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.VendorCodeName = (string)returnData["VendorCodeName"];
            obj.VendorId = Convert.ToInt32(returnData["VendorId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Area_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.AreaName = (string)returnData["AreaName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Dept_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.DeptName = (string)returnData["DeptName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Machine_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.MachineName = (string)returnData["MachineName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_SubMachine_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.SubMachineName = (string)returnData["SubMachineName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_KKType_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.KKName = (string)returnData["KKName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Problem_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.ProbDesc = (string)returnData["ProbDesc"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Process_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.ProcessName = (string)returnData["ProcessName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_Batch_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.BatchName = (string)returnData["BatchName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Prod_StorageLocation_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.StorageLocationName = (string)returnData["StorageLocationName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    public CollectionBase Get_All_Proc_VendorBatch_Mst(ref IDataReader returnData)
    {
        BLLCollection<Common_mst> col = new BLLCollection<Common_mst>();
        while (returnData.Read())
        {
            Common_mst obj = new Common_mst();

            obj.VendorBatchName = (string)returnData["VendorBatchName"];
            obj.AutoId = Convert.ToInt32(returnData["AutoId"].ToString());
            col.Add(obj);
        }
        returnData.Close();
        returnData.Dispose();
        return col;
    }

    #endregion    

    #endregion

    #region***********************Insert/Update Functions********************

    #region Sales

    public string InsertUpdate_In_Glb_PerformaInvoice(PerformaInvoice_Tran objPerformaInvoice_Tran)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("PI");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PerfInvTypeID", SqlDbType.Int).Value = objPerformaInvoice_Tran.PerfInvTypeID;
            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objPerformaInvoice_Tran.Year;
            cmd.Parameters.Add("@PIDate", SqlDbType.DateTime).Value = objPerformaInvoice_Tran.PIDate;
            cmd.Parameters.Add("@Customer", SqlDbType.Int).Value = objPerformaInvoice_Tran.Customer;
            cmd.Parameters.Add("@Consignee", SqlDbType.Int).Value = objPerformaInvoice_Tran.Consignee;
            cmd.Parameters.Add("@DeliveryTo", SqlDbType.Int).Value = objPerformaInvoice_Tran.DeliveryTo;
            cmd.Parameters.Add("@CustomerOrderNo", SqlDbType.VarChar).Value = objPerformaInvoice_Tran.CustomerOrderNo;
            cmd.Parameters.Add("@CustomerArticleNo", SqlDbType.VarChar).Value = objPerformaInvoice_Tran.CustomerArticleNo;
            cmd.Parameters.Add("@CustomerPartNo", SqlDbType.VarChar).Value = objPerformaInvoice_Tran.CustomerPartNo;
            if (objPerformaInvoice_Tran.CustomerOrderDate != "")
            {
                cmd.Parameters.Add("@CustomerOrderDate", SqlDbType.DateTime).Value = objPerformaInvoice_Tran.CustomerOrderDate;
            }
            else
            {
                cmd.Parameters.Add("@CustomerOrderDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@FinalDestination", SqlDbType.Int).Value = objPerformaInvoice_Tran.FinalDestination;
            cmd.Parameters.Add("@DeliveryTolerance", SqlDbType.Int).Value = objPerformaInvoice_Tran.DeliveryTolerance;
            cmd.Parameters.Add("@TermsOfDelivery", SqlDbType.Int).Value = objPerformaInvoice_Tran.TermsOfDelivery;
            cmd.Parameters.Add("@Logistics", SqlDbType.Int).Value = objPerformaInvoice_Tran.Logistics;
            cmd.Parameters.Add("@Currency", SqlDbType.Int).Value = objPerformaInvoice_Tran.Currency;
            cmd.Parameters.Add("@PaymentMode", SqlDbType.Int).Value = objPerformaInvoice_Tran.PaymentMode;
            cmd.Parameters.Add("@Certificates", SqlDbType.Int).Value = objPerformaInvoice_Tran.Certificates;
            cmd.Parameters.Add("@NoOfShipment", SqlDbType.Int).Value = objPerformaInvoice_Tran.NoOfShipment;
            cmd.Parameters.Add("@PackingStandard", SqlDbType.Int).Value = objPerformaInvoice_Tran.PackingStandard;
            cmd.Parameters.Add("@RemittanceDays", SqlDbType.Int).Value = objPerformaInvoice_Tran.RemittanceDays;
            cmd.Parameters.Add("@CreditDays", SqlDbType.Int).Value = objPerformaInvoice_Tran.CreditDays;
            cmd.Parameters.Add("@FilmType", SqlDbType.Int).Value = objPerformaInvoice_Tran.FilmType;
            cmd.Parameters.Add("@UnitOfSales", SqlDbType.Int).Value = objPerformaInvoice_Tran.UnitOfSales;

            cmd.Parameters.Add("@SalesAreaId", SqlDbType.Int).Value = objPerformaInvoice_Tran.SalesAreaId;
            cmd.Parameters.Add("@SalesOrganizationId", SqlDbType.Int).Value = objPerformaInvoice_Tran.SalesOrganizationId;
            cmd.Parameters.Add("@DistributionChannelId", SqlDbType.Int).Value = objPerformaInvoice_Tran.DistributionChannelId;
            cmd.Parameters.Add("@ProfitCenterId", SqlDbType.Int).Value = objPerformaInvoice_Tran.ProfitCenterId;

            cmd.Parameters.Add("@SpecialInstruction", SqlDbType.VarChar).Value = objPerformaInvoice_Tran.SpecialInstruction;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objPerformaInvoice_Tran.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objPerformaInvoice_Tran.ModifiedBy;
            cmd.Parameters.Add("@PerformaInvoiceID", SqlDbType.Int).Value = objPerformaInvoice_Tran.PerformaInvoiceID;

            cmd.Parameters.Add("@NewPerformaInvoiceID", SqlDbType.Int);
            cmd.Parameters["@NewPerformaInvoiceID"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Glb_PerformaInvoiceHeader";
            cmd.ExecuteNonQuery();

            string NewPerformaInvoiceID = cmd.Parameters["@NewPerformaInvoiceID"].Value.ToString();
            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Insert/Update record of line item

            if (IsSaved == "YES")
            {
                DataTable dt = objPerformaInvoice_Tran.dtPILineItems;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = objConnectionClass.PolypexSqlConnection;
                        cmd.Transaction = sqltran;
                        cmd.CommandTimeout = 60;
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            cmd.Parameters.Add("@LineItemID", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["LineItemID"].ToString());
                            if (objPerformaInvoice_Tran.PerformaInvoiceID == 0)
                            {
                                cmd.Parameters.Add("@PerformaInvoiceID", SqlDbType.Int).Value = Convert.ToInt32(NewPerformaInvoiceID);
                            }
                            else
                            {
                                cmd.Parameters.Add("@PerformaInvoiceID", SqlDbType.Int).Value = objPerformaInvoice_Tran.PerformaInvoiceID;
                            }
                            cmd.Parameters.Add("@LineNo", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["LineNo"].ToString());
                            cmd.Parameters.Add("@SubFilmType", SqlDbType.Int).Value = dt.Rows[i]["SubFilmType"].ToString();
                            cmd.Parameters.Add("@Micron", SqlDbType.VarChar).Value = dt.Rows[i]["Micron"].ToString();
                            cmd.Parameters.Add("@Core", SqlDbType.VarChar).Value = dt.Rows[i]["Core"].ToString();
                            cmd.Parameters.Add("@WidthInMM", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["WidthInMM"].ToString());
                            cmd.Parameters.Add("@WidthInInch", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["WidthInInch"].ToString());
                            cmd.Parameters.Add("@LengthInMtr", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["LengthInMtr"].ToString());
                            cmd.Parameters.Add("@LengthInFt", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["LengthInFt"].ToString());
                            cmd.Parameters.Add("@UnitPrice", SqlDbType.Float).Value = dt.Rows[i]["UnitPrice"].ToString();
                            cmd.Parameters.Add("@NoOfRolls", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["NoOfRolls"].ToString());
                            cmd.Parameters.Add("@ReqQuantityInKG", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["ReqQuantityInKG"].ToString());
                            if (dt.Rows[i]["EstimatedDate"].ToString() != "")
                            {
                                cmd.Parameters.Add("@EstimatedDate", SqlDbType.DateTime).Value = dt.Rows[i]["EstimatedDate"].ToString();
                            }
                            else
                            {
                                cmd.Parameters.Add("@EstimatedDate", SqlDbType.DateTime).Value = DBNull.Value;
                            }
                            cmd.Parameters.Add("@Application", SqlDbType.VarChar).Value = dt.Rows[i]["Application"].ToString();
                            cmd.Parameters.Add("@COFMin", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["COFMin"].ToString());
                            cmd.Parameters.Add("@COFMax", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["COFMax"].ToString());
                            cmd.Parameters.Add("@ODMin", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["ODMin"].ToString());
                            cmd.Parameters.Add("@ODAvg", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["ODAvg"].ToString());
                            cmd.Parameters.Add("@ODMax", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["ODMax"].ToString());
                            cmd.Parameters.Add("@ShipmentNo", SqlDbType.VarChar).Value = dt.Rows[i]["ShipmentNo"].ToString();
                            cmd.Parameters.Add("@Include", SqlDbType.Bit).Value = Convert.ToBoolean(dt.Rows[i]["Include"].ToString());

                            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = Convert.ToBoolean(dt.Rows[i]["ActiveStatus"].ToString());
                            cmd.Parameters.Add("@PalletType", SqlDbType.VarChar).Value = dt.Rows[i]["PalletType"].ToString();
                            cmd.Parameters.Add("@NoofRollsInPallet", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["NoofRollsInPallet"].ToString());
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objPerformaInvoice_Tran.CreatedBy;
                            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objPerformaInvoice_Tran.ModifiedBy;

                            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                            cmd.CommandText = "SP_InsertUpadte_In_Glb_PerformaInvoiceLineItems";
                            cmd.ExecuteNonQuery();

                            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();
                        }
                        catch
                        {
                            IsSaved = "NO";
                            sqltran.Rollback("PI");
                            return IsSaved;
                        }
                    }
                }
            }
            else if (IsSaved == "NO")
            {
                sqltran.Rollback("PI");
            }
            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("PI");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("PI");
            return IsSaved;
        }
    }

    public string InsertUpdate_In_Glb_SalesOrder(SalesOrder_Trans objSalesOrder_Trans)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("SO");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SOTypeID", SqlDbType.Int).Value = objSalesOrder_Trans.SOTypeID;
            cmd.Parameters.Add("@SOFYear", SqlDbType.VarChar).Value = objSalesOrder_Trans.Year;
            cmd.Parameters.Add("@PINo", SqlDbType.Int).Value = objSalesOrder_Trans.PINo;
            cmd.Parameters.Add("@SOCustomer", SqlDbType.Int).Value = objSalesOrder_Trans.SOCustomer;
            cmd.Parameters.Add("@SODate", SqlDbType.DateTime).Value = objSalesOrder_Trans.SODate;
            cmd.Parameters.Add("@Confirmed", SqlDbType.Bit).Value = objSalesOrder_Trans.Confirmed;
            cmd.Parameters.Add("@CustomerOrderNo", SqlDbType.VarChar).Value = objSalesOrder_Trans.CustomerOrderNo;
            cmd.Parameters.Add("@CustomerArticleNo", SqlDbType.VarChar).Value = objSalesOrder_Trans.CustomerArticleNo;
            cmd.Parameters.Add("@CustomerPartNo", SqlDbType.VarChar).Value = objSalesOrder_Trans.CustomerPartNo;
            cmd.Parameters.Add("@SOConsignee", SqlDbType.Int).Value = objSalesOrder_Trans.SOConsignee;
            cmd.Parameters.Add("@SODeliveryTo", SqlDbType.Int).Value = objSalesOrder_Trans.SODeliveryTo;
            if (objSalesOrder_Trans.SOCustomerOrderDate != "")
            {
                cmd.Parameters.Add("@SOCustomerOrderDate", SqlDbType.DateTime).Value = objSalesOrder_Trans.SOCustomerOrderDate;
            }
            else
            {
                cmd.Parameters.Add("@SOCustomerOrderDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@RevisionNo", SqlDbType.VarChar).Value = objSalesOrder_Trans.RevisionNo;
            if (objSalesOrder_Trans.RevisionDate != "")
            {
                cmd.Parameters.Add("@RevisionDate", SqlDbType.DateTime).Value = objSalesOrder_Trans.RevisionDate;
            }
            else
            {
                cmd.Parameters.Add("@RevisionDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@SOCreditDays", SqlDbType.Int).Value = objSalesOrder_Trans.SOCreditDays;
            cmd.Parameters.Add("@SOCreditDaysFrom", SqlDbType.Int).Value = objSalesOrder_Trans.SOCreditDaysFrom;
            cmd.Parameters.Add("@SOFinalDestination", SqlDbType.Int).Value = objSalesOrder_Trans.SOFinalDestination;
            cmd.Parameters.Add("@PartialShipment", SqlDbType.Bit).Value = objSalesOrder_Trans.PartialShipment;
            cmd.Parameters.Add("@SOCurrency", SqlDbType.Int).Value = objSalesOrder_Trans.SOCurrency;
            cmd.Parameters.Add("@TermsOfDelivery", SqlDbType.Int).Value = objSalesOrder_Trans.TermsOfDelivery;
            cmd.Parameters.Add("@SOLogistics", SqlDbType.Int).Value = objSalesOrder_Trans.SOLogistics;
            cmd.Parameters.Add("@SOVAT", SqlDbType.Bit).Value = objSalesOrder_Trans.SOVAT;
            cmd.Parameters.Add("@SOFilmType", SqlDbType.Int).Value = objSalesOrder_Trans.SOFilmType;
            cmd.Parameters.Add("@SOUnitOfSales", SqlDbType.Int).Value = objSalesOrder_Trans.SOUnitOfSales;

            cmd.Parameters.Add("@SalesAreaId", SqlDbType.Int).Value = objSalesOrder_Trans.SalesAreaId;
            cmd.Parameters.Add("@SalesOrganizationId", SqlDbType.Int).Value = objSalesOrder_Trans.SalesOrganizationId;
            cmd.Parameters.Add("@DistributionChannelId", SqlDbType.Int).Value = objSalesOrder_Trans.DistributionChannelId;
            cmd.Parameters.Add("@ProfitCenterId", SqlDbType.Int).Value = objSalesOrder_Trans.ProfitCenterId;

            cmd.Parameters.Add("@SOPaymentMode", SqlDbType.Int).Value = objSalesOrder_Trans.SOPaymentMode;
            cmd.Parameters.Add("@SOCertificateOfOrigin", SqlDbType.Bit).Value = objSalesOrder_Trans.SOCertificateOfOrigin;
            cmd.Parameters.Add("@SOPaymentTerms", SqlDbType.NVarChar).Value = objSalesOrder_Trans.SOPaymentTerms;
            cmd.Parameters.Add("@SOPaymentTerms1", SqlDbType.NVarChar).Value = objSalesOrder_Trans.SOPaymentTerms1;
            cmd.Parameters.Add("@SOPaymentTerms2", SqlDbType.NVarChar).Value = objSalesOrder_Trans.SOPaymentTerms2;
            cmd.Parameters.Add("@SOSpecailIntructions", SqlDbType.NVarChar).Value = objSalesOrder_Trans.SOSpecailIntructions;
            if (objSalesOrder_Trans.CommittedETD != "")
            {
                cmd.Parameters.Add("@CommittedETD", SqlDbType.DateTime).Value = objSalesOrder_Trans.CommittedETD;
            }
            else
            {
                cmd.Parameters.Add("@CommittedETD", SqlDbType.DateTime).Value = DBNull.Value;
            }

            if (objSalesOrder_Trans.CommittedETA != "")
            {
                cmd.Parameters.Add("@CommittedETA", SqlDbType.DateTime).Value = objSalesOrder_Trans.CommittedETA;
            }
            else
            {
                cmd.Parameters.Add("@CommittedETA", SqlDbType.DateTime).Value = DBNull.Value;
            }

            if (objSalesOrder_Trans.RevisedETD != "")
            {
                cmd.Parameters.Add("@RevisedETD", SqlDbType.DateTime).Value = objSalesOrder_Trans.RevisedETD;
            }
            else
            {
                cmd.Parameters.Add("@RevisedETD", SqlDbType.DateTime).Value = DBNull.Value;
            }

            if (objSalesOrder_Trans.RevisedETA != "")
            {
                cmd.Parameters.Add("@RevisedETA", SqlDbType.DateTime).Value = objSalesOrder_Trans.RevisedETA;
            }
            else
            {
                cmd.Parameters.Add("@RevisedETA", SqlDbType.DateTime).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@SOPackingStandard", SqlDbType.Int).Value = objSalesOrder_Trans.SOPackingStandard;
            cmd.Parameters.Add("@SODeliveryTolerance", SqlDbType.Int).Value = objSalesOrder_Trans.SODeliveryTolerance;
            cmd.Parameters.Add("@SOInvoiceLength", SqlDbType.Float).Value = objSalesOrder_Trans.SOInvoiceLength;
            cmd.Parameters.Add("@AllowJoints", SqlDbType.Bit).Value = objSalesOrder_Trans.AllowJoints;
            cmd.Parameters.Add("@SOStickerType", SqlDbType.Int).Value = objSalesOrder_Trans.SOStickerType;
            cmd.Parameters.Add("@SOServiceLength", SqlDbType.Float).Value = objSalesOrder_Trans.SOServiceLength;
            cmd.Parameters.Add("@MaxLengthTolerance", SqlDbType.Int).Value = objSalesOrder_Trans.MaxLengthTolerance;
            cmd.Parameters.Add("@SOFumigation", SqlDbType.Bit).Value = objSalesOrder_Trans.SOFumigation;
            cmd.Parameters.Add("@SOCertificates", SqlDbType.Int).Value = objSalesOrder_Trans.SOCertificates;
            cmd.Parameters.Add("@COOCTH", SqlDbType.VarChar).Value = objSalesOrder_Trans.COOCTH;
            cmd.Parameters.Add("@BOIIncentive", SqlDbType.VarChar).Value = objSalesOrder_Trans.BOIIncentive;

            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objSalesOrder_Trans.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objSalesOrder_Trans.ModifiedBy;
            cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = objSalesOrder_Trans.SalesOrderId;

            cmd.Parameters.Add("@NewSalesOrderId", SqlDbType.Int);
            cmd.Parameters["@NewSalesOrderId"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Glb_SalesOrderHeader";
            cmd.ExecuteNonQuery();

            string NewSalesOrderId = cmd.Parameters["@NewSalesOrderId"].Value.ToString();
            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Insert/Update record of line item

            if (IsSaved == "YES")
            {
                DataTable dt = objSalesOrder_Trans.dtSOLineItems;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = objConnectionClass.PolypexSqlConnection;
                        cmd.Transaction = sqltran;
                        cmd.CommandTimeout = 60;
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            cmd.Parameters.Add("@LineItemID", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["SOLineItemID"].ToString());
                            if (objSalesOrder_Trans.SalesOrderId == 0)
                            {
                                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = Convert.ToInt32(NewSalesOrderId);
                            }
                            else
                            {
                                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = Convert.ToInt32(objSalesOrder_Trans.SalesOrderId);
                            }
                            cmd.Parameters.Add("@LineNo", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["LineNo"].ToString());
                            cmd.Parameters.Add("@SubFilmType", SqlDbType.Int).Value = dt.Rows[i]["SubFilmType"].ToString();
                            cmd.Parameters.Add("@SOMicron", SqlDbType.VarChar).Value = dt.Rows[i]["SOMicron"].ToString();
                            cmd.Parameters.Add("@SOCore", SqlDbType.VarChar).Value = dt.Rows[i]["SOCore"].ToString();
                            cmd.Parameters.Add("@SOWidthInMM", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["SOWidthInMM"].ToString());
                            cmd.Parameters.Add("@SOWidthInInch", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOWidthInInch"].ToString());
                            cmd.Parameters.Add("@SOLengthInMtr", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOLengthInMtr"].ToString());
                            cmd.Parameters.Add("@SOLengthInFt", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOLengthInFt"].ToString());
                            cmd.Parameters.Add("@SOUnitPrice", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOUnitPrice"].ToString());
                            cmd.Parameters.Add("@SONoOfRolls", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["SONoOfRolls"].ToString());
                            cmd.Parameters.Add("@SOReqQuantityInKG", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOReqQuantityInKG"].ToString());
                            if (dt.Rows[i]["SODeliveryDate"].ToString() != "")
                            {
                                cmd.Parameters.Add("@SODeliveryDate", SqlDbType.DateTime).Value = dt.Rows[i]["SODeliveryDate"].ToString();
                            }
                            else
                            {
                                cmd.Parameters.Add("@SODeliveryDate", SqlDbType.DateTime).Value = DBNull.Value;
                            }
                            cmd.Parameters.Add("@SOApplication", SqlDbType.VarChar).Value = dt.Rows[i]["SOApplication"].ToString();
                            cmd.Parameters.Add("@SOCOFMin", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOCOFMin"].ToString());
                            cmd.Parameters.Add("@SOCOFMax", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOCOFMax"].ToString()); ;
                            cmd.Parameters.Add("@SOODMin", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOODMin"].ToString());
                            cmd.Parameters.Add("@SOODAvg", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOODAvg"].ToString());
                            cmd.Parameters.Add("@SOODMax", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SOODMax"].ToString());
                            cmd.Parameters.Add("@ShipmentNo", SqlDbType.VarChar).Value = dt.Rows[i]["ShipmentNo"].ToString();
                            cmd.Parameters.Add("@SOInclude", SqlDbType.Bit).Value = Convert.ToBoolean(dt.Rows[i]["SOInclude"].ToString());

                            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = Convert.ToBoolean(dt.Rows[i]["ActiveStatus"].ToString());
                            cmd.Parameters.Add("@PalletType", SqlDbType.VarChar).Value = dt.Rows[i]["PalletType"].ToString();
                            cmd.Parameters.Add("@NoofRollsInPallet", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["NoofRollsInPallet"].ToString());
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = Convert.ToInt32(objSalesOrder_Trans.CreatedBy);
                            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = Convert.ToInt32(objSalesOrder_Trans.ModifiedBy);

                            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                            cmd.CommandText = "SP_InsertUpadte_In_Glb_SalesOrderLineItems";
                            cmd.ExecuteNonQuery();

                            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();
                        }
                        catch
                        {
                            IsSaved = "NO";
                            sqltran.Rollback("SO");
                            return IsSaved;
                        }
                    }
                }
            }
            else if (IsSaved == "NO")
            {
                sqltran.Rollback("SO");
            }
            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("SO");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("SO");
            return IsSaved;
        }
    }        

    public string InsertUpdate_In_Sal_Glb_RollAllocationDeallocation_Tran(RollAllocationDeallocation objRollAllocationDeallocation)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of GoodsReceipt

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objRollAllocationDeallocation.Year;
            if (objRollAllocationDeallocation.IssueDate != "")
            {
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = objRollAllocationDeallocation.IssueDate;
            }
            else
            {
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = objRollAllocationDeallocation.SalesOrderId;
            cmd.Parameters.Add("@Invoiceid", SqlDbType.Int).Value = objRollAllocationDeallocation.Invoiceid;
            cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = objRollAllocationDeallocation.CustomerId;
            cmd.Parameters.Add("@AllocationType", SqlDbType.VarChar).Value = objRollAllocationDeallocation.AllocationType;

            cmd.Parameters.AddWithValue("@dtLineitems", objRollAllocationDeallocation.dtLineItems);
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objRollAllocationDeallocation.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objRollAllocationDeallocation.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Sal_Glb_RollAllocationDeallocation_Tran";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string InsertUpdate_In_Sal_PackingCreation_Tran(PackingListCreation objPackingListCreation)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of GoodsReceipt

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dtLineitems", objPackingListCreation.dtLineItems);
            cmd.Parameters.AddWithValue("@dtToUpdateRADForPacking", objPackingListCreation.dtToUpdateRADForPacking);

            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objPackingListCreation.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objPackingListCreation.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Sal_PackingCreation_Tran";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }    

    public int Insert_In_Sal_Glb_MaterialReturnNote_Tran(MaterialReturnNote objMaterialReturnNote)
    {
        return (int)ExecuteNonQuery(SP_Insert_In_Sal_Glb_MaterialReturnNote_Tran, new object[] { objMaterialReturnNote.Year, objMaterialReturnNote.MRNNo,
        objMaterialReturnNote.MRNDate,objMaterialReturnNote.InvoiceId,objMaterialReturnNote.SalesOrderId,objMaterialReturnNote.Customer,objMaterialReturnNote.InventoryId,objMaterialReturnNote.RollNo,
        objMaterialReturnNote.SubFilmTypeId,objMaterialReturnNote.Micron,objMaterialReturnNote.Width,objMaterialReturnNote.Length,objMaterialReturnNote.Core,
        objMaterialReturnNote.Weight,objMaterialReturnNote.CreatedBy,objMaterialReturnNote.ModifiedBy});
    }

    public string InsertUpdate_In_Sal_Glb_CreditDebitNote_Tran(CreditDebitNoteProposal_Tran objCreditDebitNoteProposal_Tran)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CBNId", SqlDbType.Int).Value = objCreditDebitNoteProposal_Tran.CBNId;
            cmd.Parameters.Add("@CreditDebit", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.CreditDebit;
            cmd.Parameters.Add("@SalesTypeId", SqlDbType.Int).Value = objCreditDebitNoteProposal_Tran.SalesTypeId;
            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.Year;
            cmd.Parameters.Add("@CRDBProposalNo", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.CRDBProposalNo;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = objCreditDebitNoteProposal_Tran.Date;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.Type;
            cmd.Parameters.Add("@MRNNo", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.MRNNo;
            cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = objCreditDebitNoteProposal_Tran.CustomerId;
            cmd.Parameters.Add("@DocumentNo", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.DocumentNo;
            if (objCreditDebitNoteProposal_Tran.DocumentDate != "")
            {
                cmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime).Value = objCreditDebitNoteProposal_Tran.DocumentDate;
            }
            else
            {
                cmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@From", SqlDbType.DateTime).Value = objCreditDebitNoteProposal_Tran.From;
            cmd.Parameters.Add("@To", SqlDbType.DateTime).Value = objCreditDebitNoteProposal_Tran.To;
            cmd.Parameters.Add("@Preamble", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.Preamble;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.Remarks;
            cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = objCreditDebitNoteProposal_Tran.Value;
            cmd.Parameters.Add("@Vat", SqlDbType.Float).Value = objCreditDebitNoteProposal_Tran.Vat;
            cmd.Parameters.Add("@GrandTotal", SqlDbType.Float).Value = objCreditDebitNoteProposal_Tran.GrandTotal;
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objCreditDebitNoteProposal_Tran.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objCreditDebitNoteProposal_Tran.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objCreditDebitNoteProposal_Tran.ModifiedBy;

            cmd.Parameters.Add("@NewCBNId", SqlDbType.Int);
            cmd.Parameters["@NewCBNId"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "Sp_InsertUpdate_In_Sal_Glb_CreditDebitNote_Header";
            cmd.ExecuteNonQuery();

            string NewCBNId = cmd.Parameters["@NewCBNId"].Value.ToString();
            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Insert/Update record of line item

            if (IsSaved == "YES")
            {
                DataTable dt = objCreditDebitNoteProposal_Tran.dtCDNPLineItems;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = objConnectionClass.PolypexSqlConnection;
                        cmd.Transaction = sqltran;
                        cmd.CommandTimeout = 60;
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            cmd.Parameters.Add("@CBNLineItemId", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["CBNLineItemId"].ToString());
                            if (objCreditDebitNoteProposal_Tran.CBNId == 0)
                            {
                                cmd.Parameters.Add("@CBNId", SqlDbType.Int).Value = Convert.ToInt32(NewCBNId);
                            }
                            else
                            {
                                cmd.Parameters.Add("@CBNId", SqlDbType.Int).Value = Convert.ToInt32(objCreditDebitNoteProposal_Tran.CBNId);
                            }
                            cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["InvoiceId"].ToString());
                            cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["SalesOrderId"].ToString());
                            cmd.Parameters.Add("@SOLineItemId", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["SOLineItemId"].ToString());
                            cmd.Parameters.Add("@SubFilmTypeId", SqlDbType.VarChar).Value = Convert.ToInt32(dt.Rows[i]["SubFilmTypeId"].ToString());
                            cmd.Parameters.Add("@Micron", SqlDbType.VarChar).Value = dt.Rows[i]["Micron"].ToString();
                            cmd.Parameters.Add("@Core", SqlDbType.VarChar).Value = dt.Rows[i]["Core"].ToString();
                            cmd.Parameters.Add("@WidthInMM", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["WidthInMM"].ToString());
                            cmd.Parameters.Add("@LengthInMtr", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["LengthInMtr"].ToString());
                            cmd.Parameters.Add("@UnitPrice", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["UnitPrice"].ToString());
                            cmd.Parameters.Add("@ReqQuantityInKG", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["ReqQuantityInKG"].ToString());
                            cmd.Parameters.Add("@Currency", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["Currency"].ToString());
                            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["Rate"].ToString());
                            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["Amount"].ToString());
                            cmd.Parameters.Add("@VatAmount", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["VatAmount"].ToString());
                            cmd.Parameters.Add("@NetAmount", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["NetAmount"].ToString());
                            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = dt.Rows[i]["Description"].ToString();
                            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = Convert.ToBoolean(dt.Rows[i]["ActiveStatus"].ToString());
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = Convert.ToInt32(objCreditDebitNoteProposal_Tran.CreatedBy);
                            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = Convert.ToInt32(objCreditDebitNoteProposal_Tran.ModifiedBy);

                            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                            cmd.CommandText = "Sp_InsertUpdate_In_Sal_Glb_CreditDebitNote_LineItems";
                            cmd.ExecuteNonQuery();

                            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();
                        }
                        catch
                        {
                            IsSaved = "NO";
                            sqltran.Rollback("SO");
                            return IsSaved;
                        }
                    }
                }
            }
            else if (IsSaved == "NO")
            {
                sqltran.Rollback("SO");
            }
            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }


    }

    public int InsertRollIssuedForRollsInternalTransfer(RollsInternalTransfer objRollsInternalTransfer)
    {
        return (int)ExecuteNonQuery(Sp_InsertInRollsInternalTransfer, new object[] {
      
        objRollsInternalTransfer.Year,  
        objRollsInternalTransfer.IssueDate ,
        objRollsInternalTransfer.TransferNo,
        objRollsInternalTransfer.TransferFromPlantId,
        objRollsInternalTransfer.TransferToPlantId,
        objRollsInternalTransfer.InventoryId,
        objRollsInternalTransfer.RollNo,
        objRollsInternalTransfer.SubFilmTypeId,
        objRollsInternalTransfer.Micron,
        objRollsInternalTransfer.Core,
        objRollsInternalTransfer.Width,
        objRollsInternalTransfer.Length,
        objRollsInternalTransfer.Weight,
        objRollsInternalTransfer.ActiveStatus,
        objRollsInternalTransfer.CreatedBy,
        objRollsInternalTransfer.ModifiedBy        
        });
    }

    public int InsertInSalesOrderClosing(SalesOrderClosing objSalesOrderClosing)
    {
        return (int)ExecuteNonQuery(Sp_InsertInSalesOrderClosing, new object[] {
        objSalesOrderClosing.OrderTypeId,
        objSalesOrderClosing.SearchTypeId,
        objSalesOrderClosing.PISONo,
        objSalesOrderClosing.OrderDate,
        objSalesOrderClosing.PIOrderNo,
        objSalesOrderClosing.Confirmed,
        objSalesOrderClosing.CustomerOrderNo,
        objSalesOrderClosing.CustomerId,
        objSalesOrderClosing.Reason,              
        objSalesOrderClosing.ActiveStatus,
        objSalesOrderClosing.CreatedBy,
        objSalesOrderClosing.ModifiedBy        
        });
    }

    public int InsertUpadte_In_FA_Glb_CreditDebitNoteForm_Trans(FA_CreaditDebitNoteForm objFA_CreaditDebitNoteForm)
    {
        return (int)ExecuteNonQuery(SP_InsertUpadte_In_FA_Glb_CreditDebitNoteForm_Trans, new object[] {

           objFA_CreaditDebitNoteForm.CDNId,
           objFA_CreaditDebitNoteForm.CBDBProposalId,
           objFA_CreaditDebitNoteForm.CreditDebit,
           objFA_CreaditDebitNoteForm.SalesTypeId,
           objFA_CreaditDebitNoteForm.Year, 
           objFA_CreaditDebitNoteForm.CRDBNo,
           objFA_CreaditDebitNoteForm.Date, 
           objFA_CreaditDebitNoteForm.Type, 
           objFA_CreaditDebitNoteForm.CurrencyId, 
           objFA_CreaditDebitNoteForm.Description, 
           objFA_CreaditDebitNoteForm.CustomerID, 
           objFA_CreaditDebitNoteForm.ProfitCenter, 
           objFA_CreaditDebitNoteForm.SalesAmount, 
           objFA_CreaditDebitNoteForm.VATAmount, 
           objFA_CreaditDebitNoteForm.Commission, 
           objFA_CreaditDebitNoteForm.CashDiscount, 
           objFA_CreaditDebitNoteForm.NetAmount, 
           objFA_CreaditDebitNoteForm.NoteToCustomerVendor, 
           objFA_CreaditDebitNoteForm.ActiveStatus, 
           objFA_CreaditDebitNoteForm.CreatedBy,
           objFA_CreaditDebitNoteForm.ModifiedBy                 
        });
    }

    public string InsertUpdate_In_FA_Glb_ItemInventoryInvoice_Tran(FA_InventoryItemInvoice objFA_InventoryItemInvoice)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objFA_InventoryItemInvoice.AutoId;
            cmd.Parameters.Add("@SalesTypeId", SqlDbType.Int).Value = objFA_InventoryItemInvoice.SalesTypeId;
            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objFA_InventoryItemInvoice.Year;
            cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = objFA_InventoryItemInvoice.InvoiceId;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = objFA_InventoryItemInvoice.Date;
            if (objFA_InventoryItemInvoice.DueDate != "")
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = objFA_InventoryItemInvoice.DueDate;
            }
            else
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = objFA_InventoryItemInvoice.CustomerId;
            cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = objFA_InventoryItemInvoice.SalesOrderId;
            cmd.Parameters.Add("@SalesOrderDate", SqlDbType.DateTime).Value = objFA_InventoryItemInvoice.SalesOrderDate;
            cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = objFA_InventoryItemInvoice.CurrencyId;
            cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = objFA_InventoryItemInvoice.ExchangeRate;
            cmd.Parameters.Add("@FixedAmount", SqlDbType.Float).Value = objFA_InventoryItemInvoice.FixedAmount;
            cmd.Parameters.Add("@BaseAmount", SqlDbType.Float).Value = objFA_InventoryItemInvoice.BaseAmount;
            cmd.Parameters.Add("@VatAmount", SqlDbType.Float).Value = objFA_InventoryItemInvoice.VatAmount;
            cmd.Parameters.Add("@NetInvoiceAmount", SqlDbType.Float).Value = objFA_InventoryItemInvoice.NetInvoiceAmount;
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objFA_InventoryItemInvoice.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objFA_InventoryItemInvoice.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objFA_InventoryItemInvoice.ModifiedBy;


            cmd.Parameters.Add("@NewAutoId", SqlDbType.Int);
            cmd.Parameters["@NewAutoId"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpadte_In_FA_Glb_ItemInventoryInvoice_Tran";
            cmd.ExecuteNonQuery();

            string NewAutoId = cmd.Parameters["@NewAutoId"].Value.ToString();
            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Insert/Update record of line item

            if (IsSaved == "YES")
            {
                DataTable dt = objFA_InventoryItemInvoice.dtItemInventory;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = objConnectionClass.PolypexSqlConnection;
                        cmd.Transaction = sqltran;
                        cmd.CommandTimeout = 60;
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            cmd.Parameters.Add("@AutoIdLineNo", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["AutoIdLineNo"].ToString());
                            if (objFA_InventoryItemInvoice.AutoId == 0)
                            {
                                cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = Convert.ToInt32(NewAutoId);
                            }
                            else
                            {
                                cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objFA_InventoryItemInvoice.AutoId;
                            }
                            cmd.Parameters.Add("@MaterialDescription", SqlDbType.VarChar).Value = dt.Rows[i]["MaterialDescription"].ToString();
                            cmd.Parameters.Add("@Quantity", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["Quantity"].ToString());
                            cmd.Parameters.Add("@UOM", SqlDbType.VarChar).Value = dt.Rows[i]["UOM"].ToString();
                            cmd.Parameters.Add("@MaterialCost", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["MaterialCost"].ToString());
                            cmd.Parameters.Add("@SaleRate", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["SaleRate"].ToString());
                            if (dt.Rows[i]["ActiveStatus"].ToString() != "")
                            {
                                cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = dt.Rows[i]["ActiveStatus"].ToString();
                            }
                            else
                            {
                                cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = 1;
                            }
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objFA_InventoryItemInvoice.CreatedBy;
                            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objFA_InventoryItemInvoice.ModifiedBy;

                            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                            cmd.CommandText = "SP_InsertUpadte_In_FA_Glb_ItemInventoryInvoiceLineItem_Tran";
                            cmd.ExecuteNonQuery();

                            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();
                        }
                        catch
                        {
                            IsSaved = "NO";
                            sqltran.Rollback("Transaction");
                            return IsSaved;
                        }
                    }
                }
            }
            else if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }
    }

    public int InsertRollIssuedForStockLotReservation(SAL_StockLotReservation objSAL_StockLotReservation)
    {
        return (int)ExecuteNonQuery(Sp_InsertIn_Sal_Glb_StockLotRollReservation_Tran, new object[] {
      
        objSAL_StockLotReservation.InventoryId,  
        objSAL_StockLotReservation.SalesOrderId,
        objSAL_StockLotReservation.LineNo,       
        objSAL_StockLotReservation.CustomerId,
        objSAL_StockLotReservation.RollNo,
        objSAL_StockLotReservation.SubFilmTypeId,
        objSAL_StockLotReservation.Micron,
        objSAL_StockLotReservation.Width ,
        objSAL_StockLotReservation.Length,
        objSAL_StockLotReservation.Core,
        objSAL_StockLotReservation.Weight,
        objSAL_StockLotReservation.IS_Pac,
        objSAL_StockLotReservation.Is_Date,       
        objSAL_StockLotReservation.ftype,       
        objSAL_StockLotReservation.CreatedBy,
        objSAL_StockLotReservation.ModifiedBy,
        objSAL_StockLotReservation.ActiveStatus,
        objSAL_StockLotReservation.IsValueExistInRAD 
        });
    }
    //lalit
    public int InsertRollIssuedForRollReservation(Prod_ReservationRoll objSAL_StockLotReservation)
    {
        return (int)ExecuteNonQuery(Sp_InsertIn_Prod_Glb_RollReservation_Tran, new object[] {
      
        objSAL_StockLotReservation.InventoryId,  
        objSAL_StockLotReservation.SalesOrderId,
        objSAL_StockLotReservation.LineNo,       
        objSAL_StockLotReservation.CustomerId,
        objSAL_StockLotReservation.RollNo,
        objSAL_StockLotReservation.SubFilmTypeId,
        objSAL_StockLotReservation.Micron,
        objSAL_StockLotReservation.Width ,
        objSAL_StockLotReservation.Length,
        objSAL_StockLotReservation.Core,
        objSAL_StockLotReservation.Weight,
        objSAL_StockLotReservation.IS_Pac,
        objSAL_StockLotReservation.Is_Date,       
        objSAL_StockLotReservation.ftype,       
        objSAL_StockLotReservation.CreatedBy,
        objSAL_StockLotReservation.ModifiedBy,
        objSAL_StockLotReservation.ActiveStatus,
        objSAL_StockLotReservation.IsValueExistInRAD 
        });
    }

    #endregion

    #region Production

    public string InsertAndUpdate_In_Prod_Glb_MainDetails_Trans(Prod_PetJumbo_Tran objProd_PetJumbo_Tran)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");

            #region Insert/Update Records Of MainDetailsTab

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Year;
            cmd.Parameters.Add("@LineId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.LineId;
            if (objProd_PetJumbo_Tran.JumboDate != "")
            {
                cmd.Parameters.Add("@JumboDate", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.JumboDate;
            }
            else
            {
                cmd.Parameters.Add("@JumboDate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@ShiftId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.ShiftId;
            if (objProd_PetJumbo_Tran.DateIn != "")
            {
                cmd.Parameters.Add("@DateIn", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.DateIn;
            }
            else
            {
                cmd.Parameters.Add("@DateIn", SqlDbType.VarChar).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@TimeIn", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TimeIn;
            if (objProd_PetJumbo_Tran.DateOut != "")
            {
                cmd.Parameters.Add("@DateOut", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.DateOut;
            }
            else
            {
                cmd.Parameters.Add("@DateOut", SqlDbType.VarChar).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@TimeOut", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TimeOut;
            cmd.Parameters.Add("@RawMaterial", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.RawMaterial;
            cmd.Parameters.Add("@ThicknessId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.ThicknessId;
            cmd.Parameters.Add("@SubFilmTypeId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.SubFilmTypeId;
            cmd.Parameters.Add("@RunNo", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.RunNo;
            cmd.Parameters.Add("@GradeId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.GradeId;
            cmd.Parameters.Add("@BreakNo", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.BreakNo;
            cmd.Parameters.Add("@ElectrodKW1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ElectrodKW1;
            cmd.Parameters.Add("@AvgGuage", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.AvgGuage;
            cmd.Parameters.Add("@CoreNo", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoreNo;
            cmd.Parameters.Add("@OsicllationWidth", SqlDbType.Float).Value = objProd_PetJumbo_Tran.OsicllationWidth;
            cmd.Parameters.Add("@ElectrodKW2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ElectrodKW2;
            cmd.Parameters.Add("@FinalWidth", SqlDbType.Float).Value = objProd_PetJumbo_Tran.FinalWidth;
            cmd.Parameters.Add("@Length", SqlDbType.Float).Value = objProd_PetJumbo_Tran.Length;
            cmd.Parameters.Add("@Joint", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Joint;
            cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = objProd_PetJumbo_Tran.Weight;
            cmd.Parameters.Add("@FrictionS", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.FrictionS;
            cmd.Parameters.Add("@FrictionK", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.FrictionK;
            cmd.Parameters.Add("@ELMDLeft", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELMDLeft;
            cmd.Parameters.Add("@ELMDCenter", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELMDCenter;
            cmd.Parameters.Add("@ELMDRight", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELMDRight;
            cmd.Parameters.Add("@ELMDMainThick", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELMDMainThick;
            cmd.Parameters.Add("@ELTDLeft", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELTDLeft;
            cmd.Parameters.Add("@ELTDCenter", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELTDCenter;
            cmd.Parameters.Add("@ELTDRight", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELTDRight;
            cmd.Parameters.Add("@ELTDCoexThick", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ELTDCoexThick;
            cmd.Parameters.Add("@TSMDLeft", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSMDLeft;
            cmd.Parameters.Add("@TSMDCenter", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSMDCenter;
            cmd.Parameters.Add("@TSMDRight", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSMDRight;
            cmd.Parameters.Add("@TSMDMainRPM", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSMDMainRPM;
            cmd.Parameters.Add("@TSTDLeft", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSTDLeft;
            cmd.Parameters.Add("@TSTDCenter", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSTDCenter;
            cmd.Parameters.Add("@TSTDRight", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSTDRight;
            cmd.Parameters.Add("@TSTDCoexRPM", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TSTDCoexRPM;
            cmd.Parameters.Add("@Haze1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Haze1;
            cmd.Parameters.Add("@Haze2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Haze2;
            cmd.Parameters.Add("@TapeTestSideCoated", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TapeTestSideCoated;
            cmd.Parameters.Add("@BothSide", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.BothSide;
            cmd.Parameters.Add("@BreakDownVoltage", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.BreakDownVoltage;
            cmd.Parameters.Add("@DynamicMin", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.DynamicMin;
            cmd.Parameters.Add("@DynamicMax", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.DynamicMax;
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_PetJumbo_Tran.ActiveStatus;
            cmd.Parameters.Add("@PetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PetJumboId;
            cmd.Parameters.Add("@IntermediatePetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.IntermediatePetJumboId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.ModifiedBy;

            cmd.Parameters.Add("@NewPetJumboId", SqlDbType.Int);
            cmd.Parameters["@NewPetJumboId"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Prod_Glb_PetJumbo_MainDetails_Trans";
            cmd.ExecuteNonQuery();

            string NewPetJumboId = cmd.Parameters["@NewPetJumboId"].Value.ToString();
            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Insert/Update Records Of ShrinkPolrisedTab And Other Tabs

            if (IsSaved == "YES")
            {
                try
                {
                    cmd = new SqlCommand();
                    cmd.Connection = objConnectionClass.PolypexSqlConnection;
                    cmd.Transaction = sqltran;
                    cmd.CommandTimeout = 60;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ShrinkPolarisedID", SqlDbType.Int).Value = objProd_PetJumbo_Tran.ShrinkPolarisedID;

                    if (objProd_PetJumbo_Tran.PetJumboId == 0)
                    {
                        cmd.Parameters.Add("@PetJumboId", SqlDbType.Int).Value = Convert.ToInt32(NewPetJumboId);
                    }
                    else
                    {
                        cmd.Parameters.Add("@PetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PetJumboId;
                    }
                    cmd.Parameters.Add("@IntermediatePetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.IntermediatePetJumboId;
                    cmd.Parameters.Add("@PeakToPeak", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PeakToPeak;
                    cmd.Parameters.Add("@F5MDAvg", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.F5MDAvg;
                    cmd.Parameters.Add("@F5TDAvg", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.F5TDAvg;
                    cmd.Parameters.Add("@CDSpread", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CDSpread;
                    cmd.Parameters.Add("@YoungModulesMD", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.YoungModulesMD;
                    cmd.Parameters.Add("@F5MDLeft", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.F5MDLeft;
                    cmd.Parameters.Add("@F5MDRight", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.F5MDRight;
                    cmd.Parameters.Add("@YoungModulesTD", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.YoungModulesTD;
                    cmd.Parameters.Add("@F5MDCenter", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.F5MDCenter;
                    cmd.Parameters.Add("@MDL", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MDL;
                    cmd.Parameters.Add("@MDC", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MDC;
                    cmd.Parameters.Add("@MDR", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MDR;
                    cmd.Parameters.Add("@TDL", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TDL;
                    cmd.Parameters.Add("@TDC", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TDC;
                    cmd.Parameters.Add("@TDR", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TDR;
                    cmd.Parameters.Add("@PolarisedCode1", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PolarisedCode1;
                    cmd.Parameters.Add("@PolarisedTotal1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedTotal1;
                    cmd.Parameters.Add("@PolarisedCenter1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedCenter1;
                    cmd.Parameters.Add("@PolarisedRight1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedRight1;
                    cmd.Parameters.Add("@PolarisedCode2", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PolarisedCode2;
                    cmd.Parameters.Add("@PolarisedLeft2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedLeft2;
                    cmd.Parameters.Add("@PolarisedCenter2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedCenter2;
                    cmd.Parameters.Add("@PolarisedRight2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedRight2;
                    cmd.Parameters.Add("@PolarisedCode3", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PolarisedCode3;
                    cmd.Parameters.Add("@PolarisedLeft3", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedLeft3;
                    cmd.Parameters.Add("@PolarisedCenter3", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedCenter3;
                    cmd.Parameters.Add("@PolarisedRight3", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedRight3;
                    cmd.Parameters.Add("@PolarisedCode4", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PolarisedCode4;
                    cmd.Parameters.Add("@PolarisedLeft4", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedLeft4;
                    cmd.Parameters.Add("@PolarisedCenter4", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedCenter4;
                    cmd.Parameters.Add("@PolarisedRight4", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.PolarisedRight4;
                    cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_PetJumbo_Tran.ActiveStatus;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.CreatedBy;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.ModifiedBy;

                    cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                    cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                    cmd.CommandText = "SP_InsertAndUpdate_In_Prod_Glb_PetJumbo_ShrinkPolariseCode_Trans";
                    cmd.ExecuteNonQuery();

                    IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

                    if (IsSaved == "YES")
                    {
                        #region Insert/Update Records Of JumboQualityAnalysisTab

                        cmd = new SqlCommand();
                        cmd.Connection = objConnectionClass.PolypexSqlConnection;
                        cmd.Transaction = sqltran;
                        cmd.CommandTimeout = 60;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@JumboQualityId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.JumboQualityId;

                        if (objProd_PetJumbo_Tran.PetJumboId == 0)
                        {
                            cmd.Parameters.Add("@PetJumboId", SqlDbType.Int).Value = Convert.ToInt32(NewPetJumboId);
                        }
                        else
                        {
                            cmd.Parameters.Add("@PetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PetJumboId;
                        }
                        cmd.Parameters.Add("@IntermediatePetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.IntermediatePetJumboId;
                        cmd.Parameters.Add("@Unflush", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Unflush;
                        cmd.Parameters.Add("@RoughCutting", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.RoughCutting;
                        cmd.Parameters.Add("@Telescoping", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Telescoping;
                        cmd.Parameters.Add("@LooseWinding", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.LooseWinding;
                        cmd.Parameters.Add("@WindVariation", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.WindVariation;
                        cmd.Parameters.Add("@TrimInside", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TrimInside;
                        cmd.Parameters.Add("@FoldInside", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.FoldInside;
                        cmd.Parameters.Add("@TrimCut", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TrimCut;
                        cmd.Parameters.Add("@WrinklesInTop", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.WrinklesInTop;
                        cmd.Parameters.Add("@WrinklesInButtom", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.WrinklesInButtom;
                        cmd.Parameters.Add("@HardRipplesonTop", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.HardRipplesonTop;
                        cmd.Parameters.Add("@HardRipplesinBetween", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.HardRipplesinBetween;
                        cmd.Parameters.Add("@AccrossFullWidthScratch", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.AccrossFullWidthScratch;
                        cmd.Parameters.Add("@OnlyinSomePortionScratch", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.OnlyinSomePortionScratch;
                        cmd.Parameters.Add("@AccrossFullWidthHT", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.AccrossFullWidthHT;
                        cmd.Parameters.Add("@OnlyinSomePortionHT", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.OnlyinSomePortionHT;
                        cmd.Parameters.Add("@DieResetJumbo", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.DieResetJumbo;
                        cmd.Parameters.Add("@NegativeBandVisibleonWinder", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.NegativeBandVisibleonWinder;
                        cmd.Parameters.Add("@GuageBandVisibleonWinder", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.GuageBandVisibleonWinder;
                        cmd.Parameters.Add("@ProcessConditionChanged", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ProcessConditionChanged;
                        cmd.Parameters.Add("@ShadeVariation", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ShadeVariation;
                        cmd.Parameters.Add("@DifferentMicrons", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.DifferentMicrons;
                        cmd.Parameters.Add("@CoatedUncoated", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoatedUncoated;
                        cmd.Parameters.Add("@CoronaPlan", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoronaPlan;
                        cmd.Parameters.Add("@BlackDustParticle", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.BlackDustParticle;
                        cmd.Parameters.Add("@Gels", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Gels;
                        cmd.Parameters.Add("@UnmoltenParticle", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.UnmoltenParticle;
                        cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_PetJumbo_Tran.ActiveStatus;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.CreatedBy;
                        cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.ModifiedBy;

                        cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                        cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                        cmd.CommandText = "SP_InsertAndUpdate_In_Prod_Glb_PetJumbo_JumboQualityAnalysis_Trans";
                        cmd.ExecuteNonQuery();

                        IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

                        if (IsSaved == "YES")
                        {
                            #region Insert/Update Records Of OtherDetailsTab

                            cmd = new SqlCommand();
                            cmd.Connection = objConnectionClass.PolypexSqlConnection;
                            cmd.Transaction = sqltran;
                            cmd.CommandTimeout = 60;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@OtherDetailsId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.OtherDetailsId;

                            if (objProd_PetJumbo_Tran.PetJumboId == 0)
                            {
                                cmd.Parameters.Add("@PetJumboId", SqlDbType.Int).Value = Convert.ToInt32(NewPetJumboId);
                            }
                            else
                            {
                                cmd.Parameters.Add("@PetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.PetJumboId;
                            }
                            cmd.Parameters.Add("@IntermediatePetJumboId", SqlDbType.Int).Value = objProd_PetJumbo_Tran.IntermediatePetJumboId;
                            cmd.Parameters.Add("@Remarks1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Remarks1;
                            cmd.Parameters.Add("@Remarks2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.Remarks2;
                            cmd.Parameters.Add("@JumboPlannedUnplanned", SqlDbType.Bit).Value = objProd_PetJumbo_Tran.JumboPlannedUnplanned;
                            cmd.Parameters.Add("@ReasonforUnplanned", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.ReasonforUnplanned;
                            cmd.Parameters.Add("@TrimWeightpermtr", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.TrimWeightpermtr;
                            cmd.Parameters.Add("@JumboExtrusionQty", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.JumboExtrusionQty;
                            cmd.Parameters.Add("@MainSiloMaterialCode1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MainSiloMaterialCode1;
                            cmd.Parameters.Add("@MainSiloPercentage1", SqlDbType.Float).Value = objProd_PetJumbo_Tran.MainSiloPercentage1;
                            cmd.Parameters.Add("@MainSiloGrade1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MainSiloGrade1;
                            cmd.Parameters.Add("@MainSiloVendor1", SqlDbType.Int).Value = objProd_PetJumbo_Tran.MainSiloVendor1;
                            cmd.Parameters.Add("@CoexMaterialCode1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoexMaterialCode1;
                            cmd.Parameters.Add("@CoexPercentage1", SqlDbType.Float).Value = objProd_PetJumbo_Tran.CoexPercentage1;
                            cmd.Parameters.Add("@CoexGrade1", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoexGrade1;
                            cmd.Parameters.Add("@CoexVendor1", SqlDbType.Int).Value = objProd_PetJumbo_Tran.CoexVendor1;
                            cmd.Parameters.Add("@MainSiloMaterialCode2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MainSiloMaterialCode2;
                            cmd.Parameters.Add("@MainSiloPercentage2", SqlDbType.Float).Value = objProd_PetJumbo_Tran.MainSiloPercentage2;
                            cmd.Parameters.Add("@MainSiloGrade2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MainSiloGrade2;
                            cmd.Parameters.Add("@MainSiloVendor2", SqlDbType.Int).Value = objProd_PetJumbo_Tran.MainSiloVendor2;
                            cmd.Parameters.Add("@CoexMaterialCode2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoexMaterialCode2;
                            cmd.Parameters.Add("@CoexPercentage2", SqlDbType.Float).Value = objProd_PetJumbo_Tran.CoexPercentage2;
                            cmd.Parameters.Add("@CoexGrade2", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoexGrade2;
                            cmd.Parameters.Add("@CoexVendor2", SqlDbType.Int).Value = objProd_PetJumbo_Tran.CoexVendor2;
                            cmd.Parameters.Add("@MainSiloMaterialCode3", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MainSiloMaterialCode3;
                            cmd.Parameters.Add("@MainSiloPercentage3", SqlDbType.Float).Value = objProd_PetJumbo_Tran.MainSiloPercentage3;
                            cmd.Parameters.Add("@MainSiloGrade3", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.MainSiloGrade3;
                            cmd.Parameters.Add("@MainSiloVendor3", SqlDbType.Int).Value = objProd_PetJumbo_Tran.MainSiloVendor3;
                            cmd.Parameters.Add("@CoexMaterialCode3", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoexMaterialCode3;
                            cmd.Parameters.Add("@CoexPercentage3", SqlDbType.Float).Value = objProd_PetJumbo_Tran.CoexPercentage3;
                            cmd.Parameters.Add("@CoexGrade3", SqlDbType.VarChar).Value = objProd_PetJumbo_Tran.CoexGrade3;
                            cmd.Parameters.Add("@CoexVendor3", SqlDbType.Int).Value = objProd_PetJumbo_Tran.CoexVendor3;

                            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_PetJumbo_Tran.ActiveStatus;
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.CreatedBy;
                            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProd_PetJumbo_Tran.ModifiedBy;

                            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                            cmd.CommandText = "SP_InsertAndUpdate_In_Prod_Glb_PetJumbo_OtherDetails_Trans";
                            cmd.ExecuteNonQuery();

                            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

                            #endregion
                        }
                        else if (IsSaved == "NO")
                        {
                            sqltran.Rollback("Transaction");
                        }

                        #endregion
                    }
                    else if (IsSaved == "NO")
                    {
                        sqltran.Rollback("Transaction");
                    }
                }
                catch
                {
                    IsSaved = "NO";
                    sqltran.Rollback("Transaction");
                    return IsSaved;
                }
            }
            else if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }
    }

    public string Insert_In_Prod_Glb_RollRecoveryFromMRN_Tran(Prod_RollRecoveryFromMRN objProd_RollRecoveryFromMRN)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");

            #region Insert/Update record of line item

            DataTable dt = objProd_RollRecoveryFromMRN.dtRollsRecoveryMRN;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = objConnectionClass.PolypexSqlConnection;
                    cmd.Transaction = sqltran;
                    cmd.CommandTimeout = 60;
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {

                        cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objProd_RollRecoveryFromMRN.Year;
                        cmd.Parameters.Add("@MaterialReturnId", SqlDbType.Int).Value = Convert.ToInt32(objProd_RollRecoveryFromMRN.MaterialReturnId);
                        if (objProd_RollRecoveryFromMRN.MRNDate != "")
                        {
                            cmd.Parameters.Add("@MRNDate", SqlDbType.DateTime).Value = objProd_RollRecoveryFromMRN.MRNDate;
                        }
                        else
                        {
                            cmd.Parameters.Add("@MRNDate", SqlDbType.DateTime).Value = DBNull.Value;
                        }
                        if (objProd_RollRecoveryFromMRN.RecoverDate != "")
                        {
                            cmd.Parameters.Add("@RecoverDate", SqlDbType.DateTime).Value = objProd_RollRecoveryFromMRN.RecoverDate;
                        }
                        else
                        {
                            cmd.Parameters.Add("@RecoverDate", SqlDbType.DateTime).Value = DBNull.Value;
                        }
                        cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = Convert.ToInt32(objProd_RollRecoveryFromMRN.InvoiceId);
                        cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = Convert.ToInt32(objProd_RollRecoveryFromMRN.SalesOrderId);
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = Convert.ToInt32(objProd_RollRecoveryFromMRN.CustomerId);
                        cmd.Parameters.Add("@InventoryId", SqlDbType.Int).Value = Convert.ToInt32(objProd_RollRecoveryFromMRN.InventoryId);
                        cmd.Parameters.Add("@RollNo", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["RollNo"].ToString());
                        cmd.Parameters.Add("@SubFilmTypeId", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["SubFilmTypeId"].ToString());
                        cmd.Parameters.Add("@Micron", SqlDbType.VarChar).Value = dt.Rows[i]["Micron"].ToString();
                        cmd.Parameters.Add("@Width", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[i]["Width"].ToString());
                        cmd.Parameters.Add("@Length", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["Length"].ToString());
                        cmd.Parameters.Add("@Core", SqlDbType.VarChar).Value = dt.Rows[i]["Core"].ToString();
                        cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = Convert.ToDouble(dt.Rows[i]["Weight"].ToString());
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Convert.ToBoolean(objProd_RollRecoveryFromMRN.IsActive);
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = Convert.ToInt32(objProd_RollRecoveryFromMRN.CreatedBy);

                        cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
                        cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

                        cmd.CommandText = "SP_Insert_In_Prod_Glb_RollRecoveryFromMRN_Tran";
                        cmd.ExecuteNonQuery();
                        IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

                        if (IsSaved == "NO")
                        {
                            sqltran.Rollback("Transaction");
                            return IsSaved;
                        }
                    }
                    catch
                    {
                        IsSaved = "NO";
                        sqltran.Rollback("Transaction");
                        return IsSaved;
                    }
                }
            }

            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }
    }

    public string InsertAndUpdate_In_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping(Prod_RollIssueToRecycle_Tran objProd_RollIssueToRecycle_Tran)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");
            #region Insert/Update Records Of MainDetailsTab

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@BatchNo", SqlDbType.Int).Value = objProd_RollIssueToRecycle_Tran.BatchNo;
            if (objProd_RollIssueToRecycle_Tran.Issue_Date != "")
            {
                cmd.Parameters.Add("@Issue_Date", SqlDbType.VarChar).Value = objProd_RollIssueToRecycle_Tran.Issue_Date;
            }
            else
            {
                cmd.Parameters.Add("@Issue_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@Original_Weight_Kg", SqlDbType.Float).Value = objProd_RollIssueToRecycle_Tran.Original_Weight_Kg;
            cmd.Parameters.Add("@Balance_Weight_Kg", SqlDbType.Float).Value = objProd_RollIssueToRecycle_Tran.Balance_Weight_Kg;
            if (objProd_RollIssueToRecycle_Tran.Production_Date != "")
            {
                cmd.Parameters.Add("@Production_Date", SqlDbType.VarChar).Value = objProd_RollIssueToRecycle_Tran.Production_Date;
            }
            else
            {
                cmd.Parameters.Add("@Production_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@Original_Length_Mtr", SqlDbType.Float).Value = objProd_RollIssueToRecycle_Tran.Original_Length_Mtr;
            cmd.Parameters.Add("@Balance_Length_Mtr", SqlDbType.Float).Value = objProd_RollIssueToRecycle_Tran.Balance_Length_Mtr;
            cmd.Parameters.Add("@Issue_Length_Mtr", SqlDbType.Float).Value = objProd_RollIssueToRecycle_Tran.Issue_Length_Mtr;
            cmd.Parameters.Add("@Issue_Qty_Kg", SqlDbType.Float).Value = objProd_RollIssueToRecycle_Tran.Issue_Qty_Kg;
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_RollIssueToRecycle_Tran.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = objProd_RollIssueToRecycle_Tran.CreatedBy;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.VarChar).Value = objProd_RollIssueToRecycle_Tran.LastModifiedBy;
            cmd.Parameters.Add("@AutoID", SqlDbType.VarChar).Value = objProd_RollIssueToRecycle_Tran.AutoID;
            cmd.Parameters.Add("@IntermediateAutoID", SqlDbType.VarChar).Value = objProd_RollIssueToRecycle_Tran.IntermediateAutoID;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping";
            cmd.ExecuteNonQuery();

            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion
            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion
            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }
    }

    public string InsertAndUpdate_In_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping(Prod_JumboIssueToRecycle_Tran objProd_JumboIssueToRecycle_Tran)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");

            #region Insert/Update Records Of MainDetailsTab

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@JumboNo", SqlDbType.Int).Value = objProd_JumboIssueToRecycle_Tran.JumboNo;
            if (objProd_JumboIssueToRecycle_Tran.Issue_Date != "")
            {
                cmd.Parameters.Add("@Issue_Date", SqlDbType.DateTime).Value = objProd_JumboIssueToRecycle_Tran.Issue_Date;
            }
            else
            {
                cmd.Parameters.Add("@Issue_Date", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@Original_Weight_Kg", SqlDbType.Float).Value = objProd_JumboIssueToRecycle_Tran.Original_Weight_Kg;
            cmd.Parameters.Add("@Balance_Weight_Kg", SqlDbType.Float).Value = objProd_JumboIssueToRecycle_Tran.Balance_Weight_Kg;
            if (objProd_JumboIssueToRecycle_Tran.Production_Date != "")
            {
                cmd.Parameters.Add("@Production_Date", SqlDbType.DateTime).Value = objProd_JumboIssueToRecycle_Tran.Production_Date;
            }
            else
            {
                cmd.Parameters.Add("@Production_Date", SqlDbType.DateTime).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@Original_Length_Mtr", SqlDbType.Float).Value = objProd_JumboIssueToRecycle_Tran.Original_Length_Mtr;
            cmd.Parameters.Add("@Balance_Length_Mtr", SqlDbType.Float).Value = objProd_JumboIssueToRecycle_Tran.Balance_Length_Mtr;
            cmd.Parameters.Add("@Recycle_Length_Mtr", SqlDbType.Float).Value = objProd_JumboIssueToRecycle_Tran.Recycle_Length_Mtr;
            cmd.Parameters.Add("@Recycle_Qty_Kg", SqlDbType.Float).Value = objProd_JumboIssueToRecycle_Tran.Recycle_Qty_Kg;
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_JumboIssueToRecycle_Tran.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProd_JumboIssueToRecycle_Tran.CreatedBy;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = objProd_JumboIssueToRecycle_Tran.LastModifiedBy;
            cmd.Parameters.Add("@AutoID", SqlDbType.Int).Value = objProd_JumboIssueToRecycle_Tran.AutoID;
            cmd.Parameters.Add("@IntermediateAutoID", SqlDbType.Int).Value = objProd_JumboIssueToRecycle_Tran.IntermediateAutoID;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping";
            cmd.ExecuteNonQuery();

            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }
    }

    public string InsertAndUpdate_In_Prod_PET_MET_Downtime(Prod_DownTime objProd_DownTime)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");

            #region Insert/Update Records Of MainDetailsTab

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objProd_DownTime.Year;
            cmd.Parameters.Add("@ProcessType", SqlDbType.VarChar).Value = objProd_DownTime.ProcessType;
            cmd.Parameters.Add("@PlantId", SqlDbType.Int).Value = objProd_DownTime.PlantId;
            if (objProd_DownTime.VoucherDate != "")
            {
                cmd.Parameters.Add("@VoucherDate", SqlDbType.DateTime).Value = objProd_DownTime.VoucherDate;
            }
            else
            {
                cmd.Parameters.Add("@VoucherDate", SqlDbType.DateTime).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@LineId", SqlDbType.Int).Value = objProd_DownTime.LineId;
            cmd.Parameters.Add("@AreaId", SqlDbType.Int).Value = objProd_DownTime.AreaId;
            cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = objProd_DownTime.DepartmentId;
            cmd.Parameters.Add("@MachineId", SqlDbType.Int).Value = objProd_DownTime.MachineId;
            cmd.Parameters.Add("@SubMachineId", SqlDbType.Int).Value = objProd_DownTime.SubMachineId;
            cmd.Parameters.Add("@KKTypeId", SqlDbType.Int).Value = objProd_DownTime.KKTypeId;
            cmd.Parameters.Add("@ProblemCodeDescId", SqlDbType.Int).Value = objProd_DownTime.ProblemCodeDescId;
            if (objProd_DownTime.StartDate != "")
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = objProd_DownTime.StartDate;
            }
            else
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@StartTime", SqlDbType.VarChar).Value = objProd_DownTime.StartTime;
            if (objProd_DownTime.EndDate != "")
            {
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = objProd_DownTime.EndDate;
            }
            else
            {
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@EndTime", SqlDbType.VarChar).Value = objProd_DownTime.EndTime;
            cmd.Parameters.Add("@ProcessAffected", SqlDbType.Bit).Value = objProd_DownTime.ProcessAffected;
            cmd.Parameters.Add("@DetailsOfObservation", SqlDbType.VarChar).Value = objProd_DownTime.DetailsOfObservation;

            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_DownTime.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProd_DownTime.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProd_DownTime.ModifiedBy;
            cmd.Parameters.Add("@AutoID", SqlDbType.Int).Value = objProd_DownTime.AutoID;
            cmd.Parameters.Add("@IntermediateAutoID", SqlDbType.Int).Value = objProd_DownTime.IntermediateAutoID;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Prod_PET_MET_Downtime";
            cmd.ExecuteNonQuery();

            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }
    }

    public string InsertAndUpdate_In_Prod_MET_Plant_Feeding(Prod_MetPlantFeeding objProd_MetPlantFeeding)
    {
        try
        {
            objConnectionClass.OpenConnection();
            sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("Transaction");

            #region Insert/Update Records Of MainDetailsTab

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            if (objProd_MetPlantFeeding.Date != "")
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = objProd_MetPlantFeeding.Date;
            }
            else
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@Line", SqlDbType.Int).Value = objProd_MetPlantFeeding.Line;
            cmd.Parameters.Add("@Aluminimum_Wire_Consump_KG", SqlDbType.Float).Value = objProd_MetPlantFeeding.Aluminimum_Wire_Consump_KG;
            cmd.Parameters.Add("@Boats_Consump_KG", SqlDbType.Int).Value = objProd_MetPlantFeeding.Boats_Consump;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = objProd_MetPlantFeeding.Remarks;
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProd_MetPlantFeeding.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProd_MetPlantFeeding.CreatedBy;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = objProd_MetPlantFeeding.LastModifiedBy;
            cmd.Parameters.Add("@AutoID", SqlDbType.Int).Value = objProd_MetPlantFeeding.AutoID;
            cmd.Parameters.Add("@IntermediateAutoID", SqlDbType.Int).Value = objProd_MetPlantFeeding.IntermediateAutoID;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Prod_MET_Plant_Feeding";
            cmd.ExecuteNonQuery();

            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            if (IsSaved == "NO")
            {
                sqltran.Rollback("Transaction");
            }
            else if (IsSaved == "YES")
            {
                sqltran.Commit();
            }
            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            sqltran.Rollback("Transaction");
            return IsSaved;
        }
    }

    #endregion

    #region Procurement

    public string InsertUpdate_In_Proc_ChipsMasterBatch(Proc_ChipsMasterBatch objProc_ChipsMasterBatch)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of ChipsMasterBatch

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objProc_ChipsMasterBatch.Year;
            cmd.Parameters.Add("@ProcessCodeId", SqlDbType.Int).Value = objProc_ChipsMasterBatch.ProcessCodeId;
            cmd.Parameters.Add("@MasterBatchId", SqlDbType.Int).Value = objProc_ChipsMasterBatch.MasterBatchId;

            if (objProc_ChipsMasterBatch.Date != "")
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = objProc_ChipsMasterBatch.Date;
            }
            else
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProc_ChipsMasterBatch.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProc_ChipsMasterBatch.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_ChipsMasterBatch.ModifiedBy;

            cmd.Parameters.Add("@ChipsMasterBatchId", SqlDbType.Int).Value = objProc_ChipsMasterBatch.ChipsMasterBatchId;
            cmd.Parameters.AddWithValue("@dtLineitems", objProc_ChipsMasterBatch.dtLineItems);

            cmd.Parameters.Add(new SqlParameter("@NewChipsMasterBatchId", SqlDbType.Int, 10));
            cmd.Parameters["@NewChipsMasterBatchId"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Proc_ChipsMasterBatch";
            cmd.ExecuteNonQuery();

            string NewChipsMasterBatchId = cmd.Parameters["@NewChipsMasterBatchId"].Value.ToString();
            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            return "NO";
        }
    }

    public string InsertUpdate_In_Proc_ChipsProductionCPBP_Trans(Proc_ChipsProductionCPBP objProc_ChipsProductionCPBP)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of ChipsMasterBatch

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AutoID", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.AutoId;
            cmd.Parameters.Add("@ProcessId", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.ProcessId;
            cmd.Parameters.Add("@Year", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.Year;
            if (objProc_ChipsProductionCPBP.Date != "")
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = objProc_ChipsProductionCPBP.Date;
            }
            else
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (objProc_ChipsProductionCPBP.DateFrom != "")
            {
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = objProc_ChipsProductionCPBP.DateFrom;
            }
            else
            {
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@TimeFrom", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.TimeFrom;
            if (objProc_ChipsProductionCPBP.DateTo != "")
            {
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = objProc_ChipsProductionCPBP.DateTo;
            }
            else
            {
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@TimeTo", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.TimeTo;
            cmd.Parameters.Add("@PTA", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.PTA;
            cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.Quantity;
            cmd.Parameters.Add("@MEG", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.MEG;
            cmd.Parameters.Add("@VirginQuantity", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.VirginQuantity;
            cmd.Parameters.Add("@BatchEG", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.BatchEG;
            cmd.Parameters.Add("@HotWellQuantity", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.HotWellQuantity;
            cmd.Parameters.Add("@ATAATO", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ATAATO;
            cmd.Parameters.Add("@QuantityATA", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityATA;
            cmd.Parameters.Add("@ItemCode1", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode1;
            cmd.Parameters.Add("@QuantityItemCode1", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode1;
            cmd.Parameters.Add("@ItemCode2", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode2;
            cmd.Parameters.Add("@QuantityItemCode2", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode2;
            cmd.Parameters.Add("@ItemCode3", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode3;
            cmd.Parameters.Add("@QuantityItemCode3", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode3;
            cmd.Parameters.Add("@ItemCode4", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode4;
            cmd.Parameters.Add("@QuantityItemCode4", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode4;
            cmd.Parameters.Add("@ItemCode5", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode5;
            cmd.Parameters.Add("@QuantityItemCode5", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode5;
            cmd.Parameters.Add("@ItemCode6", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode6;
            cmd.Parameters.Add("@QuantityItemCode6", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode6;
            cmd.Parameters.Add("@ItemCode7", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode7;
            cmd.Parameters.Add("@QuantityItemCode7", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode7;
            cmd.Parameters.Add("@ItemCode8", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.ItemCode8;
            cmd.Parameters.Add("@QuantityItemCode8", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityItemCode8;
            cmd.Parameters.Add("@OutputCode1", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.OutputCode1;
            cmd.Parameters.Add("@QuantityOutputCode1", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityOutputCode1;
            cmd.Parameters.Add("@OutputCode2", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.OutputCode2;
            cmd.Parameters.Add("@QuantityOutputCode2", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityOutputCode2;
            cmd.Parameters.Add("@OutputCode3", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.OutputCode3;
            cmd.Parameters.Add("@QuantityOutputCode3", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityOutputCode3;
            cmd.Parameters.Add("@OutputCode4", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.OutputCode4;
            cmd.Parameters.Add("@QuantityOutputCode4", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.QuantityOutputCode4;
            cmd.Parameters.Add("@CrudeMEGQuantity", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.CrudeMEGQuantity;
            cmd.Parameters.Add("@Water", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.Water;
            cmd.Parameters.Add("@Lumps", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.Lumps;
            cmd.Parameters.Add("@OverSize", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.OverSize;
            cmd.Parameters.Add("@Residue", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.Residue;
            cmd.Parameters.Add("@PTAWaste", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.PTAWaste;
            cmd.Parameters.Add("@NonUsableChips", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.NonUsableChips;
            cmd.Parameters.Add("@WasteMEG", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.WasteMEG;
            cmd.Parameters.Add("@Silica", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.Silica;
            cmd.Parameters.Add("@Catalyst", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.Catalyst;

            cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.DepartmentId;
            cmd.Parameters.Add("@MachineId", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.MachineId;
            cmd.Parameters.Add("@SubMachineId", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.SubMachineId;
            cmd.Parameters.Add("@KKTypeId", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.KKTypeId;
            cmd.Parameters.Add("@ProblemCodeId", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.ProblemCodeId;
            if (objProc_ChipsProductionCPBP.StartDate != "")
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = objProc_ChipsProductionCPBP.StartDate;
            }
            else
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@StartTime", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.StartTime;
            if (objProc_ChipsProductionCPBP.EndDate != "")
            {
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = objProc_ChipsProductionCPBP.EndDate;
            }
            else
            {
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@EndTime", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.EndTime;
            cmd.Parameters.Add("@ProcessAffected", SqlDbType.Bit).Value = objProc_ChipsProductionCPBP.ProcessAffected;
            cmd.Parameters.Add("@DetailsOfObservation", SqlDbType.VarChar).Value = objProc_ChipsProductionCPBP.DetailsOfObservation;
            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProc_ChipsProductionCPBP.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_ChipsProductionCPBP.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@IsSaved", SqlDbType.VarChar, 10));
            cmd.Parameters["@IsSaved"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertAndUpdate_In_Proc_ChipsProductionCPBP_Trans";
            cmd.ExecuteNonQuery();

            IsSaved = cmd.Parameters["@IsSaved"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return IsSaved;
        }
        catch
        {
            return "NO";
        }
    }

    public string InsertUpdate_In_Proc_GoodsReceipt(Proc_GoodsReceipt objProc_GoodsReceipt)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of GoodsReceipt

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@GRYear", SqlDbType.VarChar).Value = objProc_GoodsReceipt.GRYear;
            cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objProc_GoodsReceipt.AutoId;
            if (objProc_GoodsReceipt.GRDate != "")
            {
                cmd.Parameters.Add("@GRDate", SqlDbType.DateTime).Value = objProc_GoodsReceipt.GRDate;
            }
            else
            {
                cmd.Parameters.Add("@GRDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@POId", SqlDbType.Int).Value = objProc_GoodsReceipt.POId;
            cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = objProc_GoodsReceipt.VendorId;
            cmd.Parameters.Add("@GateEntryNo", SqlDbType.VarChar).Value = objProc_GoodsReceipt.GateEntryNo;
            if (objProc_GoodsReceipt.GateEntryDate != "")
            {
                cmd.Parameters.Add("@GateEntryDate", SqlDbType.DateTime).Value = objProc_GoodsReceipt.GateEntryDate;
            }
            else
            {
                cmd.Parameters.Add("@GateEntryDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@TaxInvoiceNo", SqlDbType.VarChar).Value = objProc_GoodsReceipt.TaxInvoiceNo;
            if (objProc_GoodsReceipt.TaxInvoiceDate != "")
            {
                cmd.Parameters.Add("@TaxInvoiceDate", SqlDbType.DateTime).Value = objProc_GoodsReceipt.TaxInvoiceDate;
            }
            else
            {
                cmd.Parameters.Add("@TaxInvoiceDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@SalesOrder", SqlDbType.VarChar).Value = objProc_GoodsReceipt.SalesOrder;
            cmd.Parameters.Add("@VehicleNo", SqlDbType.VarChar).Value = objProc_GoodsReceipt.VehicleNo;
            if (objProc_GoodsReceipt.DueDate != "")
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = objProc_GoodsReceipt.DueDate;
            }
            else
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@BillofEntryNo", SqlDbType.VarChar).Value = objProc_GoodsReceipt.BillofEntryNo;
            cmd.Parameters.Add("@BillofEntryDate", SqlDbType.VarChar).Value = objProc_GoodsReceipt.BillofEntryDate;
            cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = objProc_GoodsReceipt.ExchangeRate;
            cmd.Parameters.Add("@MaterialCost", SqlDbType.Float).Value = objProc_GoodsReceipt.MaterialCost;
            cmd.Parameters.Add("@VATTotal", SqlDbType.Float).Value = objProc_GoodsReceipt.VATTotal;
            cmd.Parameters.Add("@GIATotalValue", SqlDbType.Float).Value = objProc_GoodsReceipt.GIATotalValue;
            cmd.Parameters.Add("@TotalStockUOM", SqlDbType.Float).Value = objProc_GoodsReceipt.TotalStockUOM;
            cmd.Parameters.Add("@BalanceQuantity", SqlDbType.Float).Value = objProc_GoodsReceipt.BalanceQuantity;
            cmd.Parameters.AddWithValue("@dtLineitems", objProc_GoodsReceipt.dtLineItems);
            cmd.Parameters.AddWithValue("@dtDetailsLineitems", objProc_GoodsReceipt.dtDetailsLineItems);

            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProc_GoodsReceipt.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProc_GoodsReceipt.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_GoodsReceipt.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Proc_GoodsReceipt";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string Update_In_Proc_GoodsReceiptByTaxInvoiceUpdation(Proc_GRTaxInvoiceUpdation objProc_Proc_GRTaxInvoiceUpdation)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of GoodsReceipt

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objProc_Proc_GRTaxInvoiceUpdation.AutoId;
            if (objProc_Proc_GRTaxInvoiceUpdation.TaxInvoiceDate != "")
            {
                cmd.Parameters.Add("@TaxInvoiceDate", SqlDbType.DateTime).Value = objProc_Proc_GRTaxInvoiceUpdation.TaxInvoiceDate;
            }
            else
            {
                cmd.Parameters.Add("@TaxInvoiceDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (objProc_Proc_GRTaxInvoiceUpdation.DueDate != "")
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = objProc_Proc_GRTaxInvoiceUpdation.DueDate;
            }
            else
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_Proc_GRTaxInvoiceUpdation.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_Update_In_Proc_GoodsReceiptByTaxInvoiceUpdation";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string InsertUpdate_In_Proc_ServiceAcceptance(Proc_ServiceAcceptance objProc_ServiceAcceptance)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of GoodsReceipt

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objProc_ServiceAcceptance.AutoId;
            cmd.Parameters.Add("@VoucherYear", SqlDbType.VarChar).Value = objProc_ServiceAcceptance.VoucherYear;
            if (objProc_ServiceAcceptance.VoucherDate != "")
            {
                cmd.Parameters.Add("@VoucherDate", SqlDbType.DateTime).Value = objProc_ServiceAcceptance.VoucherDate;
            }
            else
            {
                cmd.Parameters.Add("@VoucherDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@POId", SqlDbType.Int).Value = objProc_ServiceAcceptance.POId;
            cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = objProc_ServiceAcceptance.VendorId;
            cmd.Parameters.Add("@TaxInvoiceNo", SqlDbType.VarChar).Value = objProc_ServiceAcceptance.TaxInvoiceNo;
            if (objProc_ServiceAcceptance.TaxInvoiceDate != "")
            {
                cmd.Parameters.Add("@TaxInvoiceDate", SqlDbType.DateTime).Value = objProc_ServiceAcceptance.TaxInvoiceDate;
            }
            else
            {
                cmd.Parameters.Add("@TaxInvoiceDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (objProc_ServiceAcceptance.DueDate != "")
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = objProc_ServiceAcceptance.DueDate;
            }
            else
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@TotalPOValue", SqlDbType.Float).Value = objProc_ServiceAcceptance.TotalPOValue;
            cmd.Parameters.Add("@TotalPOFXValue", SqlDbType.Float).Value = objProc_ServiceAcceptance.TotalPOFXValue;
            cmd.Parameters.Add("@VATTotal", SqlDbType.Float).Value = objProc_ServiceAcceptance.VATTotal;
            cmd.Parameters.Add("@GIATotalValue", SqlDbType.Float).Value = objProc_ServiceAcceptance.GIATotalValue;

            cmd.Parameters.AddWithValue("@dtLineitems", objProc_ServiceAcceptance.dtLineItems);

            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProc_ServiceAcceptance.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProc_ServiceAcceptance.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_ServiceAcceptance.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Proc_ServiceAcceptance";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string InsertUpdate_In_Proc_IssueReservation(Proc_IssueReservation objProc_IssueReservation)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of IssueReservation

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objProc_IssueReservation.AutoId;


            cmd.Parameters.Add("@ReservationYear", SqlDbType.VarChar).Value = objProc_IssueReservation.ReservationYear;
            if (objProc_IssueReservation.IssueReservationDate != "")
            {
                cmd.Parameters.Add("@IssueReservationDate", SqlDbType.DateTime).Value = objProc_IssueReservation.IssueReservationDate;
            }
            else
            {
                cmd.Parameters.Add("@IssueReservationDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@CostCenterId", SqlDbType.Int).Value = objProc_IssueReservation.CostCenterId;
            cmd.Parameters.Add("@GoodRecipient", SqlDbType.VarChar).Value = objProc_IssueReservation.GoodRecipient;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = objProc_IssueReservation.Remarks;

            cmd.Parameters.AddWithValue("@dtLineitems", objProc_IssueReservation.dtLineItems);

            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProc_IssueReservation.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProc_IssueReservation.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_IssueReservation.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Proc_IssueReservation";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string InsertUpdate_In_Proc_PostIssueReservation(Proc_PostIssueReservation objProc_PostIssueReservation)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of IssueReservation

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objProc_PostIssueReservation.AutoId;


            cmd.Parameters.Add("@IssueYear", SqlDbType.VarChar).Value = objProc_PostIssueReservation.IssueYear;
            if (objProc_PostIssueReservation.IssueDate != "")
            {
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = objProc_PostIssueReservation.IssueDate;
            }
            else
            {
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@ReservationId", SqlDbType.Int).Value = objProc_PostIssueReservation.ReservationId;
            cmd.Parameters.AddWithValue("@dtLineitems", objProc_PostIssueReservation.dtLineItems);

            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProc_PostIssueReservation.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProc_PostIssueReservation.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_PostIssueReservation.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Proc_PostIssueReservation";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string InsertUpdate_In_Proc_IssueModification(Proc_IssueModification objProc_IssueModification)
    {
        try
        {
            objConnectionClass.OpenConnection();

            #region Insert/Update Records Of IssueReservation

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AutoId", SqlDbType.Int).Value = objProc_IssueModification.AutoId;


            cmd.Parameters.Add("@IssueYear", SqlDbType.VarChar).Value = objProc_IssueModification.IssueYear;
            if (objProc_IssueModification.IssueDate != "")
            {
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = objProc_IssueModification.IssueDate;
            }
            else
            {
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@CostCenterId", SqlDbType.Int).Value = objProc_IssueModification.CostCenterId;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = objProc_IssueModification.Remarks;

            cmd.Parameters.AddWithValue("@dtLineitems", objProc_IssueModification.dtLineItems);

            cmd.Parameters.Add("@ActiveStatus", SqlDbType.Bit).Value = objProc_IssueModification.ActiveStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = objProc_IssueModification.CreatedBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objProc_IssueModification.ModifiedBy;

            cmd.Parameters.Add(new SqlParameter("@ErrorStatus", SqlDbType.Int, 100));
            cmd.Parameters["@ErrorStatus"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_InsertUpdate_In_Proc_IssueModification";
            cmd.ExecuteNonQuery();

            string ErrorStatus = cmd.Parameters["@ErrorStatus"].Value.ToString();

            #endregion

            #region Commit/Rollback Transaction

            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();

            #endregion

            return ErrorStatus;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    #endregion

    #endregion   

    #region***********************Delete Functions********************

    public int Delete_In_Sal_PackingCreation_Tran_For_OrderNo(PackingListCreation objPackingListCreation)
    {
        return (int)ExecuteNonQuery(SP_Delete_In_Sal_PackingCreation_Tran_For_OrderNo, new object[] { objPackingListCreation.SalesOrderId });
    }

    #endregion

    #endregion


    #region FA module
    public BLLCollection<FA_VoucherType> Get_VoucherType()
    {
        return (BLLCollection<FA_VoucherType>)ExecuteReader("Sp_FA_Get_Voucher_All", new object[] { }, new GenerateCollectionFromReader(GeneratVoucherType_mstCollection));
    }
    public CollectionBase GeneratVoucherType_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<FA_VoucherType> col = new BLLCollection<FA_VoucherType>();
        try
        {
            while (returnData.Read())
            {
                FA_VoucherType obj = new FA_VoucherType();
                obj.VoucherType = (string)returnData["VoucherType"];
                obj.Id = (int)(returnData["Id"]);

                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratVoucherType_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<FA_VoucherSeries> Get_VoucherSeries()
    {
        return (BLLCollection<FA_VoucherSeries>)ExecuteReader("Sp_FA_Get_VoucherSeries_All", new object[] { }, new GenerateCollectionFromReader(GeneratVoucherSeries_mstCollection));
    }
    public CollectionBase GeneratVoucherSeries_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<FA_VoucherSeries> col = new BLLCollection<FA_VoucherSeries>();
        try
        {
            while (returnData.Read())
            {
                FA_VoucherSeries obj = new FA_VoucherSeries();
                obj.VoucherSeries = (string)returnData["VoucherSeries"];
                obj.Id = (int)returnData["Id"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratVoucherSeries_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_VendorInvoice> Get_VoucherInvoiceById(string vendorid)
    {
        return (BLLCollection<FA_VendorInvoice>)ExecuteReader("Sp_FA_Get_VendorInvoice_ById", new object[] { vendorid }, new GenerateCollectionFromReader(GeneratVendorInvoice_mstCollection));
    }
    public BLLCollection<FA_VendorInvoice> Get_VoucherInvoiceByInvoiceId(string invoiceno)
    {
        return (BLLCollection<FA_VendorInvoice>)ExecuteReader("Sp_FA_Get_VendorInvoice_ByInvoiceId", new object[] { invoiceno }, new GenerateCollectionFromReader(GeneratVendorInvoice_mstCollection));
    }
    
    public BLLCollection<FA_VendorInvoice> Get_VoucherInvoices(string invoiceno)
    {
        return (BLLCollection<FA_VendorInvoice>)ExecuteReader("Sp_Get_InvoiceNo_FromVendorPayable", new object[] { invoiceno }, new GenerateCollectionFromReader(GeneratVendorInvoicelist_mstCollection));
    }

    public CollectionBase GeneratVendorInvoicelist_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<FA_VendorInvoice> col = new BLLCollection<FA_VendorInvoice>();
        try
        {
            while (returnData.Read())
            {
                FA_VendorInvoice obj = new FA_VendorInvoice();
                obj.InvoiceNo = (int)returnData["InvoiceNo"];
                obj.InvoiceDate = (DateTime)returnData["InvoiceDate"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratVendorInvoicelist_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public CollectionBase GeneratVendorInvoice_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<FA_VendorInvoice> col = new BLLCollection<FA_VendorInvoice>();
        try
        {
            while (returnData.Read())
            {
                FA_VendorInvoice obj = new FA_VendorInvoice();
                obj.InvoiceNo = (int)returnData["InvoiceNo"];
                obj.InvoiceDate = (DateTime)returnData["InvoiceDate"];
                obj.AmountDueFx = Convert.ToDouble(returnData["AmountDue(Fx)"]);
                obj.Currency = (string)returnData["Currency"];
                obj.ExchangeRate = Convert.ToDouble(returnData["ExchangeRate"]);
                obj.AmountDueLC = Convert.ToDouble(returnData["AmountDue(LC)"]);
                obj.DueDate = (DateTime)returnData["DueDate"];
                obj.AmountPaid = Convert.ToDouble(returnData["AmountPaid(Fx)"]);
                obj.DebitAdjFx = Convert.ToDouble(returnData["DebitAdj(Fx)"]);
                obj.AmountPaidLC = Convert.ToDouble(returnData["AmountPaid(LC)"]);
                obj.DebitAdjLC = Convert.ToDouble(returnData["DebitAdj(LC)"]);
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratVendorInvoice_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<FA_Vendor_Invoice_WHT> Get_InvoiceWHT_ById(int invoiceid)
    {
        return (BLLCollection<FA_Vendor_Invoice_WHT>)ExecuteReader("FA_Sp_Get_InvoiceWHT_ById", new object[] { invoiceid }, new GenerateCollectionFromReader(GeneratInvoiceWHT_mstCollection));
    }
    public CollectionBase GeneratInvoiceWHT_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<FA_Vendor_Invoice_WHT> col = new BLLCollection<FA_Vendor_Invoice_WHT>();
        try
        {
            while (returnData.Read())
            {
                FA_Vendor_Invoice_WHT obj = new FA_Vendor_Invoice_WHT();
                if (returnData["WHTLineNo"] != DBNull.Value)
                {
                    obj.WHTLineNo = (int)returnData["WHTLineNo"];
                }
                if (returnData["WHTAmount"] != null)
                {
                    obj.WHTAmount = (double)returnData["WHTAmount"];
                }

                if (returnData["WHTGroup"] != DBNull.Value)
                {
                    obj.WHTGRP = (int)returnData["WHTGroup"];
                }
                if (returnData["TypeOfPymt"] != DBNull.Value)
                {
                    obj.TypeOfPayment = (string)returnData["TypeOfPymt"];
                }
                if (returnData["Baseamount"] != DBNull.Value)
                {
                    obj.BAmt = (double)returnData["Baseamount"];
                }
                if (returnData["WHTRate"] != DBNull.Value)
                {
                    obj.WhtRate = (double)returnData["WHTRate"];
                }
                if (returnData["BaseAmount"] != DBNull.Value)
                {
                    obj.WHTAmount = (double)returnData["BaseAmount"];
                }
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratInvoiceWHT_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public FA_PaymentToVendor Get_By_VoucherId(int voucherno)
    {
        return (FA_PaymentToVendor)ExecuteReader("FA_Sp_Get_ByVoucherId", new object[] { voucherno }, new GenerateObjectFromReader(GeneratDataByVoucherId_mstCollection));
    }
    public object GeneratDataByVoucherId_mstCollection(ref IDataReader returnData)
    {
        FA_PaymentToVendor obj = new FA_PaymentToVendor();
        try
        {
            while (returnData.Read())
            {
                obj.VoucherType = (string)returnData["VoucherType"];
                obj.VoucherSeries = (string)returnData["VoucherSeries"];
                obj.Year = (string)returnData["VoucherYear"];
                obj.VoucherNo = (int)returnData["VoucherNo"];
                obj.VoucherDate = (DateTime)returnData["VoucherDate"];
                obj.BankAccountNo = (string)returnData["polyplexBankAccount"];
                obj.Vendor = (string)returnData["VendorName"];
                obj.ChequeNo = (string)returnData["ChequeNo"];
                obj.ChequeDate = (DateTime)returnData["ChequeDate"];
                obj.Currency = (string)returnData["Currency"];
                obj.ExchangeRate = (double)returnData["ExchangeRate"];
                obj.LocalBankCharges = (double)returnData["LocalBankCharges"];
                obj.ForeignBankCharges = (double)returnData["ForeignBankCharges"];
                obj.ForeignBankChargesinLC = (double)returnData["ForeignBankChargesinLC"];
                obj.Fx = (double)returnData["FxPlusMinus"];
                obj.Adj = (double)returnData["AdjPlusMinus"];
            }

            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratDataByVoucherId_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public BLLCollection<FA_VendorMaster> GetVendorList_ByVendorCode(string vendorcode)
    {
        return (BLLCollection<FA_VendorMaster>)ExecuteReader("SP_FA_GetVendorListFromVendor_mst", new object[] { vendorcode }, new GenerateCollectionFromReader(GeneratVendorList_mstCollection));
    }
    public BLLCollection<FA_VendorMaster> GetVendorList_ByVendorName(string vendorname)
    {
        return (BLLCollection<FA_VendorMaster>)ExecuteReader("SP_FA_GetVendorNameFromVendor_mst", new object[] { vendorname }, new GenerateCollectionFromReader(GeneratVendorList_mstCollection));
    }
    public CollectionBase GeneratVendorList_mstCollection(ref IDataReader rdr)
    {
        BLLCollection<FA_VendorMaster> col = new BLLCollection<FA_VendorMaster>();
        try
        {
            while (rdr.Read())
            {
                FA_VendorMaster obj = new FA_VendorMaster();
                obj.FIVendorCode = (string)rdr["Vendor Code"];
                obj.VendorName = (string)rdr["Vendor Name"];
                obj.City = (string)rdr["City"];
                col.Add(obj);
            }

            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratVendorList_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public int IsWHTExist(int invoiceid)
    {
        return (int)ExecuteScalar("Sp_FA_IsWHTExist_By_VoucherId_InvoiceId", new object[] { invoiceid });
    }

    public int IsWHTExist_ByInvoiceId(int invoiceid)
    {
        return (int)ExecuteScalar("IsWHTExist_By_InvoiceId", new object[] { invoiceid });
    }
    public int Insert_VendorPaymentInvoiceLineItem_WHT(int voucherno, int invoiceno, double whtgroup, string whttype, double baseamount, double whtrate)
    {
        return (int)ExecuteNonQuery("SA_FA_Glb_Insert_VendorPaymentInvoiceLineItem", new object[] { voucherno, invoiceno, whtgroup, whttype, baseamount, whtrate });
    }
    public double Get_BaseAmount_ById(int invoiceid)
    {
        return (double)ExecuteScalarDecimal("Sp_GetBaseAmount_By_InvoiceId", new object[] { invoiceid });
    }
    public double Get_WHTAmount_ById(int invoiceid)
    {
        return (double)ExecuteScalarDecimal("Sp_GetWHTAmount_By_InvoiceId", new object[] { invoiceid });
    }

    public int InsertPaymentheader(int voucherno, string vouchertype, string voucheryear, string voucherseries, DateTime voucherdate, string vendorname, string chequeno, DateTime chequedate, string currency, double exchangerate, double localbankcharges, double foreignbankcharges, double foreignbankchargesinlc, double fxplusminus, double adjplusminus, string polyplexbankaccount, int invoiceno)
    {
        return (int)ExecuteNonQuery("Sp_FA_Glb_InsertPaymentheader", new object[] { voucherno, vouchertype, voucheryear, voucherseries, voucherdate, vendorname, chequeno, chequedate, currency, exchangerate, localbankcharges, foreignbankcharges, foreignbankchargesinlc, fxplusminus, adjplusminus, polyplexbankaccount, invoiceno });
    }
    public int InsertVendorInvoice_PaymentSent(int invoiceno, string changedby)
    {
        return (int)ExecuteNonQuery("Sp_FA_Glb_InsertVendorInvoice_PaymentSent", new object[] { invoiceno, changedby });
    }

    public BLLCollection<FA_GLMaster> GetGLCodeList()
    {
        return (BLLCollection<FA_GLMaster>)ExecuteReader("Sp_FA_GetGLList", new object[] { }, new GenerateCollectionFromReader(GenerateGLCodeList_mstCollection));
    }

    public CollectionBase GenerateGLCodeList_mstCollection(ref IDataReader rdr)
    {
        BLLCollection<FA_GLMaster> col = new BLLCollection<FA_GLMaster>();
        try
        {
            while (rdr.Read())
            {
                FA_GLMaster obj = new FA_GLMaster();
                obj.GeneralLedgerCode = (int)rdr["GeneralLedgerCode"];
                obj.Subglflag = (bool)rdr["SubGLFlag"];
                col.Add(obj);
            }

            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateGLCodeList_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<FA_GLMaster> GetGLCodeList_ByGLGroupName(string name)
    {
        return (BLLCollection<FA_GLMaster>)ExecuteReader("Sp_FA_GetGLByGLGroupName", new object[] { name}, new GenerateCollectionFromReader(GetGLCodeByGLGroupName_mstCollection));
    }

    public CollectionBase GetGLCodeByGLGroupName_mstCollection(ref IDataReader rdr)
    {
        BLLCollection<FA_GLMaster> col = new BLLCollection<FA_GLMaster>();
        try
        {
            while (rdr.Read())
            {
                FA_GLMaster obj = new FA_GLMaster();
                obj.GeneralLedgerCode = (int)rdr["GeneralLedgerCode"];
                obj.GroupCode = rdr["GeneralLedgerCode"].ToString();
                obj.Description = rdr["Description"].ToString();
                col.Add(obj);
            }

            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateGLCodeList_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    

    public FA_GLMaster GetGLCode_ById(int Glcode)
    {
        return (FA_GLMaster)ExecuteReader("Sp_FA_GetGLList_ByGLCode", new object[] { Glcode }, new GenerateObjectFromReader(GenerateGLCodeById_mstCollection));
    }
    public object GenerateGLCodeById_mstCollection(ref IDataReader rdr)
    {
        FA_GLMaster obj = new FA_GLMaster();
        try
        {
            while (rdr.Read())
            {
                obj.GeneralLedgerCode = (int)rdr["GeneralLedgerCode"];
                obj.Subglflag = (bool)rdr["SubGLFlag"];
                obj.GroupCode = (string)rdr["GroupCode"];
                obj.EmployeeCode = (bool)rdr["EmployeeCode"];
            }

            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateGLCodeById_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public FA_GLGroupMaster GetGLGroupName_ById(int GlGroupCode)
    {
        return (FA_GLGroupMaster)ExecuteReader("Sp_FA_GetGLGroupList_ByGLGroupCode", new object[] { GlGroupCode }, new GenerateObjectFromReader(GenerateGLGroupById_mstCollection));
    }
    public object GenerateGLGroupById_mstCollection(ref IDataReader rdr)
    {
        FA_GLGroupMaster obj = new FA_GLGroupMaster();
        try
        {
            while (rdr.Read())
            {
                obj.GLGroupName = (string)rdr["description"];
            }

            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateGLGroupById_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public BLLCollection<FA_Currencymaster> GetCurrenyList()
    {
        return (BLLCollection<FA_Currencymaster>)ExecuteReader("Sp_FA_GetAllCurrencyList", new object[] { }, new GenerateCollectionFromReader(GenerateCurrencyList));
    }
    public CollectionBase GenerateCurrencyList(ref IDataReader rdr)
    {
        BLLCollection<FA_Currencymaster> col = new BLLCollection<FA_Currencymaster>();
        try
        {
            while (rdr.Read())
            {
                FA_Currencymaster obj = new FA_Currencymaster();
                obj.CurrencyName = (string)rdr["CurrencyCode"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateCurrencyList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_ProfitCentermaster> GetProfitCenter()
    {
        return (BLLCollection<FA_ProfitCentermaster>)ExecuteReader("Sp_FA_GetProfitCenter", new object[] { }, new GenerateCollectionFromReader(GenerateProfitList));
    }
    public CollectionBase GenerateProfitList(ref IDataReader rdr)
    {
        BLLCollection<FA_ProfitCentermaster> col = new BLLCollection<FA_ProfitCentermaster>();
        try
        {
            while (rdr.Read())
            {
                FA_ProfitCentermaster obj = new FA_ProfitCentermaster();
                obj.ProfitCenterName = (string)rdr["Description"];
                obj.ProfitCenterId = (int)rdr["ProfitCenterCode"];
                obj.Id = (int)rdr["Id"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateProfitList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_CostCentermaster> GetCostCenter()
    {
        return (BLLCollection<FA_CostCentermaster>)ExecuteReader("Sp_FA_GetCostCenter", new object[] { }, new GenerateCollectionFromReader(GenerateCostCenterList));
    }
    public CollectionBase GenerateCostCenterList(ref IDataReader rdr)
    {
        BLLCollection<FA_CostCentermaster> col = new BLLCollection<FA_CostCentermaster>();
        try
        {
            while (rdr.Read())
            {
                FA_CostCentermaster obj = new FA_CostCentermaster();
                obj.CostCenterCode = (int)rdr["CostCenterCode"];
                obj.CostCenterName = (string)rdr["Description"];
                obj.Id = Convert.ToInt32(rdr["Id"]);
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateCostCenterList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<FA_ProjectCode> GetProjectCode()
    {
        return (BLLCollection<FA_ProjectCode>)ExecuteReader("Sp_FA_GetProjectCode", new object[] { }, new GenerateCollectionFromReader(GenerateProjectCodeList));
    }
    public CollectionBase GenerateProjectCodeList(ref IDataReader rdr)
    {
        BLLCollection<FA_ProjectCode> col = new BLLCollection<FA_ProjectCode>();
        try
        {
            while (rdr.Read())
            {
                FA_ProjectCode obj = new FA_ProjectCode();
                obj.ProjectCode = (int)rdr["ProjectCode"];
                obj.ProjectName = (string)rdr["ProjectName"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateProjectCodeList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<FA_SubProjectmst> GetSubProject()
    {
        return (BLLCollection<FA_SubProjectmst>)ExecuteReader("Sp_FA_GetSubProjectCode", new object[] { }, new GenerateCollectionFromReader(GenerateSubProjectCodeList));
    }
    public CollectionBase GenerateSubProjectCodeList(ref IDataReader rdr)
    {
        BLLCollection<FA_SubProjectmst> col = new BLLCollection<FA_SubProjectmst>();
        try
        {
            while (rdr.Read())
            {
                FA_SubProjectmst obj = new FA_SubProjectmst();
                obj.SubProjectCode = (int)rdr["SubProjectCode"];
                obj.SubProjectName = (string)rdr["SubProjectName"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateSubProjectCodeList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_SubProjectmst> GetSubProject_ByProjectId(int projectid)
    {
        return (BLLCollection<FA_SubProjectmst>)ExecuteReader("Sp_FA_GetSubProjectCode_ByProjectId", new object[] { projectid }, new GenerateCollectionFromReader(GenerateSubProjectCodeByProjectIdList));
    }
    public CollectionBase GenerateSubProjectCodeByProjectIdList(ref IDataReader rdr)
    {
        BLLCollection<FA_SubProjectmst> col = new BLLCollection<FA_SubProjectmst>();
        try
        {
            while (rdr.Read())
            {
                FA_SubProjectmst obj = new FA_SubProjectmst();
                obj.SubProjectCode = (int)rdr["SubProjectCode"];
                obj.SubProjectName = (string)rdr["SubProjectName"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateSubProjectCodeByProjectIdList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_WHTType> GetWHTType()
    {
        return (BLLCollection<FA_WHTType>)ExecuteReader("Sp_FA_GetVoucherType", new object[] { }, new GenerateCollectionFromReader(GenerateWHTTypeList));
    }
    public CollectionBase GenerateWHTTypeList(ref IDataReader rdr)
    {
        BLLCollection<FA_WHTType> col = new BLLCollection<FA_WHTType>();
        try
        {
            while (rdr.Read())
            {
                FA_WHTType obj = new FA_WHTType();
                obj.WHTDescription = (string)rdr["Description"];
                obj.WHTId = (int)rdr["Id"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateWHTTypeList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_CountryClass> GetAllCountries()
    {
        return (BLLCollection<FA_CountryClass>)ExecuteReader("Sp_FA_GetCountryClass", new object[] { }, new GenerateCollectionFromReader(GenerateCountriesList));
    }
    public CollectionBase GenerateCountriesList(ref IDataReader rdr)
    {
        BLLCollection<FA_CountryClass> col = new BLLCollection<FA_CountryClass>();
        try
        {
            while (rdr.Read())
            {
                FA_CountryClass obj = new FA_CountryClass();
                obj.CountryId = (int)rdr["Id"];
                obj.CountryName = (string)rdr["Description"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateCountriesList -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public int inserjournaldetails(FA_JournalVoucher obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_JournalVoucher_Insert", new object[] { obj.LineNo, obj.VoucherType, obj.VoucherSeries, obj.VoucherYear, obj.VoucherNo, obj.VoucherDate, obj.MarkReversal, obj.Currency, obj.ExchangeRate, obj.Asset, obj.EmpCode, obj.Fxamount, obj.Project, obj.SubProject, obj.VoucherDescription, obj.GlCode, obj.GlSubCode, obj.DebitAmount, obj.CreditAmount, obj.CostCenter, obj.ProfitCenter, obj.ChequeNo, obj.ChequeDate, obj.CreatedBy, obj.CreatedDate });
    }
    public int insertjournal_whtdetails(FA_Journal_WHT obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_WHTDetail_Insert", new object[] { obj.VoucherNo, obj.LineNo, obj.WhtLineNo, obj.VendorCode, obj.VendorName, obj.WhtGroup, obj.WhtType, obj.BaseAmount, obj.WhtRate, obj.WhtAmount, obj.CreatedBy, obj.Active });
    }

    public int Updatejournal_whtdetails(string voucherno, int whtlineno, string vendorcode, string vendorname, int WHTGroup, string TypeOfPayment, double BaseAmount, double WHTRate, double WHTAmount, string LastChange)
    {
        return (int)ExecuteNonQuery("SP_FA_UpdateWhtDetails", new object[] { voucherno, whtlineno, vendorcode, vendorname, WHTGroup, TypeOfPayment, BaseAmount, WHTRate, WHTAmount, LastChange });
    }

    public int insertjournal_vatdetails(FA_Journal_Vat obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_VatDetail_Insert", new object[] { obj.LineNo, obj.VoucherNo, obj.VatLineNo, obj.VendorCode, obj.VendorName, obj.BaseAmount, obj.VAmount, obj.TaxInvoice, obj.TaxInvoiceDate, obj.Rate, obj.CreatedBy, obj.Active });
    }

    public int updatejournal_vatdetails(string voucherno, int vatlineno, double baseamount, double taxamount, string taxinvoice, DateTime taxinvoicedate, string lastchange, double rate)
    {
        return (int)ExecuteNonQuery("SP_FA_UpdateVatDetails", new object[] { voucherno, vatlineno, baseamount, taxamount, taxinvoice, taxinvoicedate, lastchange, rate });
    }

    public int updatejournal_vatdetails_otherpurchase(string voucherno, int vatlineno, double baseamount, double taxamount, string taxinvoice, string taxinvoicedate, string lastchange, double rate)
    {
        return (int)ExecuteNonQuery("SP_FA_Update_OtherPurchase_VatDetails", new object[] { voucherno, vatlineno, baseamount, taxamount, taxinvoice, taxinvoicedate, lastchange, rate });
    }

    public int insertjournal_traveldetails(FA_Journal_traveldetail obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_TravelDetail_Insert", new object[] { obj.VoucherNo, obj.LineNo, obj.TravelLineNo, obj.EmpCode, obj.EmpName, obj.CountryClass, obj.NoOfDays, obj.FromDate, obj.ToDate, obj.DA, obj.OtherCost, obj.CreatedBy, obj.Active });
    }

    public int updatejournal_traveldetails(string voucherno, int travellineno, int CountryClass, int NoOfDays, DateTime FromDate, DateTime ToDate, double DA, double OtherCost, string LastChange)
    {
        return (int)ExecuteNonQuery("SP_FA_UpdateTravelDetails", new object[] { voucherno, travellineno, CountryClass, NoOfDays, FromDate, ToDate, DA, OtherCost, LastChange });
    }

    public string GetTopVoucherNo()
    {
        return (string)ExecuteScalarString("Sp_FA_GetTopVoucherNo", new object[] { });
    }
    public int GetTopLineNo()
    {
        return (int)ExecuteScalar("Sp_FA_GetTopLineNo", new object[] { });
    }

    public int GetTopVoucherNo_FromPaymentToVendor()
    {
        return (int)ExecuteScalar("Sp_FA_GetTopVoucherNo_FromVendorPaymentHeader", new object[] { });
    }

    public BLLCollection<FA_JournalVoucher> Search_JournalVoucher_MarkReversal(string keyword)
    {
        return (BLLCollection<FA_JournalVoucher>)ExecuteReader("Sp_FA_SearchVoucher_By_Keywork_category", new object[] { keyword }, new GenerateCollectionFromReader(SearchJournalVoucherMarkReversal));
    }
    public CollectionBase SearchJournalVoucherMarkReversal(ref IDataReader rdr)
    {
        BLLCollection<FA_JournalVoucher> col = new BLLCollection<FA_JournalVoucher>();
        try
        {
            while (rdr.Read())
            {
                FA_JournalVoucher obj = new FA_JournalVoucher();
                obj.VoucherType = (string)rdr["VoucherType"];
                obj.VoucherSeries = (string)rdr["VoucherSeries"];
                obj.VoucherYear = (string)rdr["Voucher_Year"];
                obj.VoucherNo = (string)rdr["VoucherNumber"];
                obj.VoucherDate = (DateTime)rdr["VoucherDate"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- SearchJournalVoucherMarkReversal -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public FA_JournalVoucher Get_JournalVoucherDetails_ByVoucherId(string voucherno)
    {
        return (FA_JournalVoucher)ExecuteReader("Sp_FA_Get_JournalVoucherDetails_ByVoucherId", new object[] { voucherno }, new GenerateObjectFromReader(GetDetailsByJournalVoucherId));
    }
    public object GetDetailsByJournalVoucherId(ref IDataReader rdr)
    {
        FA_JournalVoucher obj = new FA_JournalVoucher();
        try
        {
            while (rdr.Read())
            {
                if (rdr["VoucherType"] != DBNull.Value)
                {
                    obj.VoucherType = (string)rdr["VoucherType"];
                }
                if (rdr["VoucherSeries"] != DBNull.Value)
                {
                    obj.VoucherSeries = (string)rdr["VoucherSeries"];
                }
                if (rdr["Voucher_Year"] != DBNull.Value)
                {
                    obj.VoucherYear = (string)rdr["Voucher_Year"];
                }
                if (rdr["VoucherNumber"] != DBNull.Value)
                {
                    obj.VoucherNo = (string)rdr["VoucherNumber"];
                }
                if (rdr["VoucherDate"] != DBNull.Value)
                {
                    obj.VoucherDate = (DateTime)rdr["VoucherDate"];
                }
                if (rdr["MarkReversal"] != DBNull.Value)
                {
                    obj.MarkReversal = (bool)rdr["MarkReversal"];
                }
                if (rdr["ExchangeRate"] != DBNull.Value)
                {
                    obj.ExchangeRate = Convert.ToDouble(rdr["ExchangeRate"]);
                }
                if (rdr["VoucherDescr"] != DBNull.Value)
                {
                    obj.VoucherDescription = (string)rdr["VoucherDescr"];
                }
                if (rdr["GLCode"] != DBNull.Value)
                {
                    obj.GlCode = (string)rdr["GLCode"];
                }
                if (rdr["SubGLCode"] != DBNull.Value)
                {
                    obj.GlSubCode = (string)rdr["SubGLCode"];
                }
                if (rdr["ProfitCenter"] != DBNull.Value)
                {
                    obj.ProfitCenter = (string)rdr["ProfitCenter"];
                }
                if (rdr["CostCenter"] != DBNull.Value)
                {
                    obj.CostCenter = (string)rdr["CostCenter"];
                }
                if (rdr["DebitAmount"] != DBNull.Value)
                {
                    obj.DebitAmount = Convert.ToDouble(rdr["DebitAmount"]);
                }
                if (rdr["CreditAmount"] != DBNull.Value)
                {
                    obj.CreditAmount = Convert.ToDouble(rdr["CreditAmount"]);
                }
                if (rdr["ChequeNo"] != DBNull.Value)
                {
                    obj.ChequeNo = (string)rdr["ChequeNo"];
                }
                if (rdr["ChequeDate"] != DBNull.Value)
                {
                    obj.ChequeDate = (DateTime)rdr["ChequeDate"];
                }
                if (rdr["Asset"] != DBNull.Value)
                {
                    obj.Asset = (string)rdr["Asset"];
                }
                if (rdr["EmpCode"] != DBNull.Value)
                {
                    obj.EmpCode = (string)rdr["EmpCode"];
                }
                if (rdr["FxAmount"] != DBNull.Value)
                {
                    obj.Fxamount = Convert.ToDouble(rdr["FxAmount"]);
                }
                if (rdr["Project"] != DBNull.Value)
                {
                    obj.Project = Convert.ToInt32(rdr["Project"]);
                }
                if (rdr["SubProject"] != DBNull.Value)
                {
                    obj.SubProject = Convert.ToInt32(rdr["SubProject"]);
                }
                if (rdr["Currency"] != DBNull.Value)
                {
                    obj.Currency = (string)rdr["Currency"];
                }
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetDetailsByJournalVoucherId -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public BLLCollection<FA_JournalVoucher> Get_JournalVoucherDetailsCol_ByVoucherId(string voucherno)
    {
        return (BLLCollection<FA_JournalVoucher>)ExecuteReader("Sp_FA_Get_JournalVoucherDetails_ByVoucherId", new object[] { voucherno }, new GenerateCollectionFromReader(GetDetailsColByJournalVoucherId));
    }
    public CollectionBase GetDetailsColByJournalVoucherId(ref IDataReader rdr)
    {
        BLLCollection<FA_JournalVoucher> col = new BLLCollection<FA_JournalVoucher>();
        try
        {
            while (rdr.Read())
            {
                FA_JournalVoucher obj = new FA_JournalVoucher();
                if (rdr["VoucherType"] != DBNull.Value)
                {
                    obj.VoucherType = (string)rdr["VoucherType"];
                }
                if (rdr["VoucherSeries"] != DBNull.Value)
                {
                    obj.VoucherSeries = (string)rdr["VoucherSeries"];
                }
                if (rdr["Voucher_Year"] != DBNull.Value)
                {
                    obj.VoucherYear = (string)rdr["Voucher_Year"];
                }
                if (rdr["VoucherNumber"] != DBNull.Value)
                {
                    obj.VoucherNo = (string)rdr["VoucherNumber"];
                }
                if (rdr["VoucherDate"] != DBNull.Value)
                {
                    obj.VoucherDate = (DateTime)rdr["VoucherDate"];
                }
                if (rdr["MarkReversal"] != DBNull.Value)
                {
                    obj.MarkReversal = (bool)rdr["MarkReversal"];
                }
                if (rdr["ExchangeRate"] != DBNull.Value)
                {
                    obj.ExchangeRate = Convert.ToDouble(rdr["ExchangeRate"]);
                }
                if (rdr["VoucherDescr"] != DBNull.Value)
                {
                    obj.VoucherDescription = (string)rdr["VoucherDescr"];
                }
                if (rdr["LineNo"] != DBNull.Value)
                {
                    obj.LineNo = (int)rdr["LineNo"];
                }

                if (rdr["GLCode"] != DBNull.Value)
                {
                    obj.GlCode = (string)rdr["GLCode"];
                }
                if (rdr["SubGLCode"] != DBNull.Value)
                {
                    obj.GlSubCode = (string)rdr["SubGLCode"];
                }
                if (rdr["ProfitCenter"] != DBNull.Value)
                {
                    obj.ProfitCenter = (string)rdr["ProfitCenter"];
                }
                if (rdr["CostCenter"] != DBNull.Value)
                {
                    obj.CostCenter = (string)rdr["CostCenter"];
                }
                if (rdr["DebitAmount"] != DBNull.Value)
                {
                    obj.DebitAmount = Convert.ToDouble(rdr["DebitAmount"]);
                }
                if (rdr["CreditAmount"] != DBNull.Value)
                {
                    obj.CreditAmount = Convert.ToDouble(rdr["CreditAmount"]);
                }
                if (rdr["ChequeNo"] != DBNull.Value)
                {
                    obj.ChequeNo = (string)rdr["ChequeNo"];
                }
                if (rdr["ChequeDate"] != DBNull.Value)
                {
                    obj.ChequeDate = (DateTime)rdr["ChequeDate"];
                }
                if (rdr["Asset"] != DBNull.Value)
                {
                    obj.Asset = (string)rdr["Asset"];
                }
                if (rdr["EmpCode"] != DBNull.Value)
                {
                    obj.EmpCode = (string)rdr["EmpCode"];
                }
                if (rdr["FxAmount"] != DBNull.Value)
                {
                    obj.Fxamount = Convert.ToDouble(rdr["FxAmount"]);
                }
                if (rdr["Project"] != DBNull.Value)
                {
                    obj.Project = Convert.ToInt32(rdr["Project"]);
                }
                if (rdr["SubProject"] != DBNull.Value)
                {
                    obj.SubProject = Convert.ToInt32(rdr["SubProject"]);
                }
                if (rdr["Currency"] != DBNull.Value)
                {
                    obj.Currency = (string)rdr["Currency"];
                }
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetDetailsColByJournalVoucherId -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public FA_JournalVoucher Get_JournalVoucherDetailsCol_ByLineNo(string lineno, string voucherno)
    {
        return (FA_JournalVoucher)ExecuteReader("Sp_FA_Get_JournalVoucherDetails_ByLineNo", new object[] { lineno, voucherno }, new GenerateObjectFromReader(GetDetailsColByLineNo));
    }

    public object GetDetailsColByLineNo(ref IDataReader rdr)
    {
        FA_JournalVoucher obj = new FA_JournalVoucher();
        try
        {
            while (rdr.Read())
            {

                if (rdr["GLCode"] != DBNull.Value)
                {
                    obj.GlCode = (string)rdr["GLCode"];
                }
                if (rdr["SubGLCode"] != DBNull.Value)
                {
                    obj.GlSubCode = (string)rdr["SubGLCode"];
                }
                if (rdr["ProfitCenter"] != DBNull.Value)
                {
                    obj.ProfitCenter = (string)rdr["ProfitCenter"];
                }
                if (rdr["CostCenter"] != DBNull.Value)
                {
                    obj.CostCenter = (string)rdr["CostCenter"];
                }
                if (rdr["DebitAmount"] != DBNull.Value)
                {
                    obj.DebitAmount = Convert.ToDouble(rdr["DebitAmount"]);
                }
                if (rdr["CreditAmount"] != DBNull.Value)
                {
                    obj.CreditAmount = Convert.ToDouble(rdr["CreditAmount"]);
                }
                if (rdr["ChequeNo"] != DBNull.Value)
                {
                    obj.ChequeNo = (string)rdr["ChequeNo"];
                }
                if (rdr["VoucherDescr"] != DBNull.Value)
                {
                    obj.VoucherDescription = (string)rdr["VoucherDescr"];
                }
                if (rdr["ChequeDate"] != DBNull.Value)
                {
                    obj.ChequeDate = (DateTime)rdr["ChequeDate"];
                }
                if (rdr["Asset"] != DBNull.Value)
                {
                    obj.Asset = (string)rdr["Asset"];
                }
                if (rdr["EmpCode"] != DBNull.Value)
                {
                    obj.EmpCode = (string)rdr["EmpCode"];
                }
                if (rdr["FxAmount"] != DBNull.Value)
                {
                    obj.Fxamount = Convert.ToDouble(rdr["FxAmount"]);
                }
                if (rdr["Project"] != DBNull.Value)
                {
                    obj.Project = Convert.ToInt32(rdr["Project"]);
                }
                if (rdr["SubProject"] != DBNull.Value)
                {
                    obj.SubProject = Convert.ToInt32(rdr["SubProject"]);
                }

            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetDetailsColByLineNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public int UpdateJournalVoucher_HeaderDetails(string vouchertype, string voucherseries, string voucheryear, string voucherno, DateTime voucherdate, bool markreversal, string lastchange, string currency, double exchangerate)
    {
        return (int)ExecuteNonQuery("Sp_FA_UpdateJournalVoucherHeader", new object[] { vouchertype, voucherseries, voucheryear, voucherno, voucherdate, markreversal, lastchange, currency, exchangerate });
    }

    public int UpdateJournalVoucher_Otherpurchase_HeaderDetails(string voucherseries, string voucheryear, string voucherno, string voucherdate,string Vendor, string VendorInvoice, string InvoiceDate,string InvoiceBLDate, string CreditDays, string DueDate,string Amount,string Description ,string lastchange)
    {
        return (int)ExecuteNonQuery("Sp_FA_UpdateJournal_OtherPurchase_VoucherHeader", new object[] { voucherseries, voucheryear, voucherno, voucherdate, Vendor, VendorInvoice, InvoiceDate, InvoiceBLDate, CreditDays, DueDate, Amount, Description, lastchange });
    }
    public int UpdateJournalVoucher_Details(string voucherno, string lineno, string glcode, string subglcode, string profitcenter, string costcenter, double debitamount, double creditamount, string chequeno, DateTime chequedate, string lastchange, string asset, string empcode, double fxamount, string project, string subproject, string voucherdesc)
    {
        return (int)ExecuteNonQuery("Sp_FA_UpdateJournalVoucherDetails", new object[] { voucherno, lineno, glcode, subglcode, profitcenter, costcenter, debitamount, creditamount, chequeno, chequedate, lastchange, asset, empcode, fxamount, project, subproject, voucherdesc });
    }
    public int UpdateJournalVoucher_Otherpurchase_Details(string VoucherNo,string LineNo,string GLCode,string SubGLCode,string ProfitCenter,string CostCenter,double DebitAmount,string Asset,string EmpCode,string Project,string SubProject,string VoucherDesc,string LastChange,string DetailsDesc)
    {
        return (int)ExecuteNonQuery("Sp_FA_UpdateJournal_Otherpurchase_VoucherDetails", new object[] { VoucherNo, LineNo, GLCode, SubGLCode, ProfitCenter, CostCenter, DebitAmount, Asset, EmpCode, Project, SubProject, VoucherDesc, LastChange, DetailsDesc });
    }
 
    public int insertJournalVoucerToMarkReversalHistory(FA_JournalVoucherToMarkReversalHistory obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_InsertJournalVoucherToMarkReversalHistory", new object[] { obj.VoucherNo, obj.MarkReversalStatus, obj.CreatedBy });
    }

    public FA_Journal_Vat GetVatDetailsBy_Voucherno(string voucherno, string vatlineno)
    {
        return (FA_Journal_Vat)ExecuteReader("SP_FA_GetVatDetailsBy_VoucherId_LineNo", new object[] { voucherno, vatlineno }, new GenerateObjectFromReader(GetVatDetailsColByVoucherNo));
    }
    public object GetVatDetailsColByVoucherNo(ref IDataReader rdr)
    {
        FA_Journal_Vat obj = new FA_Journal_Vat();
        try
        {
            while (rdr.Read())
            {
                if (rdr["VendorCode"] != DBNull.Value)
                {
                    obj.VendorCode = (string)rdr["VendorCode"];
                }
                if (rdr["VendorName"] != DBNull.Value)
                {
                    obj.VendorName = (string)rdr["VendorName"];
                }
                if (rdr["BaseAmount"] != DBNull.Value)
                {
                    obj.BaseAmount = Convert.ToDouble(rdr["BaseAmount"]);
                }
                if (rdr["VAmt"] != DBNull.Value)
                {
                    obj.VAmount = Convert.ToDouble(rdr["VAmt"]);
                }
                if (rdr["TaxInvoice"] != DBNull.Value)
                {
                    obj.TaxInvoice = (string)rdr["TaxInvoice"];
                }
                if (rdr["TaxInvoiceDate"] != DBNull.Value)
                {
                    obj.TaxInvoiceDate = (DateTime)rdr["TaxInvoiceDate"];
                }
                if (rdr["Rate"] != DBNull.Value)
                {
                    obj.Rate = Convert.ToDouble(rdr["Rate"]);
                }
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetVatDetailsColByVoucherNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public BLLCollection<FA_Journal_Vat> GetVatDetailsBy_Vrno(string voucherno)
    {
        return (BLLCollection<FA_Journal_Vat>)ExecuteReader("SP_FA_GetVatDetailsBy_VoucherId", new object[] { voucherno }, new GenerateCollectionFromReader(GetVatDetailsByVNo));
    }
    public BLLCollection<FA_Journal_OtherPurchases_Vat> GetVatDetails_Otherpurchase_By_Vrno(string voucherno)
    {
        return (BLLCollection<FA_Journal_OtherPurchases_Vat>)ExecuteReader("SP_FA_GetVatDetails_Otherpurchase_By_VoucherId", new object[] { voucherno }, new GenerateCollectionFromReader(GetVatDetails_Otherpurchase_ByVNo));
    }

    public CollectionBase GetVatDetails_Otherpurchase_ByVNo(ref IDataReader rdr)
    {
        BLLCollection<FA_Journal_OtherPurchases_Vat> col = new BLLCollection<FA_Journal_OtherPurchases_Vat>();
        try
        {
            while (rdr.Read())
            {
                FA_Journal_OtherPurchases_Vat obj = new FA_Journal_OtherPurchases_Vat();
                if (rdr["VATLineNo"] != DBNull.Value)
                {
                    obj.VatLineNo = (int)rdr["VATLineNo"];
                }
                if (rdr["VendorCode"] != DBNull.Value)
                {
                    obj.VendorCode = (string)rdr["VendorCode"];
                }
                if (rdr["VendorName"] != DBNull.Value)
                {
                    obj.VendorName = (string)rdr["VendorName"];
                }
                if (rdr["BaseAmount"] != DBNull.Value)
                {
                    obj.BaseAmount = Convert.ToDouble(rdr["BaseAmount"]);
                }
                if (rdr["VAmt"] != DBNull.Value)
                {
                    obj.VAmount = Convert.ToDouble(rdr["VAmt"]);
                }
                if (rdr["TaxInvoice"] != DBNull.Value)
                {
                    obj.TaxInvoice = (string)rdr["TaxInvoice"];
                }
                if (rdr["TaxInvoiceDate"] != DBNull.Value)
                {
                    obj.TaxInvoiceDate = rdr["TaxInvoiceDate"].ToString();
                }
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetVatDetailsByVNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public CollectionBase GetVatDetailsByVNo(ref IDataReader rdr)
    {
        BLLCollection<FA_Journal_Vat> col = new BLLCollection<FA_Journal_Vat>();
        try
        {
            while (rdr.Read())
            {
                FA_Journal_Vat obj = new FA_Journal_Vat();
                if (rdr["VATLineNo"] != DBNull.Value)
                {
                    obj.VatLineNo = (int)rdr["VATLineNo"];
                }
                if (rdr["VendorCode"] != DBNull.Value)
                {
                    obj.VendorCode = (string)rdr["VendorCode"];
                }
                if (rdr["VendorName"] != DBNull.Value)
                {
                    obj.VendorName = (string)rdr["VendorName"];
                }
                if (rdr["BaseAmount"] != DBNull.Value)
                {
                    obj.BaseAmount = Convert.ToDouble(rdr["BaseAmount"]);
                }
                if (rdr["VAmt"] != DBNull.Value)
                {
                    obj.VAmount = Convert.ToDouble(rdr["VAmt"]);
                }
                if (rdr["TaxInvoice"] != DBNull.Value)
                {
                    obj.TaxInvoice = (string)rdr["TaxInvoice"];
                }
                if (rdr["TaxInvoiceDate"] != DBNull.Value)
                {
                    obj.TaxInvoiceDate = (DateTime)rdr["TaxInvoiceDate"];
                }
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetVatDetailsByVNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public FA_Journal_WHT GetWHTDetailsBy_Voucherno(string voucherno, string lineno)
    {
        return (FA_Journal_WHT)ExecuteReader("SP_FA_GetWHTDetailsBy_VoucherId_LineNo", new object[] { voucherno, lineno }, new GenerateObjectFromReader(GetWHTDetailsColByVoucherNo));
    }

    public BLLCollection<FA_Journal_WHT> GetWHTDetailsBy_Vrno(string voucherno)
    {
        return (BLLCollection<FA_Journal_WHT>)ExecuteReader("SP_FA_GetWHTDetailsBy_VoucherId", new object[] { voucherno }, new GenerateCollectionFromReader(GetWHTDetailsByVNo));
    }
    public CollectionBase GetWHTDetailsByVNo(ref IDataReader rdr)
    {
        BLLCollection<FA_Journal_WHT> col = new BLLCollection<FA_Journal_WHT>();
        try
        {
            while (rdr.Read())
            {
                FA_Journal_WHT obj = new FA_Journal_WHT();
                if (rdr["VendorCode"] != DBNull.Value)
                {
                    obj.VendorCode = (string)rdr["VendorCode"];
                }
                if (rdr["VendorName"] != DBNull.Value)
                {
                    obj.VendorName = (string)rdr["VendorName"];
                }
                if (rdr["BaseAmount"] != DBNull.Value)
                {
                    obj.BaseAmount = Convert.ToDouble(rdr["BaseAmount"]);
                }
                if (rdr["WHTGroup"] != DBNull.Value)
                {
                    obj.WhtGroup = (int)rdr["WHTGroup"];
                }
                if (rdr["TypeOfPayment"] != DBNull.Value)
                {
                    obj.WhtType = (string)rdr["TypeOfPayment"];
                }
                if (rdr["WHTRate"] != DBNull.Value)
                {
                    obj.WhtRate = Convert.ToDouble(rdr["WHTRate"]);
                }
                if (rdr["WHTAmount"] != DBNull.Value)
                {
                    obj.WhtAmount = Convert.ToDouble(rdr["WHTAmount"]);
                }
                if (rdr["WHTLineNo"] != DBNull.Value)
                {
                    obj.WhtLineNo = Convert.ToInt32(rdr["WHTLineNo"]);
                }
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetWHTDetailsByVNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }


    public object GetWHTDetailsColByVoucherNo(ref IDataReader rdr)
    {
        FA_Journal_WHT obj = new FA_Journal_WHT();
        try
        {
            while (rdr.Read())
            {
                if (rdr["VendorCode"] != DBNull.Value)
                {
                    obj.VendorCode = (string)rdr["VendorCode"];
                }
                if (rdr["VendorName"] != DBNull.Value)
                {
                    obj.VendorName = (string)rdr["VendorName"];
                }
                if (rdr["BaseAmount"] != DBNull.Value)
                {
                    obj.BaseAmount = Convert.ToDouble(rdr["BaseAmount"]);
                }
                if (rdr["WHTGroup"] != DBNull.Value)
                {
                    obj.WhtGroup = (int)rdr["WHTGroup"];
                }
                if (rdr["TypeOfPayment"] != DBNull.Value)
                {
                    obj.WhtType = (string)rdr["TypeOfPayment"];
                }
                if (rdr["WHTRate"] != DBNull.Value)
                {
                    obj.WhtRate = Convert.ToDouble(rdr["WHTRate"]);
                }
                if (rdr["WHTAmount"] != DBNull.Value)
                {
                    obj.WhtAmount = Convert.ToDouble(rdr["WHTAmount"]);
                }
                //if (rdr["WHTLineNo"] != DBNull.Value)
                //{
                //    obj.WhtLineNo = Convert.ToInt32(rdr["WHTLineNo"]);
                //}
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetWHTDetailsColByVoucherNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public BLLCollection<FA_Journal_traveldetail> GetTravelDetailsBy_Vrno(string voucherno)
    {
        return (BLLCollection<FA_Journal_traveldetail>)ExecuteReader("SP_FA_GetTravelDetailsBy_VoucherId", new object[] { voucherno }, new GenerateCollectionFromReader(GetTravelDetailsByVNo));
    }

    public CollectionBase GetTravelDetailsByVNo(ref IDataReader rdr)
    {
        BLLCollection<FA_Journal_traveldetail> col = new BLLCollection<FA_Journal_traveldetail>();
        try
        {
            while (rdr.Read())
            {
                FA_Journal_traveldetail obj = new FA_Journal_traveldetail();
                if (rdr["EmpCode"] != DBNull.Value)
                {
                    obj.EmpCode = (string)rdr["EmpCode"];
                }
                if (rdr["EmpName"] != DBNull.Value)
                {
                    obj.EmpName = (string)rdr["EmpName"];
                }
                if (rdr["CountryClass"] != DBNull.Value)
                {
                    obj.CountryClass = (int)rdr["CountryClass"];
                }
                if (rdr["NoOfDays"] != DBNull.Value)
                {
                    obj.NoOfDays = (int)rdr["NoOfDays"];
                }
                if (rdr["FromDate"] != DBNull.Value)
                {
                    obj.FromDate = (DateTime)rdr["FromDate"];
                }
                if (rdr["ToDate"] != DBNull.Value)
                {
                    obj.ToDate = (DateTime)rdr["ToDate"];
                }
                if (rdr["D.A"] != DBNull.Value)
                {
                    obj.DA = Convert.ToDouble(rdr["D.A"]);
                }
                if (rdr["OtherCost"] != DBNull.Value)
                {
                    obj.OtherCost = Convert.ToDouble(rdr["OtherCost"]);
                }
                if (rdr["TravelLineNo"] != DBNull.Value)
                {
                    obj.TravelLineNo = (int)rdr["TravelLineNo"];
                }
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetWHTDetailsByVNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public FA_Journal_traveldetail GetTravelDetailsBy_Voucherno(string voucherno, string travellineno)
    {
        return (FA_Journal_traveldetail)ExecuteReader("SP_FA_GetTravelDetailsBy_VoucherId_TravelLineNo", new object[] { voucherno, travellineno }, new GenerateObjectFromReader(GetTravelDetailsColByVoucherNo));
    }
    public object GetTravelDetailsColByVoucherNo(ref IDataReader rdr)
    {
        FA_Journal_traveldetail obj = new FA_Journal_traveldetail();
        try
        {
            while (rdr.Read())
            {
                if (rdr["EmpCode"] != DBNull.Value)
                {
                    obj.EmpCode = (string)rdr["EmpCode"];
                }
                if (rdr["EmpName"] != DBNull.Value)
                {
                    obj.EmpName = (string)rdr["EmpName"];
                }
                if (rdr["CountryClass"] != DBNull.Value)
                {
                    obj.CountryClass = (int)rdr["CountryClass"];
                }
                if (rdr["NoOfDays"] != DBNull.Value)
                {
                    obj.NoOfDays = (int)rdr["NoOfDays"];
                }
                if (rdr["FromDate"] != DBNull.Value)
                {
                    obj.FromDate = (DateTime)rdr["FromDate"];
                }
                if (rdr["ToDate"] != DBNull.Value)
                {
                    obj.ToDate = (DateTime)rdr["ToDate"];
                }
                if (rdr["D.A"] != DBNull.Value)
                {
                    obj.DA = Convert.ToDouble(rdr["D.A"]);
                }
                if (rdr["OtherCost"] != DBNull.Value)
                {
                    obj.OtherCost = Convert.ToDouble(rdr["OtherCost"]);
                }
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetTravelDetailsColByVoucherNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }

    public BLLCollection<FA_SLMaster> GetSLCodeList()
    {
        return (BLLCollection<FA_SLMaster>)ExecuteReader("SP_FA_GLb_SLMaster", new object[] { }, new GenerateCollectionFromReader(GenerateSLCodeList_mstCollection));
    }

    public CollectionBase GenerateSLCodeList_mstCollection(ref IDataReader rdr)
    {
        BLLCollection<FA_SLMaster> col = new BLLCollection<FA_SLMaster>();
        try
        {
            while (rdr.Read())
            {
                FA_SLMaster obj = new FA_SLMaster();
                obj.GeneralLedgerCode = (string)rdr["GeneralLedgerCode"];
                obj.SubSidiaryLedgerCode = (int)rdr["SubSidiaryLedgerCode"];
                obj.Description = (string)rdr["SLDescription"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateSLCodeList_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public int inserpredefineddetails(FA_PredefinedEntries obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_Insert_PredefinedEntries", new object[] { obj.EntryNo, obj.StartDate, obj.EndDate, obj.Planned, obj.DebitAmount, obj.CreditAmount, obj.GLCode, obj.ProfitCenter, obj.SubGLCode, obj.CostCenter, obj.Description, obj.LineNo });
    }

    public int insertPostpredefineddetails(int entryno, string startdate, string enddate, string postedby, string vouchertype, string voucherseries, string voucheryear, string voucherdate, string planned)
    {
        return (int)ExecuteNonQuery("Sp_FA_InsertPostPredefinedEntries", new object[] {entryno,startdate,enddate, postedby,vouchertype,voucherseries,voucheryear,voucherdate,planned});
    }
    public int insertPostpredefinedHistorydetails(FA_PostPredefinedEntriesHistory obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_InsertPostPredefinedEntriesHistory", new object[] { obj.EntryNo, obj.PostedBy });
    }

    public int GetLastEntryNo()
    {
        return (int)ExecuteScalar("Sp_FA_GetTopEntryNo", new object[] { });
    }

    public BLLCollection<FA_PredefinedEntries> GetAllPredefinedEntries(string searchtype, string searchtext)
    {
        return (BLLCollection<FA_PredefinedEntries>)ExecuteReader("Sp_FA_GetPredefinedEntriesSearchList", new object[] { searchtype, searchtext }, new GenerateCollectionFromReader(GeneratePredefinedEntriesList_mstCollection));
    }

    public CollectionBase GeneratePredefinedEntriesList_mstCollection(ref IDataReader rdr)
    {
        BLLCollection<FA_PredefinedEntries> col = new BLLCollection<FA_PredefinedEntries>();
        try
        {
            while (rdr.Read())
            {
                FA_PredefinedEntries obj = new FA_PredefinedEntries();
                obj.EntryNo = (int)rdr["EntryNo"];
                obj.StartDate = rdr["StartDate"].ToString();
                obj.EndDate = rdr["EndDate"].ToString();
                obj.LineNo = (int)rdr["LineNo"];
                obj.Id = (int)rdr["Id"];
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratePredefinedEntriesList_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<FA_PredefinedEntries> GetAllPredefined()
    {
        return (BLLCollection<FA_PredefinedEntries>)ExecuteReader("Sp_FA_GetPredefinedEntries_forposing", new object[] { }, new GenerateCollectionFromReader(GenerateAllPredefinedEntries));
    }

    public CollectionBase GenerateAllPredefinedEntries(ref IDataReader rdr)
    {
        BLLCollection<FA_PredefinedEntries> col = new BLLCollection<FA_PredefinedEntries>();
        try
        {
            while (rdr.Read())
            {
                FA_PredefinedEntries obj = new FA_PredefinedEntries();
                
                obj.EntryNo = (int)rdr["EntryNo"];
                obj.StartDate = rdr["StartDate"].ToString();
                obj.EndDate = rdr["EndDate"].ToString();
                obj.Planned = rdr["Planned"].ToString();
                obj.GLCode = rdr["GLCode"].ToString();
                obj.SubGLCode = rdr["SubGLCode"].ToString();
                obj.ProfitCenter = rdr["ProfitCenter"].ToString();
                obj.CostCenter = rdr["CostCenter"].ToString();
                obj.DebitAmount=Convert.ToDouble(rdr["DebitAmount"]);
                obj.CreditAmount=Convert.ToDouble(rdr["CreditAmount"]);
                obj.Description=rdr["Description"].ToString();
                obj.PostedBy = rdr["PostedBy"].ToString();
                obj.PostedOn = rdr["PostedOn"].ToString();
                obj.LineNo = (int)rdr["LineNo"];
                obj.Id = (int)rdr["Id"];
               // obj.Planned = rdr["Planned"].ToString();
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratePredefinedEntriesList_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }


    public FA_PredefinedEntries GetPredefinedEntries_ById(int id)
    {
        return (FA_PredefinedEntries)ExecuteReader("Sp_FA_GetPredefinedEntriesDetails_ById", new object[] { id }, new GenerateObjectFromReader(GeneratePredefinedEntriesById_mstCollection));
    }

    public object GeneratePredefinedEntriesById_mstCollection(ref IDataReader rdr)
    {
        FA_PredefinedEntries obj = new FA_PredefinedEntries();
        try
        {
            while (rdr.Read())
            {
                obj.EntryNo = (int)rdr["EntryNo"];
                obj.StartDate = rdr["StartDate"].ToString();
                obj.EndDate = rdr["EndDate"].ToString();
                obj.Planned = rdr["Planned"].ToString();
                obj.GLCode = rdr["GLCode"].ToString();
                obj.ProfitCenter = rdr["ProfitCenter"].ToString();
                obj.SubGLCode = rdr["SubGLCode"].ToString();
                obj.CostCenter = rdr["CostCenter"].ToString();
                obj.Description = rdr["Description"].ToString();
                if (rdr["DebitAmount"] != DBNull.Value)
                {
                    obj.DebitAmount = Convert.ToDouble(rdr["DebitAmount"]);
                }
                if (rdr["CreditAmount"] != DBNull.Value)
                {
                    obj.CreditAmount = Convert.ToDouble(rdr["CreditAmount"]);
                }
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GeneratePredefinedEntriesById_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }


    public int UpdatePredefinedEntries(int Id, string startdate, string enddate, string planned, string glcode, string profitcenter, string subglcode, string costcenter, string description, double debitamount, double creditamount)
    {
        return (int)ExecuteNonQuery("Sp_FA_UpdatePredefinedEntriesDetails", new object[] { Id, startdate, enddate, planned, glcode, profitcenter, subglcode, costcenter, description, debitamount, creditamount });
    }
  
   
    public BLLCollection<FA_PostExpenseForwarding> GetAllExpenseForForwarding(string voucherid)
    {
        return (BLLCollection<FA_PostExpenseForwarding>)ExecuteReader("Sp_FA_GetExpenseforwarding", new object[] { voucherid }, new GenerateCollectionFromReader(GenerateAllExpenseForwarding));
    }
    public BLLCollection<FA_PostExpenseForwarding> GetExpense_By_BillNo(string billno)
    {
        return (BLLCollection<FA_PostExpenseForwarding>)ExecuteReader("Sp_FA_GetExpenseforwarding_ByBillNo", new object[] { billno }, new GenerateCollectionFromReader(GenerateAllExpenseForwarding));
    }
    public BLLCollection<FA_PostExpenseForwarding> GetExpenseBillNo(string billno)
    {
        return (BLLCollection<FA_PostExpenseForwarding>)ExecuteReader("Sp_FA_GetExpenseforwardingBillNos", new object[] { billno }, new GenerateCollectionFromReader(GenerateExpenseForwardingBillNo));
    }
    public CollectionBase GenerateExpenseForwardingBillNo(ref IDataReader rdr)
    {
        BLLCollection<FA_PostExpenseForwarding> col = new BLLCollection<FA_PostExpenseForwarding>();
        try
        {
            while (rdr.Read())
            {
                FA_PostExpenseForwarding obj = new FA_PostExpenseForwarding();
                obj.InvoiceId = rdr["Invoiceid"].ToString();
                obj.BillNo=rdr["BillNo"].ToString();
                obj.BillDate = rdr["BillDate"].ToString();
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateAllExpenseForwarding -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public CollectionBase GenerateAllExpenseForwarding(ref IDataReader rdr)
    {
        BLLCollection<FA_PostExpenseForwarding> col = new BLLCollection<FA_PostExpenseForwarding>();
        try
        {
            while (rdr.Read())
            {
                FA_PostExpenseForwarding obj = new FA_PostExpenseForwarding();
                obj.Id = rdr["VoucherId"].ToString();
                obj.LineitemId = rdr["PaymentForwardLineId"].ToString();
                obj.VoucherSeries = rdr["VoucherSeries"].ToString();
                obj.VoucherDate = rdr["VoucherDate"].ToString();
                obj.FYear = rdr["FYear"].ToString();
                obj.VendorCode = rdr["VendorCode"].ToString();
                obj.Remarks = rdr["Remarks"].ToString();
                obj.InvoiceId = rdr["Invoiceid"].ToString();
                obj.ExpenseType = rdr["ExpenseType"].ToString();
                obj.BillNo=rdr["BillNo"].ToString();
                obj.BillDate = rdr["BillDate"].ToString();
                obj.Currency = rdr["Currency"].ToString();
                obj.FxAmount = rdr["FxAmount"].ToString();
                obj.FxRate = rdr["FxRate"].ToString();
                obj.AmountInUsed = rdr["AmountInUSD"].ToString();
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateAllExpenseForwarding -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_PostExpenseForwarding> GetExpenseVoucherId()
    {
        return (BLLCollection<FA_PostExpenseForwarding>)ExecuteReader("Sp_FA_GetAllExpenseVocherNo", new object[] { }, new GenerateCollectionFromReader(GenerateAllExpenseVoucherId));
    }
    public CollectionBase GenerateAllExpenseVoucherId(ref IDataReader rdr)
    {
        BLLCollection<FA_PostExpenseForwarding> col = new BLLCollection<FA_PostExpenseForwarding>();
        try
        {
            while (rdr.Read())
            {
                FA_PostExpenseForwarding obj = new FA_PostExpenseForwarding();
                obj.Id = rdr["VoucherId"].ToString();
                obj.VoucherNo = rdr["VoucherNo"].ToString();
                obj.FYear = rdr["FinancialYear"].ToString();
                obj.VoucherDate = rdr["VoucherDate"].ToString();
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateAllExpenseVoucherId -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_PostExpenseForwarding> GetExpenseByVoucherId(string voucherid)
    {
        return (BLLCollection<FA_PostExpenseForwarding>)ExecuteReader("Sp_FA_GetAllExpenseVocherNo", new object[] { voucherid }, new GenerateCollectionFromReader(GenerateAllExpenseVoucherId));
    }
    public int Updateexpenseforwarding(string voucherid,string lineid)
    {
        return (int)ExecuteNonQuery("Sp_FA_expenseentrysent_update", new object[] { voucherid,lineid });
    }
    public int insertexpenseforwarding(string voucherid, string vtype, string vseries, string vyear, string vdate, string createdby, string lineitemid)
    {
        return (int)ExecuteNonQuery("Sp_FA_expenseentry_insert", new object[] {voucherid,vtype,vseries,vyear,vdate,createdby,lineitemid});
    }
    public int inserjournal_Otherpurchases_details(FA_JournalVoucher_OtherPurchases obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_JournalVoucher_OtherPurchase_Insert", new object[] { obj.LineNo, obj.VoucherSeries, obj.VoucherYear, obj.VoucherNo, obj.VoucherDate, obj.Vendor, obj.VendorInvoice, obj.VendorInvoiceDate, obj.InvoiceBLDate, obj.CreditDays, obj.DueDate, obj.Amount, obj.HeaderDesc, obj.Asset, obj.EmpCode, obj.Project, obj.SubProject, obj.VoucherDescription, obj.GlCode, obj.GlSubCode, obj.DebitAmount, obj.CostCenter, obj.ProfitCenter, obj.CreatedBy, obj.CreatedDate,obj.DetailDescription });
    }
    public int insertjournal_vatdetails_OtherPurchases(FA_Journal_OtherPurchases_Vat obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_VATDetail_OtherPurchases_Insert", new object[] { obj.LineNo, obj.VoucherNo, obj.VatLineNo, obj.VendorCode, obj.VendorName, obj.BaseAmount, obj.VAmount, obj.TaxInvoice, obj.TaxInvoiceDate, obj.Rate, obj.CreatedBy, obj.Active });
    }
    public string GetTopVoucherNo_OtherPurchase()
    {
        return (string)ExecuteScalarString("Sp_FA_GetTopVoucherNo_OtherPurchase", new object[] { });
    }
    public int InsertInvoiceVerification(FA_InvoiceVerification obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_InsertInvoiceVerification", new object[] { obj.VoucherSeries, obj.VoucherYear, obj.IVType, obj.VoucherDate, obj.GR, obj.PO, obj.Vendor, obj.POValueInLC, obj.TaxInvoice, obj.TaxInvoiceDate, obj.DueDate, obj.POFxValue,obj.POFxValueAlreadyCreated, obj.PaymentTermsInPO, obj.ExchangerateInPO, obj.FxValueInPO, obj.Vat, obj.AdjValue, obj.VatAdj, obj.ImportDuty, obj.FxValue, obj.Currency, obj.ExchangeRate, obj.ValueInLC,obj.CreatedBy });              
    }
    public int UpdateInvoiceVerification(string voucherno, string voucherseries, string voucheryear, string ivtype, string vouchedate, string gr, string po,
                                  string vendor, double povalueinlc, string taxinvoice, string taxinvoicedate, string duedate,double pofxvaluealreadycreated,
                                  string paymenttermsinpo, double exchangerateinpo, double fxvalueinpo, double vat, double adjvalue,
                                  double vatadj, double importduty, double fxvalue, string currency, double exchangerate, double valueinlc, string modifiedby)
    {
        return (int)ExecuteNonQuery("Sp_FA_UpdateInvoiceVerification", new object[] {voucherno,voucherseries,voucheryear,ivtype,vouchedate,gr,po,vendor,povalueinlc,
                                   taxinvoice,taxinvoicedate,duedate,pofxvaluealreadycreated,paymenttermsinpo,exchangerateinpo,fxvalueinpo,
                                   vat, adjvalue,vatadj, importduty, fxvalue,currency,exchangerate,valueinlc,modifiedby});              
    }


    public BLLCollection<FA_SLMaster> GetSLA_ByGLCode(string glcode)
    {
        return (BLLCollection<FA_SLMaster>)ExecuteReader("Sp_FA_GetSLCodes_ByGLCode", new object[] { glcode }, new GenerateCollectionFromReader(GenerateSLByGLCode));
    }
    public CollectionBase GenerateSLByGLCode(ref IDataReader rdr)
    {
        BLLCollection<FA_SLMaster> col = new BLLCollection<FA_SLMaster>();
        try
        {
            while (rdr.Read())
            {
                FA_SLMaster obj = new FA_SLMaster();
                obj.SubSidiaryLedgerCode = Convert.ToInt32(rdr["SubsidiaryLedgerCode"]);
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateSLByGLCode -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public string GetVendorName_By_VendorCode(string vcode)
    {
        return (string)ExecuteScalarString("Sp_FA_GetVendorName_ByVendorId", new object[] { vcode});
    }
    public int insertinimportdutybooking(FA_ImportDutyBooking obj)
    {
        return (int)ExecuteNonQuery("Sp_FA_ImportDutyBooking_Insert", new object[] { obj.LineNo, obj.VoucherYear, obj.VoucherNo, obj.VoucherDate, obj.GlCode, obj.GlSubCode,obj.InputSubCode, obj.PONO, obj.DutyAmount, obj.ImportVat, obj.MisLeAdj, obj.ChequeNo, obj.ChequeDate, obj.CreatedBy, obj.CreatedDate });
    }
    public int updateinimportdutybooking(string voucherno, string glcode, string glsubcode, string inputsubcode, string chequeno, string cheqedate,string modifiedby)
    {
        return (int)ExecuteNonQuery("Sp_FA_ImportDutyBooking_Update", new object[] { voucherno,glcode,glsubcode,inputsubcode,chequeno,cheqedate,modifiedby });
    }
    public BLLCollection<FA_ImportDutyBooking> GetAllImportDutyVoucherNo(string searchwhat)
    {
        return (BLLCollection<FA_ImportDutyBooking>)ExecuteReader("Sp_FA_GetImportDutyBooking_VoucherNo", new object[] {searchwhat}, new GenerateCollectionFromReader(GenerateImportDutyBookingVoucherNo));
    }
    public CollectionBase GenerateImportDutyBookingVoucherNo(ref IDataReader rdr)
    {
        BLLCollection<FA_ImportDutyBooking> col = new BLLCollection<FA_ImportDutyBooking>();
        try
        {
            while (rdr.Read())
            {
                FA_ImportDutyBooking obj = new FA_ImportDutyBooking();
                obj.VoucherNo = rdr["VoucherNo"].ToString();
                obj.GlCode = rdr["BankGLCode"].ToString();
                obj.GlSubCode = rdr["SLCode"].ToString();
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateImportDutyBookingVoucherNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_InvoiceVerification> GetAllVoucherNo(string searchwhat)
    {
        return (BLLCollection<FA_InvoiceVerification>)ExecuteReader("Sp_FA_GetAll_InvoiceVerification_VoucherNo", new object[] { searchwhat }, new GenerateCollectionFromReader(GenerateAllVoucherNoInvoiceVerification));
    }
    public CollectionBase GenerateAllVoucherNoInvoiceVerification(ref IDataReader rdr)
    {
        BLLCollection<FA_InvoiceVerification> col = new BLLCollection<FA_InvoiceVerification>();
        try
        {
            while (rdr.Read())
            {
                FA_InvoiceVerification obj = new FA_InvoiceVerification();
                obj.VoucherNo = rdr["VoucherNo"].ToString();
                obj.GR = rdr["GR"].ToString();
                obj.PO = rdr["PO"].ToString();
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateImportDutyBooking -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public FA_ImportDutyBooking GetImportDuty_HeaderInfo_By_Voucherno(string vnumber)
    {
        return (FA_ImportDutyBooking)ExecuteReader("Sp_FA_GetImportDutyHeaderInfo_By_VoucherNo", new object[] { vnumber }, new GenerateObjectFromReader(GenerateImportDutyBooking_HeaderInfo_VoucherNo));
    }
    public object GenerateImportDutyBooking_HeaderInfo_VoucherNo(ref IDataReader rdr)
    {
        FA_ImportDutyBooking obj = new FA_ImportDutyBooking();
        try
        {
            while (rdr.Read())
            {
                obj.VoucherNo = rdr["VoucherNo"].ToString();
                obj.VoucherYear = rdr["VoucherYear"].ToString();
                obj.VoucherDate = rdr["VoucherDate"].ToString();
                obj.GlCode = rdr["BankGLCode"].ToString();
                obj.GlSubCode = rdr["SLCode"].ToString();
                obj.InputSubCode = rdr["InputSLCode"].ToString();
                obj.ChequeNo = rdr["ChequeNo"].ToString();
                obj.ChequeDate = rdr["ChequeDate"].ToString();
            }

            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateImportDutyBooking_HeaderInfo_VoucherNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }    //
    public FA_InvoiceVerification GetInvoiceVerification_HeaderInfo_By_Voucherno(string vnumber)
    {
        return (FA_InvoiceVerification)ExecuteReader("Sp_FA_GetInvoiceVerificationInfo_By_VoucherNo", new object[] { vnumber }, new GenerateObjectFromReader(GetInvoiceVerificationHeaderInfoByVoucherno));
    }
    public object GetInvoiceVerificationHeaderInfoByVoucherno(ref IDataReader rdr)
    {
        FA_InvoiceVerification obj = new FA_InvoiceVerification();
        try
        {
            while (rdr.Read())
            {
                obj.VoucherNo = rdr["VoucherNo"].ToString();
                obj.VoucherSeries = rdr["VoucherSeries"].ToString();
                obj.VoucherYear = rdr["VoucherYear"].ToString();
                obj.IVType = rdr["IVType"].ToString();
                obj.VoucherDate = rdr["VoucherDate"].ToString();
                obj.GR = rdr["GR"].ToString();
                obj.PO = rdr["PO"].ToString();
                obj.Vendor = rdr["Vendor"].ToString();
                obj.POValueInLC = Convert.ToDouble(rdr["POValueInLC"]);
                obj.TaxInvoice = rdr["TaxInvoice"].ToString();
                obj.TaxInvoiceDate = rdr["TaxInvoiceDate"].ToString();
                obj.DueDate = rdr["DueDate"].ToString();
                obj.PO = rdr["PO"].ToString();
                obj.POFxValue = Convert.ToDouble(rdr["POFxValue"]);
                obj.POFxValueAlreadyCreated = Convert.ToDouble(rdr["POFxValueAlreadyCreated"]);
                obj.PaymentTermsInPO = rdr["PaymentTermsInPO"].ToString();
                obj.ExchangerateInPO = Convert.ToDouble(rdr["ExchangerateInPO"]);
                obj.FxValueInPO = Convert.ToDouble(rdr["FxValueInPO"]);
                obj.Vat = Convert.ToDouble(rdr["Vat"].ToString());
                obj.AdjValue =Convert.ToDouble(rdr["AdjValue"]);
                obj.VatAdj = Convert.ToDouble(rdr["VatAdj"]);
                obj.ImportDuty = Convert.ToDouble(rdr["ImportDuty"]);
                obj.FxValue = Convert.ToDouble(rdr["FxValue"]);
                obj.Currency = rdr["Currency"].ToString();
                obj.ExchangeRate = Convert.ToDouble(rdr["ExchangeRate"]);
                obj.ValueInLC = Convert.ToDouble(rdr["ValueInLC"]);
            }

            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetInvoiceVerificationHeaderInfoByVoucherno -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return obj;
    }    //
    public BLLCollection<FA_ImportDutyBooking> GenerateImportDutyBooking_DetailsInfo_VoucherNo(string voucherno)
    {
        return (BLLCollection<FA_ImportDutyBooking>)ExecuteReader("Sp_FA_GetImportDutyDetailsInfo_By_VoucherNo", new object[] { voucherno }, new GenerateCollectionFromReader(GenerateImportDutyBooking_Details_VoucherNo));
    }
    public CollectionBase GenerateImportDutyBooking_Details_VoucherNo(ref IDataReader rdr)
    {
        BLLCollection<FA_ImportDutyBooking> col = new BLLCollection<FA_ImportDutyBooking>();
        try
        {
            while (rdr.Read())
            {
                FA_ImportDutyBooking obj = new FA_ImportDutyBooking();
                obj.PONO = rdr["PONumber"].ToString();
                obj.LineNo = Convert.ToInt32(rdr["LineNo"]);
                obj.DutyAmount = Convert.ToDouble(rdr["DutyAmount"]);
                obj.ImportVat = Convert.ToDouble(rdr["ImportVat"]);
                obj.MisLeAdj=Convert.ToDouble(rdr["MeslAdj"]);
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GenerateImportDutyBooking -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<FA_Glb_WHTType> GetAllWHTType()
    {
        return (BLLCollection<FA_Glb_WHTType>)ExecuteReader("Sp_FA_GetAllWHTType", new object[] { }, new GenerateCollectionFromReader(GetAll_whttype));
    }
    public CollectionBase GetAll_whttype(ref IDataReader rdr)
    {
        BLLCollection<FA_Glb_WHTType> col = new BLLCollection<FA_Glb_WHTType>();
        try
        {
            while (rdr.Read())
            {
                FA_Glb_WHTType obj = new FA_Glb_WHTType();
                obj.Id = rdr["Id"].ToString();
                obj.WhtType = rdr["WHTType"].ToString();
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetAll_whttype -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    #endregion

    public int insertcustomercallservice(SAL_CustomerCallService obj)
    {
        return (int)ExecuteNonQuery("Sp_Sal_Insert_CustomerCallService_header_trans", new object[] {obj.CSCRType,obj.Year,obj.CSCRDate,obj.ComplaintObservation,obj.CustomerCode,obj.FinalCustomer,obj.ContactPerson,obj.HeaderWeight,obj.Value,obj.Currency,obj.SampleRecieved,obj.NatureOfComplaint,obj.CustomerClaim,obj.PhotoReceived,obj.AreaOfComplaint,obj.DANo,obj.NoOfRolls,obj.CreditNotes,obj.TSObservation,obj.FirstResponseDate,obj.FirstDelyBy,obj.SecondResponseDate,obj.SecondDelyBy,obj.ThirdResponseDate,obj.ThirdDelyBy,obj.OPLS,obj.ActionPlan,obj.ActionTaken,obj.ReturnQuality,obj.ReturnValue,obj.CreatedOn,obj.CreatedBy,obj.CSCRLineNo,obj.InvoiceNo,obj.FullInvoice,obj.BatchNo,obj.SubType,obj.Micron,obj.Length,obj.Width,obj.Weight,obj.ComplaintDescription,obj.ExpDateOfCompletion,obj.ResponsiblePerson,obj.CompletionDate,obj.Remarks,obj.CallStatus });
    }

    #region Vishal Code
    //////////// Add by Vishal 20 June

    public BLLCollection<Prod_RawMaterialFeeding> Get_LineCode()
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Sp_Get_Prod_Line_Mst", new object[] { }, new GenerateCollectionFromReader(GetLineCode_mstCollection));
    }
    public CollectionBase GetLineCode_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Prod_RawMaterialFeeding> col = new BLLCollection<Prod_RawMaterialFeeding>();
        try
        {
            while (returnData.Read())
            {
                Prod_RawMaterialFeeding obj = new Prod_RawMaterialFeeding();
                obj.LineCode = (string)returnData["LineCode"];
                obj.autoId = (int)returnData["autoid"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetLineCode_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<Prod_RawMaterialFeeding> Get_ExtruderCode()
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Sp_Get_Prod_Extruder_Mst", new object[] { }, new GenerateCollectionFromReader(Get_ExtruderCode_mstCollection));
    }
    public CollectionBase Get_ExtruderCode_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Prod_RawMaterialFeeding> col = new BLLCollection<Prod_RawMaterialFeeding>();
        try
        {
            while (returnData.Read())
            {
                Prod_RawMaterialFeeding obj = new Prod_RawMaterialFeeding();
                obj.ExtruderCode = (string)returnData["ExtruderCode"];
                obj.autoId = (int)returnData["autoid"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- Get_ExtruderCode_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<Prod_RawMaterialFeeding> Get_RawMatCode()
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Sp_Get_Prod_RawMaterial_Mst", new object[] { }, new GenerateCollectionFromReader(Get_RawMatCode_mstCollection));
    }
    public CollectionBase Get_RawMatCode_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Prod_RawMaterialFeeding> col = new BLLCollection<Prod_RawMaterialFeeding>();
        try
        {
            while (returnData.Read())
            {
                Prod_RawMaterialFeeding obj = new Prod_RawMaterialFeeding();
                obj.RMCode = (string)returnData["RMCode"];
                //    obj.RMDesc = (string)returnData["RMDesc"];
                obj.autoId = (int)returnData["autoid"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- Get_RawMatCode_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<Prod_RawMaterialFeeding> Get_RawMaterialVoucherNumber()
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Sp_Prod_Get_Raw_Material_FeedingVoucherNumber", new object[] { }, new GenerateCollectionFromReader(Get_RawMaterialVoucherNumber_mstCollection));
    }
    public CollectionBase Get_RawMaterialVoucherNumber_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Prod_RawMaterialFeeding> col = new BLLCollection<Prod_RawMaterialFeeding>();
        try
        {
            while (returnData.Read())
            {
                Prod_RawMaterialFeeding obj = new Prod_RawMaterialFeeding();
                obj.VoucherNo = (int)returnData["VoucherNo"];
                //  obj.Id = (int)returnData["Id"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- Get_RawMaterialVoucherNumber_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    
    public BLLCollection<Prod_RawMaterialFeeding> Get_AllDataRawMat()
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Sp_Get_Prod_Raw_Material_Feeding", new object[] { }, new GenerateCollectionFromReader(Get_AllDataRawMat_mstCollection));
    }
    public CollectionBase Get_AllDataRawMat_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Prod_RawMaterialFeeding> col = new BLLCollection<Prod_RawMaterialFeeding>();
        try
        {
            while (returnData.Read())
            {
                Prod_RawMaterialFeeding obj = new Prod_RawMaterialFeeding();
                obj.autoId = (int)returnData["autoid"];
                obj.ExtruderCode = (string)returnData["Extruder"];
                obj.RMCode = (string)returnData["Raw_Mat_Code"];
                obj.quantity = Convert.ToString((decimal)returnData["Qty_In_KG"]);
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- Get_AllDataRawMat_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public BLLCollection<Prod_RawMaterialFeeding> Get_RawMaterialVoucherDetails_ByVoucherId(int voucherno)
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Sp_Set_Prod_Raw_Material_Feeding_by_VoucherNo", new object[] { voucherno }, new GenerateCollectionFromReader(GetDetailsByRawMaterialVoucherId));
    }
    public CollectionBase GetDetailsByRawMaterialVoucherId(ref IDataReader rdr)
    {
        BLLCollection<Prod_RawMaterialFeeding> col = new BLLCollection<Prod_RawMaterialFeeding>();
        try
        {
            while (rdr.Read())
            {
                Prod_RawMaterialFeeding obj = new Prod_RawMaterialFeeding();
                if (rdr["autoid"] != DBNull.Value)
                {
                    obj.autoId = (int)rdr["autoid"];
                }
                if (rdr["VoucherNo"] != DBNull.Value)
                {
                    obj.VoucherNo = (int)rdr["VoucherNo"];
                }
                if (rdr["Extruder"] != DBNull.Value)
                {
                    obj.ExtruderCode = (string)rdr["Extruder"];
                }
                if (rdr["Raw_Mat_Code"] != DBNull.Value)
                {
                    obj.RMCode = (string)rdr["Raw_Mat_Code"];
                }
                if (rdr["Qty_In_KG"] != DBNull.Value)
                {
                    obj.quantity = Convert.ToString((decimal)rdr["Qty_In_KG"]);
                }
                col.Add(obj);
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetDetailsByRawMaterialVoucherId -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public int UpdateRawMaterialVoucher(int VoucherNo, int Line, string Remarks, string Extruder, string Raw_Mat_Code, string Qty_In_KG, string LastModifiedBy)
    {
        return (int)ExecuteNonQuery("Sp_Prod_Update_RawMaterial", new object[] { VoucherNo, Line, Remarks, Extruder, Raw_Mat_Code, Qty_In_KG, LastModifiedBy });

    }
    ///////Plant Feeding
    public BLLCollection<Prod_RawMaterialFeeding> Get_Thickness()
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Sp_Get_Prod_Thickness_Mst", new object[] { }, new GenerateCollectionFromReader(GetThicknessCode_mstCollection));
    }
    public CollectionBase GetThicknessCode_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Prod_RawMaterialFeeding> col = new BLLCollection<Prod_RawMaterialFeeding>();
        try
        {
            while (returnData.Read())
            {
                Prod_RawMaterialFeeding obj = new Prod_RawMaterialFeeding();
                obj.Thickness = (string)returnData["Thickness"];
                obj.Thicknessid = Convert.ToInt32(returnData["ThicknessId"].ToString());
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetThicknessCode_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }
    public int UpdatePETPlantFeeding(int Autoid, int Line, int Thickness, string Run, string Lumps, string Cast, string Mono, string Break, string Remarks, string LastModifiedBy, string LastModifiedOn)
    {
        return (int)ExecuteNonQuery("Sp_Prod_Update_PET_Plant_Feeding", new object[] { Autoid, Line, Thickness, Run, Lumps, Cast, Mono, Break, Remarks, LastModifiedBy, LastModifiedOn });

    }
    public int UpdateMETPlantFeeding(int Autoid, int line, string Aluminium, string Boats, string Remarks, string LastModifiedBy, string LastModifiedOn)
    {
        return (int)ExecuteNonQuery("Sp_Prod_Update_MET_Plant_Feeding", new object[] { Autoid, line, Aluminium, Boats, Remarks, LastModifiedBy, LastModifiedOn });

    }

    ////////26/06/2012 Vishal
    /// <summary>
    /// //Scarp Received
    /// </summary>
    /// <returns></returns>
    /// 
    public BLLCollection<Proc_ScarpReceived> Get_MaterialCode()
    {
        return (BLLCollection<Proc_ScarpReceived>)ExecuteReader("Sp_Get_Proc_Material_Mst", new object[] { }, new GenerateCollectionFromReader(GetMaterialCode_mstCollection));
    }

    public CollectionBase GetMaterialCode_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Proc_ScarpReceived> col = new BLLCollection<Proc_ScarpReceived>();
        try
        {
            while (returnData.Read())
            {
                Proc_ScarpReceived obj = new Proc_ScarpReceived();
                obj.Code = (string)returnData["Code"];
                obj.autoId = Convert.ToInt32(returnData["AutoId"]);
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetLineCode_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<Proc_ScarpReceived> Get_Plant()
    {
        return (BLLCollection<Proc_ScarpReceived>)ExecuteReader("Sp_Get_Proc_Plant_Mst", new object[] { }, new GenerateCollectionFromReader(GetPlant_mstCollection));
    }

    public CollectionBase GetPlant_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Proc_ScarpReceived> col = new BLLCollection<Proc_ScarpReceived>();
        try
        {
            while (returnData.Read())
            {
                Proc_ScarpReceived obj = new Proc_ScarpReceived();
                obj.PlantCode = (string)returnData["PlantCode"];
                obj.autoId = Convert.ToInt32(returnData["autoid"].ToString());
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetPlant_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<Proc_ScarpReceived> Get_Valuatory()
    {
        return (BLLCollection<Proc_ScarpReceived>)ExecuteReader("Sp_Get_Proc_Valuatory_Mst", new object[] { }, new GenerateCollectionFromReader(GetValuetary_mstCollection));
    }

    public CollectionBase GetValuetary_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Proc_ScarpReceived> col = new BLLCollection<Proc_ScarpReceived>();
        try
        {
            while (returnData.Read())
            {
                Proc_ScarpReceived obj = new Proc_ScarpReceived();
                obj.Valuetype = (string)returnData["ValuationType"];
                obj.autoId = (int)returnData["AutoId"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetValuetary_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public BLLCollection<Proc_ScarpReceived> Get_StorageLocation()
    {
        return (BLLCollection<Proc_ScarpReceived>)ExecuteReader("Sp_Get_Proc_StorageLocation_Mst", new object[] { }, new GenerateCollectionFromReader(GetStorageLocation_mstCollection));
    }

    public CollectionBase GetStorageLocation_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Proc_ScarpReceived> col = new BLLCollection<Proc_ScarpReceived>();
        try
        {
            while (returnData.Read())
            {
                Proc_ScarpReceived obj = new Proc_ScarpReceived();
                obj.StorageLocCode = (string)returnData["StorageLocCode"];
                obj.autoId = (int)returnData["autoid"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetStorageLocation_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public decimal GetScarpTopEntryNo()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Proc_Get_Scrap_Received_Header_EntryNumber", new object[] { });
    }

    public BLLCollection<Proc_ScarpReceived> Get_AllDataScarpReceived()
    {
        return (BLLCollection<Proc_ScarpReceived>)ExecuteReader("Sp_Get_Prod_Raw_Material_Feeding", new object[] { }, new GenerateCollectionFromReader(Get_AllDataScarpReceived_mstCollection));
    }

    public CollectionBase Get_AllDataScarpReceived_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Proc_ScarpReceived> col = new BLLCollection<Proc_ScarpReceived>();
        try
        {
            while (returnData.Read())
            {
                Proc_ScarpReceived obj = new Proc_ScarpReceived();
                //obj.autoId = (int)returnData["autoid"];
                //obj.ExtruderCode = (string)returnData["Extruder"];
                //obj.RMCode = (string)returnData["Raw_Mat_Code"];
                //obj.quantity = Convert.ToString((decimal)returnData["Qty_In_KG"]);
                //col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- Get_AllDataScarpReceived_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public string Insert_In_Scarp_Received_Header(string Year, string Entry, string EntreyDate, string CreatedBy)
    {
        string ScrapID = "";
        try
        {
            objConnectionClass.OpenConnection();
            //    sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("PI");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            //  cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Year", Year);
            cmd.Parameters.Add("@Entry", Convert.ToInt32(Entry));
            cmd.Parameters.Add("@EntryDate", Convert.ToDateTime(EntreyDate));
            //
            cmd.Parameters.Add("@CreatedBy", Convert.ToInt32(CreatedBy));
            cmd.Parameters.Add("@ScrapID", SqlDbType.Int);
            cmd.Parameters["@ScrapID"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_Proc_Insert_In__ScrapReceivedHeader";
            cmd.ExecuteNonQuery();

            ScrapID = cmd.Parameters["@ScrapID"].Value.ToString();


            #endregion


            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();


        }
        catch
        {

        }


        return ScrapID;
    }

    public decimal GetScarpTopLineNumber()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Proc_Get_Scrap_Received_LineNumber", new object[] { });
    }

    public int UpdateScrapReceived(int autoid, int MaterialCode, int PlantCode, int Valuetype, int StorageLocCode, string Quantity, string StockOUM, string LastModifiedBy)
    {
        return (int)ExecuteNonQuery("Sp_Proc_Update_ScrapReceived", new object[] { autoid, MaterialCode, PlantCode, Valuetype, StorageLocCode, Quantity, StockOUM, LastModifiedBy });

    }

    public decimal GetLastSeriesNumber()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Proc_Get_Chips_Bagging_Header_SeriesNumber", new object[] { });
    }

    public decimal GetChipsTopLineNo()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Proc_Get_Chips_Bagging_ListItems_LineNumber", new object[] { });
    }

    public string Insert_In_Chip_Bagging_Header(int Series, string Year, string VoucherNumber, string BaggingDate, string CreatedBy)
    {
        string ChipID = "";
        try
        {
            objConnectionClass.OpenConnection();
            //    sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("PI");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            //  cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Series", Series);
            cmd.Parameters.Add("@Year", Year);
            cmd.Parameters.Add("@VoucherNumber", VoucherNumber);
            cmd.Parameters.Add("@BaggingDate", Convert.ToDateTime(BaggingDate));
            //
            cmd.Parameters.Add("@CreatedBy", Convert.ToInt32(CreatedBy));
            cmd.Parameters.Add("@ChipsID", SqlDbType.Int);
            cmd.Parameters["@ChipsID"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_Proc_Insert_In__ChipsBaggingHeader";
            cmd.ExecuteNonQuery();

            ChipID = cmd.Parameters["@ChipsID"].Value.ToString();


            #endregion


            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();


        }
        catch
        {

        }


        return ChipID;
    }

    public int UpdateChipsBagging(string VoucherNumber, int MaterialCode, string StockOUM, int StorageLocCode, string chipsBag, string Quantity, string LastModifiedBy)
    {
        return (int)ExecuteNonQuery("Sp_Proc_Update_ChipsBagging", new object[] { VoucherNumber, MaterialCode, StockOUM, StorageLocCode, chipsBag, Quantity, LastModifiedBy });

    }

    public BLLCollection<Proc_SalesOrderInventory> Get_MaterialType()
    {
        return (BLLCollection<Proc_SalesOrderInventory>)ExecuteReader("Sp_Get_Proc_MaterialType_Mst", new object[] { }, new GenerateCollectionFromReader(GetMaterialType_mstCollection));
    }

    public CollectionBase GetMaterialType_mstCollection(ref IDataReader returnData)
    {
        BLLCollection<Proc_SalesOrderInventory> col = new BLLCollection<Proc_SalesOrderInventory>();
        try
        {
            while (returnData.Read())
            {
                Proc_SalesOrderInventory obj = new Proc_SalesOrderInventory();
                obj.Code = (string)returnData["Code"];
                obj.autoId = (int)returnData["AutoId"];
                col.Add(obj);
            }
            returnData.Close();
            returnData.Dispose();
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-SqlDataProvider- GetMaterialType_mstCollection -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return col;
    }

    public string Insert_In_Inventory_Sales_Order_Header(int SalesType, string Year, string Date, int CustomerCode, int ConsigneeCode, int DeliveryTo, int MatType, int CustomerOrderNumber, string CustomerOrderDate, int CurrencyCode, int VatRate, int FinalDestination, int PaymentTerm, int DeliveryTerms, int PaymentMode, string Special, int Createdby)
    {
        string OrderID = "";
        try
        {
            objConnectionClass.OpenConnection();
            //    sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("PI");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            //  cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalesType", SalesType);
            cmd.Parameters.Add("@Year", Year);
            cmd.Parameters.Add("@Date", Convert.ToDateTime(Date));
            cmd.Parameters.Add("@CustomerCode", CustomerCode);
            //
            cmd.Parameters.Add("@ConsigneeCode", Convert.ToInt32(ConsigneeCode));
            cmd.Parameters.Add("@DeliveryTo", Convert.ToInt32(DeliveryTo));
            cmd.Parameters.Add("@MatType", Convert.ToInt32(MatType));
            cmd.Parameters.Add("@CustomerOrderNumber", Convert.ToInt32(CustomerOrderNumber));
            cmd.Parameters.Add("@CustomerOrderDate", Convert.ToDateTime(CustomerOrderDate));
            cmd.Parameters.Add("@CurrencyCode", Convert.ToInt32(CurrencyCode));
            cmd.Parameters.Add("@VatRate", Convert.ToInt32(VatRate));
            cmd.Parameters.Add("@FinalDestination", Convert.ToInt32(FinalDestination));
            cmd.Parameters.Add("@PaymentTerm", Convert.ToInt32(PaymentTerm));

            cmd.Parameters.Add("@DeliveryTerms", Convert.ToInt32(DeliveryTerms));
            cmd.Parameters.Add("@PaymentMode", Convert.ToInt32(PaymentMode));
            cmd.Parameters.Add("@Special", Special);
            cmd.Parameters.Add("@Createdby", Convert.ToInt32(Createdby));

            cmd.Parameters.Add("@OrderID", SqlDbType.Int);
            cmd.Parameters["@OrderID"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_Proc_Insert_In__Sales_Order_Inventory_Header";
            cmd.ExecuteNonQuery();

            OrderID = cmd.Parameters["@OrderID"].Value.ToString();


            #endregion


            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();


        }
        catch
        {

        }


        return OrderID;
    }

    public decimal GetLastOrderNumber()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Proc_Get_InventorySalesOrder_Header_SeriesNumber", new object[] { });
    }

    public int UpdateSalesOrder(int Autoid, int SalesType, string Year, string Date, int CustomerCode, int ConsigneeCode, int DeliveryTo, int MatType, int CustomerOrderNumber, string CustomerOrderDate, int CurrencyCode, int VatRate, int FinalDestination, int PaymentTerm, int DeliveryTerms, int PaymentMode, string Special, int OrderID, int MaterialCode, string StockOUM, string Rate, decimal Quantity, int Createdby)
    {
        return (int)ExecuteNonQuery("SP_Proc_Update_In__Sales_Order_Inventory", new object[] { Autoid, SalesType, Year, Date, CustomerCode, ConsigneeCode, DeliveryTo, MatType, CustomerOrderNumber, CustomerOrderDate, CurrencyCode, VatRate, FinalDestination, PaymentTerm, DeliveryTerms, PaymentMode, Special, OrderID, MaterialCode, StockOUM, Rate, Quantity, Createdby });

    }

    public decimal GetLastIssueNumber()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Proc_Get_MaterialIssueforSales_Header_IssueNumber", new object[] { });
    }

    public string Insert_In_MaterialIssue_Sales_Order_Header(int SaleType, string Year, string Date, int Truck, string SaleOrder, int SOCustomerID, string SOCustomerCode, string SOCustomerName, int Createdby)
    {
        string IssueID = "";
        try
        {
            objConnectionClass.OpenConnection();
            //    sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("PI");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            //  cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleType", Convert.ToInt32(SaleType));
            cmd.Parameters.Add("@Year", Year);
            cmd.Parameters.Add("@Date", Convert.ToDateTime(Date));

            cmd.Parameters.Add("@Truck", Convert.ToInt32(Truck));

            cmd.Parameters.Add("@SaleOrder", SaleOrder);
            cmd.Parameters.Add("@SOCustomerID", Convert.ToInt32(SOCustomerID));
            cmd.Parameters.Add("@SOCustomerCode", SOCustomerCode);
            cmd.Parameters.Add("@SOCustomerName", SOCustomerName);

            cmd.Parameters.Add("@Createdby", Convert.ToInt32(Createdby));

            cmd.Parameters.Add("@IssueID", SqlDbType.Int);
            cmd.Parameters["@IssueID"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_Proc_Insert_In_MaterialIssueforSales_Header";
            cmd.ExecuteNonQuery();

            IssueID = cmd.Parameters["@IssueID"].Value.ToString();


            #endregion


            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();


        }
        catch
        {

        }


        return IssueID;
    }

    public int UpdateMaterialSalesOrder(int Autoid, int IssueID, int SaleType, string Year, string Date, int Truck, string SaleOrder
    , int SOCustomerID, string SOCustomerCode, string SOCustomerName
    , int Line, int SOLine, int MaterialCodeID, int PlantID
    , int ValuationTypeID, int StorageLocationID, int Batch, int Stock
      , decimal Quantity, string UOM, int value, int LastModifyby)
    {
        return (int)ExecuteNonQuery("SP_Proc_Update_In_MaterialIssueforSales", new object[] {  Autoid ,IssueID ,SaleType, Year , Date ,Truck ,SaleOrder ,SOCustomerID, SOCustomerCode ,SOCustomerName ,Line ,SOLine , MaterialCodeID , PlantID,ValuationTypeID ,StorageLocationID , Batch , Stock 
      , Quantity , UOM , value , LastModifyby  });

    }

    public decimal GetLastVoucherNumber()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Proc_Get_CPChipsQuality_SeriesNumber", new object[] { });
    }

    public int UpdateCpChipsQuality(int Autoid, string VoucherYear, string VoucherNo, string voucherDate, string Time, int Type, decimal LAB, decimal TOV, decimal COOH, decimal ASH, decimal DEG, decimal Chips, string ColorVisual, decimal L, decimal a, decimal b, string Remarks, int Createdby)
    {
        return (int)ExecuteNonQuery("Sp_Prod_Update_CPChipsQuality", new object[] { Autoid, VoucherYear, VoucherNo, voucherDate, Time, Type, LAB, TOV, COOH, ASH, DEG, Chips, ColorVisual, L, a, b, Remarks, Createdby });

    }

    public decimal GetLastPETBatchVoucherNumber()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Prod_Get_PETBatchHistoryQuality_SeriesNumber", new object[] { });
    }

    public int UpdatePETBatchQuality(int Autoid, string VoucherYear, string VoucherNo, string VoucherDate, string Time, int Type, decimal silica, string EICycleTime, decimal EIFinalTemp, decimal BHTFilter, string BATransTime, decimal FINProdTemp, string PCReacTime
      , decimal BACustoffRPM, decimal BACutoffKW, string CastingTime, decimal IV, decimal COOH, decimal ASH, decimal DEG, decimal MP, decimal Numberofchipps, string ColourVisual, decimal L, decimal a, decimal b, string Grade, decimal Moisture
      , decimal Oligomer, string Remarks, int Createdby)
    {
        return (int)ExecuteNonQuery("Sp_Prod_Update_PETBatchHistoryQuality", new object[] { Autoid,  VoucherYear, VoucherNo, VoucherDate, Time, Type,silica, EICycleTime, EIFinalTemp,BHTFilter, BATransTime, FINProdTemp, PCReacTime
      ,BACustoffRPM,BACutoffKW, CastingTime, IV, COOH, ASH, DEG, MP, Numberofchipps, ColourVisual, L, a, b, Grade, Moisture
      , Oligomer,Remarks, Createdby});

    }

    ////////    Vishal 9 July
    public BLLCollection<Prod_RawMaterialFeeding> Get_AllDataRawMatMachinData()
    {
        return (BLLCollection<Prod_RawMaterialFeeding>)ExecuteReader("Prod_Raw_Material_Feeding_Intermediate", new object[] { }, new GenerateCollectionFromReader(Get_AllDataRawMat_mstCollection));
    }

    public string Insert_In_Raw_Material_Header(string VoucherNumber, string Date, string Line, string Remarks, string CreatedBy)
    {
        string RawMaterialID = "";
        try
        {
            objConnectionClass.OpenConnection();
            //    sqltran = objConnectionClass.PolypexSqlConnection.BeginTransaction("PI");

            #region Insert/Update in Header Table

            cmd = new SqlCommand();
            cmd.Connection = objConnectionClass.PolypexSqlConnection;
            //  cmd.Transaction = sqltran;
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoucherNumber", VoucherNumber);
            cmd.Parameters.Add("@Date", Convert.ToDateTime(Date));
            cmd.Parameters.Add("@Line", Convert.ToInt32(Line));
            cmd.Parameters.Add("@Remarks", Remarks);
            //
            cmd.Parameters.Add("@CreatedBy", Convert.ToInt32(CreatedBy));
            cmd.Parameters.Add("@RawMaterialid", SqlDbType.Int);
            cmd.Parameters["@RawMaterialid"].Direction = ParameterDirection.Output;

            cmd.CommandText = "SP_Prod_Insert_In__RawMaterialHeader";
            cmd.ExecuteNonQuery();

            RawMaterialID = cmd.Parameters["@RawMaterialid"].Value.ToString();


            #endregion


            objConnectionClass.CloseConnection();
            objConnectionClass.DisposeConnection();


        }
        catch
        {

        }


        return RawMaterialID;
    }

    public decimal GetRawMaterialTopVoucherNo()
    {
        return (decimal)ExecuteScalarDecimal("Sp_Prod_Get_Raw_Material_FeedingVoucherNumber", new object[] { });
    }
    
    public int UpdateRawMaterialHeaderandList(int Autoid, string VoucherNo, int Line, string Remarks, string Extruder, string Raw_Mat_Code, string Qty_In_KG, string LastModifiedBy)
    {
        return (int)ExecuteNonQuery("Sp_Prod_Update_RawMaterial", new object[] { Autoid, VoucherNo, Line, Remarks, Extruder, Raw_Mat_Code, Qty_In_KG, LastModifiedBy });

    }

    #endregion
}