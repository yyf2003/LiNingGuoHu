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

public partial class WebUI_ShopPOP_UpdatePOPInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
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
            if (path != "")
            {
                path = Server.MapPath(path);
                excelConnString = excelConnString.Replace("ExcelPath", path);
                OleDbConnection conn;
                OleDbDataAdapter da;
                conn = new OleDbConnection(excelConnString);
                string sql = "select * from [Sheet1$]";
                da = new OleDbDataAdapter(sql, conn);
                excelDs = new DataSet();
                da.Fill(excelDs);
                conn.Dispose();
                conn.Close();
                da.Dispose();

            }
            if (excelDs != null && excelDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in excelDs.Tables[0].Rows)
                { 
                    
                }
            }
        }
    }
}