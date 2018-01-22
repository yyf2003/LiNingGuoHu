<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPromotion.aspx.cs" Inherits="WebUI_Promotion_AddPromotion" %>

<%@ Register src="../../FileUploadUC/UpLoadContraol.ascx" tagname="UpLoadContraol" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    <style type="text/css">
        .divstype
        {
            width: 100%;
            font-weight: bold;
            background-color: InactiveCaption;
            font-size: 13px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("input[type='checkbox'][name='checkType']").bind("click", function () {
                var checked = this.checked;
                $(this).parent().siblings().find("input[type='checkbox']").each(function () {
                    $(this).attr("checked", checked);
                })
            })
        })

        function check() {
            if ($.trim($("#txt_btime").val()) == "") {
                alert("请填写开始时间");
                return false;
            }
            if ($.trim($("#txt_etime").val()) == "") {
                alert("请填写结束时间");
                return false;
            }
            if ($.trim($("#txt_poptitle").val()) == "") {
                alert("请填写主题");
                return false;
            }
            if ($.trim($("#txt_remarks").val()) == "") {
                alert("请填写备注");
                return false;
            }
//            if (GetProduceLines())
//                return checkFile();
//            else {
//                alert("请选择产品系列");
//                return false;
            //            }
            return checkFile();
        }

        function GetProduceLines() {
            var lines = "";
            $("input[type='checkbox'][name='checkLines']:checked").each(function () {
                lines += $(this).val() + ","
            })
            $("#hfProductLines").val(lines);
            return lines.length > 0;
        }

        function checkFile() {

            var flag = true;
            var val = $("#FileUpload1").val()||"";
            if (val != "") {
                if (val.substring(val.lastIndexOf('.') + 1) == "exe") {
                    alert("禁止上传exe文件");
                    flag = false;
                }
            }
            return flag;

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 添加POP推广信息</div>
        <br />
        <table class="table">
            <tr>
                <td style="width: 170px; text-align: right">
                    推广ID:
                </td>
                <td style="width: 300px; text-align: left">
                    <asp:TextBox ID="txt_PromotionId" runat="server" BorderStyle="None" CssClass="txtwith"
                        Enabled="False"></asp:TextBox>
                </td>
                <td style="width: 100px; text-align: right">
                    <%--是否重新报价:--%>
                </td>
                <td>
                    <%--<asp:DropDownList ID="DDL_price" runat="server">
                        <asp:ListItem Value="0">不需要重新报价</asp:ListItem>
                        <asp:ListItem Value="1">重新报价</asp:ListItem>
                    </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    起始时间:
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txt_btime" ContentEditable="false" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                        CssClass="txtwith" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    结束时间:
                </td>
                <td>
                    <asp:TextBox ID="txt_etime" ContentEditable="false" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                        runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    推广主题:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txt_poptitle" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    请选择故事包:
                </td>
                <td colspan="3">
                    <div style="width: 100%;">
                        <%--<asp:Label ID="labProductLine" runat="server" Text=""></asp:Label>--%>
                        <asp:Repeater ID="Repeater1" runat="server" 
                            onitemdatabound="Repeater1_ItemDataBound">
                        <HeaderTemplate>
                          <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                              <td style=" width:80px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;">故事包</td>
                              <td style=" text-align:left; padding-left:10px;border:0px; border-bottom:1px solid #ccc;">位置</td>
                            </tr>
                         
                        </HeaderTemplate>
                        <ItemTemplate>
                           <tr>
                              <td style=" width:80px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;">
                                  <asp:CheckBox ID="cbStoryBag" runat="server"/><%#Eval("StoryBagName")%>
                                  
                                  <asp:HiddenField ID="hfStoryBagId" runat="server" Value='<%#Eval("Id")%>'/>
                                  

                              </td>
                              <td style=" text-align:left; padding-left:10px;border:0px; border-bottom:1px solid #ccc;">
                                  <asp:CheckBoxList ID="cblSeats" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                  </asp:CheckBoxList>
                              </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                           </table>
                        </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    推广描述:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txt_remarks" runat="server" CssClass="txtwith" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    推广活动相关文档:
                </td>
                <td colspan="3">
                    <asp:Panel ID="UpFilePanel1" runat="server">
                        <asp:FileUpload ID="FileUpload1" runat="server" class="txtwith" />
                    </asp:Panel>
                    <asp:Panel ID="UpFilePanel2" runat="server">
                        <div id="show1" class="ShowFileInfo"></div>
                        <uc1:UpLoadContraol ID="UpLoadContraol1" runat="server" Code="1"/>
                        
                    </asp:Panel>
                    
                </td>
            </tr>
        </table>
        <br />
        <div style="text-align: center; width: 900px;">
            <asp:Button ID="BtnNext" CssClass="qr0" runat="server" Text="下一步" OnClientClick="return check()"
                OnClick="BtnNext_Click" />
        </div>
    </div>
    <asp:HiddenField ID="hfProductLines" runat="server" />
    </form>
</body>
</html>
