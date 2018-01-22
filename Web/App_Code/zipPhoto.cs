using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

/// <summary>
/// zipPhoto 的摘要说明
/// </summary>
public class zipPhoto
{
	public zipPhoto()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    #region 图片处理
    /// <summary>
    /// 获取缩略图的长与宽
    /// </summary>
    /// <param name="minwidth">原宽</param>
    /// <param name="minheight">原长</param>
    /// <param name="width">宽</param>
    /// <param name="height">长</param>
    /// <returns>长宽整数对</returns>
    private static Size NewSize(int minwidth, int minheight, int width, int height)
    {
        double w = 0.0;
        double h = 0.0;
        double sw = Convert.ToDouble(width);
        double sh = Convert.ToDouble(height);
        double mw = Convert.ToDouble(minwidth);
        double mh = Convert.ToDouble(minheight);

        if (sw < mw && sh < mh)
        {
            w = sw;
            h = sh;
        }
        else if ((sw / sh) > (mw / mh))
        {
            w = minwidth;
            h = (w * sh) / sw;
        }
        else
        {
            h = minheight;
            w = (h * sw) / sh;
        }

        return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
    }

    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="filename">上传图片数据源</param>
    /// <param name="_filepath">要上传到文件夹的路径</param>
    /// <param name="minwidth">缩略图宽</param>
    /// <param name="minheight">缩略图高</param>
    /// <param name="FileName">上传到DISK文件夹下目录</param>
    /// <param name="type">图片类型,BOOL型变量,true为jpg,反之为gif</param>
    /// <returns>返回当前图片名</returns>
    public static string SendToSmallImage(Stream _stream,string _filepath, int minwidth, int minheight, string FileName, bool type)
    {
     //判断上传的文件夹是否存在 不存在则创建
        if (!Directory.Exists(HttpContext.Current.Server.MapPath(_filepath)))
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_filepath));

        System.Drawing.Image img = System.Drawing.Image.FromStream(_stream);
        //System.Drawing.Image img = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(filename));
        ImageFormat imgformat = img.RawFormat;

        Size newSize = NewSize(minwidth, minheight, img.Width, img.Height);

        Bitmap bm = new Bitmap(newSize.Width, newSize.Height);
        Graphics g = Graphics.FromImage(bm);

        // 设置画布的描绘质量
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
        g.Dispose();

        // 以下代码为保存图片时，设置压缩质量
        EncoderParameters encoderParams = new EncoderParameters();
        long[] quality = new long[1];
        quality[0] = 100;

        EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        encoderParams.Param[0] = encoderParam;

        //获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象。
        ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
        ImageCodecInfo jpegICI = null;
        ImageCodecInfo GIFICI = null;
        ImageCodecInfo allICI = null;
        for (int x = 0; x < arrayICI.Length; x++)
        {
            if (arrayICI[x].FormatDescription.Equals("JPEG"))
            {
                jpegICI = arrayICI[x];//设置JPEG编码
            }

            if (arrayICI[x].FormatDescription.Equals("GIF"))
            {
                GIFICI = arrayICI[x];//设置GIF编码
            }
        }

        string stringpath = null;
        string imagename = DateTime.Now.Ticks.ToString();
        if (type)
        {
            stringpath = _filepath+"/" + imagename + ".jpg";
            allICI = jpegICI;
            imagename = imagename + ".jpg";
        }
        else
        {
            stringpath = _filepath + "/" + imagename + ".gif";
            allICI = GIFICI;
            imagename = imagename + ".gif";
        }

        try
        {
            bm.Save(HttpContext.Current.Server.MapPath(stringpath), allICI, encoderParams);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            img.Dispose();
            bm.Dispose();
        }

        return imagename;
    }
    #endregion
}
