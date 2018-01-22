<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAssignUser.aspx.cs" Inherits="WebUI_UserManage_AddAssignUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加人员分配</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <script>
          var uid ="<%#UID %>";  
    function SearchData()
   { 
        var rols =""; 
        var ary=""; 
       var role = document.getElementsByTagName ("input");
        for(var i =0;i<role.length;i++)
       {
            var ab =role[i];
             if(ab.type=="checkbox")
            {
              if(ab.checked)
               rols +=ab.value+",";  
            } 
       }
       rols =rols.substring(0,rols.length-1); 
       var username ="";
        username=$("#txt_UserName").val();
         if(rols!="")
        { 
           ary ="&Role="+rols;
        } 
       if(username!="")
       {
       if(ary!="") 
        ary +="&UserName="+username; 
       else
        ary ="&UserName="+username;
       }  
      window.location ="AddAssignUser.aspx?UserID="+uid+ary;
   } 
   function openwinaddUser()
  { 
    window.location ="../UserInfo/AddUser.aspx";
  }  
  function SetAssginUser()
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
            $.get("../ashx/AddAssignUser.ashx",{UserItem:useritem,UserID:uid},function(data){
             if(data.length>0) 
                 $.prompt("操作成功!",{callback:reloadpage}); 
            }) ;
        }
  }
   function reloadpage()
  {
    window.location ='AssignUser.aspx?UserID='+uid;
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
                分配人员</div>
        <table cellpadding="0" cellspacing="0" border="0" class="table"  style ="margin-top: 20px; margin-left: 5%">
            <tr>
                <td colspan="3">
                    分配<%#UserName %>人员
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    角 色 :<%#RoleData %>
                </td>
            </tr>
            <tr>
                <td width="33%">
                    人员名称
                    <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
                </td>
                <td width="33%">
                    <input id="Button4" type="button" value="查询" class="qr0" onclick="SearchData();" />
                </td>
                <td width="33%">
                </td>
            </tr>
        </table>
        <div style="width: 898px; margin-top: 10px; margin-left: 5%" class="table">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="50" Width="898px">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <input id="Checkbox1" type="checkbox" value='<%#Eval("UserID") %>' name="role" />
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
                            <%#Eval("Username")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人员角色" ItemStyle-Width="30%" HeaderStyle-Width="30%"
                        ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <%#GetUserRole(Eval("Usertype").ToString ())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;margin-left: 5%">
            <tr>
                <td align="center">
                    <input id="Button1" type="button" value="提交" class="qr0" onclick ="return SetAssginUser();" />
                    <input id="Button3" type="button" value="返回" onclick="javascript:if(window.history.length==0) window.close();else window.history.back();"
                        class="qr0" />
                </td>
            </tr>
        </table>
        </div> 
    </form>
</body>
</html>
