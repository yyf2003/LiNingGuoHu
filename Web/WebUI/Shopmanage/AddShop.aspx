﻿<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeFile="AddShop.aspx.cs"   Inherits="WebUI_Shopmanage_AddShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>店铺信息</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />

<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
<script language="javascript" type="text/javascript" src="../../js/calendar.js" ></script>
<script language="javascript" type="text/javascript" src="../../js/Validate.js"></script>
<script language="javascript" type="text/javascript"  src="../../js/GetAreaBydept.js"></script>
<script language="javascript" type="text/javascript"  src="../../js/GetProvinceName.js"></script>
<script language="javascript" type="text/javascript"  src="../../js/GetCityByProvince.js"></script>
<script language="javascript" type="text/javascript"  src="../../js/GetTownByCity.js"></script>
<script language="javascript" type="text/javascript" src="javascript/checkposid.js"></script>
<script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
<script language="javascript" type="text/javascript" src="../../js/GetVmMasterByAreaID.js"></script>
<script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
<script language="javascript" type="text/javascript">
function CheckData()
{
    if($("#PosID").val()=='')
    {
        alert('请填写店铺编号！');
        $("#PosID").focus();
        return false;
    }
    if($("#SaleTypeID").val()=='0')
     {  alert('请选择零售分类!');
        $("#SaleTypeID").focus();
        return false;
    }
    if($("#Txt_Shopname").val()=='')
    {
      alert('请填写店铺名称！');
      $("#Txt_Shopname").focus();
      return false;
    }
    if($("#txt_samplename").val()=="")
    {
    alert('请填写店铺简称！');
    $("#Txt_Address").focus();
    return false;
    }
   if($("#DDL_Shoptype").val()=="0")
    {
    alert('请选择店铺类型！');
    $("#DDL_Shoptype").focus();
    return false;
    }
   if($("#DDL_shopLevel").val()=="0")
    {
        alert("请选择店铺级别！");
        $("#DDL_shopLevel").focus();
        return false;
    }
   if($("#DDL_shopOwnerShip").val()=="0")
    {
        alert("请选择店铺产权关系！");
        $("#DDL_shopOwnerShip").focus();
        return false;
    }
   if($("#DDL_Province").val()=="0")
    {
    alert('请选择店铺所在省！');
    $("#DDL_Province").focus();
    return false;
    }
   if($("#DDL_city").val()=="0" || $("#DDL_city").val()=="")
    {
    alert('请选择店铺所在市！');
    $("#DDL_city").focus();
    return false;
    }
//   if($("#DDL_town").val()=="0" || $("#DDL_town").val()=="")
//    {
//    alert('请选择店铺所在区县级！');
//    $("#DDL_town").focus();
//    return false;
//    }
    if($("#DDL_AreaCityLevel").val()=="0" || $("#DDL_AreaCityLevel").val()=="")
    {
    alert('请选择区县级城市级别_市场定义！');
    $("#DDL_AreaCityLevel").focus();
    return false;
    }
    if($("#DDL_TownCityLevel").val()=="0" || $("#DDL_TownCityLevel").val()=="")
    {
    alert('请选择地市级城市级别_市场定义！');
    $("#DDL_TownCityLevel").focus();
    return false;
    }
    
   if($("#Txt_LinkPhone").val()!="")
    {
      if((!isMob($("#Txt_LinkPhone").val())) && (!istell($("#Txt_LinkPhone").val())))
      {
        alert("请正确填写联系号码 格式 13812345678 或 010-88888888");
        $("#Txt_LinkPhone").focus();
        return false;
      }
    }
    if($("#Txt_Shopmaster").val()=="")
    {
      alert('请正确填写店铺负责人');
      $("#Txt_Shopmaster").focus();
	  return false;
    }
     if(!isMob($("#Txt_ShopMasterPhone").val()))
    {
      alert('请正确填写店铺负责人联系电话 例如：13812345678');
      $("#Txt_ShopMasterPhone").focus();
	  return false;
    }

      if($("#DDL_install").val()=="-1")
    {
    alert('请选择供应商是否支持安装！');
    $("#DDL_install").focus();
    return false;
    }
   if($("#ddl_dealer").val()=="0")
    {
    alert('请选择店铺的一级客户！');
    $("#ddl_dealer").focus();
    return false;
    }
    if(($("#DDL_fx").val()=="0") || ($("#DDL_fx").val()==""))
    {
    alert('请选择店铺的直属客户！');
    $("#DDL_fx").focus();
    return false;
    }
//    if($("#Txt_ShopOpenDate").val()!="")
//    {
//       if(!isdate($("#Txt_ShopOpenDate").val()))
//       {
//         alert('请正确填写开店日期');
//         $("#Txt_ShopOpenDate").focus();
//         return false;
//       }
//    }
    if($("#Txt_Email").val()!="")
    {
      if(!isemail($("#Txt_Email").val()))
      {
         alert("请正确填写店长Email信息");
         $("#Txt_Email").focus();
         return false;
      }
    }
    
    if((!isMob($("#txt_shopphone").val())) && (!istell($("#txt_shopphone").val())))
      {
        alert("请正确填写店铺固定电话号码 格式 13812345678 或 010-88888888");
        $("#txt_shopphone").focus();
        return false;
      }
//    if(trim($("#Txt_Shoparea").val())!="")
//    {
      if(!isnumber(trim($("#Txt_Shoparea").val())))
      {
        alert("请正确填写店铺营业面积，只能为数字");
        $("#Txt_Shoparea").focus();
        return false;
      }
      if($("#DDL_Area").val()=="0")
      {
         alert("请正确选择店铺所在省区");
        $("#DDL_Area").focus();
        return false;
      }
     if($("#DDL_KHSF").val()=="0")
      {
         alert("请正确选择客户身份");
        $("#DDL_KHSF").focus();
        return false;
      }
//    }
    return true;
}

