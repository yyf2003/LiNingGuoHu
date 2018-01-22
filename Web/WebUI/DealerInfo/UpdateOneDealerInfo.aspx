<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateOneDealerInfo.aspx.cs"
    Inherits="WebUI_DealerInfo_UpdateOneDealerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>更新一级客户信息 </title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <!-- Can't miss  begin -->
    <script type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" src="../../js/common.js"></script>
    <!--  end-->
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript">
    
		function GetcityList()
		{
			var pro=$("#DDL_Province").val();
			GetCityname(pro);
		}
		
       function CheckAdd()
       {
            var deakerid =$("#txt_DealerID").val();
            if(deakerid=="")
            {
                $.prompt("一级客户编号不能为空!",{callback:getdeakerid});
             	return false; 
            }
           	var txt_DealerName =$("#txt_DealerName").val();
            if(txt_DealerName=="")
            {
                $.prompt("一级客户名称不能为空!",{callback:gettxt_DealerName});
             	return false; 
            }
            var DDL_Area =document.getElementById ("DDL_Area");
            var areatxt=DDL_Area.options[DDL_Area.selectedIndex].value;
            if(areatxt=="0")
            {
                $.prompt("请选择一级客户区域!",{callback:gettxt_DDL_Area});
             	return false; 
            }  
            var DDL_Province =document.getElementById ("DDL_Province");
            var provtxt=DDL_Province.options[DDL_Province.selectedIndex].value;
            if(provtxt=="0")
            {
                $.prompt("请选择一级客户省份!",{callback:getDDL_Province});
             	return false; 
            }
            var DDL_city =document.getElementById ("DDL_city");
            var citytxt=DDL_city.options[DDL_city.selectedIndex].value;
            if(citytxt=="0")
            {
                $.prompt("请选择一级客户市区!",{callback:getDDL_city});
             	return false; 
            }  
            
            var txt_Contactor =$("#txt_Contactor").val();
            if(txt_Contactor=="")
            {
                $.prompt("一级客户联系人不能为空!",{callback:gettxt_Contactor});
             	return false; 
            }
            var txt_UserMobile =$("#txt_UserMobile").val();
            if(txt_UserMobile=="")
            {
                $.prompt("一级客户联系人电话不能为空!",{callback:gettxt_UserMobile});
             	return false; 
            }
            var txt_Address =$("#txt_Address").val();
            if(txt_Address=="")
            {
                $.prompt("一级客户联系人地址不能为空!",{callback:gettxt_Address});
             return false; 
            }
            var txt_PostAddress =$("#txt_PostAddress").val();
            if(txt_PostAddress=="")
            {
                $.prompt("一级客户送货地址不能为空!",{callback:gettxt_PostAddress});
             	return false; 
            }
//            var txt_Dealerchannel =$("#txt_Dealerchannel").val();
//            if(txt_Dealerchannel=="")
//            {
//                $.prompt("一级客户渠道信息不能为空!",{callback:gettxt_Dealerchannel});
//             	return false; 
//            }
       } 
       
       function getdeakerid() {$("#txt_DealerID").focus();}
       function gettxt_DealerName(){$("#txt_DealerName").focus();}
       function gettxt_DDL_Area(){$("#DDL_Area").focus();}
       function getDDL_Province(){$("#DDL_Province").focus();}
       function getDDL_city(){$("#DDL_city").focus();}
       function gettxt_Contactor(){$("#txt_Contactor").focus();}
       function gettxt_UserMobile(){$("#txt_UserMobile").focus();}
       function gettxt_Address(){$("#txt_Address").focus();}
       function gettxt_PostAddress(){$("#txt_PostAddress").focus();}
      
       function GetCity()
       {
	       var abc =<%#CityID %>;
	       var ab =$("#DDL_city");
	       if(ab!=null)
	       {
		       alert("存在");
		       $("DDL_city").value=abc;
	       }
	       else
	       		alert("不存在");
       } 
    </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                <a href="DealerList.aspx" title="一级客户管理" style="color: #c86000;">一级客户管理</a> &gt;&gt;
                更新一级客户信息</div>
            <table class="table" style="margin-top: 20px; margin-left: 20px">
                <tr>
                    <td style="width: 15%">
                        一级客户编号</td>
                    <td style="width: 35%; text-align: left">
                        <asp:TextBox ID="txt_DealerID" runat="server" CssClass="txtwith" Text='<%#DealerID %>'></asp:TextBox></td>
                    <td style="width: 15%">
                        一级客户名称</td>
                    <td style="text-align: left; width: 35%">
                        <asp:TextBox ID="txt_DealerName" runat="server" CssClass="txtwith" Text='<%#DealerName %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        所在区域：</td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_Area" runat="server">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                       所在省市：</td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_Province" onchange="GetcityList()" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        所在市区：</td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择市</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        联系人：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_Contactor" runat="server" CssClass="txtwith" Text='<%#Contactor %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        联系电话：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_UserMobile" runat="server" CssClass="txtwith" Text='<%#ContactorPhone %>'></asp:TextBox></td>
                    <td>
                        联系地址：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_Address" runat="server" CssClass="txtwith" Text='<%#Address %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        邮政地址：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_PostAddress" runat="server" CssClass="txtwith" Text='<%#PostAddress %>'></asp:TextBox></td>
                    <td>
                        </td>
                    <td align="left">
                        <asp:TextBox ID="txt_Dealerchannel" runat="server" CssClass="txtwith" Visible="false"  Text='<%#DealerChannel %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <asp:Button ID="Button1" runat="server" Text="更 新" OnClick="Button1_Click" OnClientClick="return CheckAdd();"
                            CssClass="qr0" />&nbsp;&nbsp;
                        <input id="Button2" type="button" value="返回" class="qr0" onclick="javascript:if(window.history.length==0) window.close();else window.history.back();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
