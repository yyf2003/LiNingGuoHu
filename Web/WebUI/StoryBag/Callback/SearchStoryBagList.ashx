<%@ WebHandler Language="C#" Class="SearchStoryBagList" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class SearchStoryBagList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //获取故事包名称
        string PName = context.Request.QueryString["pname"] == null ? "" : context.Request.QueryString["pname"].ToString();
        //获取品牌编号
        string TypeID = context.Request.QueryString["tid"] == null ? "" : context.Request.QueryString["tid"].ToString();
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
        model.SelectSql = LN.DAL.GetTableListSqlExec.strGetStoryBagListSql(PName, TypeID);
        model.pageIndex = Int32.Parse(pageIndex);
        model.pageSize = Int32.Parse(pageSize);
        model.OrderField = "ProductLineID DESC";
        DataTable dt = new LN.BLL.ProductLineData().GetListPageByWhere(model, out TotleNumber);
        _return = "[";
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{SNumberID:\"" + dr["SNumberID"].ToString().Trim() + "\"");
                sb.Append(",ProductLineID:\"" + dr["ProductLineID"].ToString().Trim() + "\"");
                sb.Append(",ProductLine:\"" + dr["ProductLine"].ToString().Trim() + "\"");
                sb.Append(",TypeID:\"" + dr["TypeID"].ToString().Trim() + "\"");
                sb.Append(",ProductTypeName:\"" + dr["ProductTypeName"].ToString().Trim() + "\"");
                sb.Append(",IsDelete:\"" + dr["IsDelete"].ToString().Trim() + "\"");
                sb.Append(",TotleNumber:\"" + TotleNumber.ToString().Trim() + "\"},");
            }
        }
        else
        {
            sb.Append("{SNumberID:\"\",ProductLineID:\"\",ProductLine:\"没有检索到指定故事包\",TypeID:\"\",ProductTypeName:\"\",IsDelete:\"\",TotleNumber:\"0\"}");
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