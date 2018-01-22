<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamPOPAddition.aspx.cs"
    Inherits="WebUI_POPAddition_ExamPOPAddition" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>审核-POP增补</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="JavaScript/GetShopInfoList.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>
    <style type="text/css">
        .datalist tr.altrow
        {
            background-color: #a5e5aa; /* 隔行变色 */
        }
        td
        {
            background-color: white;
        }
    </style>
</head>
<body style="font-size: 12px; background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
    <div style="width: 90%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            季度原损加单审核</div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td style="width: 15%; text-align: left">
                    POP发起ID
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="ddl_poplaunch" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择发起POP的ID</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    店铺编号：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td style="width: 15%; text-align: left">
                    店铺名称：
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    部门名称：
                </td>
                <td align="left">
                   <%-- onchange=" GetAreaName(this.value);"--%>
                    <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" 
                        onselectedindexchanged="DDL_department_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td>
                    区域名称：
                </td>
                <td align="left">
                   <%--onchange="GetprovinceList()"--%>
                    <asp:DropDownList ID="DDL_Area"  CssClass="txtwith" runat="server" 
                        onselectedindexchanged="DDL_Area_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    省市：
                </td>
                <td style="width: 30%;">
<%--                   onchange="GetcityList()"--%>
                   <asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" 
                        onselectedindexchanged="DDL_Province_SelectedIndexChanged" AutoPostBack="true"> 
                    
                        <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    地级城市：
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    一级客户：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%">
                    供应商;
                </td>
                <td>
                    <asp:DropDownList ID="ddl_supplier" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺的供应商</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    审批状态：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="DDL_examstate" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="-1">请选择审批状态</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">已通过</asp:ListItem>
                        <asp:ListItem Value="-1">未通过</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    &nbsp;<input id="Btn_search" type="button" class="qr0" value="查 询" onserverclick="Btn_search_ServerClick"
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="margin-top: 20px; margin-left: 5%; font-size: 12px;">
        <table class="table" style="margin-top: 3px; font-weight: bold;">
            <tr>
                <td align="left" style="color: Red">
                    增补数量<%=POPAddtionCount %>个，增补面积<%=POPAddtitionArea %>
                    <asp:HiddenField ID="HF_areaid" runat="server" />
                </td>
            </tr>
        </table>
        <table class="table" style="width: 100%">
            <caption style="font-weight: bold; font-size: 12px">
            </caption>
            <tr>
                <th>
                    店铺名称
                </th>
                <th style="width: 8%">
                    位置
                </th>
                <th>
                    POP编号
                </th>
                <th style="width: 7%">
                    POP实际制作高
                </th>
                <th style="width: 5%">
                    POP实际制作宽
                </th>
                <th style="width: 7%">
                    POP可视画面高
                </th>
                <th style="width: 5%">
                    POP可视画面宽
                </th>
                <th style="width: 5%">
                    面积
                </th>
                <th style="width: 7%">
                    POP可视画面位置
                </th>
                <th style="width: 5%">
                    POP可视画面偏离角度
                </th>
                <th>
                    图片
                </th>
                <th style="width: 15%">
                    备注
                </th>
                <th style="width: 7%">
                    状态
                </th>
                <th style="width: 10%">
                    审核结果
                </th>
            </tr>
            <asp:Repeater runat="server" ID="gv_popaddition">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='#' onclick='javascript:ShowDIV("30%","30%","900px","50px","500px","[店铺详情]","../ShopPOP/ShopPOPList.aspx?shopid=<%#Eval("shopid")%>")'>
                                <%# Eval("shopname")%></a>
                        </td>
                        <td align="left">
                            <%# Eval("POPseat")%>
                        </td>
                        <td align="left">
                            <%# Eval("seatnum")%>
                        </td>
                        <td align="left">
                            <%# Eval("realHeight")%>
                        </td>
                        <td align="left">
                            <%# Eval("realWith")%>
                        </td>
                        <td align="left">
                            <%# Eval("POPHeight")%>
                        </td>
                        <td align="left">
                            <%# Eval("POPWith")%>
                        </td>
                        <td align="left">
                            <%# Eval("POPArea")%>
                        </td>
                        <td align="left">
                            <%# Eval("POPplwz")%>
                        </td>
                        <td align="left">
                            <%# Eval("POPpljd")%>
                        </td>
                        <td align="left">
                            <img src='../../<%# Eval("PhotoUrl")%>' height="28px" width="45px" style="cursor: pointer;"
                                alt='<%#Eval("Des") %>' onclick="javascript:ShowDIV('30%','30%','700px','50px','500px',this.alt,this.src)" />
                        </td>
                        <td>
                            <%# Eval("Des")%>
                        </td>
                        <td align="left">
                            <%if (!string.IsNullOrEmpty(deptname))
                              {%>
                            <%#Eval("ExamState").ToString() == "0" ? " <a href='#' onclick='doSet('dept',"+Eval("AddID")+");'>通过</a>&nbsp;&nbsp; <a href='#'onclick='UndoSet('dept',"+Eval("AddID")+");'>不通过</a>" :Eval ("ExamState").ToString ()=="1"? "<font color=red>通过</font>":"<font color=red>未通过</font>"%>
                            <%}
                              else
                              {%>
                            <%#Eval("VMExamState").ToString() == "0" ? " <a href='#' onclick='doSet('VM'," + Eval("AddID") + ");'>通过</a>&nbsp;&nbsp; <a href='#'onclick='UndoSet('VM'," + Eval("AddID") + ");'>不通过</a>" : Eval("ExamState").ToString() == "1" ? "<font color=red>通过</font>" : "<font color=red>未通过</font>"%>
                            <% } %>
                        </td>
                        <td>
                            <%#Eval("UnDes").ToString() == "" ? "无" : Eval("UnDes").ToString ()%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="HyperLinkPage" style="margin-top: 20px; text-align: center; padding-left: 10px;
        width: 900px; font-size: 14px; margin-left: 5%">
    </div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    function GetcityList() {
        var pro = $("#DDL_Province").val();
        GetCityname(pro);
    }

    $(function () {
        $("table.datalist tr:nth-child(odd)").addClass("altrow");
    });
