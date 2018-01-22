// JScript 文件

var levellist="";
 var typeStr="";
  var VIstr="";
  var citylist="";
  var townlist="";
  var provicelist="";
  var arealist="";
  /////////////////////////////用来用全选和取消全选
function TypeChoose(typeid,obj)
{
var divchecklist= $("#line_"+typeid+" input[type=checkbox]").get();
  if(obj.checked)
  {
    for(var i=0;i<divchecklist.length;i++)
    {
        divchecklist[i].checked=obj.checked;
    }
  }
  else
  {
    for(var i=0;i<divchecklist.length;i++)
    {
        divchecklist[i].checked=obj.checked;
    }
  }
}

//验证数据
function checkdata()
{
   levellist="";
   typeStr="";
   VIstr="";
   citylist="";
   townlist="";
  provicelist="";
  arealist="";
  shopSa = "";
  shopACL = "";
  shopTCL = "";
//   var f=0;
//    var prolist=$("#divpro input[name=linename]").get();
//    for(var i=0;i<prolist.length;i++)
//    {
//      if(prolist[i].checked)
//      {
//        f++;
//      }
//    }
//   if(f<=0)
//   {
//     alert("请选择产品系列！");
//     return false;
//   }
   
    var sa=0;
    var salist=$("#saname input[type=checkbox]").get();
    for(var i=0;i<salist.length;i++)
    {
      if(salist[i].checked)
      {
        sa++;
        shopSa+=salist[i].value+",";
      }
    }
   if(sa<=0)
   {
     alert("请选择店铺零售属性！");
     return false;
   }
   else
   {
        shopSa=shopSa.substr(0,shopSa.length-1);
   }
   
   /////////////////////////////////////////////////////////////
    var acl=0;
    var acllist=$("#div_shopACL input[type=checkbox]").get();
    for(var i=0;i<acllist.length;i++)
    {
      if(acllist[i].checked)
      {
        acl++;
        shopACL+=acllist[i].value+",";
      }
    }
   if(acl<=0)
   {
     alert("请选择区县级城市级别-市场定义！");
     return false;
   }
   else
   {
        shopACL=shopACL.substr(0,shopACL.length-1);
   }
   
    /////////////////////////////////////////////////////////////
    var tcl=0;
    var tcllist=$("#div_shopTCL input[type=checkbox]").get();
    for(var i=0;i<tcllist.length;i++)
    {
      if(tcllist[i].checked)
      {
        tcl++;
        shopTCL+=tcllist[i].value+",";
      }
    }
   if(tcl<=0)
   {
     alert("请选择地市级城市级别-市场定义！");
     return false;
   }
    else
   {
        shopTCL=shopTCL.substr(0,shopTCL.length-1);
   }
   
   /////////////////////////////////////////////////////////////
   c=0;
     var leveldiv=$("#levelname input[type=checkbox]").get();
     for(var i=0;i<leveldiv.length;i++)
     {
        if(leveldiv[i].checked)
        {
           c++;
           levellist+=leveldiv[i].value+",";
        }
     }
     if(c<=0)
     {
        alert('您没有选择相应的店铺级别，请重新选择！');
        return false;
     }else
     {
       levellist=levellist.substr(0,levellist.length-1);
     }
     
     //--------------------------------------------------------------
     var d=0;
    
     var typelist=$("#div_shoptype input[type=checkbox]").get();
     for(var i=0;i<typelist.length;i++)
     {
      if(typelist[i].checked)
      {
         d++;
         typeStr+=typelist[i].value+",";
      }  
     }
     if(d<=0)
     {
       alert("请选择相应的店铺类型");
       return false;
     }
     else
      {
         typeStr=typeStr.substr(0,typeStr.length-1);
      }
     //--------------------------------------------------------------
     var e=0;
    
     var VIlist=$("#div_shopVI input[type=checkbox]").get();
      for(var i=0;i<VIlist.length;i++)
     {
      if(VIlist[i].checked)
      {
         e++;
         VIstr+=VIlist[i].value+",";
      }  
     }
     if(e<=0)
     {
       alert("请选择相应的店铺V/I模式");
       return false;
     }
     else
      {
         VIstr=VIstr.substr(0,VIstr.length-1);
      }
      
   var ab=0;
   var areadivlist= $("#areadiv input[type=checkbox]").get();
   //alert(divlist.length);
   for(var i=0;i<areadivlist.length;i++)
  {//alert(divlist[i].checked);
    if(areadivlist[i].checked)
    {
       arealist+=areadivlist[i].value+",";
       ab++;
    }
  }
  if(ab<=0)
  {
    alert('您没有选择任何的省区，请重新选择！');
    return false;
  }
    else
      {
         arealist=arealist.substr(0,arealist.length-1);
      }  
      
      ///////////////////////////////////////////////
   var pc=0;
   var provicedivlist= $("#pro input[type=checkbox]").get();
   for(var i=0;i<provicedivlist.length;i++)
  {//alert(divlist[i].checked);
    if(provicedivlist[i].checked)
    {
       provicelist+=provicedivlist[i].value+",";
       pc++;
    }
  }
  if(pc>0)
  {
    provicelist=provicelist.substr(0,provicelist.length-1);
  }
       
     ////////////////////////////////////////////////////
   /*var a=0;
   var divlist= $("#citytable div").get();
   //var divlist= $("#citytable div").get();
   for(var i=0;i<divlist.length;i++)
      {
         if(divlist[i].style.display!='none')
         {
            if(divlist[i].firstChild.checked)
            {
               a++;
               citylist=citylist+divlist[i].firstChild.value+",";
           }
         }
     
      }
//      if(a<=0)
//      {
//        alert('您没有选择相应的城市，请重新选择！');
//        return false;
//      }
     if(a>0)
      {
         citylist=citylist.substr(0,citylist.length-1);
      }
      ////////////////////////////////////////////////
     var b=0;
     var towndivlist= $("#towntable div").get();
     for( var i=0 ;i<towndivlist.length;i++)
     {
       if(towndivlist[i].style.display!='none')
        {
            if(towndivlist[i].firstChild.checked)
            {
               b++;
               townlist+=towndivlist[i].firstChild.value+",";
            }
        }
     }
     
     if(b>0)
     { 
        townlist=townlist.substr(0,townlist.length-1);
     }*/
     
     return true;
}
function GetselctShop()
{

   if(!checkdata())
   {
      return false;
   }
   else
   {
     //var url="GetShopByCity.aspx?province="+provicelist+"&citylist="+citylist+"&townlist="+townlist+"&levellist="+levellist+"&typelist="+typeStr+"&VIlist="+VIstr;
     var url="GetShopByCity.aspx?province="+provicelist+"&SaleType="+shopSa+"&AreaCityLevel="+shopACL+"&TownCityLevel="+shopTCL+"&levellist="+levellist+"&typelist="+typeStr+"&VIlist="+VIstr;
    //alert(url);
     onObjMore(url,"shop","800px","1000px","form1");
   }
}

 function onObjMore(url,name,height,width,formName) {
		 //window.alert(formName.file.type);
		 var feature = "dialogWidth:"+width+"px;dialogHeight:"+height+"px;scroll:yes;status:no;help:no;center:1";
		 var returnTarget = window.showModalDialog(url, name, feature);
		 //alert(returnTarget);
		 if(returnTarget != undefined && returnTarget.length > 0) {
		  //document.location = returnTarget;
	
		 $("#HF_shopid").val(returnTarget);
  }
 return false;
}