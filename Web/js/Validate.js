﻿// JScript 文件


//校验文本是否为空
function checknull(field,sval)
{
	if (field.value =="")
  	{
    	//alert("请您填写" + sval + "！");
    	//field.focus();
    	return false;
  	}
  	return true;
}

// 判断输入是否是一个由 0-9 / A-Z / a-z 组成的字符串
function isalphanumber(str)
{
	var result=str.match(/^[a-zA-Z0-9]+$/);
	if(result==null) return false;
	return true;
}


// 判断输入是否是一个数字--(数字包含小数)--
function isnumber(str)
{
if(str.length<=0)
return false;
    return !isNaN(str);
}


// 判断输入是否是一个整数
function isint(str)
{
	var result=str.match(/^(-|\+)?\d+$/);
	if(result==null) return false;
	return true;
}


// 判断输入是否是有效的长日期格式 - "YYYY-MM-DD HH:MM:SS" || "YYYY/MM/DD HH:MM:SS"
function isdatetime(str)
{
	var result=str.match(/^(\d{4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/);
	if(result==null) return false;
	var d= new Date(result[1], result[3]-1, result[4], result[5], result[6], result[7]);
	return (d.getFullYear()==result[1]&&(d.getMonth()+1)==result[3]&&d.getDate()==result[4]&&d.getHours()==result[5]&&d.getMinutes()==result[6]&&d.getSeconds()==result[7]);
}


// 检查是否为 YYYY-MM-DD || YYYY/MM/DD 的日期格式
function isdate(str){
   var result=str.match(/^(\d{4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
   if(result==null) return false;
   var d=new Date(result[1], result[3]-1, result[4]);
   return (d.getFullYear()==result[1] && d.getMonth()+1==result[3] && d.getDate()==result[4]);
}


// 判断输入是否是有效的电子邮件
function isemail(str)
{
	var result=str.match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/);
	if(result==null) return false;
	return true;
}


// 去除字符串的首尾的空格
function trim(str){
   return str.replace(/(^\s*)|(\s*$)/g, "");
}


// 返回字符串的实际长度, 一个汉字算2个长度
function strlen(str){
   return str.replace(/[^\x00-\xff]/g, "**").length;
}


//匹配中国邮政编码(6位)
function ispostcode(str)
{
	var result=str.match(/[1-9]\d{5}(?!\d)/);
	if(result==null) return false;
	return true;
}
//匹配国内电话号码(0511-4405222 或 021-87888822)
function istell(str)
{
	var result=str.match(/\d{3}-\d{8}|\d{4}-\d{7}/);
	if(result==null) return false;
	return true;
}

//校验是否为(0-10000)的整数
function isint1(str)
{
	var result=str.match(/^[0-9]$|^([1-9])([0-9]){0,3}$|^10000$/);
	if(result==null) return false;
	return true;
}


//匹配腾讯QQ号
function isqq(str)
{
	var result=str.match(/[1-9][0-9]{4,}/);
	if(result==null) return false;
	return true;
}

//匹配手机号码
function isMob(str)
{
	var result=str.match(/\d{11}/);
	if(result==null) return false;
	return true;
}


//匹配身份证(15位或18位)
function isidcard(str)
{
	var result=str.match(/\d{15}|\d{18}/);
	if(result==null) return false;
	return true;
}

//比较两时间大小
function bjsj(t1,t2)
{
   var a=new Date(t1);
   var b=new Date(t2);
   if(b>=a)
   {
     return false;
   }
   else
   {
     return true;
   }
}

//判断文件类型是否符合条件
function checkuploadfile(filename,type)
{
	var pos = filename.value.lastIndexOf(".");
	var lastname = filename.value.substring(pos+1,filename.value.length);
	if(lastname.toLowerCase()!=type)
	{
		return false;
	}
	return true;
}

//判断文件类型是否符合条件
function checkuploadfiles(filename)
{

    var array=new Array('jpg', 'jpeg', 'gif', 'bmp', 'png', 'doc', 'pdf', 'ppt', 'xls', 'docx', 'xlsx', 'rar', 'zip');
      var stuts=false;
     var fileExtensions=trim($(filename).value).split('.');
     var Extensions=fileExtensions[fileExtensions.length-1].toLowerCase();
     for(var i=0;i<array.length;i++)
     {
        if(array[i]==Extensions)
        {
           stuts=true;
           break;
        }
     }
     return stuts;
}

function checkspecial(str)
{
     var array=new Array('&','#','$','^','*','~','/','\'','\\');
     var temp='';
     for(var i=0;i<array.length;i++)
     {
      
       if(str.indexOf(array[i].toString())>=0)
       {
          temp=temp+array[i]+',';
       }
       
     }
    
     if(temp.length>0)
     {
        alert(temp+'等特殊字符不允许输入;');
        return false;
     }
     
}