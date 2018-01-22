<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionFive.aspx.cs" Inherits="WebUI_Promotion_PromotionFive" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 原始订单导出</div>
    </div>
    <br />
    <table class="table">
        <tr>
            <td style="width: 150px; text-align: right">
                推广ID:
            </td>
            <td style="text-align: left">
                <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                推广主题:
            </td>
            <td style="text-align: left">
                <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table class="table">
        <tr>
            <td style="text-align: right; width: 150px;">
                请选择故事包<span style="color:Red;">*</span>:
            </td>
            <td>
               
               <%-- <asp:RadioButtonList ID="rblStoryBag" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="true" 
                    RepeatLayout="Flow" 
                    onselectedindexchanged="rblStoryBag_SelectedIndexChanged">
                </asp:RadioButtonList>--%>
                <asp:CheckBoxList ID="cblStoryBag" runat="server"  RepeatDirection="Horizontal" AutoPostBack="true" 
                    RepeatLayout="Flow" 
                    onselectedindexchanged="cblStoryBag_SelectedIndexChanged">
                </asp:CheckBoxList>
                <asp:HiddenField ID="hfParentStoryBagId" runat="server" />
                <asp:HiddenField ID="hfSonStoryBagId" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 150px;">
                请选择店铺类型<span style="color:Red;">*</span>:
            </td>
            <td>
               
                
               
                <asp:Repeater ID="Repeater1" runat="server" 
                            onitemdatabound="Repeater1_ItemDataBound">
                        <HeaderTemplate>
                          <table id="shopLevelTb" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                              <td style=" width:150px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;"> 
                                  <asp:CheckBox ID="cbAllShopType" runat="server" />
                                <%--店铺类型--%>
                                区县级城市级别
                              </td>
                              <td style=" width:80px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;">发货方式</td>
                              <td style=" text-align:left; padding-left:10px;border:0px; border-bottom:1px solid #ccc;">
                               <asp:CheckBox ID="cbAllRack" runat="server" />
                               道具
                              </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <tr>
                              <td style=" width:80px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;">
                                  <%--<asp:CheckBox ID="cbShopLevel"  data-val='<%#Eval("ShortName")%>' runat="server" Visible="false"/>
                                  <%#Eval("ShortName")%>--%>
                                  <%--<asp:HiddenField ID="hfShopLevelId" runat="server" Value='<%#Eval("Id")%>'/>--%>
                                  <asp:CheckBox ID="cbACL" runat="server" data-val='<%#(string)Container.DataItem%>'/>
                                  <%#(string)Container.DataItem %>
                              </td>
                              <td style=" width:80px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;">
                                  <asp:RadioButtonList ID="rblAddressType" runat="server" RepeatLayout="Flow" >
                                    <asp:ListItem Value="1" Selected="True">到店 </asp:ListItem>
                                    <asp:ListItem Value="2">到仓 </asp:ListItem>
                                  </asp:RadioButtonList>
                              </td>
                              <td style=" text-align:left; padding:0px;border:0px; vertical-align:top; border-bottom:1px solid #ccc;">
                              
                                  <asp:Repeater ID="Repeater2" runat="server">
                                  <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                      <tr>
                                         <th>
                                           <asp:CheckBox ID="cbAll" runat="server"/>
                                         </th>
                                         <th>位置</th>
                                         <th>道具类型</th>
                                         <th>道具尺寸</th>
                                         <th>道具名称</th>
                                         
                                      </tr>
                                    
                                  </HeaderTemplate>
                                    <ItemTemplate>
                                       <tr>
                                         <td style=" text-align:center;">
                                            <asp:CheckBox ID="rackcbOne" runat="server"/>
                                            <asp:HiddenField ID="hfRackId"  runat="server" Value='<%#Eval("rackId")%>'/>
                                         </td>
                                         <td><%#Eval("seat")%></td>
                                         <td><%#Eval("RackType")%></td>
                                         <td><%#Eval("Size")%></td>
                                         <td><%#Eval("StoryBagName")%>-<%#Eval("RackName")%>-<%#Eval("Category")%></td>
                                         
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
                
            </td>
        </tr>
    </table>

    
    <br />
    <br />
    <div style="text-align: center; width: 900px;">
       <div id="loading" style=" height:30px; text-align:center; display:none;color:Red;">
            <img src="../../images/loading.gif" />正在导出，请稍等....&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div id="buttons" style="text-align: center; width: 900px;">
            <asp:Button ID="btnExport" CssClass="qr0" runat="server" Text="导出" 
                OnClientClick="return check()" onclick="btnExport_Click"
                />
           
            &nbsp; &nbsp;
            <asp:Button ID="btnOk" runat="server" Text="完成" CssClass="qr0" 
                onclick="btnOk_Click"  />
            &nbsp; &nbsp;
            <asp:Button ID="Button1" runat="server" Text="上一步" CssClass="qr0" 
                onclick="Button1_Click1"  />
        </div>
       


        <%--<asp:Button ID="BtnFinish" CssClass="qr0" runat="server" Text="完 成" OnClientClick="return check()"
            OnClick="BtnFinish_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPrev" CssClass="qr0" runat="server" Text="上一步" OnClick="btnPrev_Click" />--%>
    </div>
    <br />
    <br />
    <div style=" display:none;">
      <iframe src="" name="iframe1" id="iframe1"></iframe>
    </div>
    <asp:HiddenField ID="hfSbId" runat="server" />
    </form>
