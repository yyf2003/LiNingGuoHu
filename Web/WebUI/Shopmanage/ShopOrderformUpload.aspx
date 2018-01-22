<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopOrderformUpload.aspx.cs" Inherits="WebUI_Shopmanage_ShopOrderformUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上传POP安装后的效果图</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div style="margin-left: 20px">
            <div style="font-size: 14px; color: #c86000; font-weight: bold">
                &nbsp;上传POP安装前后的效果图</div>
                
            <table class="table" style="margin-top: 20px; width: 95%; ">
                <tr>
                    <td style="text-align:right; width:40%;height:100px;">安装后照片：</td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server" /><span style="color:Red">只能上传 jpg，gif 格式文件</span>
                    <input type="button" id="btn_save" runat="server" class="qr0" onserverclick="Button_Click" value="上传" /></td>
                </tr>
                <tr>
                    <td style="text-align:right; width:40%; height:100px;">安装前照片：</td>
                    <td><asp:FileUpload ID="FileUpload2" runat="server" /><span style="color:Red">只能上传 jpg，gif 格式文件</span>
                    <input type="button" id="Button2" runat="server" class="qr0"  value="上传" onserverclick="Button2_ServerClick" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        
                        <input type="button" id="Button1" onclick="history.back()" class="qr0"  style="margin-left:100px;" value="返回" />
                    </td>
                </tr>
            </table>        
    </div>
    </form>
</body>
</html>