function GetcityList()
{
var pro=$("#DDL_Province").val();
   GetCityname(pro);
}
function GetTownList()
{
  var cityid=$("#DDL_city").val();
  GetTownname(cityid);
}
</script>

</head>
<body style="font-size:12px; background-position:center bottom; background-repeat:no-repeat;border-width: 1px; border-color: #ffccff">
    <form id="form1" runat="server">
    <div style="width:90%">
    	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="ShopInfoList.aspx" title="店铺信息" style="color: #c86000;">店铺信息</a>  &gt;&gt; 添加店铺信息</div>
    	<table class="table" style="margin-top:20px; margin-left:20px"  >
			<tr>
				<td style="width: 15%; text-align:left">店铺编号：</td>
				<td style="width:35%">
				<asp:TextBox id="PosID" onblur="checkposcode(this.value)" runat="server" CssClass="txtwith"></asp:TextBox>
				&nbsp;</td>
				<td style="width: 20%; text-align:left">
                    店铺零售属性：</td>
				<td  style="width:35%">
				<asp:DropDownList id="SaleTypeID" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择零售分类</asp:ListItem>
				</asp:DropDownList>
				&nbsp;</td>
			</tr>
            <tr>
                <td style=" height: 30px; text-align:left">店铺名称：</td>
				<td colspan="3" style="height: 30px">
				<asp:TextBox id="Txt_Shopname"   CssClass="txtwith" runat="server"></asp:TextBox></td>
            </tr>
			<tr>
				<td style=" height: 30px; text-align:left">
                    店铺简称：</td>
                <td colspan="3" style="height: 30px">
                    <asp:TextBox ID="txt_samplename" runat="server" CssClass="txtwith"></asp:TextBox>
                    &nbsp;&nbsp;</td>
			</tr>
			<tr>
				<td style=" text-align:left">店铺级别：</td>
				<td ><asp:DropDownList id="DDL_shopLevel" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择店铺级别</asp:ListItem>
				</asp:DropDownList></td>
				<td style=" text-align:left">
                    店铺产权关系：</td>
				<td><asp:DropDownList ID="DDL_shopOwnerShip"  CssClass="txtwith" runat="server">
                    <asp:ListItem Selected="True" Value="0">请选择店铺产权关系</asp:ListItem>
                    <asp:ListItem Value="直营店">直营店</asp:ListItem>
                    <asp:ListItem Value="分销店">分销店</asp:ListItem>
                    <asp:ListItem Value="经销店">经销店</asp:ListItem>
                </asp:DropDownList>&nbsp;</td>
			</tr>
			<tr>
				<td style=" text-align:left">店铺类型：</td>
				<td ><asp:DropDownList id="DDL_Shoptype" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择店铺类型</asp:ListItem>
                </asp:DropDownList></td>
				<td style=" text-align:left">
                    店铺形象属性：</td>
				<td><asp:DropDownList id="DDL_shopVI" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择店铺V/I形象</asp:ListItem>
                </asp:DropDownList></td>
			</tr>
			<tr>
				<td>部门名称：</td>
				<td>
                    <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" Width="200px" onchange="GetAreaName(this.value)">
                    <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    <asp:ListItem Value="西南区">西南区</asp:ListItem>
                    <asp:ListItem Value="西北区">西北区</asp:ListItem>
                    <asp:ListItem Value="华北区">华北区</asp:ListItem> 
                    <asp:ListItem Value="华东区">华东区</asp:ListItem>
                    <asp:ListItem Value="华中区">华中区</asp:ListItem>
                    <asp:ListItem Value="华南区">华南区</asp:ListItem>
                    <asp:ListItem Value="东北区">东北区</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>区域名称：</td>
                <td>
					<asp:DropDownList ID="DDL_Area" name="DDL_Area" runat="server"  CssClass="DDlstyle" Width="200px" onchange="GetProvincename(this.value);GetVmMasterByAreaID(this.value);">
					  <asp:ListItem Value="0">请选择区域</asp:ListItem>
					</asp:DropDownList>
                </td>
			</tr>
			<tr>
				<td style=" text-align:left">
                    省名称：</td>
				<td ><asp:DropDownList ID="DDL_Province"  CssClass="txtwith" Width="200px" onchange="GetcityList()" runat="server">
                    <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList></td>
				<td style=" text-align:left">
                    地级城市名称：</td>
				<td><asp:DropDownList ID="DDL_city"  CssClass="txtwith" Width="200px"  onchange="GetTownList()" runat="server">
                    <asp:ListItem Value="0">请选择市</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td style=" text-align:left">
                    区县级城市名称：</td>
				<td ><asp:DropDownList ID="DDL_town"  CssClass="txtwith" Width="200px" runat="server">
                    <asp:ListItem Value="0">请选择区级市</asp:ListItem>
                </asp:DropDownList></td>
				<td style=" text-align:left">店铺状态：</td>
				<td><asp:DropDownList ID="DDL_ShopState" runat="server" Enabled="false">
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td style=" text-align:left">区县级城市级别_市场定义：</td>
				<td >
					<asp:DropDownList ID="DDL_AreaCityLevel"  CssClass="txtwith" Width="200px" runat="server">
                    </asp:DropDownList>
                </td>
				<td style=" text-align:left">地市级城市级别_市场定义：</td>
				<td>
					<asp:DropDownList ID="DDL_TownCityLevel"  CssClass="txtwith" Width="200px" runat="server">
                    </asp:DropDownList>
                </td>
			</tr>
			<tr>
			 <td>
                 上级客户集团编号：</td> <td>
                 <asp:TextBox ID="txt_customergroupID" runat="server" CssClass="txtwith"   onkeyup='showGs(event,"../GetBaseInfo/Base_CustomerInfo.aspx",txt_customergroupID,txt_customergroupname,"Cusdiv")' ></asp:TextBox></td> <td>
                     上级客户级别：</td> <td><asp:TextBox ID="txt_customergroupname" runat="server" CssClass="txtwith"></asp:TextBox><br /><div id="Cusdiv" class="ts"></div></td>
			</tr>
			<tr>
			<td>
                一级客户：</td><td><asp:DropDownList ID="ddl_dealer" onchange="GetFxlist()" runat="server">
                    <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                    </asp:DropDownList></td><td>
                        直属客户：</td>
                        <td><asp:DropDownList ID="DDL_fx" runat="server">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                        </asp:DropDownList></td>
			</tr>

