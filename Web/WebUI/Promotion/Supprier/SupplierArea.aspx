<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierArea.aspx.cs" Inherits="WebUI_Promotion_Supprier_SupplierArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../../js/ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/ztree/js/jquery.ztree.core-3.5.js" type="text/javascript"></script>
    <script src="../../../js/ztree/js/jquery.ztree.excheck-3.5.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table">
            <tr>
                <td style="width: 120px;">
                    供应商名称
                </td>
                <td style="text-align: left; padding-left: 5px;">
                    <asp:Label ID="labName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 120px;">
                    简称
                </td>
                <td style="text-align: left; padding-left: 5px;">
                    <asp:Label ID="labShortName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    负责区域
                </td>
                <td style="text-align: left; padding-left: 5px;">
                    <span id="editArea" style="color: blue; cursor: hand; text-decoration: underline;">编辑/查看</span>
                    <asp:Button ID="btnSubmit" runat="server" Text="Button" style="display:none;"
                        onclick="btnSubmit_Click"/>
                        <br />
                    
       
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: left; padding-left: 5px;">
                    
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div style=" text-align:center;">
    
    </div>
    <div id="areaDiv" title="供应商负责区域设置" style="width: 400px; height: 350px; display:none; ">
        <ul id="treeDemo" class="ztree">
        </ul>
    </div>
    <asp:HiddenField ID="hfJson" runat="server" />
    <asp:HiddenField ID="hfProvinces" runat="server" />
    </form>
</body>
</html>
<link href="../../../js/jquery-ui-1.11.4.custom/jquery-ui.min.css" rel="stylesheet"
    type="text/css" />
<script src="../../../js/jquery-ui-1.11.4.custom/jquery-ui.min.js" type="text/javascript"></script>
<script type="text/javascript">
    var setting = {
        check: {
            enable: true
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        callback: {
            
            onCheck: onCheck
        }
    };
    
    function setCheck() {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo");
        type = { "Y": "ps", "N": "s" };
        zTree.setting.check.chkboxType = type;
       
    }

    function onCheck(e, treeId, treeNode) {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo"),
			nodes = zTree.getCheckedNodes(true),
			v = "";
        var departId = "";
        for (var i = 0, l = nodes.length; i < l; i++) {
            var childrenLen = 0;
            if(nodes[i].children!=null)
            {
                childrenLen = nodes[i].children.length;
            }
            if (childrenLen == 0) {
                departId = nodes[i].pId || 0;
                if (departId != 0) {
                    v += departId + ":" + nodes[i].id + ",";
                }
                else {
                    v += nodes[i].id + ":0,";
                }
            }
            //departId += nodes[i].id + ",";  
        }
        if (v.length > 0) v = v.substring(0, v.length - 1);
        $("#hfProvinces").val(v);
        
    }

    $(function () {
        if ($.trim($("#hfJson").val()) != "") {
            var zNodes = eval("(" + $("#hfJson").val() + ")");
            $.fn.zTree.init($("#treeDemo"), setting, zNodes);
            
            setCheck();

        }

        $("#editArea").click(function () {
            $("#areaDiv").dialog({
                resizable: false,
                modal: true,
                width: '400px',
                height: '400',
                overflow: 'auto',
                buttons: {
                    "修 改": function () {
                        $("#btnSubmit").click();
                    },
                    "返 回": function () {
                        $(this).dialog('close');
                    }
                }
            })
        })
    })
</script>
