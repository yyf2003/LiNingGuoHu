<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="WebUI_Shopmanage_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
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
<body>
    <form id="form1" runat="server">
    <table>
             <tr>
				<td>部门名称：</td>
				<td>
                    <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" Width="200px" onchange="GetAreaName(this.value)">
                    <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    <asp:ListItem Value="东区">东区</asp:ListItem>
                    <asp:ListItem Value="南区">南区</asp:ListItem>
                    <asp:ListItem Value="北区">北区</asp:ListItem> 
                    <asp:ListItem Value="西区">西区</asp:ListItem>
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
				<td>
				    <asp:DropDownList ID="DDL_city"  CssClass="txtwith" Width="200px"  onchange="GetTownList()" runat="server">
                       <asp:ListItem Value="0">请选择市</asp:ListItem>
                    </asp:DropDownList>
                    
                    </td>
			</tr>
			<tr>
				<td style=" text-align:left">
                    区县级城市名称：</td>
				<td >
				<asp:DropDownList ID="DDL_town"  CssClass="txtwith" Width="200px" runat="server">
                    <asp:ListItem Value="0">请选择区级市</asp:ListItem>
                </asp:DropDownList>
                
                </td>
				
			</tr>
    </table>
    </form>
</body>
</html>
