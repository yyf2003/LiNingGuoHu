<%@ WebHandler Language="C#" Class="GetShopListByFXID" %>

using System;
using System.Web;
using System.Data;
using System.Text;
public class GetShopListByFXID : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        context.Response.AddHeader("pragma", "no-cache");
        context.Response.AddHeader("cache-control", "");
        context.Response.CacheControl = "no-cache";
        context.Response.ContentType = "text/plain";

        //返回给客户端的字符串
        string _return = String.Empty;
        //当前页
        int pageindex;
        //数据总数
        int TotleNumber = 0;
        int.TryParse(context.Request["p"], out pageindex);
        //获取每页显示的数据量
        string pageSize = context.Request["pagesize"] == null ? "0" : context.Request["pagesize"].ToString();
        //直属客户编号
        string FXID = context.Request["fid"] == null ? "" : context.Request["fid"].ToString();
        //店铺编号
        string ShopID = context.Request["sid"] == null ? "0" : context.Request["sid"].ToString();
        //店铺名称 
        string ShopName = context.Request["sname"] == null ? "" : context.Request["sname"].ToString();
        //排序字段
        string order = "ShopID";
        if (pageindex == 0) pageindex = 1;

        DataTable dt = new LN.BLL.ShippingSpeedData().GetConfirmShopListByFXID(FXID, ShopID, ShopName, order, Int32.Parse(pageSize), pageindex, ref TotleNumber);

        _return = "[";

        StringBuilder sb = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{SNumberID:\"" + dr["SNumberID"].ToString().Trim() + "\"");
                sb.Append(",POPID:\"" + dr["POPID"].ToString().Trim() + "\"");
                sb.Append(",ShopID:\"" + dr["ShopID"].ToString().Trim() + "\"");
                sb.Append(",PosID:\"" + dr["PosID"].ToString().Trim() + "\"");
                sb.Append(",DealerID:\"" + dr["DealerID"].ToString().Trim() + "\"");
                sb.Append(",FXID:\"" + dr["FXID"].ToString().Trim() + "\"");
                sb.Append(",Shopname:\"" + dr["Shopname"].ToString().Trim() + "\"");
                sb.Append(",SupplierID:\"" + dr["SupplierID"].ToString().Trim() + "\"");
                sb.Append(",Boolinstall:\"" + dr["Boolinstall"].ToString().Trim() + "\"");
                sb.Append(",TotleNumber:\"" + TotleNumber.ToString().Trim() + "\"},");
            }
        }
        else
            sb.Append("{SNumberID:\"0\",POPID:\"\",ShopID:\"\",PosID:\"\",DealerID:\"\",FXID:\"\",Shopname:\"暂无店铺\",SupplierID:\"\",Boolinstall:\"\",TotleNumber:\"0\"}");

        _return += sb.ToString().Trim(new char[] { ',' }) + "]";

        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}