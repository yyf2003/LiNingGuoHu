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
using Bestcomy.Web.Controls.Upload;

using System.Drawing;

/// <summary>
/// 模块名称：文件上传类
/// 编写人：秦浩
/// 编写时间：2008-06-11
/// </summary>
public class UploadFile
{

    public UploadFile()
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
        jpg, jpeg, gif, bmp, png, doc, pdf, ppt,pptx, xls, docx, xlsx, rar, zip
    }

    /// <summary>
    /// 允许文件上传的图片类型枚举
    /// </summary>
    public enum FileType_Image
    {
        jpg, jpeg, gif, bmp, png
    }

    /// <summary>
    /// 检查是否是图片
    /// </summary>
    /// <param name="strFileName">文件名称</param>
    /// <returns></returns>
    public static bool IsImage(string strFileName)
    {
        string fileExtends = GetFileExtends(strFileName);
        bool status = false;
        fileExtends = fileExtends.ToLower();
        string[] fe = Enum.GetNames(typeof(FileType_Image));
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
    /// 保存文件(时间取到毫秒才能支持多文件上传)
    /// </summary>
    /// <param name="fpath">全路径</param>
    /// <param name="myFileUpload">myFileUpload为HttpPostedFile类型</param>
    /// <param name="filePath">文件存储路径</param>
    /// <returns></returns>
    public static int FileSave(string fpath, HttpPostedFile myFileUpload, ref string filePath)
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
            //s = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + fileExtends;
            s = DateTime.Now.ToString("yyyyMMddhhmmssfff") + "-" + new Random().Next(1, 1000) + new Random().Next(100, 1000) + "." + fileExtends;
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
    public void GetNum()
    {
        string nums = DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(1, 100) + ".jpg";
    }

    private string CreateRandomCode(int codeCount)
    //创建随即码
    {
        string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z";
        string[] allCharArray = allChar.Split(',');
        string randomCode = "";
        int temp = -1;
        Random random = new Random();
        for (int i = 0; i < codeCount; i++)
        {
            if (temp != -1)
            {
                random = new Random(i * temp * (int)DateTime.Now.Ticks);
            }
            int t = random.Next(35);
            if (temp == t)
            {
                return CreateRandomCode(codeCount);
            }
            temp = t;
            randomCode += allCharArray[temp];
        }
        return randomCode;
    }

    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="fpath">全路径</param>
    /// <param name="myFileUpload">上传控件</param>
    /// <param name="filePath">文件存储路径</param>
    /// <returns></returns>
    public static int FileSave(string fpath, FileUpload myFileUpload, ref string filePath)
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
    /// 大文件上传
    /// </summary>
    /// <param name="fpath">文件路径 </param>
    /// <param name="myFileUpload">控件name 值 </param>
    /// <param name="fileExtend">文件格式</param>
    /// <returns></returns>
    public static int BigFileSave(string fpath, Bestcomy.Web.Controls.Upload.UploadFile file, ref string filePath)
    {
        int _return = 0;
        string s = "";
        string fileExtends = "";
        if (file != null)
        {
            //文件路径
            string FilePath = file.get_FileName();
            //文件名和后缀
            string FileName = Path.GetFileName(FilePath);
            //文件后缀
            fileExtends = GetFileExtends(FilePath);
            if (!CheckFileExtends(fileExtends))
            {
                return 0;
            }
            s = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "." + fileExtends;
            string serverFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(fpath), s);
            filePath = fpath + "/" + s;
            try
            {
                file.SaveAs(serverFilePath);
                _return = 1;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }

        return _return;
    }

    public static int BigFileSave1(string fpath, Bestcomy.Web.Controls.Upload.UploadFile file, ref string filePath, string filename)
    {
        int _return = 0;
        string s = "";
        string fileExtends = "";
        if (file != null)
        {
            //文件路径
            string FilePath = file.get_FileName();
            //文件名和后缀
            string FileName = Path.GetFileName(FilePath);
            //文件后缀
            fileExtends = GetFileExtends(FilePath);
            if (!CheckFileExtends(fileExtends))
            {
                return 0;
            }
            s = filename;
            string serverFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(fpath), s);
            filePath = fpath + "/" + s;
            try
            {
                file.SaveAs(serverFilePath);
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
    /// 上传图片并生成缩略图
    /// </summary>
    /// <param name="fpath">全路径</param>
    /// <param name="myFile">上传控件</param>
    /// <param name="tWidth">缩略图宽</param>
    /// <param name="tHeight">缩略图高</param>
    /// <param name="strBigPhotoUrl">原图存储路径</param>
    /// <param name="strSmallPhotoUrl">缩略图存储路径</param>
    public static void FileSave(string fpath, FileUpload myFile, int tWidth, int tHeight, ref string strBigPhotoUrl, ref string strSmallPhotoUrl)
    {
        //检查上传文件的格式是否有效 
        if (myFile.PostedFile.ContentType.ToLower().IndexOf("image") < 0)
        {
            ////Response.Write("上传图片格式无效！");
            return;
        }

        //生成原图 
        Byte[] oFileByte = new byte[myFile.PostedFile.ContentLength];
        System.IO.Stream oStream = myFile.PostedFile.InputStream;
        System.Drawing.Image oImage = System.Drawing.Image.FromStream(oStream);

        int oWidth = oImage.Width; //原图宽度 
        int oHeight = oImage.Height; //原图高度         

        //按比例计算出缩略图的宽度和高度 
        if (oWidth >= oHeight)
        {
            tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
        }
        else
        {
            tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
        }

        //生成缩略原图 
        Bitmap tImage = new Bitmap(tWidth, tHeight);
        Graphics g = Graphics.FromImage(tImage);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度 
        g.Clear(Color.Transparent); //清空画布并以透明背景色填充 
        g.DrawImage(oImage, new Rectangle(0, 0, tWidth, tHeight), new Rectangle(0, 0, oWidth, oHeight), GraphicsUnit.Pixel);

        string oFullName = DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString(); 
        string tFullName = oFullName + "s.jpg"; //保存缩略图的物理路径 
        oFullName += ".jpg";//保存原图的物理路径 

        strBigPhotoUrl = fpath + "/" + oFullName;
        strSmallPhotoUrl = fpath + "/" + tFullName;

        oFullName = System.Web.HttpContext.Current.Server.MapPath(fpath) + oFullName;
        tFullName = System.Web.HttpContext.Current.Server.MapPath(fpath) + tFullName;

        try
        {
            //以JPG格式保存图片 
            oImage.Save(oFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
            tImage.Save(tFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //释放资源 
            oImage.Dispose();
            g.Dispose();
            tImage.Dispose();

        }
    }

    /// <summary>
    /// 上传图片并生成缩略图
    /// </summary>
    /// <param name="fpath">全路径</param>
    /// <param name="myFile">上传控件</param>
    /// <param name="tWidth">缩略图宽</param>
    /// <param name="tHeight">缩略图高</param>
    /// <param name="strBigPhotoUrl">原图存储路径</param>
    /// <param name="strSmallPhotoUrl">缩略图存储路径</param>
    public static void FileSave(string fpath, HttpPostedFile myFile, int tWidth, int tHeight, ref string strBigPhotoUrl, ref string strSmallPhotoUrl)
    {
        //检查上传文件的格式是否有效 
        if (!IsImage(myFile.FileName))
        {
            ////Response.Write("上传图片格式无效！");
            return;
        }

        //生成原图 
        Byte[] oFileByte = new byte[myFile.ContentLength];
        System.IO.Stream oStream = myFile.InputStream;
        System.Drawing.Image oImage = System.Drawing.Image.FromStream(oStream);

        int oWidth = oImage.Width; //原图宽度 
        int oHeight = oImage.Height; //原图高度         

        //按比例计算出缩略图的宽度和高度 
        if (oWidth >= oHeight)
        {
            tHeight = (int)Math.Floor(Convert.ToDouble(oHeight) * (Convert.ToDouble(tWidth) / Convert.ToDouble(oWidth)));
        }
        else
        {
            tWidth = (int)Math.Floor(Convert.ToDouble(oWidth) * (Convert.ToDouble(tHeight) / Convert.ToDouble(oHeight)));
        }

        //生成缩略原图 
        Bitmap tImage = new Bitmap(tWidth, tHeight);
        Graphics g = Graphics.FromImage(tImage);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度 
        g.Clear(Color.Transparent); //清空画布并以透明背景色填充 
        g.DrawImage(oImage, new Rectangle(0, 0, tWidth, tHeight), new Rectangle(0, 0, oWidth, oHeight), GraphicsUnit.Pixel);

        string oFullName = DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
        string tFullName = oFullName + "s.jpg"; //保存缩略图的物理路径 
        oFullName += ".jpg";//保存原图的物理路径 

        strBigPhotoUrl = fpath + "/" + oFullName;
        strSmallPhotoUrl = fpath + "/" + tFullName;

        oFullName = System.Web.HttpContext.Current.Server.MapPath(fpath) + oFullName;
        tFullName = System.Web.HttpContext.Current.Server.MapPath(fpath) + tFullName;

        try
        {
            //以JPG格式保存图片 
            oImage.Save(oFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
            tImage.Save(tFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //释放资源 
            oImage.Dispose();
            g.Dispose();
            tImage.Dispose();

        }
    }

    #endregion
}
