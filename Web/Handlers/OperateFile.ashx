<%@ WebHandler Language="C#" Class="OperateFile" %>

using System;
using System.Web;
using LN.BLL;

public class OperateFile : IHttpHandler {
    int fileId;
    string OperateType = string.Empty;
    
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        
        if (context.Request.QueryString["id"] != null)
        {
            fileId = int.Parse(context.Request.QueryString["id"].ToString());
        }
        if (context.Request.QueryString["type"] != null)
        {
            OperateType = context.Request.QueryString["type"].ToString();
        }
        string r = "";
        switch (OperateType)
        {
            case "download":
                r = DownFile(context);
                break;
            case "deletefile":
                r = DeleteFile();
                break;
        }
        context.Response.Write(r);
    }

    Attachment attachBll = new Attachment();
    LN.Model.Attachment attachModel;
    string DownFile(HttpContext context)
    {

        attachModel = attachBll.GetModel(fileId);
        string path = attachModel.FilePath;
        if (path != "")
        {
            Common.UploadFileHelper.DownLoadFile(path, attachModel.Title);
            return "ok";
        }
        else
        {
            return "downloaderror";

        }
    }


    string DeleteFile()
    {
        attachModel = attachBll.GetModel(fileId);
        try
        {
            if (attachModel != null)
            {
                attachModel.IsDelete = 1;
                bool isok = attachBll.Update(attachModel);

                
            }
            return "ok";
        }
        catch
        {
            return "deleteerror";
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}