</script>
<script type="text/javascript">
      var UserID =<%=UserID %>; 
        function doSet(role,key)
        {
            if(confirm('确定通过审核吗？'))
            {
                 $.get("CallBack/doSet.ashx?Date="+new Date(),{UserRole:role,UserID:UserID,ExamState:1,AddID:key,Undes:""},function(data){
                 if(data.length>0)
                 {
                   $.prompt("操作成功",{callback:reloadpage});
                   //window.location .reload () ;
                 }
                 });
            }
        }
        
         function UndoSet(role,key)
         {
           var txt = '请填写未通过审核备注说明:<br /> <input type="text" id="alertName"  name="alertName" value="" style="width:260px;"  /><input type="text" id="key" name ="key" value='+key+' style="display:none;"/>'; 
             if(confirm('确定不通过审核吗？'))
             { 
                $.prompt(txt,{callback:mycallbackform,buttons:{确定: true, 取消: false }});
             }
         }
         
         function mycallbackform(v,m,f)
                 {  
                          if(v)
                          { 
                             var undes =f.alertName;
                             var key=f.key; 
                             var role=f.role;
                             if(undes!="")
                             {
                                $.get("CallBack/doSet.ashx?Date="+new Date(),{UserRole:role,UserID:UserID,ExamState:-1,AddID:key,Undes:undes},function(data){
                                     if(data.length>0)
                                     {
                                       $.prompt("操作成功",{callback:reloadpage});
                                       //window.location .reload () ;
                                     }
                                     });
                             }
                             else
                             {
                               alert("描述不能为空");
                             }
                          }
                 }
                 
                 function reloadpage()
                 {
                    window.location .reload () ;
                 }
         
</script>
</html>
