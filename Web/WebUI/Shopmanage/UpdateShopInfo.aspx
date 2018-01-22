<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateShopInfo.aspx.cs" Inherits="WebUI_Shopmanage_UpdateShopInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>店铺信息</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
	<style type="text/css">
td{background-color:white;}
	    .style1
        {
            width: 15%;
            height: 34px;
        }
        .style2
        {
            width: 35%;
            height: 34px;
        }
        .style3
        {
            width: 20%;
            height: 34px;
        }
	</style>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" charset="utf-8" type="text/javascript" src="../../js/jquery.min.js" ></script>
<script language="javascript" charset="utf-8" type="text/javascript" src="../../js/calendar.js" ></script>
<script language="javascript" charset="utf-8" type="text/javascript" src="../../js/Validate.js"></script>
<script language="javascript" charset="utf-8" type="text/javascript" src="../../js/GetFxname.js"></script>

<script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
<script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
<script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
<script language="javascript" type="text/javascript" src="../../js/GetTownByCity.js"></script>
<script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
<script language="javascript" type="text/javascript">
function CheckData()
{   
//alert('a'):
//    //add by mhj 2012.5.3 
//    if($("#DDL_ShopState").val()=="0")
//    {  
//        return true;
//    }alert('85'):

//    if($("#SaleTypeID").val()=="0")
//     {  alert("请选择零售分类!");
//        $("#SaleTypeID").focus();
//        return false;
//    }

//    if($("#txt_samplename").val()=="")
//    {
//        alert("请填写店铺简称！");
//        $("#txt_samplename").focus();
//        return false;
//    }
//   if($("#DDL_Shoptype").val()=="0")
//    {
//        alert("请选择店铺类型！");
//        $("#DDL_Shoptype").focus();
//        return false;
//    }
//    if($("#DDL_shopLevel").val()=="0")
//    {
//        alert("请选择店铺级别！");
//        $("#DDL_shopLevel").focus();
//        return false;
//    }
//   if($("#DDL_shopOwnerShip").val()=="0")
//    {
//        alert("请选择店铺产权关系！");
//        $("#DDL_shopOwnerShip").focus();
//        return false;
//    }   
//   //modify by mhj 2012.5.3 
//   //if((!istell($("#Txt_ShopMasterPhone").val())) && (!isMob($("#Txt_LinkPhone").val()))) 
//   if((!istell($("#Txt_ShopMasterPhone").val())) && (!isMob($("#Txt_ShopMasterPhone").val()))) 
//    { 
//      alert("请正确填写店铺负责人联系电话 例如：13812345678");
//      $("#Txt_ShopMasterPhone").focus();
//	  return false;
//    }
//   if($("#DDL_install").val()=="-1")
//    {
//        alert("请选择供应商是否支持安装！");
//        $("#DDL_install").focus();
//        return false;
//    }
//   if($("#ddl_dealer").val()=="0")
//    {
//        alert("请选择店铺的一级客户！");
//        $("#ddl_dealer").focus();
//        return false;
//    }
//   if(($("#DDL_fx").val()=="0") || ($("#DDL_fx").val()==""))
//    {
//        alert('请选择店铺的直属客户！');
//        $("#DDL_fx").focus();
//        return false;
//    } 
//  if($("#Txt_LinkPhone").val()!="")
//    {
//      if((!isMob($("#Txt_LinkPhone").val())) && (!istell($("#Txt_LinkPhone").val())))
//       {
//          alert("请正确填写联系号码 格式 13812345678 或 010-88888888");
//          $("#Txt_LinkPhone").focus();
//          return false;
//       }
//     }

//    if($("#Txt_Email").val()!="")
//    {
//      if(!isemail($("#Txt_Email").val()))
//      {
//         alert("请正确填写Email信息");
//         $("#Txt_Email").focus();
//         return false;
//      }
//    }
//     if((!isMob($("#txt_shopphone").val())) && (!istell($("#txt_shopphone").val())))
//      {
//        alert("请正确填写店铺联系号码 格式 13812345678 或 010-88888888");
//        $("#txt_shopphone").focus();
//        return false;
//      }
//    if(!isnumber($("#Txt_Shoparea").val()))
//    {
//      alert("请正确填写店铺面积");
//      $("#Txt_Shoparea").focus();
//      return false;
//    }
//    if($("#DDL_KHSF").val()=="0")
//    {
//        alert("请选择客户身份！");
//        $("#DDL_KHSF").focus();
//        return false;
//    } 
    
    //add by mhj 2013.03.25
    if($("#DDL_DepartMent").val()=="0")
    {
        alert("请选择部门名称！");
        $("#DDL_DepartMent").focus();
        return false;
    } 
    if($("#DDL_Area").val()=="0")
    {
        alert("请选择区域名称！");
        $("#DDL_Area").focus();
        return false;
    } 
    if($("#DDL_Province").val()=="0")
    {
        alert("请选择省份！");
        $("#DDL_Province").focus();
        return false;
    } 
    if($("#DDL_city").val()=="0")
    {
        alert("请选择地级城市！");
        $("#DDL_city").focus();
        return false;
    } 
//    if($("#DDL_town").val()=="0")
//    {
//        alert("请选择区县级城市名称！");
//        $("#DDL_town").focus();
//        return false;
//    } 
    alert('ok'):
    return true;
}


    //add by mhj 20130322
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
	$(function(){
		$("table.datalist tr:nth-child(odd)").addClass("altrow");
	});
    
