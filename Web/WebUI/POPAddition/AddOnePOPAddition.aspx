<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOnePOPAddition.aspx.cs"
    Inherits="WebUI_POPAddition_AddOnePOPAddition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我要增加补</title>

    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>

    <script type="text/javascript">
       function CheckSubmit()
       { 
         var file =document.getElementById ("FileUpload1").value; 
            if(file=="")
            {  
             $.prompt("请选择要上传的POP图片！");
              return false;
            }
            var des =$("#txt_des").val(); 
            if(des=="")
            {
             $.prompt("请完善备注信息！",{callback:getfocusdes});
             return false;              
            }
            if($("#DDL_addType").val()=="0")
            {
               $.prompt("请选择增补类型！");
               return false;
            }
       }
       
       function getfocusdes()
       {$("#txt_des").focus();}
       
       	this.doOk = function(){
		if(document.all){
			document.getElementById("shield").removeNode(true);
			document.getElementById("alertFram").removeNode(true);
		}else{
			document.getElementById("shield").parentNode.removeChild(document.getElementById("shield"));
			document.getElementById("alertFram").parentNode.removeChild(document.getElementById("alertFram"));
		}
	}
       
    </script>

    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <span style="font-weight: bold; font-size: 14px; cursor: hand; color: #cc3333;">填写增补表单</span>
        <table id="recevieGoods" class="table" style="display: block; width: 100%;">
            <tr>
                <td style="width: 80px">
                    操作人：
                </td>
                <td style="width: 280px">
                    <%=Username %>
                </td>
                <td style="width: 80px">
                    店铺：
                </td>
                <td style="width: 280px">
                    <%=Shopname  %>
                </td>
            </tr>
            <tr>
                <td style="width: 80px">
                    POP信息：
                </td>
                <td style="width: 280px">
                    <%=POPSeat  %>
                </td>
                <td valign="top" style="width: 80px">
                    &nbsp;图片：</td>
                <td valign="top">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="80%" />
                </td>
            </tr>
            <tr>
            <td>
                增补类型：</td><td>
                <asp:DropDownList ID="DDL_addType" runat="server" Width="140px">
                    <asp:ListItem Value="0">请选择增补类型</asp:ListItem>
                    <asp:ListItem>原损增补</asp:ListItem>
                    <asp:ListItem>运营增补</asp:ListItem>
                </asp:DropDownList></td><td></td><td></td>
            </tr>
            <tr>
                <td style="width: 80px">
                备注信息：
                </td>
                <td colspan="3"> 
                    <asp:TextBox ID="txt_des" runat="server" CssClass ="txtwith" TextMode="MultiLine" Height ="100px" Width ="320px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btn_popaddition" runat="server" Text="提交增补" CssClass="qr0" OnClick="btn_popaddition_Click"
                        OnClientClick="return CheckSubmit();" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
