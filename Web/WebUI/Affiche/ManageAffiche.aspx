<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageAffiche.aspx.cs" Inherits="WebUI_Affiche_ManageAffiche" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告管理</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
       <style>
    a:link{ text-decoration:underline;color:#424242;}
    a:visited{ text-decoration:underline;color:#424242;}
    a:active{ text-decoration:underline;color:#424242;}
    a:hover{ text-decoration:underline;color:#424242;} 
   </style> 
</head>
<body>
    <form id="form1" runat="server">
        <div class ="table">
            <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltype_SelectedIndexChanged"
                Width="120px"  CssClass ="DDlstyle">
            </asp:DropDownList>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <div style="width: 100%; height: 21px; border-bottom: solid 1px #cccccc; padding-top: 16px;">
                        <div style="float: left; width: 18%">
                            日期</div>
                        <div style="float: left; width: 50%">
                            标题</div>
                        <div style="float: left; width: 10%">
                            设置</div>
                        <div style="float: left; width: 10%">
                            修改</div>
                        <div style="float: left; width: 10%">
                            删除</div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="width: 100%; border-bottom: dotted 1px #cdcdcd;">
                        <div style="float: left; width: 18%; height: 18px; padding-top: 10px;">
                            <%#System.DateTime.Parse(Eval("Time").ToString()).ToString("yyyy-MM-dd") %>
                        </div>
                        <div style="float: left; width: 50%; height: 18px; padding-top: 10px;">
                            <a href='ShowAffiche.aspx?ID=<%#Eval("ID") %>'>
                                <%#Eval("Title") %>
                            </a>
                        </div>
                        <div style="float: left; width: 10%; height: 18px; padding-top: 10px;">
                            <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%#Eval("ID")%>'
                                CommandName='<%#Eval("IsScroll").ToString() =="0"?"setscroll":"delscroll" %>'><%#Eval("IsScroll").ToString() =="0"?"设置滚动":"取消滚动" %></asp:LinkButton>
                        </div>
                        <div style="float: left; width: 10%; height: 18px; padding-top: 10px;">
                            <a href='ModifyAffiche.aspx?ID=<%#Eval("ID") %>'>
                               修改</a>
                        </div>
                        <div style="float: left; width: 10%; height: 18px; padding-top: 10px;">
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" OnClientClick="return confirm('确认删除吗？');"
                                CommandArgument='<%#Eval("ID")%>'>删除</asp:LinkButton></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            共<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>页&nbsp; 当前
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>页 跳转到第<asp:DropDownList
                ID="DropDownList2" runat="server" Height="20px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                Width="45px" AutoPostBack="True">
            </asp:DropDownList>页
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">首页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">尾页</asp:LinkButton>
        </div>
    </form>
</body>
</html>
