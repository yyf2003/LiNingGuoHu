<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPLaunchTwo.aspx.cs" Inherits="WebUI_POPLanuch_POPLaunchTwo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>上传要替换的图片</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../js/jquery.min.js" type="text/javascript"></script>        
    <script language="javascript" type="text/javascript" src="JavaScript/launchone.js"></script>
    <script language="javascript" type="text/javascript">
    	//上传附件的总数
        var fileCount = 10;
    	//计数器
    	var fileNum = 1;
    	function AddFile()
    	{
    		if(fileNum < fileCount)
    		{
	    		var strFile = '<input id="SHWuJian" name="SHWuJian" type="file" class="txtwith" />';
	    		document.getElementById("divFile").insertAdjacentHTML("beforeEnd",strFile);
	    		fileNum ++;
    		}
    	}
    </script>
    <style type="text/css">
        .divstype{ width:100%; font-weight:bold; background-color:InactiveCaption;font-size:13px}
    </style>
</head>
<body>
    <form id="form1" runat="server"    method="post" enctype="multipart/form-data">
    <div>
    <div style="font-size:14px;color:Red">设置POP发起周期<< <a href="POPLaunchTwo.aspx?POPID=<%=POPID %>" style="color:Red">POP产品系列图片上传</a></div>
    <br />
    	<table  class="table">
			<tr>
				<td style=" width:16%">POP发起ID：</td>
				<td style=" width:50%">&nbsp;<%=POPID %></td>
                <td colspan="2">
                    </td>
			</tr>
			<tr>
				<td>涉及产品大类及系列：</td>
				<td colspan="3">
				<asp:Literal ID="L_proline" runat="server"></asp:Literal></td>
			</tr>
			<!--<tr>
				<td>涉及产品系列：</td>
				<td colspan="3">
					<div id="productline" class="divcss" style="display:none"><asp:Literal ID="Lit_productline" runat="server"></asp:Literal></div>
            	</td>
			</tr>-->
			<tr>
				<td>上传图样：</td>
				<td > <div id="divFile" style="width:80%; float:left"><input id="SHWuJian" name="SHWuJian" type="file" class="txtwith"/></div><input id="btnShowFile" name="btnShowFile" type="button" value="增加附件" style="float:left" onclick="AddFile()" />
                            <asp:FileUpload ID="FileUpload1" runat="server" style="display:none;" /></td>
                <td colspan="2" rowspan="15" valign="top"></td>
			</tr>
			<tr>
			    <td></td>
                <td style="color:Red">&nbsp;只能上传 jpg，gif 格式文件</td>
            </tr>
		</table>
       <!--<asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table class="table">
        <tr>
        <th style="width:80px">产品大类</th><th>产品系列</th><th>图片</th><th style="width:250px">描述</th><th></th>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td style="width:30px"><%#Eval("ProductTypeName").ToString()%></td>
        <td><%#Eval("ProductLineName").ToString()%></td>
        <td><img alt='<%#Eval("ProductLine")%>' src="<%#Eval("SmallImageUrl")%>"></td>
        <td><%#GetShopPro(Eval("ImageDesc").ToString())%></td>
        <td><a href="<%#Eval("ImageUrl") %>" target="_blank">查看原图</a></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
         </table>
        </FooterTemplate>
        </asp:Repeater>-->
    <div style="text-align:center; width:900px">
		<asp:Button id="Btn_next" runat="server"  OnClientClick="return checkimg();" CssClass="qr0" Text="保 存" OnClick="Btn_next_Click" />
				</div>
    </div>
<script language="javascript" type="text/javascript">

<!--
// 去除字符串的首尾的空格
function trim(str){
   return str.replace(/(^\s*)|(\s*$)/g, "");
}

function checkuploadfiles(filename)
{
    var array=new Array('jpg','gif');
    var stuts=false;
    if(filename.length>0)
    {
        var fileExtensions=trim(filename).split('.');
        var Extensions=fileExtensions[fileExtensions.length-1].toLowerCase();
        for(var i=0;i<array.length;i++)
        {
            if(array[i]==Extensions)
            {
                stuts=true;
                break;
            }
        }
    }
    else{
        return true;}

    return stuts;
}

function checkimg()
{
    if(document.getElementById('DDL_productline').value=="0")
    {
        alert("请选择需要上传的产品系列!");
        return false;
    }
    if(!checkuploadfiles(document.getElementById('SHWuJian').value))
    {
        alert('请检查上传文件，只能上传 jpg，gif 格式文件');
        return false;
    }
}
//-->
</script>
</form>
</body>
</html>
