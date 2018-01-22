<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetRackLimitCount.aspx.cs"
    Inherits="WebUI_Promotion_RackInfo_SetRackLimitCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <style type="text/css">
        .table2
        {
            border: 1px solid #6d6060; /* 表格边框 */
            font-family: Arial;
            border-collapse: collapse; /* 边框重叠 */
            background-color: #fdf6f6; /* 表格背景色 */
            font-size: 12px;
            width: 100%;
            margin: 0px;
        }
        .table2 caption
        {
            padding-bottom: 5px;
            font: bold 1.4em;
            text-align: left;
        }
        .table2 th
        {
            border: 1px solid #6d7378; /* 行名称边框 */
            background-color: #a1a1a1; /* 行名称背景色 */
            color: #fff; /* 行名称颜色 */
            font-weight: bold;
            padding-top: 4px;
            padding-bottom: 4px;
            padding-left: 12px;
            padding-right: 12px;
            text-align: center;
        }
        .table2 td
        {
            border: 1px solid #797e83; /* 单元格边框 */
            line-height: 25px;
            padding-top: 4px;
            padding-bottom: 4px;
            padding-left: 5px;
            padding-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
        color: #c86000;">
        设置道具数量上限
    </div>
    <br />
    <div>
        <asp:Button ID="btnSubmit" CssClass="qr0" runat="server" Text="提 交" OnClick="btnSubmit_Click" />
    </div>
    <br />
    <div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table class="table2">
                    <tr>
                        <th style="width: 15%">
                            店铺级别
                        </th>
                        <th style="width: 20%">
                            道具位置
                        </th>
                        <th>
                            数量上限
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width: 100px;">
                        <%#Eval("ShortName")%>
                        <asp:HiddenField ID="hfLevelId" runat="server" Value='<%#Eval("Id") %>' />
                    </td>
                    <td colspan="2" style="padding: 0;">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <HeaderTemplate>
                                <table class="table2">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 24%">
                                        <%#Eval("seat")%>
                                        <asp:HiddenField ID="hfSeatId" runat="server" Value='<%#Eval("SeatID") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
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
<script type="text/javascript">
    var isInt = /^\d{1,}$/;
    $(function () {
        $(".table2").find("input[type='text']").on("blur", function () {
            var val = $(this).val();
            if ($.trim(val) != "") {
                if (!isInt.exec(val)) {
                    alert("必须填写整数");
                    $(this).val("");
                }
                else if (parseInt(val)>100) {
                    alert("上限数量不能大于100");
                    $(this).val("");
                }
            }
        })
    })
</script>
