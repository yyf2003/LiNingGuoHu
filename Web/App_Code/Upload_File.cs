using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// 模块名称：文件上传类
/// 编写人：秦浩
/// 编写时间：2008-06-11
/// </summary>
public class Upload_File
{

    public Upload_File()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 允许文件上传的类型枚举
    /// </summary>
    public enum FileType
    {
        jpg, jpeg, gif, bmp, png
    }

    /// <summary>
    /// 取得文件后缀名
    /// </summary>
    /// <param name="fileName">文件名称</param>
    /// <returns></returns>
    public static string GetFileExtends(string fileName)
    {
        string ext = string.Empty;
        if (fileName.IndexOf('.') > 0)
        {
            string[] arrStr = fileName.Split(new char[] { '.' });
            ext = arrStr[arrStr.Length - 1];
        }
        return ext;
    }

    #region 检测文件是否合法
    /// <summary>
    /// 检测上传文件是否合法
    /// </summary>
    /// <param name="fileExtends">文件后缀名</param>
    /// <returns></returns>
    public static bool CheckFileExtends(string fileExtends)
    {
        bool status = false;
        fileExtends = fileExtends.ToLower();
        string[] fe = Enum.GetNames(typeof(FileType));
        for (int i = 0; i < fe.Length; i++)
        {
            if (fe[i].ToLower() == fileExtends)
            {
                status = true;
                break;
            }
        }
        return status;
    }
    #endregion

    #region 保存文件
    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="fpath">全路径</param>
    /// <param name="myFileUpload">上传控件</param>
    /// <param name="filePath">文件存储路径</param>
    /// <returns></returns>
    public static int FileSave(string fpath, FileUpload myFileUpload,ref string filePath)
    {
        int _return = 0;
        string s = "";
        string fileExtends = "";
        string fileName = myFileUpload.FileName;
        if (fileName != "")
        {
            //取得文件后缀
            fileExtends = GetFileExtends(fileName);
            if (!CheckFileExtends(fileExtends))
            {
                return 0;
            }
            s = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "." + fileExtends;
            string file = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(fpath), s);
            filePath = fpath + "/" + s;
            try
            {
                myFileUpload.SaveAs(file);
                _return = 1;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }
        return _return;
    }
    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="fpath">全路径</param>
    /// <param name="myFileUpload">上传控件</param>
    /// <param name="filePath">文件存储路径</param>
    ///  <param name="num"></param>
    /// <returns></returns>
    public static int FileSave(string fpath, FileUpload myFileUpload, ref string filePath, string num)
    {
        int _return = 0;
        string s = "";
        string fileExtends = "";
        string fileName = myFileUpload.FileName;
        if (fileName != "")
        {
            //取得文件后缀
            fileExtends = GetFileExtends(fileName);
            if (!CheckFileExtends(fileExtends))
            {
                return 0;
            }
            s = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + num + "." + fileExtends;
            string file = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(fpath), s);
            filePath = fpath + "/" + s;
            try
            {
                myFileUpload.SaveAs(file);
                _return = 1;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }
        return _return;
    }

    #endregion
}