</script>

</head>
<body style="font-size:12px; background-position:center bottom; background-repeat:no-repeat;border-width: 1px; border-color: #ffccff">
    <form id="form1" runat="server" >
    <div style="width:90%">
       <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="ShopInfoList.aspx" title="店铺信息" style="color: #c86000;">店铺信息</a>  &gt;&gt; 修改店铺信息</div>
       
       <br/>
    	<table class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td style="text-align:left" class="style1">店铺编号：</td>
				<td class="style2">
				<asp:TextBox id="PosID" onblur="checkposcode(this.value)" runat="server" CssClass="txtwith"></asp:TextBox>
				&nbsp;</td>
				<td style="text-align:left" class="style3">
                    店铺零售属性：</td>
				<td class="style2">
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
                <td  style="height: 30px">
                    <asp:TextBox ID="txt_samplename" runat="server" CssClass="txtwith"></asp:TextBox>
                    &nbsp;&nbsp;</td>
                <td style=" text-align:left">店铺状态：</td>
				<td><asp:DropDownList ID="DDL_ShopState" runat="server">
                    </asp:DropDownList></td>
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
		
		   <%--add by mhj 2013.03.22--%>	
		    <tr>
			<td>部门名称：</td><td><asp:DropDownList ID="DDL_DepartMent" CssClass="txtwith" runat="server" onchange="GetAreaName(this.value)" >
                <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
            </asp:DropDownList></td>
			<td>区域名称：</td><td><asp:DropDownList ID="DDL_Area" CssClass="txtwith" runat="server" onchange="GetprovinceList()">
                <asp:ListItem Value="0">请选择区域名称</asp:ListItem>
            </asp:DropDownList></td>
			</tr>
			<tr>
				<td style="width:15%;text-align:left">省：</td>
				<td style="width:30%;"><asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                    <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width:15%;text-align:left">地级城市：</td>
				<td>
				    <asp:DropDownList ID="DDL_city"  CssClass="txtwith" Width="200px"  onchange="GetTownList()" runat="server">
                       <asp:ListItem Value="0">请选择市</asp:ListItem>
                    </asp:DropDownList>
                    
                    
                </td>
			</tr>
			<tr>
			<td>区县级城市名称：</td><td>
			
			<asp:DropDownList ID="DDL_town"  CssClass="txtwith" Width="200px" runat="server">
                    <asp:ListItem Value="0">请选择区级市</asp:ListItem>
                </asp:DropDownList>
            
            </td>
			
			</tr>
			<%--end--%>	
		
			    
			<tr>
			    <td>地市级城市级别：</td>
			    <td>
			       <asp:DropDownList ID="DDL_Citylevel" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择地市级城市级别</asp:ListItem>
                    <asp:ListItem Value="1">超大</asp:ListItem>
                    <asp:ListItem Value="2">一线</asp:ListItem>
                    <asp:ListItem Value="3">二线</asp:ListItem>
                    <asp:ListItem Value="4">三线</asp:ListItem>
                    <asp:ListItem Value="5">三线一下</asp:ListItem>
                  </asp:DropDownList>
                </td>
                <td>区县级城市级别：</td>
                <td>
                   <asp:DropDownList ID="DDL_TownLevel" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择区县级城市级别</asp:ListItem>
                    <asp:ListItem Value="1">超大</asp:ListItem>
                    <asp:ListItem Value="2">一线</asp:ListItem>
                    <asp:ListItem Value="3">二线</asp:ListItem>
                    <asp:ListItem Value="4">三线</asp:ListItem>
                    <asp:ListItem Value="5">三线一下</asp:ListItem>
                   </asp:DropDownList>
               </td>
			</tr>
			
			<tr>
			 <td>
                 上级客户集团编号：</td> <td>
                 <asp:TextBox ID="txt_customergroupID" runat="server" CssClass="txtwith"></asp:TextBox></td> <td>
                     上级客户级别：</td> <td><asp:TextBox ID="txt_customergroupname" runat="server" CssClass="txtwith"></asp:TextBox></td>
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
                    店长：</td>
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
                    <asp:TextBox ID="Txt_VMMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    李宁省区VM负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_VMMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
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
				  <td>
                      区域名称：</td><td>
                      <asp:DropDownList ID="DDL_Area2" runat="server" CssClass="DDlstyle">
                          <asp:ListItem Value="0">请选择区域</asp:ListItem>
                          <asp:ListItem Value="-1">全国</asp:ListItem>
                      </asp:DropDownList></td><td>
                          客户身份：</td><td><asp:DropDownList ID="DDL_KHSF"  CssClass="txtwith" runat="server">
                          <asp:ListItem Selected="True" Value="0">请选择客户身份</asp:ListItem>
                          <asp:ListItem Value="分销商">分销商</asp:ListItem>
                          <asp:ListItem Value="经销商">经销商</asp:ListItem>
                          <asp:ListItem Value="子公司">子公司</asp:ListItem>                          
                      </asp:DropDownList></td>
				</tr>
			<tr>
				<td colspan="4" style=" height:50px; text-align:center;">  <%--OnClick="Btn_Save_Click"   OnClientClick="return CheckData();"--%>
					<asp:Button id="Btn_Save" runat="server" OnClientClick="return checkInfo();" Text="保 存"  OnClick="Btn_Save_Click" CssClass="qr0" />
					
                    </td>
			</tr>
		</table>
                          <asp:HiddenField ID="HF_OldLinkman" runat="server" />
                          <asp:HiddenField ID="h_areaid" runat="server" />
                          <asp:HiddenField ID="h_provinceid" runat="server" />
                          <asp:HiddenField ID="h_cityid" runat="server" />
                          <asp:HiddenField ID="h_townid" runat="server" />
    </div>
    </form>
    </body>
