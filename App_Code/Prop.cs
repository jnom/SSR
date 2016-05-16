using System;
using System.Web;

/// <summary>
/// Summary description for Prop
/// </summary>
public class Prop
{
}
public class UserDetails
{
    public string userName;
    public string password;
}
public class Auth
{
    public string userName;
    public string userID;
}
public class saveGrn
{
    public int comapnyID;
    public int storeID;
    public int GRNID;
    public int supplierID;
    public int transpoterID;
    public int status;
    public int approvalBy;
    public int createdBy;
    public string GRNNO;
    public string DriverName;
    public string DriverContactNo;
    public string vehicleNo;
    public string vehicleEntryNo;
    public string challanNo;
    public string invoiceNo;
    public string gatePassNo;
    public string Remark;
    public DateTime challanDate;
    public DateTime invoiceDate;
    public DateTime gatePassDate;
    public DateTime createdDate;
    public DateTime approvalDate;
    public DateTime vehicleEntryDate;
    public DateTime GRNDate; 
}
public class GetStoreItem
{
    public int ItemID;
    public string ourName;
    public string itemName;
    public string uom;
    public int uomID;
    public decimal currentStock;
    public decimal lastPORate;
    public decimal minReqQty;
}
public class grnDetails
{
    public int ItemID;
    public int uomID;
    public decimal DisPer;
    public decimal AcceptedQty;
    public decimal rate;
    public decimal TotalPrice;
    public string Remarks;
}