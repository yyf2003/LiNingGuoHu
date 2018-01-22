<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionThree.aspx.cs" Inherits="WebUI_Promotion_PromotionThree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../fancyBox/source/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <script src="../../fancyBox/source/jquery.fancybox.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("a.showimg").fancybox();

            $("input[type='checkbox'][name='cbAll']").on("click", function () {
                var checked = this.checked;

                $(this).parent().parent("span").find("input[type='checkbox'][name='cbOne']").attr("checked", checked);
            })

        })

        function check() {
            if (!GetPositions()) {
                alert("请完成产品系列所在区域的选择");
                return false;
            }
            else
              return true;
        }

        function GetPositions() {
            var isPass = true;
            $(".positionCss").each(function () {
                var count = 0;
                var positions = "";
                var hf = $(this).siblings("input[type='hidden']").eq(1);
                $(this).find("input[type='checkbox'][name$='cbOne']:checked").each(function () {
                    positions += $(this).val() + ",";
                    count++;
                })
                if (count == 0)
                    isPass = false;
                else
                    hf.val(positions);
            })
            return isPass;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 选择推广区域</div>
        <br />
        <table class="table">
            <tr>
                <td style="width: 170px; text-align: right">
                    推广ID:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    推广主题:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="table" style="text-align: center;">
            <tr>
                <th style="width: 280px;">
                    区域
                </th>
                <th style="width: 90px;">
                    产品系列
                </th>
                <th style="width: 100px;">
                    同系列画面优先级
                </th>
                <th style="width: 80px;">
                    图片编号
                </th>
                <th>
                    图片
                </th>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAllLevel" runat="server" 
                        onselectedindexchanged="ddlAllLevel_SelectedIndexChanged">
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td style=" text-align: left;">
                            <asp:HiddenField ID="hfProductLineId" runat="server" Value='<%#Eval("ProductLineId") %>' />
                            <asp:Label ID="labPosition" runat="server" Text="" class="positionCss"></asp:Label>
                            <asp:HiddenField ID="hfPositions" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="labLineName" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLevel" runat="server">
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>29</asp:ListItem>
                                <asp:ListItem>28</asp:ListItem>
                                <asp:ListItem>27</asp:ListItem>
                                <asp:ListItem>26</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>0</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="labImgNumber" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="labImg" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <br />
            <div style="text-align: center; width: 900px;">
                <asp:Button ID="BtnNext" CssClass="qr0" runat="server" Text="下一步" OnClientClick="return check()"
                    OnClick="BtnNext_Click" />
                &nbsp; &nbsp;
                <asp:Button ID="btnPrev" runat="server" Text="上一步" CssClass="qr0" OnClick="btnPrev_Click" />
            </div>
            <br />
            <br />
    </div>
    </form>
</body>
</html>
