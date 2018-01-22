<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionTwo.aspx.cs" Inherits="WebUI_Promotion_PromotionTwo" %>

<%@ Register Src="../../FileUploadUC/UpLoadContraol.ascx" TagName="UpLoadContraol"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; POP产品系列图片上传</div>
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
        <div style="padding-left: 10px; font-size: 14px; height: 30px; line-height: 30px;">
            故事包信息：
        </div>
        <asp:Repeater ID="Repeater2" runat="server" 
            onitemdatabound="Repeater2_ItemDataBound">
            <HeaderTemplate>
                <table class="table" id="sbTable" style="text-align: center;">
                    <tr>
                        <td style="width: 150px;">
                            故事包名称

                        </td>
                        <td style="text-align: left; padding-left: 5px;">
                            添加子故事包
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="labStoryBagName" runat="server" Text='<%#Eval("StoryBagName")%>'></asp:Label>
                        <asp:HiddenField ID="hfStoryBagId" runat="server" Value='<%#Eval("Id")%>' />
                       
                    </td>
                    <td style="text-align: left; padding-left: 5px;">
                        <asp:Panel ID="Panel1" runat="server">
                           <div>
                            <input type="text" style="width: 120px;" />&nbsp;
                            <input type="button" name="addSubSb" class="addSubSb" data-sbid='<%#Eval("Id")%>' style="cursor: hand;" value="添加"/>
                                
                            
                        </div>
                        <div class="sbContainer">
                        </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                            <asp:Label ID="labStoryBagNames" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
        <div style="padding-left: 10px; font-size: 14px; height: 30px; line-height: 30px;">
            推广道具信息：
        </div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table class="table" id="table1" style="text-align: center;">
                    <tr>
                        <%--<td style=" width:30px;">
                            序号
                        </td>--%>
                        <td style="width: 70px;">
                            故事包
                        </td>
                        <td style="width: 60px;">
                            位置
                        </td>
                        <td style="width: 70px;">
                            道具类型
                        </td>
                        <td style="width: 80px;">
                            道具尺寸
                        </td>
                        <td style="width: 80px;">
                            道具名称
                        </td>
                        <td style="text-align: left; padding-left: 20px;">
                            效果图
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <%-- <td style=" width:30px;">
                          <%#Container.ItemIndex+1%>
                    </td>--%>
                    <td runat="server" id="StoryBagName" style="width: 50px;">
                        <%#Eval("StoryBagName")%>
                    </td>
                    <td runat="server" id="seat" style="width: 60px;">
                        <%#Eval("seat")%>
                    </td>
                    <td runat="server" id="rackType" style="width: 60px;">
                        <%#Eval("rackType")%>
                    </td>
                    <td style="width: 80px;">
                        <%#Eval("Size")%>
                    </td>
                    <td style="width: 80px;">
                        <%#Eval("RackName")%>-<%#Eval("Category")%></td>
                    <td style="text-align: left;">
                        <div id="show<%#Eval("rackId") %>" data-rack='<%#Eval("RackName")%>-<%#Eval("Size")%>-<%#Eval("Category")%>'
                            class="ShowFileInfo">
                        </div>
                        <uc1:UpLoadContraol ID="UpLoadContraol1" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <br />
    <br />
    <div style="text-align: center;">
        <asp:Button ID="btnNext" runat="server" Text="下一步" CssClass="qr0" OnClientClick="return Check()"
            OnClick="btnNext_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="btnPrev" runat="server" Text="上一步" CssClass="qr0" OnClick="btnPrev_Click"/>
    </div>
    <br />
    <br />
    <asp:HiddenField ID="hfPromotionId" runat="server" />
    <div id="msgDiv" title="提示" style="display: none; width: 500px;">
    </div>
    <asp:HiddenField ID="hfsbJson" runat="server" />
    </form>
</body>
</html>
<link href="../../js/jquery-ui-1.11.4.custom/jquery-ui.min.css" rel="stylesheet"
    type="text/css" />
