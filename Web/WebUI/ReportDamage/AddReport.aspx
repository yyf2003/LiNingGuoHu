<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddReport.aspx.cs" Inherits="WebUI_ReportDamage_AddReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加报损</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script> 
    <!--  end-->

    <script>
     function CheckAdd()
     {
      var descshop  =$("#txt_ShopDesc").val();
      if(descshop=="")
     {
        $.prompt("描述不能为空，请添加描述内容",{callback:getfocus});
       return false; 
     }  
     }
      function getfocus()
     {
       $("#txt_ShopDesc").focus();
     }
      
    </script>

</head>
<body >
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" border="0" class="table">
            <tr height="24px">
                <td colspan="4" align="center" style="font-size: 12px; font-weight: bold;">
                    提交报损
                </td>
            </tr>
            <tr height="24px">
                <td style="width: 15%">
                    店铺：</td>
                <td width="35%">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td width="15%">
                    供应商:
                </td>
                <td width="35%">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr height="80px" align="center">
                <td style="width: 12%" align="left">
                    描述：</td>
                <td colspan="3" width="75%" align="left">
                    <asp:TextBox ID="txt_ShopDesc" runat="server" TextMode="MultiLine" Height="80px"
                        Width="360px" CssClass ="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr height="24px">
                <td style="width: 12%">
                    上传图片：</td>
                <td colspan="3" width="75%">
                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="确定提交" OnClick="Button1_Click" CssClass="qr0"
                        OnClientClick="return CheckAdd();" />
                    <input id="Button2" type="button" value="取 消" class="qr0" onclick="javascript:window.location=window.location;" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
