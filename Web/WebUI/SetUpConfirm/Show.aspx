<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Show.aspx.cs" Inherits="WebUI_SetUpConfirm_Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>确认安装详细信息</title>

  
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server" onsubmit="return CheckAdd();">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                确认安装详细信息</div>
        </div>
        <br />
        <div class="table" style=" margin-left:20px">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                OnPageIndexChanging="GridView1_PageIndexChanging" Width="899px">
                <Columns>
                    <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <%#Eval("Num") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="POP标题">
                        <ItemTemplate>
                            <%#Eval("POPTitle") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺名称">
                        <ItemTemplate>
                            <%#Eval("Shopname")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="安装数量">
                        <ItemTemplate>
                            <%#Eval("SetUpCount")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="提交人">
                        <ItemTemplate>
                            <%#Eval("UserName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="描述">
                        <ItemTemplate>
                            <%#Eval("OperatorDate")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="附件">
                        <ItemTemplate>
                            <a href='../../<%#Eval("PicUrl")%>' style="text-decoration:none;" target="_blank">附件</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="提交日期">
                        <ItemTemplate>
                            <%#Eval("OperatorDate")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
