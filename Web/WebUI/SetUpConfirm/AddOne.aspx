<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOne.aspx.cs" Inherits="WebUI_SetUpConfirm_AddOne" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加安装确认</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <!--  end-->

    <script type="text/javascript">
     function CheckAdd()
     {
      var txt_Num  =$("#txt_Num").val();
      if(txt_Num=="")
     {
        $.prompt("安装数量不能为空，请添加内容",{callback:getfocus});
       return false; 
     }  
     
       var txt_Desc  =$("#txt_Desc").val();
       if(txt_Num<<%= shouldsetup%>)
       {
      if(txt_Desc=="")
     {
        $.prompt("描述不能为空，请添加描述内容",{callback:getfocusdesc});
       return false; 
     }  
     }
     if(txt_Num><%= shouldsetup%>)
     {
         $.prompt("安装数量最大为<%= shouldsetup%>",{callback:getfocus});
         return false;

     }
     }
      function getfocus()
     {
       $("#txt_Num").focus();
     }
       function getfocusdesc()
     {
       $("#txt_Desc").focus();
     }
      
    </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="1" border="0" class="table">
            <tr height="24px">
                <td colspan="4" align="center" style="font-size: 12px; font-weight: bold;">
                    安装确认
                </td>
            </tr>
            <tr height="24px">
                <td style="width: 15%;">
                    一级客户：</td>
                <td width="350px">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td style="width: 15%;">
                    店铺名称:
                </td>
                <td width="350px">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr height="24px">
                <td style="width: 15%;">
                    供应商：</td>
                <td width="350px">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
                <td style="width: 15%;">
                    POP发起:
                </td>
                <td width="350px">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr height="24px">
                <td style="width: 15%">
                    实际确认安装数量：</td>
                <td  colspan="3" style="color: red">
                    <asp:TextBox ID="TextBox1" runat="server"  ReadOnly="true"></asp:TextBox>
                    <asp:TextBox ID="txt_Num" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                        onafterpaste="this.value=this.value.replace(/\D/g,'')" CssClass ="txtwith" Width="50%"></asp:TextBox>
                </td>
            </tr>
            <tr height="80px" align="center">
                <td  width ="100px" align="left">
                    描述：</td>
                <td colspan="3"  align="left">
                    <asp:TextBox ID="txt_Desc" runat="server" TextMode="MultiLine" Height="80px" Width="360px" CssClass ="txtwith"></asp:TextBox>
                </td>
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
