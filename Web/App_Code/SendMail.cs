using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

/// <summary>
/// 模块名称：邮件发送类
/// 编写人：秦浩
/// 编写时间：2008-06-11
/// </summary>
public class SendMail
{

    #region 数据成员

    //收件人地址
    private List<string> m_To = null;
    //发件人地址
    private string m_From = ConfigurationManager.AppSettings["EmailAddress"].ToString();
    //邮件标题
    private string m_Subject = String.Empty;
    //邮件正文
    private string m_Body = String.Empty;
    //发送服务器名或地址
    private string m_smtp = ConfigurationManager.AppSettings["EmailSMTP"].ToString();
    //发件人用户名
    private string m_UserName = ConfigurationManager.AppSettings["EmailAddress"].ToString();
    //发件人密码
    private string m_Password = ConfigurationManager.AppSettings["EmailPassWord"].ToString();
    //是否以HTML格式发送
    private bool m_IsHTML = true;

    #endregion

    #region 构造函数

    public SendMail() { }

    /// <summary>
    /// 构造函数重载
    /// </summary>
    /// <param name="ToList">收件人地址</param>
    /// <param name="subject">邮件标题</param>
    /// <param name="body">邮件正文</param>
    public SendMail(List<string> ToList, string subject, string body, bool ishtml)
    {
        this.m_To = ToList;
        this.m_Subject = subject;
        this.m_Body = body;
        this.m_IsHTML = ishtml;
    }

    #endregion

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <returns>返回 是否成功</returns>
    public bool SubmitEmail()
    {
        bool _return = false;
        MailMessage mailMessage = new MailMessage();
        string strExp = @"([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        Regex reg = new Regex(strExp);
        mailMessage.From = new MailAddress(m_From);
        if (m_To.Count > 0)
        {
            foreach (string strEmail in m_To)
            {
                Match m = reg.Match(strEmail);
                if (m.Success)
                    mailMessage.To.Add(strEmail);
            }

            mailMessage.Subject = m_Subject;
            mailMessage.Body = m_Body;
            mailMessage.IsBodyHtml = m_IsHTML;

            try
            {
                sendMail(mailMessage);
                _return = true;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        return _return;
    }

    private void sendMail(MailMessage mail)
    {
        SmtpClient smtpClient = new SmtpClient(m_smtp);
        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential(m_UserName, m_Password);
        try
        {
            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
