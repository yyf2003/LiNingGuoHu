<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPLaunchOne.aspx.cs" Inherits="WebUI_POPLanuch_POPLaunchOne" %>

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
    
    	<div style="font-size:14px; text-align:left; color:#c86000">POP发起周期及其他设置</div>    
    	<br/>
    	
		<table class="table">
		<tr>
			<td style=" width:20%;text-align:right">POP发起ID：</td>
			<td>
			&nbsp;<asp:TextBox ID="txt_POPID" runat="server" BorderStyle="None" CssClass="txtwith" Enabled="False"></asp:TextBox>
			&nbsp;</td>
			<td style="text-align:right">
			是否重新报价：
			</td>
			<td>
			<asp:DropDownList ID="DDL_price" runat="server">
			<asp:ListItem Value="0">不需要重新报价</asp:ListItem>
			<asp:ListItem Value="1">重新报价</asp:ListItem>
			</asp:DropDownList></td>
		
		</tr>
		<tr>
			<td style="text-align:right">POP发起起始时间：</td>
			<td style="width:320px"><asp:TextBox ID="txt_btime"  onclick="setday(this,document.getElementById('txt_btime'))"   CssClass="txtwith" runat="server" ></asp:TextBox></td>
			<td style="text-align:right;width:15%">结束时间：</td>
			<td><asp:TextBox ID="txt_etime"  onclick="setday(this,document.getElementById('txt_etime'))"  runat="server" CssClass="txtwith" ></asp:TextBox></td>
		</tr>
		
		<tr>
			<td style="text-align:right">POP发起主题:</td>
			<td colspan="3">
			<asp:TextBox ID="txt_poptitle" runat="server" CssClass="txtwith"></asp:TextBox>
			&nbsp;</td>
		</tr>
		
		<tr>
			<td style="text-align:right">
			所涉及产品大类与产品系列：</td>
			<td colspan="3">
			<asp:Literal ID="L_proline" runat="server"></asp:Literal></td>
		</tr>
		<tr>
			<td style="text-align:right">POP发起备注:</td>
			<td colspan="3"> <asp:TextBox id="txt_remarks" runat="server" CssClass="txtwith" TextMode="MultiLine"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td style="text-align:right">季度执行说明与季度相关资源:</td>
			<td colspan="3"> <input
			id="File1" name="File1"  type="file" class="txtwith" />
			</td>
		</tr>
		
		</table>
    	<br/>
    	<div style="text-align:center; width:900px;">
			<asp:Button id="Btn_popOne" CssClass="qr0" runat="server" OnClientClick="this.disabled=false"  Text="下一步" OnClick="Btn_popOne_Click" />
				</div>
    </div>
    </form>
</body>
     <script language="javascript" type="text/javascript">
		<!--
		
		//preload images
	//	var img1 = new Image();
	//	img1.src = "images/bar_bg.gif";
	//	var img2 = new Image();
	//	img2.src = "images/Indicatorbg.gif";
		// 去除字符串的首尾的空格
function checkdata()
{
   if(!isdate(JQ("#txt_btime").val()))
   {
     alert("请正确填写POP发起起始时间 如 2008-08-08");
     JQ("#txt_btime").focus();
     return false;
   }
   if(!isdate(JQ("#txt_etime").val()))
   {
     alert("请正确填写结束时间 如 2008-08-08");
     JQ("#txt_etime").focus();
     return false;
   }
   var checkcount=0;
   JQ("input[@name='linename']").each(function()
   {
     if(JQ(this).attr("checked")==true)
         checkcount++;
   }
   )
   if(checkcount<=0)
   {
     alert("请选择参加活动的所涉及产品系列");
     return false;
   }
}
function trim(str){
   return str.replace(/(^\s*)|(\s*$)/g, "");
}

		var ProgressInfo = Class.create();
		
		ProgressInfo.prototype = {
			initialize:	function(status,percent,file,speed,leftTime,fileCount){
							this.Status = status;
							this.Percent =percent;
							this.File = file;
							this.Speed =speed;
							this.LeftTime = leftTime;
							this.FileCount = fileCount;
			},
			
			update:	function(){
						if(this.Status == "Error")
						{
							document.location.href = document.location.href;
						}
						else
						{
							var html = "<div class=\"info\">Status:&nbsp;&nbsp;"+(this.Status=="Uploading" ? this.Percent + "% Completed" :this.Status)+"</div>";
							html += "<div class=\"info\"><nobr>File:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+(this.Status=="Completed" ? this.FileCount + " fiel(s) uploaded successfully !" : this.File)+"</nobr></div>";
							html += "<div class=\"progressBar\"><div class=\"indicator\" style=\"width:"+(3*this.Percent)+"px\"></div></div>";
							html += "<div class=\"info\">Transfer Rate:&nbsp;&nbsp;"+(this.Status=="Initializing" ? "" : this.Speed)+"</div>";
							html += "<div class=\"info\">Time Remaining:&nbsp;&nbsp;"+(this.Status=="Initializing" ? "" : this.LeftTime)+"</div>";
							var container = $("container");
							container.innerHTML = html;						
						}
			}			
		};
		
		function getProgressInfo()
		{
			var url = "GetProgressInfo.aspx";
			var pars = "UploadID=<%=UploadID%>&cmd=Update&temp="+Math.random();
			var myAjax = new Ajax.Request(url,{method: 'get', parameters: pars, onComplete: showResponse});			
		}
		
		function cancelUpload()		
		{
			var url = "GetProgressInfo.aspx";
			var pars = "UploadID=<%=UploadID%>&cmd=Cancel&temp="+Math.random();
			var myAjax = new Ajax.Request(url,{method: 'get', parameters: pars, onComplete: showResponse});
			this.disabled = true;		
		}
		
		function showResponse(request)
		{
			eval(request.responseText);
		}
		
		function showProgressBar()
		{
			var ipts = document.getElementsByTagName('INPUT');
			var openBar = false;
			for(var i=0;i<ipts.length;i++)
			{
				var obj = ipts[i];
				if(obj.type  == 'file')
				{
					if(obj.value != '')
					{
						openBar = true;
						break;
					}
				}
			}
			if(openBar)
			{
				var theHandle = $("handle");
				var theRoot   = $("root");
				Drag.init(theHandle, theRoot);
				theRoot.style.display = "";
				var internalUpdate = new PeriodicalExecuter(getProgressInfo,1);
			}
		}
			
		//-->
    </script>
</html>
