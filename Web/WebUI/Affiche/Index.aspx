<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeFile="Index.aspx.cs"
    Inherits="WebUI_Affiche_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公告</title>
    <style>
        *body
        {
            font-size: 12px;
        }
        a:link
        {
            text-decoration: none;
            color: #000;
        }
        a:visited
        {
            text-decoration: none;
            color: #000;
        }
        a:active
        {
            text-decoration: none;
            color: blue;
        }
        a:hover
        {
            text-decoration: none;
            color: blue;
        }
        #winpop
        {
            width: 200px;
            height: 120px;
            position: absolute;
            right: 0;
            bottom: 0;
            border: 1px solid #999999;
            margin: 0;
            padding: 1px;
            overflow: hidden;
            display: none;
            background: #FFFFFF;
        }
        #winpop .title
        {
            width: 100%;
            height: 20px;
            line-height: 20px;
            font-weight: bold;
            text-align: center;
            font-size: 12px;
            background-image: url('../../Images/bg_title.gif');
        }
        #winpop .con
        {
            width: 100%;
            height: 100px;
            line-height: 18px;
            font-size: 12px;
            text-align: center;
        }
        #silu
        {
            font-size: 13px;
            color: #999999;
            position: absolute;
            right: 0;
            bottom: 0px;
            text-align: right;
            text-decoration: underline;
            line-height: 22px;
        }
        #demo1
        {
            text-align: left;
        }
        #demo2
        {
            text-align: left;
        }
        .close
        {
            position: absolute;
            right: 4px;
            top: -1px;
            color: #FFFFFF;
            cursor: pointer;
            float: left;
        }
    </style>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        var url = '../../NoticeExam.aspx?' + new Date();
        $.get(url, function (data) {
            // alert(data);
            if (data.length > 0) {
                $("#notice").html("");
                $("#notice").html(data);
            }
            else {
                $("#table1").hide();
            }
        })
    
    </script>
    <script type="text/javascript">
        //function show_pop(){//显示窗口 
        //    document.getElementById("winpop").style.display="block"; 
        //    timer=setInterval("changeH(4)",2);//调用changeH(4),每0.002秒向上移动一次 
        //} 
        //function hid_pop(){//隐藏窗口 
        //    timer=setInterval("changeH(-4)",2);//调用changeH(-4),每0.002秒向下移动一次 
        //} 

        //function changeH(addH) { 
        //    var MsgPop=document.getElementById("winpop"); 
        //    var popH=parseInt(MsgPop.style.height||MsgPop.currentStyle.height);//用parseInt将对象的高度转化为数字,以方便下面比较（JS读<style>中的height要用"currentStyle.height"） 
        //    if (popH<=120&&addH>0||popH>=4&&addH<0){//如果高度小于等于100(str>0)或高度大于等于4(str<0) 
        //        MsgPop.style.height=(popH+addH).toString()+"px";//高度增加或减少4个象素 
        //    } 
        //    else{//否则 
        //        clearInterval(timer);//取消调用,意思就是如果高度超过100象素了,就不再增长了，或高度等于0象素了，就不再减少了 
        //        MsgPop.style.display=addH>0?"block":"none"//向上移动时窗口显示,向下移动时窗口隐藏（因为窗口有边框,所以还是可以看见1~2象素没缩进去,这时候就把DIV隐藏掉） 
        //    } 
        //} 
        //window.onload=function(){//加载 
        //setTimeout("show_pop()",300);//0.8秒后调用show_pop() 
        //    } 
        //    function minzoon()
        //    { 
        //    var ab =document.getElementById ("demo").style .display;
        //    if(ab=="block")
        //    {
        //    $("#demo").hide();
        //    $("#mizpop").html("□");
        //    document.getElementById ("winpop").style .height ="20px";
        //    }
        //    else
        //    {
        //    $("#mizpop").html("_");
        //    $("#demo").show();
        //    document.getElementById ("winpop").style .height ="100px";
        //    }
        //    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 97%; border-color: Red" border="1px" id="table1">
        <tr>
            <td>
                <div style="width: 99%; float: left; height: 18px; padding-top: 4px; padding-left: 0px;
                    background-image: url('../../Images/bg_title.gif');">
                    <div style="width: 100%;">
                        <div style="width: 80%; float: left; font-size: 12px;">
                            <asp:Label ID="top1" runat="server" Text="待审批任务" Font-Bold="true"></asp:Label></div>
                    </div>
                </div>
                <div style="width: 100%; height: auto;" id="notice">
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Repeater ID="Repeater4" runat="server">
        <HeaderTemplate>
            <table border="0px" class="table">
                <tr>
                    <td>
                        <div style="width: 100%; float: left; height: 18px; padding-top: 4px; padding-left: 6px;
                            background-image: url('../../Images/bg_title.gif');">
                            <div style="width: 100%;">
                                <div style="width: 80%; float: left; font-size: 12px;">
                                    <asp:Label ID="top1" runat="server" Text="公告" Font-Bold="true"></asp:Label></div>
                            </div>
                        </div>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="height: 30px; text-align: left; vertical-align: top">
                <td>
                    <font style="font-size: 12px; font-weight: normal;">＋</font><a href='ShowAffiche.aspx?ID=<%#Eval("ID") %>'
                        title='<%#Eval("Title") %>' style="font-size: 14px;">
                        <%#Eval("Title").ToString() %></a>
                    <br />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
