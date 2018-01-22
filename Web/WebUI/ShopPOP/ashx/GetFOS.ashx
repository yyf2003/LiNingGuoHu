<%@ WebHandler Language="C#" Class="GetFOS" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;

public class GetFOS : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //获取FOS店POP位置描述
        string SeatInfo = context.Request.QueryString["seat"] == null ? "0" : context.Request.QueryString["seat"].ToString();

        //返回给客户端的字符串
        string _return = String.Empty;

        LN.Model.tb_FOSPOP model = new LN.BLL.tb_FOSPOP().GetModel(SeatInfo);
        _return = "[";
        StringBuilder sb = new StringBuilder();
        if (model != null)
        {
            sb.Append("{FOS_ID:\"" + model.FOS_ID.ToString().Trim() + "\"");
            sb.Append(",FOS_POPSeat:\"" + model.FOS_POPSeat.Trim() + "\"");
            sb.Append(",FOS_POPMateria:\"" + model.FOS_POPMateria.Trim() + "\"");
            sb.Append(",FOS_POPRealHeight:\"" + model.FOS_POPRealHeight.ToString().Trim() + "\"");
            sb.Append(",FOS_POPRealWith:\"" + model.FOS_POPRealWith.ToString().Trim() + "\"");
            sb.Append(",FOS_POPHeight:\"" + model.FOS_POPHeight.ToString().Trim() + "\"");
            sb.Append(",FOS_POPWith:\"" + model.FOS_POPWith.ToString().Trim() + "\"},");
        }
        else
        {
            sb.Append("{FOS_ID:\"0\",FOS_POPSeat:\"\",FOS_POPMateria:\"\"}");
        }
        _return += sb.ToString().Trim(new char[] { ',' }) + "]";
        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}