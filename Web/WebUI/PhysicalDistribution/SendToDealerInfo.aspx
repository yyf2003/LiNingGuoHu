<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendToDealerInfo.aspx.cs"
    Inherits="WebUI_PhysicalDistribution_SendToDealerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看POP--发货到一级客户</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/Validate.js"></script>

    <script type="text/javascript" language="javascript" src="./javascript/ValidateSendFrom.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; text-align: center">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                width: 50%; float: left; height: 30px; color: #c86000;">
                <a href="SendToShopList.aspx" title="发货到一级客户" style="color: #c86000;">发货到一级客户</a> &gt;&gt;
                <%= ShopName%>
            </div>
            <table class="table" style="margin-top: 20px; float: left; margin-left: 20px; width: 90%">
                <caption style="font-weight: bold">
                    POP信息列表：</caption>
                <tr>
                    <th>
                        POP编号</th>
                    <th style="width: 25%">
                        POP位置</th>
                    <th style="width: 25%">
                        材料</th>
                    <th>
                        POP高度</th>
                    <th>
                        POP宽度</th>
                    <th>
                        POP面积</th>
                </tr>
                <asp:Repeater runat="server" ID="RepPOPList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label></td>
                            <td>
                                <%# Eval("POPseat")%>
                            </td>
                            <td>
                                <%# Eval("POPMaterial") %>
                            </td>
                            <td>
                                <%# Eval("POPHeight")%>
                            </td>
                            <td>
                                <%# Eval("POPWith")%>
                            </td>
                            <td>
                                <%# Eval("POPArea")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table class="table" style="margin-top: 10px; float: left; margin-left: 20px; width: 90%">
                <tr>
                    <td align="Center">
                        <input id="Button1" type="button" value="确   认" class="qr0" onclick="javascript:window.history.back();" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="txtPOPID" runat="server" />
    </form>
</body>
</html>