<tr>
				<td style=" text-align:left">
                    店长姓名：</td>
				<td ><asp:TextBox ID="Txt_LineMan"  CssClass="txtwith" runat="server"></asp:TextBox></td>
				<td style=" text-align:left">
                    店长移动电话：</td>
				<td><asp:TextBox ID="Txt_LinkPhone"  CssClass="txtwith" runat="server"></asp:TextBox></td>
			</tr>
			
<tr>
				<td style=" text-align:left">
                    店长email：</td>
				<td ><asp:TextBox ID="Txt_Email"  CssClass="txtwith" runat="server"></asp:TextBox></td>
				<td style=" text-align:left">
                    店铺传真号码：</td>
				<td><asp:TextBox ID="Txt_FixNumber"  CssClass="txtwith" runat="server"></asp:TextBox></td>
			</tr>

            <tr>
                <td style=" text-align:left">
                    店铺零售负责人：</td>
				<td ><asp:TextBox ID="Txt_Shopmaster"  CssClass="txtwith" runat="server"></asp:TextBox></td>
				<td style=" text-align:left">
                    零售负责人电话：</td>
				<td><asp:TextBox ID="Txt_ShopMasterPhone"  CssClass="txtwith" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style=" text-align:left">
                    李宁省区VM负责人：</td>
                <td >
                    <asp:TextBox ID="Txt_VMMaster" name="Txt_VMMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    李宁省区VM负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_VMMasterPhone" name="Txt_VMMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
			<tr>
				<td style=" text-align:left">
                    李宁DSR负责人：</td>
                <td >
                    <asp:TextBox ID="Txt_DSRMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    李宁DSR负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_DSRMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
