<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="WebUI_UserManage_UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <style>
    a:link{ text-decoration:underline;color:#424242;}
    a:visited{ text-decoration:underline;color:#424242;}
    a:active{ text-decoration:underline;color:#424242;}
    a:hover{ text-decoration:underline;color:#424242;} 
   </style>
    <title>人员分配</title>
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <!--  end-->

    <script>
    function SearchData()
   { 
        var ary="";
       var role =""; 
       var username ="";
        role =$("#ddl_UserType").val();
        username=$("#txt_UserName").val();
         if(role!="0")
        { 
           ary ="?Role="+role;
        } 
       if(username!="")
       {
       if(ary!="") 
        ary +="&UserName="+username; 
       else
        ary ="?UserName="+username;
       } 
     // window.location ="UserList.aspx"+ary;
     location.href ="UserList.aspx"+ary;
   } 
   function openwinaddUser()
  { 
    window.location ="../UserInfo/AddUser.aspx";
  }  
    </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                人员列表  <a href="#" onclick="javascript:openwinaddUser" style ="float :right ; font-size :12px;">新增人员</a></div>
   
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td width="100px">
                    角色
                </td>
                <td>
                    <asp:DropDownList ID="ddl_UserType" runat="server"  CssClass ="DDlstyle">
                        <asp:ListItem Value="0">请选择角色类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="100px">
                    员工名称
                </td>
                <td width="350px">
                    <asp:TextBox ID="txt_UserName" runat="server" CssClass ="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4"  align =center >
                    <input id="Button1" type="button" value="查找" class="qr0" onclick="SearchData();" />
                </td>
            </tr>
        </table>
        <div style=" margin-left: 5% ; margin-top :10px;" class="table">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                OnPageIndexChanging="GridView1_PageIndexChanging" Width="899px" PageSize="25">
                <Columns>
                    <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <%#Eval("UserID") %>
                        </ItemTemplate>
                        <HeaderStyle Width="10%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <%#Eval("Username") %>
                        </ItemTemplate>
                        <HeaderStyle Width="16%" />
                        <ItemStyle HorizontalAlign="Center" Width="16%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色">
                        <ItemTemplate>
                            <%#GetUserRole(Eval("Usertype").ToString ())%>
                        </ItemTemplate>
                        <HeaderStyle Width="16%" />
                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#Eval("UserState").ToString ()=="0"?"离职":"在职"%>
                        </ItemTemplate>
                        <HeaderStyle Width="10%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="分配人员">
                        <ItemTemplate>
                            <a href='AssignUser.aspx?UserID=<%#Eval("UserID") %>'>分配人员</a>
                        </ItemTemplate>
                        <HeaderStyle Width="16%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="区域分配">
                        <ItemTemplate>
                            <a href='AssignArea.aspx?UserID=<%#Eval("UserID") %>'>区域分配</a>
                        </ItemTemplate>
                        <HeaderStyle Width="16%" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人员信息">
                        <ItemTemplate>
                            <a href='../UserInfo/OneUserInfo.aspx?ID=<%#Eval("UserID") %>'>详细</a>
                        </ItemTemplate>
                        <HeaderStyle Width="16%" />
                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </div> 
    </form>
</body>
</html>
