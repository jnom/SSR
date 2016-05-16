using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService]
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

    [WebMethod]
    public int saveGRNData(saveGrn Header, grnDetails dtl)
    {
        DataAccess Ds = new DataAccess();
        DataTable dtUserInfo = new DataTable();
        var stringwriter = new System.IO.StringWriter();
        var serializer = new XmlSerializer(dtl.GetType());
        serializer.Serialize(stringwriter, dtl);
        int vGRNID = Ds.SaveGrn(Header, stringwriter.ToString());
        return vGRNID;
    }

    [WebMethod(enableSession: true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getItemDetails(string pStoreID, string vStrWork)
    {
        if (Session["dtStoreItem"] == null || Session["storeID"] == null || Session["storeID"].ToString() != pStoreID)
        {
            DataTable dtdtStoreItem = new DataTable();
            DataAccess objds = new DataAccess();
            dtdtStoreItem = objds.getStoreItem(Convert.ToInt32(pStoreID));
            Session["dtStoreItem"] = dtdtStoreItem;
            Session["storeID"] = pStoreID;
        }
        DataTable dt = Session["dtStoreItem"] as DataTable;
        DataView dView = dt.DefaultView;
        dView.RowFilter = " OurName like '%" + vStrWork + "%'";
        List<GetStoreItem> Details = new List<GetStoreItem>();
        for (int i = 0; dView.Count > i; i++)
        {
            GetStoreItem obj = new GetStoreItem();
            obj.currentStock = Convert.ToDecimal(dView[i]["currentStock"]);
            obj.ItemID = Convert.ToInt32(dView[i]["ItemID"]);
            obj.itemName = dView[i]["itemName"].ToString();
            obj.lastPORate = Convert.ToDecimal(dView[i]["lastPORate"]);
            obj.minReqQty = Convert.ToDecimal(dView[i]["minReqQty"]);
            obj.ourName = dView[i]["ourName"].ToString();
            obj.uom = dView[i]["uom"].ToString();
            obj.uomID = Convert.ToInt32(dView[i]["uomID"]);
            Details.Add(obj);
        }
        JavaScriptSerializer jss = new JavaScriptSerializer();

        string output = jss.Serialize(Details);
        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(output);
        return "";
    }
}
