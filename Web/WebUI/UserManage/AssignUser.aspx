<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignUser.aspx.cs" Inherits="WebUI_UserManage_AssignUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <title>分配人员</title>
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <script>
   function RedirectAssSignUser()
  {
    var uid="<%#UID %>";
     window.location ="AddAssignUser.aspx?UserID="+uid; 
  }  
   function DelAssginUser()
  { 
           var useritem="";
            var userrole = document.getElementsByTagName ("input");
              for(var i =0;i<userrole.length;i++)
       {
            var ab =userrole[i];
            if(ab.name=="role")
            {
                if(ab.type=="checkbox")
            {
              if(ab.checked)
               useritem +=ab.value+",";  
            } 
            }
       }
       useritem  =useritem.substring(0,useritem.length-1); 
       if(useritem=="")
       {
         $.prompt("请选择要操作的用户！");
        return false; 
       }
       else
       {
           $.get("../ashx/DelOneAssginUser.ashx",{UserItem:useritem},function(data){
             if(data.length>0) 
                 $.prompt("操作成功!",{callback:reloadpage});  
            }) ;
       } 
  } 
  
     function reloadpage()
  {
   location.reload ();
  } 
    </script>

    <!--  end-->
</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                 分配<%#UserName %>人员</div>
        <table cellpadding="0" cellspacing="0" border="0" class="table">
           
            <tr>
                <td align="center">
                    <input id="Button1" type="button" value="增配人员" class="qr0" onclick="RedirectAssSignUser();" />
                </td>
                <td align="center">
                    <input id="Button2" type="button" value="减配人员" class="qr0" onclick="return DelAssginUser();" />
                </td>
                <td align="center">
                    <input id="Button3" type="button" value="返回" onclick="javascript:if(window.history.length==0) window.close();else window.history.back();"
                        class="qr0" />
                </td>
            </tr>
        </table>
        <div style="width: 900px; float: left; margin-top: 10px; text-align: center;" class="table"
            align="center">
            <%#NoData %>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" Width="899px">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <input id="Checkbox1" type="checkbox" value='<%#Eval("ID") %>' name="role" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="编号" ItemStyle-Width="30%" HeaderStyle-Width="30%"
                        ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <%#Eval("CodeID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人员名称" ItemStyle-Width="30%" HeaderStyle-Width="30%"
                        ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <%#GetUserName(Eval("ManagedID").ToString ())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人员角色" ItemStyle-Width="30%" HeaderStyle-Width="30%"
                        ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <%#GetUserRole(Eval("ManagedRole").ToString ())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </div> 
    </form>
</body>
</html>
