<%@ WebHandler Language="C#" Class="Place" %>

using System;
using System.Web;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using LN.BLL;

public class Place : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string type = context.Request.QueryString["type"].ToString();
        string result = string.Empty;
        switch (type)
        { 
            case "getProvince":
                string regionIds = context.Request.QueryString["regionid"].ToString();
                result=GetProvincesByRegionIds(regionIds);
                break;
        }
        context.Response.Write(result);
    }

    string GetProvincesByRegionIds(string regionIds)
    {
        if (!string.IsNullOrWhiteSpace(regionIds))
        {
              regionIds = regionIds.TrimEnd(',');
        //    ProvinceData provinceBll = new ProvinceData();
        //    IList<LN.Model.ProvinceData> list = provinceBll.GetList(string.Format(" AreaID in ({0})",regionIds));
        //    if (list.Count > 0)
        //    {
        //        string jsonStr = JsonConvert.SerializeObject(list);
        //        return jsonStr;
        //    }
        //    else
        //        return "empty";

              ProvinceInDepartment pInDBll = new ProvinceInDepartment();
              DataSet ds = pInDBll.GetList(string.Format(" ProvinceInDepartment.DepartmentId in ({0})", regionIds));
              if (ds != null && ds.Tables[0].Rows.Count > 0)
              {
                  StringBuilder json = new StringBuilder();
                  foreach (DataRow dr in ds.Tables[0].Rows)
                  {
                      json.Append("{\"ProvinceID\":\"" + dr["ProvinceId"].ToString() + "\",\"ProvinceName\":\"" + dr["ProvinceName"].ToString() + "\"},");
                  }
                  if (json.Length > 0)
                  {
                      return "[" + json.ToString().TrimEnd(',') + "]";
                  }
                  else
                      return "empty";
              }
              else
                  return "empty";
            
            
        }
        else
            return "empty";
        
        
        
        
        
    }
    
    
    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}