</body>
</html>

<script type="text/javascript">
    $(function () {
        $("input[name$='cbAllShopType']").on("click", function () {
            
            if (this.checked) {
                $("#shopLevelTb").find("input[name$='cbACL']").attr("checked", "checked");
            }
            else
                $("#shopLevelTb").find("input[name$='cbACL']").attr("checked", false);
        })
        $("input[name$='cbAllRack']").on("click", function () {
            if (this.checked) {
                $("#shopLevelTb").find("input[name$='rackcbOne']").attr("checked", "checked");
            }
            else
                $("#shopLevelTb").find("input[name$='rackcbOne']").attr("checked", false);
        })


        $("input[name$='cbAll']").click(function () {

            if (this.checked) {

                $(this).parent().parent().siblings("tr").find("input[name$='rackcbOne']").attr("checked", "checked");
            }
            else {
                $(this).parent().parent().siblings("tr").find("input[name$='rackcbOne']").attr("checked", false);
            }
        })
    })


    function check() {
        //var storyBagId = $("input:radio[name='rblStoryBag']:checked").val() || "";
        //var storyBagName = $("input:radio[name='rblStoryBag']:checked").next().html();
        var storyBagName = "推广订单";
        //var shoplevel = $("input[name^='cblShopLevel']:checked").length;
        var storyBagId = $("#hfSonStoryBagId").val() || "";
//        $("input[type='checkbox'][name^='cblStoryBag']:checked").each(function () {
//            storyBagId += $(this).val() + ",";
//        })
        if (storyBagId == "") {
            alert("请选择故事包");
            return false;
        }

        

        //var shopLevelIds = ""; //格式：店铺类型Id:店铺类型名称:发货方式:道具Id1,具Id2$店铺类型Id:店铺类型名称:发货方式:道具Id1,具Id2
        var shopLevelIds = ""; //格式：级别:发货方式:道具Id1,具Id2$店铺类型Id:店铺类型名称:发货方式:道具Id1,具Id2
        $("#shopLevelTb tr").each(function () {
            var rackids = "";
            //var shoplevelcb = $(this).find("td").eq(0).find("input[name$='cbShopLevel']");
            var shoplevelcb = $(this).find("td").eq(0).find("input[name$='cbACL']");
            var addressType = $(this).find("td").eq(1).find("input:radio[name$='rblAddressType']:checked").val() || "";
            var racktr = $(this).find("td").eq(2).find("tr");
            if (shoplevelcb.attr("checked")) {

                //var id = shoplevelcb.parent().siblings("input").val();
                var name = shoplevelcb.parent().data("val");

                //shopLevelIds += id + ":" + name + ":" + addressType;
                shopLevelIds += name + ":" + addressType;
                $(racktr).each(function () {
                    var cb = $(this).find("td").eq(0).find("input[name$='cbOne']");
                    if (cb.attr("checked")) {
                        var rid = cb.siblings("input").val();
                        rackids += rid + ",";
                    }
                })
                if (rackids != "") {
                    rackids = rackids.substring(0, rackids.length - 1);

                }
                shopLevelIds += ":" + rackids + "$";
            }

        })
        if (shopLevelIds.length > 0) {
            shopLevelIds = shopLevelIds.substring(0, shopLevelIds.length - 1);
        }
        
        var canExport = true;
        if ($.trim(shopLevelIds) == "") {
            canExport = false;
            alert("请选择店铺类型");
        }
        else {
            var arr = shopLevelIds.split('$');
            for (var i = 0; i < arr.length; i++) {
                var subArr = arr[i].split(':');
                
                if (subArr[3] == "") {
                    alert("请为" + subArr[1] + "选择道具");
                    canExport = false;
                }
            }
        }
        if (canExport) {
            //var isIE = ! -[1, ];
            //if (!isIE) {
                $("#buttons").css({ display: "none" });
                $("#loading").css({ display: "" });
                CheckExport();

            //}
            var pid = "<%=pid %>";
            var parentStoryBagId = $("#hfParentStoryBagId").val() || "";


            var url = "handler/ExportOrder.aspx?pid=" + pid + "&sonStoryBagId=" + storyBagId + "&parentStoryBagId=" + parentStoryBagId + "&storyBagName=" + escape(storyBagName) + "&shopLevels=" + escape(shopLevelIds).replace(/\+/g, '%2B');
            
            $("#iframe1").attr("src", url);
        }
        

        
        return false;
    }

    var timer;
    var button1 = $("#buttons");
    var loading = $("#loading");
    function CheckExport() {
        timer = setInterval(function () {
            $.ajax({
                type: "get",
                url: "handler/CheckExportOrder.ashx",
                cache:false,
                success: function (data) {
                    
                    if (data == "ok") {
                        button1.css({ display: "" });
                        loading.css({ display: "none" });
                        clearInterval(timer);
                    }
                }
            })
        }, 1000);
    }

    function Cancel() {
        alert("没有可导出的数据");
        $("#buttons").css({ display: "" });
        $("#loading").css({ display: "none" });
    }

    function CancelLoading() {
        alert("ok");
        $("#buttons").css({ display: "" });
        $("#loading").css({ display: "none" });
    }
</script>