<script src="../../js/jquery-ui-1.11.4.custom/jquery-ui.min.js" type="text/javascript"></script>
<script type="text/javascript">

    var flag1 = false;
    function Check() {
        var flag = true;
        var rackInfos = "";
        if ($.trim(sbJson) != "") {
            var temp = "[" + sbJson + "]";
            $("#hfsbJson").val(temp);
        }
        if (!flag1) {
            $("div.ShowFileInfo").each(function () {
                if ($.trim($(this).html()) == "") {
                    flag = false;
                    var a = $(this).data("rack");
                    rackInfos += a + "；";
                }
            })
        }

        if (!flag) {

            rackInfos = "以下道具没有上传效果图：<br/>" + rackInfos;
            $("#msgDiv").html(rackInfos).dialog({
                resizable: false,
                modal: true,
                width: '500px',
                buttons: {
                    "继续上传": function () {
                        $(this).dialog('close');
                    },
                    "下一步": function () {
                        flag1 = true;
                        $("#btnNext").click();
                    }
                }
            })

            return false;
        }
        else
            return true;
    }

    var sbJson = "";
    var container;
    $(function () {

        LoadSbJson();



        $(".addSubSb").click(function () {
            var storyBagId = $(this).data("sbid");
            
            var txtName = $(this).siblings("input");
            container = $(this).parent().siblings("div");
            if ($.trim($(txtName).val()) != "") {
                var json = '{"ParentStoryBagId":"' + storyBagId + '","StoryBagName":"' + $(txtName).val() + '"}';
                if ($.trim(sbJson) != "") {
                    sbJson += "," + json;
                }
                else
                    sbJson = json;
                $(txtName).val("");

            }
            displayStoryName(storyBagId);
        })

        //删除
        $(".sbContainer").delegate("span[name='deleteItem']", "click", function () {
            var txt = $(this).siblings("span").html();
            var sbid = $(this).data("sbid");

            var div = $(this).parent("div");
            if ($.trim(sbJson) != "") {
                var temp = "[" + sbJson + "]";

                var json = eval("(" + temp + ")");

                if (json.length > 0) {
                    var index = -1;
                    var rowIndex = 0;
                    $.each(json, function (key, val) {


                        if (parseInt(val.ParentStoryBagId) == parseInt(sbid) && val.StoryBagName == txt) {
                            index = rowIndex;
                        }
                        rowIndex++;
                    })
                    if (index > -1) {
                        json.splice(index, 1);
                        div.remove();
                    }
                    sbJson = "";
                    for (var i = 0; i < json.length; i++) {
                        sbJson += '{"ParentStoryBagId":"' + json[i].ParentStoryBagId + '","StoryBagName":"' + json[i].StoryBagName + '"},';
                    }
                    sbJson = sbJson.length > 0 ? sbJson.substring(0, sbJson.length - 1) : "";

                }
            }
        })

    })


    function displayStoryName(storyBagId) {
        if ($.trim(sbJson) != "") {
            var temp = "[" + sbJson + "]";
            var json = eval("(" + temp + ")");
            if (json.length > 0) {
                var div = "";
                for (var i = 0; i < json.length; i++) {
                    if (parseInt(json[i].ParentStoryBagId) == parseInt(storyBagId)) {
                        div += "<div style='float:left;width：auto;margin-right:10px;'><span>" + json[i].StoryBagName + "</span><span name='deleteItem' data-sbid='" + json[i].ParentStoryBagId + "' style='cursor:hand;color:red;'>×</span></div>";
                    }
                }
                $(container).html(div);
            }
        }
    }

    function LoadSbJson() {
        
        if ($.trim($("#hfsbJson").val()) != "") {
            sbJson = $("#hfsbJson").val();

            $("#sbTable tr").each(function () {
                var button = $(this).find("input[name='addSubSb']");
                var sbid = $(button).data("sbid");
                container = $(button).parent().siblings("div");
                displayStoryName(sbid)
            })


        }
    }
</script>
