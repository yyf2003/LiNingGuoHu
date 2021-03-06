﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPOPAddition.aspx.cs" Inherits="WebUI_POPAddition_AddPOPAddition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺增补POP信息</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js">
    </script>

    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>

    <script type="text/javascript">
        var IsAllCheck = 0;
        var checkval="";
    function AllCheck()
    {
        var selectSpan = $("#selectSpan");
        var chk = $("input[type='checkbox']");
        if(IsAllCheck == 0)
        {
            chk.attr("checked",'true');//全选

            IsAllCheck = 1;
            selectSpan.html("取消");
            selectSpan.attr("title","全部取消");
        }
        else
        {
            chk.removeAttr("checked");//取消
            IsAllCheck = 0;
            selectSpan.html("全选");
            selectSpan.attr("title","全部选择");
        }
	    }
	    
	    function GetCheckVal()
	    { 
	        var checkval="";
	         var chk =document.getElementsByTagName ("input");
	         for(var i =0;i<chk.length;i++)
	         { 
	             
	             if(chk[i].type=="checkbox")
	             {
	                if(chk[i].checked)
	                 {
	                      checkval +=chk[i].id+",";
	                 }
	             }
	         }
	        if(checkval!="")
	        {
	         checkval=checkval.substring(0,checkval.length-1);
	        }
	        else
	        {
	          $.prompt("请选择要增补的项！");
	          return false;
	        }
	        
	      
	       
	    }
    </script>

    <script type="text/javascript" src="../../js/ShowDIV.js"></script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div>
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                <%=Shopname %>
                POP信息</div>
            <table class="table">
                <tr>
                    <td style="width: 15%">
                        店铺编号：</td>
                    <td style="width: 35%">
                        &nbsp;<asp:TextBox ID="PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        零售分类：</td>
                    <td style="width: 35%">
                        &nbsp;<asp:TextBox ID="Txt_Saletype" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;">
                        店铺名称：</td>
                    <td colspan="3">
                        &nbsp;
                        <asp:TextBox ID="Txt_Shopname" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺地址</td>
                    <td colspan="3">
                        &nbsp;
                        <asp:TextBox ID="Txt_Address" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺类型：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="Txt_shoplevel" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        开店时间：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopOpenDate" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        省：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="Txt_Pro" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        地级市：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_City" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        区级市：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_town" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        店铺状态：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopState" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        联系人：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_LineMan" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        联系电话：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_LinkPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        负责人：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        负责人电话：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        Email：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_Email" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        传真号码：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_FixNumber" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        邮政编码：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_PostCode" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        POP安装：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="Txt_install" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        POP配送地址：</td>
                    <td colspan="3">
                        &nbsp;<asp:TextBox ID="Txt_PostAddress" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        一级客户：</td>
                    <td colspan="3">
                        &nbsp;
                        <asp:TextBox ID="Txt_Dealer" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="width: 15%">
                    </td>
                    <td>
                        &nbsp; <a href="#" onclick="history.back(-1)">返回上一页</a></td>
                </tr>
            </table>
            <br />
            <table class="table">
                <caption style="font-weight: bold">
                    POP信息列表：</caption>
                <tr>
                    <th>
                        POP编号</th>
                    <th>
                        POP位置</th>
                    <th>
                        材料</th>
                    <th>
                        POP高度</th>
                    <th>
                        POP宽度</th>
                    <th>
                        POP面积</th>
                     <th>
                        增补</th>
                    <th>
                        状态
                    </th>
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
                            <td align="center">
                                <%# Eval("POPHeight")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPWith")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPArea")%>
                            </td>
                              <td align="center"> 
                                <%#Eval("isdone").ToString() == "0" ? "<a href ='#' onclick=\"javascript:ShowDIV('30%','30%','700px','50px','500px','[我要增补]','AddOnePOPAddition.aspx?shopid=" + Eval("Shopid") + "&POPinfoID=" + Eval("ID") + "&POPID=" + POPID + "&prolineid=" + Eval("ProductLineID") + "')\">增补</a>" : "已增补"%>
                            </td>
                            <td>
                                <%#Eval("isdone").ToString() == "0" ? "未增补" : Eval("isdone").ToString() == "1" ? "<font color=red>本期已增补</font>" : "未知"%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table class="table" style="margin-top: 3px;">
                <tr>
                    <td align="center">
                        <input id="btn_ok" type="button" class ="qr0" value="确定提交" onclick ="window.location='POPAdditionResult.aspx?Shopid=<%=shopid %>'" />
                    
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
