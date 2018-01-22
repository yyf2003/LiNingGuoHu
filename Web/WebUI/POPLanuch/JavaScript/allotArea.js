// JScript 文件

function GetProvince(areaid)
{
  $('#pro')[0].style.display='';
  if($('#'+areaid).attr('checked'))
  {
   var divlist= $("#pro div").get();
   disp(divlist,areaid,'');
  }
  else
  {
   var divlist= $("#pro div").get();
   disp(divlist,areaid,'none');
   clearchoose1(divlist,areaid);
  }
}

function GetPOPImageData(popid)
{
    $('#imgDIV')[0].style.display='';
    var divlist= $("#imgDIV div").get();
    if($('#'+popid).attr('checked'))
    {
        for(var i=0;i<divlist.length;i++)
        {
            if(divlist[i].id=='i'+popid)
            {
              divlist[i].style.display='';
            }
        }
    }
    else
    {
        for(var i=0;i<divlist.length;i++)
        {
            if(divlist[i].id=='i'+popid)
            {
              divlist[i].style.display='none';
              divlist[i].firstChild.checked=false;
            }
        }
    }
}


//控制层的现实和隐藏
function disp(tdlist,oid,flag)
{
  for(var i=0;i<tdlist.length;i++)
  {
    if(tdlist[i].id=='a'+oid)
    {
      tdlist[i].style.display=flag;
    }
  }
}

function clearchoose1(tdlist,oid)
{
  for(var i=0;i<tdlist.length;i++)
  {
    if(tdlist[i].id=='a'+oid)
    {
      tdlist[i].firstChild.checked=false;
    }
  }
}

//把隐藏的checkbox 的状态改为未选择状态
function clearchoose(tdlist,oid)
{
  for(var i=0;i<tdlist.length;i++)
  {
    if(tdlist[i].style.display=='none')
    {
      tdlist[i].firstChild.checked=false;
    }
  }
}

//把隐藏的checkbox 的状态改为未选择状态
function clearTownchoose(tdlist,oid,flag)
{
  for(var i=0;i<tdlist.length;i++)
  {
    if(tdlist[i].style.display=='none')
    {
      tdlist[i].firstChild.checked=flag;
    }
    if(tdlist[i].style.display=='')
    {
      tdlist[i].firstChild.checked=flag;
    }
  }
}
//显示和隐藏相应的子项目
function GetCity(proid)
{
$('#citytable')[0].style.display='';
if($('#'+proid).attr('checked'))
  {
   var divlist= $("#citytable div").get();
   disp(divlist,proid,'');
  }
   if(!$('#'+proid).attr('checked'))
  {
   var divlist= $("#citytable div").get();
   disp(divlist,proid,'none');
   clearchoose(divlist,proid);
  }
}

function checkcity()
{
   var a=0;
   var divlist= $("#areadiv input[type=checkbox]").get();
   //alert(divlist.length);
   for(var i=0;i<divlist.length;i++)
  {//alert(divlist[i].checked);
    if(divlist[i].checked)
    {
       a++;
    }
  }
  if(a<=0)
  {
    alert('您没有选择任何的省区，请重新选择！');
    return false;
  }
  return true;
}

function GetTown(cityid)
{
$('#towntable')[0].style.display='';

 if($('#'+cityid).attr('checked'))
  {
   var divlist= $("#towntable div").get();
   disp(divlist,cityid,'');
   clearTownchoose(divlist,cityid,false);
  }
 if(!$('#'+cityid).attr('checked'))
  {
   var divlist= $("#towntable div").get();
   disp(divlist,cityid,'none');
   clearTownchoose(divlist,cityid,false);
  }
}
//function GetselctShop()
//{

//   if(!checkdata())
//   {
//      return false;
//   }
//   else
//   {
//     var url="GetShopByCity.aspx?citylist="+citylist+"&townlist="+townlist+"&levellist="+levellist+"&typelist="+typeStr+"&VIlist="+VIstr;
//   // alert(url);
//     onObjMore(url,"shop","800px","1000px","form1");
//   }
//}

// function onObjMore(url,name,height,width,formName) {
//		 //window.alert(formName.file.type);
//		 var feature = "dialogWidth:"+width+"px;dialogHeight:"+height+"px;scroll:yes;status:no;help:no;center:1";
//		 var returnTarget = window.showModalDialog(url, name, feature);
//		 //alert(returnTarget);
//		 if(returnTarget != undefined && returnTarget.length > 0) {
//		  //document.location = returnTarget;
//	
//		 $("#HF_shopid").val(returnTarget);
//  }
// return false;
//}