<%@ WebHandler Language="C#" Class="GetDisList" %>

using System;
using System.Web;
using System.Text;
using System.Data;
public class GetDisList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        //dealerId:this.DealerID,dept:this.department,areaId:this.AreaId,ProId:this.ProvinceID,CId:this.CityID
        //获取直属客户编号
        string FXID = context.Request.QueryString["fid"] == null ? "" : context.Request.QueryString["fid"].ToString();
        //获取直属客户名称
        string FXName = context.Request.QueryString["fname"] == null ? "" : context.Request.QueryString["fname"].ToString();
        //获取所属一级客户名称
        string DealerName = context.Request.QueryString["dname"] == null ? "" : context.Request.QueryString["dname"].ToString();
        string DealerID = context.Request.QueryString["dealerId"] == null ? "" : context.Request.QueryString["dealerId"].ToString();
        string dept = context.Request.QueryString["dept"] == null ? "" : context.Request.QueryString["dept"].ToString();
        string areaID = context.Request.QueryString["areaId"] == null ? "" : context.Request.QueryString["areaId"].ToString();
        string ProID = context.Request.QueryString["ProId"] == null ? "" : context.Request.QueryString["ProId"].ToString();
        string CityID = context.Request.QueryString["CId"] == null ? "" : context.Request.QueryString["CId"].ToString();
        //获取当前页码
        string pageIndex = context.Request.QueryString["page"] == null ? "0" : context.Request.QueryString["page"].ToString();
        //获取当前页码
        string pageSize = context.Request.QueryString["pagesize"] == null ? "0" : context.Request.QueryString["pagesize"].ToString();
        //得到总个数
        int TotleNumber = 0;
        //返回给客户端的字符串
        string _return = String.Empty;

        StringBuilder sb = new StringBuilder();

        LN.Model.PageModel model = new LN.Model.PageModel();
        model.SelectSql = LN.DAL.GetTableListSqlExec.strGetDistributorsInfoSql(FXID, FXName, DealerName,DealerID,dept,areaID,ProID,CityID);
        model.pageIndex = Int32.Parse(pageIndex);
        model.pageSize = Int32.Parse(pageSize);
        model.OrderField = "FXID ASC";
        DataTable dt = new LN.BLL.DistributorsInfo().GetListPageByWhere(model, out TotleNumber);
        _return = "[";
        if (dt != null && dt.Rows.Count > 0)
        {
            
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{SNumberID:\"" + dr["SNumberID"].ToString().Trim() + "\"");
                sb.Append(",FXID:\"" + dr["FXID"].ToString().Trim() + "\"");
                sb.Append(",FXName:\"" + dr["FXName"].ToString().Trim() + "\"");
                sb.Append(",FXContactor:\"" + dr["FXContactor"].ToString().Trim() + "\"");
                sb.Append(",FXPhone:\"" + dr["FXPhone"].ToString().Trim() + "\"");
                sb.Append(",FXtel:\"" + dr["FXtel"].ToString().Trim() + "\"");
                sb.Append(",DealerName:\"" + dr["DealerName"].ToString().Trim() + "\"");
                sb.Append(",TotleNumber:\"" + TotleNumber.ToString().Trim() + "\"},");
            }
        }
        else
        {
            sb.Append("{SNumberID:\"\",FXID:\"\",FXName:\"没有检索到指定直属客户\",FXContactor:\"\",FXPhone:\"\",FXtel:\"\",DealerName:\"\",TotleNumber:\"0\"}");
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