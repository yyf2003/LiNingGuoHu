using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.UI.WebControls;
using Common;
using LN.BLL;
using System.Linq;

public partial class WebUI_Promotion_RackInfo_import : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["success"] != null)
        {
            int successNum = int.Parse(Request.QueryString["success"].ToString());
            int failNum = int.Parse(Request.QueryString["fail"].ToString());
            uploadMsg.Style.Add("display", "");
            labuploadMsg.Text = "更新成功！";
            labTotal.Text = (successNum + failNum).ToString();
            labSuccessNum.Text = successNum.ToString();
            labFailNum.Text = failNum.ToString();
        }
    }
    protected void Button_ImportProp_Click(object sender, EventArgs e)
    {
        string excelConnString = string.Empty;
        if (ConfigurationManager.AppSettings["ExcelConnString"] != null)
            excelConnString = ConfigurationManager.AppSettings["ExcelConnString"].ToString();
        if (FileUpload1.HasFile)
        {
            DataSet excelDs = null;
            LN.Model.Attachment fileModel = new LN.Model.Attachment();
            fileModel.FileType = FileTypeEnum.Excel.ToString();
            UploadFileHelper.UpFiles(FileUpload1.PostedFile, ref fileModel);
            string path = fileModel.FilePath;
            StringBuilder errorData = new StringBuilder();
            int successNum = 0;//成功导入的数量
            int failNum = 0;//失败数量
            if (path != "")
            {
                path = Server.MapPath(path);
                excelConnString = excelConnString.Replace("ExcelPath", path);
                OleDbConnection conn;
                OleDbDataAdapter da;
                conn = new OleDbConnection(excelConnString);
                conn.Open();
                string sql = "select * from [Sheet1$]";
                da = new OleDbDataAdapter(sql, conn);
                excelDs = new DataSet();
                da.Fill(excelDs);
                da.Dispose();
                if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
                {
                    DataColumnCollection cols = excelDs.Tables[0].Columns;
                    string rackNo = string.Empty;
                    string price = string.Empty;
                    RackInfo rackBll = new RackInfo();
                    LN.Model.RackInfo rackModel;
                    foreach (DataRow dr in excelDs.Tables[0].Rows)
                    {
                        int rackId = 0;
                        rackNo = string.Empty;
                        price = string.Empty;
                        if (cols.Contains("道具编码"))
                        {
                            rackNo = dr["道具编码"].ToString();
                        }
                        else if (cols.Contains("道具编号"))
                        {
                            rackNo = dr["道具编号"].ToString();
                        }
                        if (cols.Contains("价格"))
                        {
                            price = dr["价格"].ToString();
                        }
                        else if (cols.Contains("单价"))
                        {
                            price = dr["单价"].ToString();
                        }
                        DataSet ds = rackBll.GetList(string.Format(" RackCode='{0}'", rackNo));
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            rackId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                            rackModel = rackBll.GetModel(rackId);

                            if (rackModel != null && !string.IsNullOrWhiteSpace(price) && StringHelper.IsDecimal(price))
                            {
                                rackModel.Price = StringHelper.ToDecimal(price);
                                rackBll.Update(rackModel);
                                successNum++;
                            }
                            else
                                failNum++;
                        }

                    }
                    conn.Dispose();
                    conn.Close();

                    Response.Redirect("import.aspx?success=" + successNum + "&fail=" + failNum, false);
                }

            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx",false);
    }
}