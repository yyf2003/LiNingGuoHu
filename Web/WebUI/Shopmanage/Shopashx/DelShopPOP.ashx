<%@ WebHandler Language="C#" Class="DelShopPOP" %>

using System;
using System.Web;

public class DelShopPOP : IHttpHandler
{
    /// <summary>
    /// 删除当前季度发起POP下,店铺提交的POP信息
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        LN.Model.LoginLog model = new LN.Model.LoginLog();
        model.LoginIP = HttpContext.Current.Request.UserHostAddress;
        model.LoginUserID = context.Server.UrlDecode(HttpContext.Current.Request.Cookies["UserName"].Value);
        if (context.Request.QueryString["shopid"] != null)
        {
            string shopid = context.Request.QueryString["shopid"].ToString();
            string popid = new LN.BLL.POPLaunch().GetNewestModel().POPID.ToString();
            if (popid != "")
            {
                new LN.BLL.imageToPOP().Delete("POPID=" + popid + " and shopid=" + shopid + " ");
                new LN.BLL.imageToPOPTemp().Delete("POPID=" + popid + " and shopid=" + shopid + " ");
                model.Result = "操作成功--已将店铺提交的POP信息初始化为提交前状态";
            }
            else
            {
                model.Result = "操作失败--删除失败,当前没有发起POP订单";
            }
        }
        else
        {
            model.Result = "操作失败--获取店铺信息失败!请联系管理员!";
        }
        new LN.BLL.LoginLog().Add(model);
        context.Response.Write(model.Result);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}