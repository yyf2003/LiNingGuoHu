// JScript 文件

var a_i;
//var base_url;
function showGs(event,base_url,txt_a,txt_b,divname){
 if($.browser.msie){
	 var keyStr=event.keyCode;
 }
 else var keyStr=event.which;
 if(keyStr!=38&&keyStr!=40&&keyStr!=13){
	$("#"+divname).empty();
	var vsposID=escape($(txt_a).val());
	//alert(vsposID);
	if(vsposID!=""){
		$("#"+divname).html("正在加载...");
		$.get(base_url+"?"+new Date(),{ID:vsposID},function(m){
			$("#"+divname).html(unescape(m));
			$("#"+divname+">a").bind("click",
			function()
			{
			  var liText=$(this).text();
			 var arr=liText.split("|");
			 var namestr=arr[0];
			 var IDstr=arr[1];
			 //alert (namestr+IDstr);
			 $(txt_b).val(namestr);
			 $(txt_a).val(IDstr);
	        //$(txt_b).val(liText);
	        $("#"+divname).css("display","none");
			}
			);
			$("#"+divname).css("display","block");
			//初始化全局变量
			a_i=-1;
		});
	}
	else $("#"+divname).css("display","none");
 }
 else{
	 //使用键盘上下键选择
	 if($("#"+divname).css("display")=="block"){
		 //得到选择列表的长度
		 var aLen=$("#ts>a").length;
		 var _aLen=Number(aLen)-1;
		 //按下键盘向下方向键
		 if(keyStr==38){
			 if(a_i>=0&&a_i<=_aLen) $("#ts>a").get(a_i).style.backgroundColor="";
			 a_i=Number(a_i)-1;
			 if(a_i<0) a_i=_aLen;
			 $("#"+divname+">a").get(a_i).style.backgroundColor="#CCCCCC";
		 }
		 //按下键盘的向上方向键
		 else if(keyStr==40){
			 if(a_i>=0&&a_i<=_aLen) $("#"+divname+">a").get(a_i).style.backgroundColor="";
			 a_i=Number(a_i)+1;
			 if(a_i>=aLen) a_i=0;
			 $("#"+divname+">a").get(a_i).style.backgroundColor="#CCCCCC";
		 }
		 //按下回车键
		 else if(keyStr==13){
			 var entLiText=$("#"+divname+">a").get(a_i).innerHTML;
			 var arr=entLiText.split("|");
			 var namestr=arr[0];
			 var IDstr=arr[0];
			 $(txt_b).val(namestr);
			 $(txt_a).val(IDstr);
			 $("#"+divname).css("display","none");
		 }
	}
 }
}

////返回查询的公司的信息
//function gsInfo(){
//	var vsGsName=$("#sGsName").val();
//	if(vsGsName!=""){
//		$.post("s.asp",{sGsName:vsGsName},function(m){
//			$("#content").html(m);
//		});
//	}
//}