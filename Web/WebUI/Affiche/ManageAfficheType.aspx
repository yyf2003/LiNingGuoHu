<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageAfficheType.aspx.cs"
    Inherits="WebUI_Affiche_ManageAfficheType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理公告分类</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <style>
    a:link{ text-decoration:underline;color:#424242;}
    a:visited{ text-decoration:underline;color:#424242;}
    a:active{ text-decoration:underline;color:#424242;}
    a:hover{ text-decoration:underline;color:#424242;} 
   </style>
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <!--  end-->

    <script>
 function Add()
   {
    var typedd =$("#Text1").val();
   if(typedd=="")
   {
  $.prompt("请输入分类名称！",{callback:gettypefocus});
   return false;
   } 
    $.get("ashx/AddAfficheType.ashx",{TypeName:typedd},
			function(data){
				if(data.length > 0){
				  $.prompt(data,{callback:reloadpage});  
				}
		});
   }
   function gettypefocus()
  {
   $("#Text1").focus();
  } 
  function reloadpage()
  {
    location.reload ();
  } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <%#nodata %>
        <asp:DataList ID="DataList1" runat="server" Width="600px" OnItemCommand="DataList1_ItemCommand"
            OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand"
            OnUpdateCommand="DataList1_UpdateCommand" CssClass="table">
            <HeaderTemplate>
                <div style="width: 100%; height: 21px;">
                    <div style="float: left; width: 60%">
                        分类名</div>
                    <div style="float: left; width: 16%">
                        修改</div>
                    <div style="float: left; width: 16%">
                        删除</div>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div style="width: 100%;">
                    <div style="float: left; width: 60%; height: 18px;">
                        <%#Eval("Type") %>
                    </div>
                    <div style="float: left; width: 16%; height: 18px;">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit">修改</asp:LinkButton>
                    </div>
                    <div style="float: left; width: 16%; height: 18px;">
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" OnClientClick="return confirm('确认删除吗？');"
                            CommandArgument='<%#Eval("ID")%>'>删除</asp:LinkButton></div>
                </div>
            </ItemTemplate>
            <EditItemTemplate>
                <div style="width: 100%;">
                    <div style="float: left; width: 40%;">
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("Type") %>'></asp:TextBox>
                    </div>
                    <div style="float: left; width: 50%;">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="update" CommandArgument='<%#Eval("ID") %>'>更新</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="cancel">取消</asp:LinkButton>
                    </div>
                </div>
            </EditItemTemplate>
        </asp:DataList>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;
            width: 600px">
            <tr>
                <td align="center">
                    添加公告分类</td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 2px;
            width: 600px">
            <tr>
                <td width="100px" >
                    分类名称：
                </td>
                <td width="200px">
                    <input id="Text1" type="text" />
                </td>
                <td>
                    <input id="Button1" type="button" value="保存" onclick="Add();" class="qr0" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
