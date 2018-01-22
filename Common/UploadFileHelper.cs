using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


namespace Common
{
    public class UploadFileHelper
    {
        public static void UpFiles(HttpPostedFile file, ref LN.Model.Attachment models)
        {
            //检查文件扩展名字

            HttpPostedFile postedFile = file;
            string fileName;
            fileName = System.IO.Path.GetFileName(postedFile.FileName);
            if (fileName.ToLower() != "")
            {
                string name = fileName.Substring(0, fileName.LastIndexOf("."));
                string scurTypeName = fileName.Substring(fileName.LastIndexOf(".") + 1);
                //初始化原图物理路径
                string sGuid_phy = Guid.NewGuid().ToString();

                string strFile = "~/UpLoad/" + CommonMethod.GeEnumName<FileCodeEnum>(models.FileCode) + "/" + models.FileType;
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strFile)))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strFile));
                }
                //原图 原文件
                string FliePath = strFile + "/" + sGuid_phy + "." + scurTypeName;

                //小图片路径  SmallImgFilePath
                string SmallImgFilePath = string.Empty;
                postedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(FliePath));
                string extents = ConfigurationManager.AppSettings["UpLoadImgType"];
                if (extents != "")
                {
                    string[] ExtentArr = extents.Split('|');
                    if (ExtentArr.Contains(scurTypeName.ToLower()))
                    {

                        SmallImgFilePath = strFile + "/Small_" + sGuid_phy + "." + scurTypeName;
                        MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(FliePath), SmallImgFilePath, 90, 100, "Cut");
                    }
                    models.SmallImgUrl = SmallImgFilePath;
                }
                models.Title = name;
                models.FilePath = FliePath;


                //try
                //{
                //    string strFile = "../../UpLoad/" + CommonMethod.GeEnumName<FileCodeEnum>(models.FileCode) + "/" + models.FileType;
                //    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strFile)))
                //    {
                //        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strFile));
                //    }
                //    //原图 原文件
                //    string FliePath = strFile + "/" + sGuid_phy + "." + scurTypeName;

                //    //小图片路径  SmallImgFilePath
                //    string SmallImgFilePath = string.Empty;
                //    postedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(FliePath));
                //    string extents = ConfigurationManager.AppSettings["UpLoadImgType"];
                //    if (extents != "")
                //    {
                //        string[] ExtentArr = extents.Split('|');
                //        if (ExtentArr.Contains(scurTypeName.ToLower()))
                //        {

                //            SmallImgFilePath = strFile + "/Small_" + sGuid_phy + "." + scurTypeName;
                //            MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(FliePath), SmallImgFilePath, 90, 100, "Cut");
                //        }
                //        models.SmallImgUrl = SmallImgFilePath;
                //    }
                //    models.Title = name;
                //    models.FilePath = FliePath;
                //}
                //catch
                //{
                //    string strFile = "./UpLoad/" + CommonMethod.GeEnumName<FileCodeEnum>(models.FileCode) + "/" + models.FileType;
                //    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strFile)))
                //    {
                //        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strFile));
                //    }
                //    //原图 原文件
                //    string FliePath = strFile + "/" + sGuid_phy + "." + scurTypeName;

                //    //小图片路径  SmallImgFilePath
                //    string SmallImgFilePath = string.Empty;
                //    postedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(FliePath));
                //    string extents = ConfigurationManager.AppSettings["UpLoadImgType"];
                //    if (extents != "")
                //    {
                //        string[] ExtentArr = extents.Split('|');
                //        if (ExtentArr.Contains(scurTypeName.ToLower()))
                //        {

                //            SmallImgFilePath = strFile + "/Small_" + sGuid_phy + "." + scurTypeName;
                //            MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(FliePath), SmallImgFilePath, 110, 90, "Cut");
                //        }
                //        models.SmallImgUrl = SmallImgFilePath;
                //    }
                //    models.Title = name;
                //    models.FilePath = FliePath;
                //}
            }
        }


        ///<summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "A":
                    if (originalImage.Width / originalImage.Height >= width / height)
                    {
                        if (originalImage.Width > width)
                        {
                            towidth = width;
                            toheight = (originalImage.Height * width) / originalImage.Width;
                        }
                        else
                        {
                            towidth = originalImage.Width;
                            toheight = originalImage.Height;
                        }
                    }
                    else
                    {
                        if (originalImage.Height > height)
                        {
                            toheight = height;
                            towidth = (originalImage.Width * height) / originalImage.Height;
                        }
                        else
                        {
                            towidth = originalImage.Width;
                            toheight = originalImage.Height;
                        }
                    }
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
             new Rectangle(x, y, ow, oh),
             GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(System.Web.HttpContext.Current.Server.MapPath(thumbnailPath), System.Drawing.Imaging.ImageFormat.Jpeg);
                //outthumbnailPath=thumbnailPath;
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }


        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="path"></param>
        public static void DownLoadFile(string path,string fileName=null)
        {

            if (path != "")
            {
                try
                {
                    if (fileName==null)
                        fileName = path.Substring(path.LastIndexOf('/') + 1);
                    else
                        fileName += path.Substring(path.LastIndexOf('.'));
                    long len = 102400;
                    byte[] buffer = new byte[len];
                    long read = 0;
                    FileStream fs = null;
                    fs = new FileStream(HttpContext.Current.Server.MapPath(path), FileMode.Open, FileAccess.Read, FileShare.Read);
                    read = fs.Length;

                   

                    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8)));

                    HttpContext.Current.Response.AddHeader("Content-Length", read.ToString());
                    HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "binary");
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                    while (read > 0)
                    {
                        if (HttpContext.Current.Response.IsClientConnected)
                        {
                            int length = fs.Read(buffer, 0, Convert.ToInt32(len));
                            HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                            HttpContext.Current.Response.Flush();
                            HttpContext.Current.Response.Clear();
                            read -= length;
                        }
                        else
                        {
                            read = -1;
                        }
                    }

                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception e)
                {
                    throw e;
                   
                }
            }
            
        }

    }
}
