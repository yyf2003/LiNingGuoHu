<%@ WebHandler Language="C#" Class="SaveIDsToSession" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

public class SaveIDsToSession : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string ShopID = context.Request["ShopID"] == null ? "" : context.Request["ShopID"].ToString();
        string DealerID = context.Request["DealerID"] == null ? "" : context.Request["DealerID"].ToString();
        string popnum = context.Request["popnum"] == null ? "0" : context.Request["popnum"].ToString();
        string fx = context.Request["fx"] == null ? "" : context.Request["fx"].ToString();
        string isAdd = context.Request["isAdd"] == null ? "" : context.Request["isAdd"].ToString();

        ArrayList arry = new ArrayList();
        arry.Add(ShopID);
        arry.Add(DealerID);
        arry.Add(popnum);
        arry.Add(fx);

        IDictionary<string, ArrayList> di = context.Session["ToDealers"] == null ? new Dictionary<string, ArrayList>() : context.Session["ToDealers"] as Dictionary<string, ArrayList>;
        if (isAdd == "")
        {
            if (di.ContainsKey(ShopID))
                di.Remove(ShopID);
            else
                di.Add(ShopID, arry);
        }
        else if (isAdd == "add")
        {
            if (!di.ContainsKey(ShopID))
                di.Add(ShopID, arry);
        }
        else
        {
            di.Remove(ShopID);
        }
        context.Session["ToDealers"] = di;

        context.Response.Write("");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}