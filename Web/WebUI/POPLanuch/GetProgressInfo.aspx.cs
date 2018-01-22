using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Bestcomy.Web.Controls.Upload;

public partial class GetProgressInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!IsPostBack)
        {           
            string uploadID = Request.QueryString["UploadID"];
            if (uploadID != null && uploadID != string.Empty)
            {
               
                
                Progress proc = new Progress(uploadID);
                
                string command = Request.QueryString["cmd"];
                if (command == "Cancel")
                    proc.Abort();
                Response.Clear();
              
                if (command == "Update")
                Response.Write("var proc = new ProgressInfo(\"" + proc.get_UploadStatus().ToString() + "\"," + proc.get_Percent() + ",\"" + proc.get_FileName() + "\",\"" + proc.GetFormatString(proc.get_Speed()) + "/Sec\",\"" + proc.get_LeftTime().ToString() + "\",\"" + proc.get_FileCount() + "\");proc.update();");
                if (command == "Cancel")
                    proc.Dispose();
                Response.End();
            }
        }
    }
}
