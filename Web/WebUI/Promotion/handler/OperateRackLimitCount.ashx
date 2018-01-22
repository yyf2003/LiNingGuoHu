<%@ WebHandler Language="C#" Class="OperateRackLimitCount" %>

using System;
using System.Web;
using LN.BLL;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

public class OperateRackLimitCount : IHttpHandler {

    PromotionShopLevel shopLevelBll = new PromotionShopLevel();
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        string optype = string.Empty;
        string result = string.Empty;
        if (context.Request.QueryString["optype"] != null)
        {
            optype = context.Request.QueryString["optype"];
        }
        switch (optype)
        { 
            case "getlist":
                result = GetList();
                break;
            case "update":
                string jsonstr = string.Empty;
                if (context.Request.QueryString["josnstr"] != null)
                {
                    jsonstr = context.Request.QueryString["josnstr"];
                }
                if (!string.IsNullOrWhiteSpace(jsonstr))
                   result = Update(jsonstr);
                break;
        }
        context.Response.Write(result);
    }

    string GetList()
    {
        StringBuilder json = new StringBuilder();
        DataSet ds = shopLevelBll.GetList("");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\",\"ShortName\":\"" + dr["ShortName"].ToString() + "\",\"RackLimitCount\":\"" + dr["RackLimitCount"].ToString() + "\"},");
            }
            return "[" + json.ToString().TrimEnd(',') + "]";
        }
        else
            return "";
    }


    string Update(string jsonstr)
    {
        try
        {
            List<LN.Model.PromotionShopLevel> shopLevelList = JsonConvert.DeserializeObject<List<LN.Model.PromotionShopLevel>>(jsonstr);
            if (shopLevelList != null && shopLevelList.Count > 0)
            {
                LN.Model.PromotionShopLevel model;
                foreach (var item in shopLevelList)
                {
                    model = new LN.Model.PromotionShopLevel();
                    model.Id = item.Id;
                    model.RackLimitCount = item.RackLimitCount;
                    shopLevelBll.Update(model);
                }
            }
            return "ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        
        
        
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}