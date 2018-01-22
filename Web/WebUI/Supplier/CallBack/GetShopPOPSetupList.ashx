<%@ WebHandler Language="C#" Class="GetShopPOPSetupList" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Data;

public class GetShopPOPSetupList : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string pid = context.Request.QueryString["Posid"] != null ? context.Request.QueryString["Posid"].ToString() : "";
        string sname = context.Request.QueryString["Sname"] != null ? context.Request.QueryString["Sname"].ToString() : "";
        string proid = context.Request.QueryString["province"] != null ? context.Request.QueryString["province"].ToString() : "0";
        string cityid = context.Request.QueryString["cityid"] != null ? context.Request.QueryString["cityid"].ToString() : "0";
        string dealerid = context.Request.QueryString["dealerid"] != null ? context.Request.QueryString["dealerid"].ToString() : "";
        string installID = context.Request.QueryString["install"] != null ? context.Request.QueryString["install"].ToString() : "-1";
        string typeid = context.Request.QueryString["typeid"] != null ? context.Request.QueryString["typeid"].ToString() : "0";
        string saleid = context.Request.QueryString["saleid"] != null ? context.Request.QueryString["saleid"].ToString() : "0";
        string StateID = context.Request.QueryString["sstate"] != null ? context.Request.QueryString["sstate"].ToString() : "-1";
        string SupplierID = context.Request.QueryString["sid"] != null ? context.Request.QueryString["sid"].ToString() : "-1";
        string FXID = context.Request.QueryString["fxid"] != null ? context.Request.QueryString["fxid"].ToString() : "0";
        string pageIndex = context.Request.QueryString["page"] != null ? context.Request.QueryString["page"].ToString() : "1";
        string PageSize = context.Request.QueryString["psize"] != null ? context.Request.QueryString["psize"].ToString() : "20";

        Hashtable hdt = new Hashtable();
        hdt.Add("pid", pid);
        hdt.Add("sname", sname);
        hdt.Add("proid", proid);
        hdt.Add("cityid", cityid);
        hdt.Add("dealerid", dealerid);
        hdt.Add("installID", installID);
        hdt.Add("typeid", typeid);
        hdt.Add("saleid", saleid);
        hdt.Add("stateID", StateID);
        hdt.Add("SupplierID", SupplierID);
        hdt.Add("fxid", FXID);
        // ----------------------------------------
        hdt.Add("pageindex", pageIndex);//的几页

        hdt.Add("PageSize", PageSize);//每页显示多少行

        //得到店铺信息列表
        int TotalNumber = 0;

        DataTable dt = new LN.BLL.ShopInfo().GetShopPOPSetupList(hdt, ref TotalNumber);

        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string ExamYes = "";
            if (dt.Rows[i]["ExamState"].ToString() == "1")
            {
                ExamYes = "(已确认)";
            }
            sb.Append("{");
            sb.Append("sID");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["ShopID"].ToString());
            sb.Append("\",");
            sb.Append("pID");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["PosID"].ToString());
            sb.Append("\",");
            sb.Append("SName");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["ShopName"].ToString() + ExamYes);
            sb.Append("\",");
            sb.Append("jxs");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["DealerName"].ToString());
            sb.Append("\",");
            sb.Append("sf");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["ProvinceName"].ToString());
            sb.Append("\",");
            sb.Append("cs");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["cityname"].ToString());
            sb.Append("\",");
            sb.Append("TotalNumber");
            sb.Append(":\"");
            sb.Append(TotalNumber.ToString());

            sb.Append("\"},");
        }
        if (dt.Rows.Count <= 0)
        {
            sb.Append("{");
            sb.Append("sID");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("pID");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("SName");
            sb.Append(":\"");
            sb.Append("<font color='red'>没有你所要的店铺！</font>");
            sb.Append("\",");
            sb.Append("jxs");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("sf");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("cs");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("TotalNumber");
            sb.Append(":\"0\"},");
        }
        context.Response.Write(sb.ToString().Substring(0, sb.ToString().Length - 1) + "]");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}