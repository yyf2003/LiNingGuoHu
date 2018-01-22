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

public partial class WebUI_POPLanuch_POPLaunchSetCiyt_do : System.Web.UI.Page
{
    protected string POPID =string.Empty;
    string Arealist = string.Empty, ProIDlist = string.Empty, CityIDlist = string.Empty, Productline = string.Empty, TownIDlist = string.Empty, shopidlist = string.Empty, SaleType = String.Empty, ShopACL = string.Empty, ShopTCL = string.Empty;
    string shoptype = string.Empty, shopVI = string.Empty,shoplevel=string.Empty,imgList = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
   
        POPID=Request.QueryString["POPID"].ToString();
       
        Arealist = Request.Form["area"].ToString();
        ProIDlist = Request.Form["province"] == null ? "" : Request.Form["province"].ToString();
        imgList = Request.Form["POPImageData"] == null ? "" : Request.Form["POPImageData"].ToString();
        //CityIDlist = Request.Form["city"] == null ? "" : Request.Form["city"].ToString();
        //TownIDlist = Request.Form["Town"] == null ? "" : Request.Form["Town"].ToString();
        //Productline = Request.Form["linename"].ToString();
        shopidlist = Request.Form["HF_shopid"] == null ? "" : Request.Form["HF_shopid"].ToString();

        shoptype = Request.Form["ck_shoptype"] == null ? "" : Request.Form["ck_shoptype"].ToString();
        shopVI = Request.Form["ck_shopVI"] == null ? "" : Request.Form["ck_shopVI"].ToString();
        shoplevel = Request.Form["level"] == null ? "" : Request.Form["level"].ToString();
        SaleType = Request.Form["SaleType"] == null ? "" : Request.Form["SaleType"].ToString();
        ShopACL = Request.Form["AreaCityLevel"] == null ? "" : Request.Form["AreaCityLevel"].ToString();
        ShopTCL = Request.Form["TownCityLevel"] == null ? "" : Request.Form["TownCityLevel"].ToString();
 
        //根据请求过来的 故事包的ID的字符串 来分解字符串。
        if (Productline.Contains(","))
        {
            string[] prolist = Productline.Split(new char[] { ',' });
            for (int i = 0; i < prolist.Length; i++)
            {
                cityset(POPID, prolist[i], ProIDlist, CityIDlist, Arealist);
            }
        }
        else
        {
            cityset(POPID, Productline, ProIDlist, CityIDlist, Arealist);
        }
        string strImgLevel = String.Empty;
        string[] arrImgList = imgList.Split(new char[] {','});
        foreach (string strItem in arrImgList)
        {
            strImgLevel += "'" + strItem + "',";
        }

        new LN.BLL.POPInfo().UpdateIsHide(strImgLevel.Trim(new char[] { ','}));
        Response.Redirect("POPLaunchSetCiyt.aspx?POPID=" + POPID);
    }

    public bool cityset(string pid,string proline,string provincelist,string citylist,string areaidlist)
    {
        string sqlstr = "";
        if (shopidlist.Length <= 0)
        {
            //if (TownIDlist.Length > 0)
            //{
            //    sqlstr = "select '" + POPID + "',0,ProvinceID,CityID,TownID,ShopID," + proline + ",'' from shopinfo where TownID in (" + TownIDlist + ") ";
            //}
            //else
            //{
            //    if (citylist.Length > 0)
            //    {
            //        sqlstr = "select '" + POPID + "',0,ProvinceID,CityID,TownID,ShopID," + proline + ",'' from shopinfo where CityID in (" + citylist + ") ";
            //    }
            //    else
            //    {

                   
            //    }
            //}
            if (provincelist.Length > 0)
            {
                sqlstr = "select '" + POPID + "',areaid,ProvinceID,0,0,ShopID,0,''  from shopinfo where provinceID in (" + provincelist + ") ";
            }
            else
            {
                if (areaidlist.Length > 0)
                {
                    sqlstr = "select '" + POPID + "',areaid,ProvinceID,0,0,ShopID,0,''  from shopinfo where areaid in (" + areaidlist + ") ";

                }
            }

            //add by mhj 20130401
            sqlstr += " and shopstate!=0 ";
            
            if (ShopACL.Length > 0)
            {
                sqlstr += " and ACL_ID in (" + ShopACL + ")";
            }
            if (ShopTCL.Length > 0)
            {
                sqlstr += " and TCL_ID in (" + ShopTCL + ")";
            }
            if (SaleType.Length > 0)
            {
                sqlstr += " and SaleTypeID in (" + SaleType + ")";
            }
            if (shopVI.Length > 0)
            {
                sqlstr += " and ShopVI in (" + shopVI + ")";
            }

            if (shoplevel.Length > 0)
            {
                sqlstr += " and shoplevelID in (" + shoplevel + ")  ";
            }
            if (shoptype.Length > 0)
            {
                sqlstr += " and shoptype in (" + shoptype + ") ";
            }
        }
        else
        {
            //modify by mhj 20130401
            //sqlstr = "select '" + POPID + "',areaid,ProvinceID,0,0,ShopID,0,'' from shopinfo where shopid in (" + shopidlist + ")";
            sqlstr = "select '" + POPID + "',areaid,ProvinceID,0,0,ShopID,0,'' from shopinfo where shopstate!=0 and shopid in (" + shopidlist + ")";
        }
        try
        {
            new LN.BLL.POPChangeSet().CitySet(pid,proline,sqlstr);
            new LN.BLL.POPLaunch().Updatesteps(0, pid);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
}
