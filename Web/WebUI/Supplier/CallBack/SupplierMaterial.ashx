<%@ WebHandler Language="C#" Class="SupplierMaterial" %>

using System;
using System.Web;
using System.Text;
using System.Data;
public class SupplierMaterial : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //获取供应商编号
        string userID = context.Request.QueryString["uID"] == null ? "0" : context.Request.QueryString["uID"].ToString();
        //获取当前页码
        string pageIndex = context.Request.QueryString["page"] == null ? "0" : context.Request.QueryString["page"].ToString();
        //获取当前页码
        string pageSize = context.Request.QueryString["pagesize"] == null ? "0" : context.Request.QueryString["pagesize"].ToString();
        //得到总个数
        int TotleNumber = 0;
        //返回给客户端的字符串
        string _return = String.Empty;
        StringBuilder sb = new StringBuilder();
        if (userID != "0")
        {
            LN.Model.PageModel model = new LN.Model.PageModel();
            model.SelectSql = LN.DAL.GetTableListSqlExec.strGetSupplierMaterialSql(userID);
            model.pageIndex = Int32.Parse(pageIndex);
            model.pageSize = Int32.Parse(pageSize);
            model.OrderField = " IsDelete asc";
            DataTable dt = new LN.BLL.POPMateriaData().GetMateriaListPageByID(model, out TotleNumber);
            _return = "[";
            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{MateriaID:\"" + dr["MateriaID"].ToString().Trim() + "\"");
                    sb.Append(",MateriaPro:\"" + dr["MateriaPro"].ToString().Trim() + "\"");
                    sb.Append(",SupplierID:\"" + dr["SupplierID"].ToString().Trim() + "\"");
                    sb.Append(",IsDelete:\"" + dr["IsDelete"].ToString().Trim() + "\"");
                    sb.Append(",IsSupport:\"" + dr["IsSupport"].ToString().Trim() + "\"");
                    sb.Append(",TotleNumber:\"" + TotleNumber.ToString().Trim() + "\"},");
                }
            }
            else
            {
                sb.Append("{MateriaID:\"\",MateriaPro:\"暂无材料\",SupplierID:\"\",IsDelete:\"\",TotleNumber:\"0\"}");
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