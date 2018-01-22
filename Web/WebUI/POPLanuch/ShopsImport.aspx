<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopsImport.aspx.cs" Inherits="WebUI_POPLanuch_ShopsImport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>POP发起周期设定</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/ProgressBar.css" rel="stylesheet" type="text/css" />
         <link href="../../CSS/ModelStyle.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
<script language="javascript" type="text/javascript" src="../../js/calendar.js" ></script>
<script language="javascript" type="text/javascript" src="JavaScript/launchone.js"></script>
<script language="javascript" type="text/javascript" src="../../js/Validate.js" ></script>
<style type="text/css">
  .divstype{ width:100%; font-weight:bold; background-color:InactiveCaption;font-size:13px}
</style>
<script type="text/javascript">
    JQ = $; //rename $ function 
</script> 

</head>
<body>
<div id="root" style="left: 180px; top: 150px; display: none;" onselectstart="javascript:return false;">
        <div id="handle">
            &nbsp;</div>
        <div id="container">
            <div class="info">
                Status:&nbsp;&nbsp;Initializing</div>
            <div class="info">
                <nobr>File:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</nobr>
            </div>
            <div class="progressBar">
                <div class="indicator" style="width: 0px">
                </div>
            </div>
            <div class="info">
                Transfer Rate:&nbsp;&nbsp;</div>
            <div class="info">
                Time Remaining:&nbsp;&nbsp;</div>
        </div>
        <div class="info">
            <a id="btn_cancel" href="javascript:cancelUpload()">Cancel</a></div>
</div>
    <form id="form1"  onsubmit="return checkdata();" runat="server">
    <div>
    
    	<div style="font-size:14px; text-align:left; color:#c86000">设置参与发起的店铺</div>    
    	<br/>
    	
		<table class="table">		
		<tr>
			<td style="text-align:right">导入excel文件:</td>
			<td colspan="3"> 
               <input id="File1" name="File1"  type="file" class="txtwith" />
			</td>
		</tr>
		
		</table>
    	<br/>
    	<div style="text-align:center; width:900px;">
			<asp:Button id="btnAddShops" CssClass="qr0" runat="server" Text="导入" OnClick="btnAddShops_Click" />
				</div>
    </div>
    </form>
</body>
</html>
