<%@ WebHandler Language="C#" Class="GetSupplierAssignRecord" %>

using System;
using System.Text;
using System.Web;
using System.Data;

public class GetSupplierAssignRecord : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //获取供应商编号
        string sID = context.Request.QueryString["sID"] == null ? "0" : context.Request.QueryString["sID"].ToString();
        //获取当前页码
        string pageIndex = context.Request.QueryString["page"] == null ? "0" : context.Request.QueryString["page"].ToString();
        //获取当前页码
        string pageSize = context.Request.QueryString["pagesize"] == null ? "0" : context.Request.QueryString["pagesize"].ToString();
        //得到总个数
        int TotleNumber = 0;
        //返回给客户端的字符串
        string _return = String.Empty;
        StringBuilder sb = new StringBuilder();
        if (sID != "0")
        {
            LN.Model.PageModel model = new LN.Model.PageModel();
            model.SelectSql = LN.DAL.GetTableListSqlExec.strGetSupplierAssignRecordSql(sID);
            model.pageIndex = Int32.Parse(pageIndex);
            model.pageSize = Int32.Parse(pageSize);
            model.OrderField = "ID DESC";
            DataTable dt = new LN.BLL.SupplierAssignRecord().GetAssignRecordByID(model,out TotleNumber);
            _return = "[";
            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{ID:\"" + dr["ID"].ToString() + "\"");
                    sb.Append(",ProvinceName:\"" + dr["ProvinceName"].ToString() + "\"");
                    sb.Append(",CityName:\"" + dr["CityName"].ToString() + "\"");
                    sb.Append(",TotleNumber:\"" + TotleNumber.ToString() + "\"");
                    sb.Append(",ShopID:\"" + dr["AssignShopID"].ToString() + "\"");
                    sb.Append(",Shopname:\"" + dr["Shopname"].ToString() + "\"},");
                }
            }
            else
            {
                sb.Append("{ID:\"\",ProvinceName:\"\",CityName:\"\",TotleNumber:\"0\",ShopID:\"0\",Shopname:\"暂无分配店铺\"}");
            }
            _return += sb.ToString().Trim(new char[] { ',' }) + "]";
        }
        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}