﻿/*

 *author:秦浩 

 *Create date: 2009-05-05
 
 *Description: 弹出层

*/


window.ShowDIV = function(strLeft,strTop,strWidth,strHeight,iframeHeight,strTitle,url)
{
	var shield = document.createElement("DIV");
	shield.id = "shield";
	shield.style.position = "absolute";
	shield.style.left = "0px";
	shield.style.top = "0px";
	shield.style.width = window.screen.width;
	shield.style.height = window.screen.height;
	shield.style.background = "#333";
	shield.style.textAlign = "center";
	shield.style.zIndex = "10000";
	shield.style.filter = "alpha(opacity=0)";
	var alertFram = document.createElement("DIV");
	alertFram.id="alertFram";
	alertFram.style.position = "absolute";
	alertFram.style.left = strLeft;
	alertFram.style.top = strTop;
	alertFram.style.marginLeft = "-225px";
	alertFram.style.marginTop = "-175px";
	alertFram.style.width = strWidth;
	alertFram.style.height = strHeight;
	alertFram.style.background = "#ccc";
	alertFram.style.textAlign = "center";
	alertFram.style.lineHeight = "30px";
	alertFram.style.zIndex = "10001";
	strHtml  = "<ul style=\"list-style:none;margin:0px;padding:0px;width:100%;\">\n";
	strHtml += "    <li><div class=\"hir1\">"+strTitle+"</div><div class=\"hirimg\"><img src=\"../../images/state3.gif\" style=\"cursor:pointer;\" alt=\"关闭\" onclick=\"doOk();\" /></div></li>\n";
	strHtml += "    <li class=\"hir2\" style='height:250px; margin-left:-1px'><iframe frameborder=\"0\" scrolling=\"auto\" width=\""+strWidth+"\" height=\""+iframeHeight+"\" src=\""+url+"\"></iframe></li>\n";
	strHtml += "    <li class=\"hirbit\"></li>\n";
	strHtml += "</ul>\n";
	alertFram.innerHTML = strHtml;
	document.body.appendChild(alertFram);
	document.body.appendChild(shield);
	var c = 40;
	this.doAlpha = function(){
	  if (c++ > 70){clearInterval(ad);return 0;}
	  0000000000000
	  shield.style.filter = "alpha(opacity="+c+");";
	}
	var ad = setInterval("doAlpha()",5);
	this.doOk = function(){
		if(document.all){
			document.getElementById("shield").removeNode(true);
			document.getElementById("alertFram").removeNode(true);
		}else{
			document.getElementById("shield").parentNode.removeChild(document.getElementById("shield"));
			document.getElementById("alertFram").parentNode.removeChild(document.getElementById("alertFram"));
		}
	}
	alertFram.focus();
	document.body.onselectstart = function(){return false;};
}


