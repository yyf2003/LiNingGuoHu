using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
	public BasePage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public void Alert(string msg, string url = null)
    {
        System.Text.StringBuilder script = new System.Text.StringBuilder();
        string jump = string.Empty;
        if (!string.IsNullOrWhiteSpace(url))
        {
            jump = "window.location='" + url + "';";
        }
        script.AppendFormat("<script>alert('{0}');{1}</script>", msg, jump);
        ClientScript.RegisterClientScriptBlock(GetType(), "al", script.ToString());
    }

    public void ExcuteJs(string fun, string msg = null)
    {
        string js = "<script>" + fun + "();</script>";
        if (!string.IsNullOrWhiteSpace(msg))
        {
            js = "<script>" + fun + "(" + msg + ");</script>";
        }
        ClientScript.RegisterClientScriptBlock(GetType(), "al", js);
    }
}