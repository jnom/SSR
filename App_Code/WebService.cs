using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Auth userLogin(UserDetails UserDetails)
    {
        DataAccess Ds = new DataAccess();
        DataTable dtUserInfo = new DataTable();
        Auth auth = new Auth();
        dtUserInfo = Ds.ExecuteDR("select UserID,UserName from User_Master where UserName='" + UserDetails.userName + "' and Password = '" + UserDetails.password + "' ");
        if (dtUserInfo.Rows.Count > 0)
        {
            auth.userID = dtUserInfo.Rows[0]["UserID"].ToString();
            auth.userName = dtUserInfo.Rows[0]["UserName"].ToString();
        }
        return auth;
    }


    [WebMethod(enableSession: true)]
    public GetStoreItem getItemDetails(string pStoreID, string vStrWork)
    {
        GetStoreItem obj = new GetStoreItem();
        if (Session["dtStoreItem"] == null || Session["storeID"] != null || Session["storeID"].ToString() != vStrWork)
        {
            DataTable dtdtStoreItem = new DataTable();
            DataAccess objds = new DataAccess();
            dtdtStoreItem = objds.getStoreItem(Convert.ToInt32(vStrWork));
            Session["dtStoreItem"] = dtdtStoreItem;
        }
        DataTable dt = Session["dtStoreItem"] as DataTable;
        DataView dView = dt.DefaultView;
        dView.RowFilter = " where ourName like '%" + vStrWork + "%'";
        foreach (DataRow dRows in dView.Table.Rows)
        {
            obj.currentStock = Convert.ToDecimal(dRows["currentStock"]);
            obj.ItemID = Convert.ToInt32(dRows["ItemID"]);
            obj.itemName = dRows["itemName"].ToString();
            obj.lastPORate = Convert.ToDecimal(dRows["lastPORate"]);
            obj.minReqQty = Convert.ToDecimal(dRows["minReqQty"]);
            obj.ourName = dRows["ourName"].ToString();
            obj.uom = dRows["uom"].ToString();
            obj.uomID = Convert.ToInt32(dRows["uomID"]);
        }
        return obj;
    }
}