</html>
<script type="text/javascript">
function checkInfo()
{ 
    //add by mhj 2012.5.3 
    if($("#DDL_ShopState").val()=="0")
    {  
        return true;
    }

    if($("#SaleTypeID").val()=="0")
     {  alert("请选择零售分类!");
        $("#SaleTypeID").focus();
        return false;
    }

    if($("#txt_samplename").val()=="")
    {
        alert("请填写店铺简称！");
        $("#txt_samplename").focus();
        return false;
    }
   if($("#DDL_Shoptype").val()=="0")
    {
        alert("请选择店铺类型！");
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
//   //modify by mhj 2012.5.3 
//   //if((!istell($("#Txt_ShopMasterPhone").val())) && (!isMob($("#Txt_LinkPhone").val()))) 
////   if((!istell($("#Txt_ShopMasterPhone").val())) && (!isMob($("#Txt_ShopMasterPhone").val()))) 
////    { 
////      alert("请正确填写店铺负责人联系电话 例如：13812345678");
////      $("#Txt_ShopMasterPhone").focus();
////	  return false;
////    } alert("85");
////   if($("#DDL_install").val()=="-1")
////    {
////        alert("请选择供应商是否支持安装！");
////        $("#DDL_install").focus();
////        return false;
////    }
////   if($("#ddl_dealer").val()=="0")
////    {
////        alert("请选择店铺的一级客户！");
////        $("#ddl_dealer").focus();
////        return false;
////    }
////   if(($("#DDL_fx").val()=="0") || ($("#DDL_fx").val()==""))
////    {
////        alert('请选择店铺的直属客户！');
////        $("#DDL_fx").focus();
////        return false;
////    } 
////  if($("#Txt_LinkPhone").val()!="")
////    {
////      if((!isMob($("#Txt_LinkPhone").val())) && (!istell($("#Txt_LinkPhone").val())))
////       {
////          alert("请正确填写联系号码 格式 13812345678 或 010-88888888");
////          $("#Txt_LinkPhone").focus();
////          return false;
////       }
////     }
////    if($("#Txt_ShopOpenDate").val()!="")
////    {
////       if(!isdate($("#Txt_ShopOpenDate").val()))
////       {
////         alert("请正确填写开店日期");
////         $("#Txt_ShopOpenDate").focus();
////         return false;
////       }
////    }
////    if($("#Txt_Email").val()!="")
////    {
////      if(!isemail($("#Txt_Email").val()))
////      {
////         alert("请正确填写Email信息");
////         $("#Txt_Email").focus();
////         return false;
////      }
////    }
////     if((!isMob($("#txt_shopphone").val())) && (!istell($("#txt_shopphone").val())))
////      {
////        alert("请正确填写店铺联系号码 格式 13812345678 或 010-88888888");
////        $("#txt_shopphone").focus();
////        return false;
////      }
////    if(!isnumber($("#Txt_Shoparea").val()))
////    {
////      alert("请正确填写店铺面积");
////      $("#Txt_Shoparea").focus();
////      return false;
////    }
////    if($("#DDL_KHSF").val()=="0")
////    {
////        alert("请选择客户身份！");
////        $("#DDL_KHSF").focus();
////        return false;
////    } 
    
    //add by mhj 2013.03.25
    if($("#DDL_DepartMent").val()=="0")
    {
        alert("请选择部门名称！");
        $("#DDL_DepartMent").focus();
        return false;
    } 
    if($("#DDL_Area").val()=="0")
    {
        alert("请选择区域名称！");
        $("#DDL_Area").focus();
        return false;
    } 
    if($("#DDL_Province").val()=="0")
    {
        alert("请选择省份！");
        $("#DDL_Province").focus();
        return false;
    } 
    if($("#DDL_city").val()=="0")
    {
        alert("请选择地级城市！");
        $("#DDL_city").focus();
        return false;
    }        
//    if($("#DDL_town").val()=="0")
//    {
//        alert("请选择区县级城市名称！");
//        $("#DDL_town").focus();
//        return false;
//    } 
    $("#h_areaid").val($("#DDL_Area").val())
    $("#h_provinceid").val($("#DDL_Province").val())
    $("#h_cityid").val($("#DDL_city").val())
    $("#h_townid").val($("#DDL_town").val())
    
    return confirm("您确定要更新吗？");
}
</script>