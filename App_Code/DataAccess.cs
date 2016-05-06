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

    public int insertFeedback(saveGrn objGRN)
    {
        try
        {
            int vRetu;
            if (objcon.State == ConnectionState.Closed) objcon.Open();
            objcmd.Parameters.AddWithValue("", objGRN.GRNID);
            objcmd.Parameters.AddWithValue("", objGRN.GRNNO);
            objcmd.Parameters.AddWithValue("", objGRN.comapnyID);
            objcmd.Parameters.AddWithValue("", objGRN.storeID);
            objcmd.Parameters.AddWithValue("", objGRN.supplierID);
            objcmd.Parameters.AddWithValue("", objGRN.transpoterID);
            objcmd.Parameters.AddWithValue("", objGRN.vehicleNo);
            objcmd.Parameters.AddWithValue("", objGRN.vehicleEntryNo);
            objcmd.Parameters.AddWithValue("", objGRN.vehicleEntryDate);
            objcmd.Parameters.AddWithValue("", objGRN.status);
            objcmd.Parameters.AddWithValue("", objGRN.Remark);
            objcmd.Parameters.AddWithValue("", objGRN.invoiceNo);
            objcmd.Parameters.AddWithValue("", objGRN.invoiceDate);
            objcmd.Parameters.AddWithValue("", objGRN.gatePassNo);
            objcmd.Parameters.AddWithValue("", objGRN.gatePassDate);
            objcmd.Parameters.AddWithValue("", objGRN.DriverName);
            objcmd.Parameters.AddWithValue("", objGRN.DriverContactNo);
            objcmd.Parameters.AddWithValue("", objGRN.createdDate);
            objcmd.Parameters.AddWithValue("", objGRN.createdBy);
            objcmd.Parameters.AddWithValue("", objGRN.challanNo);
            objcmd.Parameters.AddWithValue("", objGRN.challanDate);
            objcmd.Parameters.AddWithValue("", objGRN.approvalDate);
            objcmd.Parameters.AddWithValue("", objGRN.approvalBy);
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