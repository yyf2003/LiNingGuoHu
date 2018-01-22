// JScript 文件

function TypeChoose(typeid,obj)
{

var divchecklist=  JQ("#line_"+typeid+" input[type=checkbox]").get(); 
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

