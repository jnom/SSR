using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
    SqlCommand objcmd = new SqlCommand();
    SqlCommand objcmdT = new SqlCommand();
    public string message { get; set; }

    public DataAccess()
    {
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmdT.Connection = objcon;
        objcmdT.CommandType = CommandType.Text;
    }
    public DataTable GetDataTable(string vProcedureName)
    {
        if (objcon.State == ConnectionState.Closed) objcon.Open();
        DataTable dt = new DataTable();
        objcmd.CommandText = vProcedureName;
        SqlDataReader reader = objcmd.ExecuteReader();
        dt.Load(reader);
        if (objcon.State == ConnectionState.Open) objcon.Close();
        return dt;
    }
    public int validuser(string Pparem)
    {
        int i = 0;
        try
        {
            if (objcon.State == ConnectionState.Closed) objcon.Open();
            DataTable dt = new DataTable();
            objcmd.Parameters.AddWithValue("Pwd", Pparem);
            objcmd.CommandText = "procValidUser";
            i = Convert.ToInt32(objcmd.ExecuteScalar());
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            if (objcon.State == ConnectionState.Open) objcon.Close();
        }
        return i;
    }
    public void insertFeedback(string Name, string Email, string Msg, string SiteName = "jnom1")
    {
        if (objcon.State == ConnectionState.Closed) objcon.Open();
        objcmd.Parameters.AddWithValue("Name", Name);
        objcmd.Parameters.AddWithValue("Email", Email);
        objcmd.Parameters.AddWithValue("Message", Msg);
        objcmd.Parameters.AddWithValue("SiteName", SiteName);
        objcmd.CommandText = "ProcFeedBack";
        objcmd.ExecuteNonQuery();
        if (objcon.State == ConnectionState.Open) objcon.Close();
    }
    public void ExecuteNonQ(string sql)
    {
        try
        {
            if (objcon.State == ConnectionState.Closed) objcon.Open();
            objcmdT.CommandText = sql;
            objcmdT.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            if (objcon.State == ConnectionState.Open) objcon.Close();
        }
    }
    public DataTable ExecuteDR(string sql)
    {
        DataTable dt = new DataTable();
        SqlDataReader reader;
        try
        {
            if (objcon.State == ConnectionState.Closed) objcon.Open();
            objcmdT.CommandText = sql;
            reader = objcmdT.ExecuteReader();
            dt.Load(reader);
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            if (objcon.State == ConnectionState.Open) objcon.Close();
        }
        return dt;
    }
    public DataTable getStoreItem(int pStoreID)
    {
        DataTable dt = new DataTable();
        SqlDataReader reader;
        try
        {
            objcmd.Parameters.AddWithValue("storeID", pStoreID);
            objcmd.CommandText = "getItemByStore";
            reader = objcmdT.ExecuteReader();
            dt.Load(reader);
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        finally
        {
            if (objcon.State == ConnectionState.Open) objcon.Close();
        }
        return dt;
    }

    public int SaveGrn(saveGrn objGRN, DataTable dt)
    {
        try
        {
            int vRetu;
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            if (objcon.State == ConnectionState.Closed) objcon.Open();
            objcmd.Parameters.AddWithValue("@GRNID", objGRN.GRNID);
            objcmd.Parameters.AddWithValue("@GRNNO", objGRN.GRNNO);
            objcmd.Parameters.AddWithValue("@comapnyID", objGRN.comapnyID);
            objcmd.Parameters.AddWithValue("@storeID", objGRN.storeID);
            objcmd.Parameters.AddWithValue("@supplierID", objGRN.supplierID);
            objcmd.Parameters.AddWithValue("@transpoterID", objGRN.transpoterID);
            objcmd.Parameters.AddWithValue("@vehicleNo", objGRN.vehicleNo);
            objcmd.Parameters.AddWithValue("@vehicleEntryNo", objGRN.vehicleEntryNo);
            objcmd.Parameters.AddWithValue("@vehicleEntryDate", objGRN.vehicleEntryDate);
            objcmd.Parameters.AddWithValue("@status", objGRN.status);
            objcmd.Parameters.AddWithValue("@Remark", objGRN.Remark);
            objcmd.Parameters.AddWithValue("@invoiceNo", objGRN.invoiceNo);
            objcmd.Parameters.AddWithValue("@invoiceDate", objGRN.invoiceDate);
            objcmd.Parameters.AddWithValue("@gatePassNo", objGRN.gatePassNo);
            objcmd.Parameters.AddWithValue("@gatePassDate", objGRN.gatePassDate);
            objcmd.Parameters.AddWithValue("@DriverName", objGRN.DriverName);
            objcmd.Parameters.AddWithValue("@DriverContactNo", objGRN.DriverContactNo);
            objcmd.Parameters.AddWithValue("@createdDate", objGRN.createdDate);
            objcmd.Parameters.AddWithValue("@createdBy", objGRN.createdBy);
            objcmd.Parameters.AddWithValue("@challanNo", objGRN.challanNo);
            objcmd.Parameters.AddWithValue("@challanDate", objGRN.challanDate);
            objcmd.Parameters.AddWithValue("@approvalDate", objGRN.approvalDate);
            objcmd.Parameters.AddWithValue("@approvalBy", objGRN.approvalBy);
            objcmd.Parameters.AddWithValue("@childXml", ds.GetXml());
            objcmd.Parameters.AddWithValue("@tblName", ds.DataSetName + "/" + ds.Tables[0].TableName);
            objcmd.CommandText = "ProcFeedBack";
            vRetu = objcmd.ExecuteNonQuery();
            if (objcon.State == ConnectionState.Open) objcon.Close();
            return vRetu;
        }
        catch (Exception)
        {
            if (objcon.State == ConnectionState.Open) objcon.Close();
            return 0;
        }
    }
}