<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPDetail.aspx.cs" Inherits="WebUI_POPLanuch_POPDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>POP详细信息</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />

    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../js/jquery.min.js" type="text/javascript"></script>    
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script> 
      
</head>

<script type="text/javascript">
    function openWin(ImageID) {
        var returnValue = showModalDialog('POPPhotoSetCity.aspx?ImageID=' + ImageID + '', 'example04', 'dialogWidth:950px;dialogHeight:750px;dialogLeft:200px;dialogTop:100px;center:yes;help:yes;resizable:yes;status:yes');
        if (returnValue == "ok") {
            window.location.href = window.location.href;
        }
    }
</script>

<body>
    <form id="form1" runat="server">
    <div>
    
    	<table class="table">
			<tr>
				<td style="width:15%">POPID:</td>
				<td style="width:35%">&nbsp;<%=POPID %></td>
				<td style="width:15%">POP主题：</td>
				<td style="width:35%">&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
			</tr>
			<tr>
				<td>起始时间：</td>
				<td>&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
				<td>结束时间：</td>
				<td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
			</tr>
				<tr>
				<td>描述：</td>
				<td colspan="3">&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
			</tr>
	<tr>
				<td>季度执行规范下载：</td>
				<td><a href="<%= fileurl %>"  target="_blank"><%= DownLoadFilename%></a></td>
				<td>&nbsp;</td>
				<td>&nbsp;<a href="POPList.aspx">返回列表</a></td>
			</tr>
			</table>
    <br/>
    <div style="width:900px; font-size:14px; color:Fuchsia">POP总数量:<%=totalnum.ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;POP总面积:<%=totalarea.ToString() %></div>
    <%=totalstr.ToString()%>
    <br />
    <table class="table">
    <tr>
    <td style="width:15%">产品大类：</td> <td style="width:35%">
        <asp:DropDownList ID="DDL_Prolist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Prolist_SelectedIndexChanged">
            <asp:ListItem Value="0">请选择产品大类</asp:ListItem>
        </asp:DropDownList></td> <td style="width:15%">产品系列：</td> <td style="width:35%">
        <asp:DropDownList ID="DDL_ProLine" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_ProLine_SelectedIndexChanged">
            <asp:ListItem Value="0">请选择产品系列</asp:ListItem>
        </asp:DropDownList></td> 
    </tr>
    </table>
    <br />
        <asp:Repeater ID="Repeater1" runat="server" 
            OnItemCommand="Repeater1_ItemCommand" >
        <HeaderTemplate>
        <table class="table">
        <tr>
           <th style="width:80px">产品大类</th><th>产品系列</th><th>系列优先级</th><th>图片</th><th style="width:250px">图片编号</th><th style="<%=strDisplay %>"><th style="<%=strDisplay %>"></th>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
           <td style="width:30px"><%#Eval("ProductTypeName").ToString()%></td><td><%#Eval("ProductLineName").ToString()%></td><td><%#Eval("ProductLevel")%></td><td><a href="<%#Eval("ImageUrl") %>" target="_blank"><img width="80px" height="60px" alt='<%#Eval("ProductLine")%>' src="<%#Eval("SmallImageUrl")%>"></a></td><td><%#Eval("ImageLevel")%></td>
           <td style="<%=strDisplay %>">
              <a href='#' onclick='openWin(<%#Eval("ImageID")%>)'>使用范围</a>
           </td>
           <td style="<%=strDisplay %>">               
               <asp:LinkButton ID="btn_del" OnClientClick="return confirm('您确定要删除吗？');" CommandName="del" CommandArgument='<%#Eval("ImageID")%>' runat="server">删除</asp:LinkButton>
           </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
         </table>
        </FooterTemplate>
        </asp:Repeater>
       
    </div>
    </form>
</body>
</html>