<tr>
				<td style=" text-align:left; height: 34px;">
                    店铺邮编：</td>
				<td style="height: 34px" ><asp:TextBox ID="Txt_PostCode"  CssClass="txtwith" runat="server"></asp:TextBox></td>
				<td style=" text-align:left; height: 34px;">
                    是否李宁公司统一支持安装：</td>
				<td style="height: 34px"><asp:DropDownList ID="DDL_install"  CssClass="txtwith" runat="server">
                    <asp:ListItem Value="-1">请选择供应商是否支持安装</asp:ListItem>
                    <asp:ListItem Value="1">支持</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">不支持</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
<tr>
				<td style=" text-align:left">
                    店铺邮政地址：</td>
				<td colspan="3"><asp:TextBox ID="Txt_PostAddress"  CssClass="txtwith" runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td style=" text-align:left">
                    店铺固定电话：</td>
				<td>
                    <asp:TextBox ID="txt_shopphone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    营业面积：</td>
				<td>
                    <asp:TextBox ID="Txt_Shoparea" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox>㎡</td>

				</tr>
				
				<tr>
				  <td>客户身份：</td><td><asp:DropDownList ID="DDL_KHSF"  CssClass="txtwith" runat="server">
                          <asp:ListItem Selected="True" Value="0">请选择客户身份</asp:ListItem>
                          <asp:ListItem Value="子公司">子公司</asp:ListItem>
                          <asp:ListItem Value="经销商">经销商</asp:ListItem>
                          <asp:ListItem Value="分销商">分销商</asp:ListItem>
                      </asp:DropDownList></td><td></td><td></td>
				</tr>
				<tr>
				<td colspan="4" style="text-align:center; height:50px;">
				
				<asp:Button id="Btn_Save" runat="server" Text="保 存" OnClick="Btn_Save_Click" OnClientClick="return CheckData();"  CssClass="qr0" />
				<asp:Button id="btn_clear" runat="server"  Text="清 空"  CssClass="qr0" style="margin-left:100px;"/>
				</td>
				</tr>
		</table>
    </div>
    </form>
    </body>
</html>
