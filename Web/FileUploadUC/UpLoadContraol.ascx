<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpLoadContraol.ascx.cs"
    Inherits="FileUploadUC_UpLoadContraol" %>
 <script src="../../fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
<%--<link href="../../fancyBox/source/jquery.fancybox.css" rel="stylesheet" type="text/css" />
<script src="../../fancyBox/source/jquery.fancybox.js" type="text/javascript"></script>--%>
<script type="text/javascript">
    $(function () {
        //$("a.showimg").fancybox();

    })

    $(function () {
        var code = '<%=Code %>';
        var jsonStr = '<%=JosnStr %>';
        if (jsonStr != "") {

            var FileJson = eval("(" + jsonStr + ")");
            for (var i = 0; i < FileJson.length; i++) {
                ShowFiles(FileJson[i], code);
            }
        }
    })






    function ShowFiles(json, code) {

        if (json != null) {
            $("#tr").css({ display: "block" });
            var id = json.Id;
            var fileName = json.Title;
            var imgPath = json.SmallImgUrl;
            var SourcePath = json.FilePath;
            
            var exten = SourcePath.substring(SourcePath.lastIndexOf('.') + 1);
            SourcePath = SourcePath.replace("./", "../../");
            SourcePath = SourcePath.replace("~/", "../../");
            var imgSrc = "";
            imgSrc = SetImgSrc(exten);

            var div = "";
            if (imgSrc == "" && imgPath == "") {
                imgSrc = "../../image/UploadFileType/Others.png";
            }
            if (imgSrc == "") {

                imgSrc = imgPath;
                imgSrc = imgSrc.replace("./", "../../");
                imgSrc = imgSrc.replace("~/", "../../");
                
//                div = "<div style='width:120px;float:left;margin-right:15px;'><a href='" + SourcePath + "' class='showimg' style='border:0px;'><img style='border:0px;' src='" + imgSrc + "' width='120px' height='100px' /></a><br/>";
            }
//            else {
//                div = "<div style='width:120px;float:left;margin-right:8px;'><img src='" + imgSrc + "' width='120px' height='100px' />";
//            }
            div = "<div style='width:120px;float:left;margin-right:8px;'><img src='" + imgSrc + "' width='120px' height='100px' />";

            div += "<div style='font-size:12px; text-align:center;border:1px #ccc solid;'><a href='../../Handlers/OperateFile.ashx?id=" + id + "&type=download' rel='" + fileName + "' title='" + fileName + "'>" + (fileName.length > 10 ? (fileName.substring(0, 10) + "...") : fileName) + "</a>&nbsp;<span name='DeleteFile' fileid='" + id + "' onclick='DeleteFile(this)' style='font-size:12px;color:red;cursor:pointer;'>删除</span></div>";


            div += "</div>";
            $("#show" + code).append(div);


        }
    }

    function SetImgSrc(fileType) {
        var src = "";
        switch (fileType) {
            case "xls":
            case "xlsx":
                src = "../../images/UploadFileType/EXCEL.png";
                break;
            case "doc":
            case "docx":
                src = "../../images/UploadFileType/WORD.png";
                break;
            case "ppt":
            case "pptx":
                src = "../../images/UploadFileType/PPT.png";
                break;
            case "rar":
            case "zip":
                src = "../../images/UploadFileType/yasuo.png";
                break;
        }
        return src;
    }



    function DeleteFile(obj) {
        if (confirm("确定删除吗？")) {
            var id = $(obj).attr("fileid");
           
            //var div = $(obj).parent().parent().parent().parent().parent("div");
            var div = $(obj).parent().parent("div");
            $.ajax({
                type: "get",

                url: "../../Handlers/OperateFile.ashx?id=" + id + "&type=deletefile",
                success: function (data) {

                    if (data == "ok") {
                        div.remove();

                        if ($(".ShowFileInfo").html() == "") {
                            $("#tr").css({ display: "none" });
                        }
                        return false;
                    }

                }
            })
        }
    }
</script>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td style="height: 25px; vertical-align: top;">
            <iframe src="../../FileUploadUC/Upload.aspx?userid=<%=UserId %>&filetype=<%=FileType %>&filecode=<%=FileCode %>&code=<%=Code %>&itemtypeid=<%=ItemTypeId %>&itemid=<%=ItemId %>"
                id="upFrame" name="upFrame" width="100%" style="height: 30px;" frameborder="0"
                scrolling="no"></iframe>
        </td>
    </tr>
</table>
