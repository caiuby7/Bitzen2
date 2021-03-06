/*
	* eakroko.js - Copyright 2013 by Ernst-Andreas Krokowski
	* Framework for themeforest themes

	* Date: 2013-01-01
	*/

function resize_chosen() {
    $(".chzn-container").each(function () {
        var e = $(this);
        e.css("width", e.parent().width() + "px");
        e.find(".chzn-drop").css("width", e.parent().width() - 2 + "px");
        e.find(".chzn-search input").css("width", e.parent().width() - 37 + "px")
    })
}(function (e) {
    e.fn.retina = function (t) {
        var n = {
            retina_part: "-2x"
        };
        t && jQuery.extend(n, {
            retina_part: t
        });
        window.devicePixelRatio >= 2 && this.each(function (t, r) {
            if (!e(r).attr("src")) return;
            var i = new RegExp("(.+)(" + n.retina_part + "\\.\\w{3,4})");
            if (i.test(e(r).attr("src"))) return;
            var s = e(r).attr("src").replace(/(.+)(\.\w{3,4})$/, "$1" + n.retina_part + "$2");
            e.ajax({
                url: s,
                type: "HEAD",
                success: function () {
                    e(r).attr("src", s)
                }
            })
        });
        return this
    }
})(jQuery);
$(document).ready(function () {
    var e = !1,
        t = !0,
        n = "button-active";
    /Android|webOS|iPhone|iPad|iPod|BlackBerry/i.test(navigator.userAgent) && (e = !0);
    $(".chart").length > 0 && $(".chart").each(function () {
        var e = "#881302",
            t = $(this);
        t.attr("data-color") ? e = t.attr("data-color") : parseInt(t.attr("data-percent")) <= 25 ? e = "#046114" : parseInt(t.attr("data-percent")) > 25 && parseInt(t.attr("data-percent")) < 75 && (e = "#dfc864");
        t.easyPieChart({
            animate: 1e3,
            barColor: e,
            lineWidth: 5,
            size: 110
        })
    });
   
    $(".notify").click(function () {
        var e = $(this),
            t = e.attr("data-notify-title"),
            n = e.attr("data-notify-message"),
            r = e.attr("data-notify-time"),
            i = e.attr("data-notify-sticky"),
            s = e.attr("data-notify-overlay");
        $.gritter.add({
            title: typeof t != "undefined" ? t : "Message - Head",
            text: typeof n != "undefined" ? n : "Body",
            image: typeof image != "undefined" ? image : null,
            sticky: typeof i != "undefined" ? i : !1,
            time: typeof r != "undefined" ? r : 3e3
        })
    });
    $(".mask_date").length > 0 && $(".mask_date").mask("99/99/9999");
    $(".mask_time").length > 0 && $(".mask_time").mask("99:99");
    $(".mask_phone").length > 0 && $(".mask_phone").mask("(999) 999-9999");
    $(".mask_serialNumber").length > 0 && $(".mask_serialNumber").mask("9999-9999-99");
    $(".mask_productNumber").length > 0 && $(".mask_productNumber").mask("aaa-9999-a");
    $(".tagsinput").length > 0 && $(".tagsinput").tagsInput({
        width: "auto",
        height: "auto"
    });
    $(".datepick").length > 0 && $(".datepick").datepicker();
    $(".timepick").length > 0 && $(".timepick").timepicker({
        defaultTime: "current",
        minuteStep: 1,
        showMeridian: false,
        disableFocus: !0, 
        template: "dropdown"
    });
    $(".colorpick").length > 0 && $(".colorpick").colorpicker();
    $(".uniform-me").length > 0 && $(".uniform-me").uniform({
        radioClass: "uni-radio",
        buttonClass: "uni-button"
    });
    $(".chosen-select").length > 0 && $(".chosen-select").each(function () {
        var e = $(this),
            t = e.attr("data-nosearch") === "true" ? !0 : !1,
            n = {};
        t && (n.disable_search_threshold = 9999999);
        e.chosen(n)
    });
    $(".multiselect").length > 0 && $(".multiselect").each(function () {
        var e = $(this),
            t = e.attr("data-selectableheader"),
            n = e.attr("data-selectionheader");
        t != undefined && (t = "<div class='multi-custom-header'>" + t + "</div>");
        n != undefined && (n = "<div class='multi-custom-header'>" + n + "</div>");
        e.multiSelect({
            selectionHeader: n,
            selectableHeader: t
        })
    });
    $(".spinner").length > 0 && $(".spinner").spinner();
    $(".filetree").length > 0 && $(".filetree").each(function () {
        var e = $(this),
            t = {};
        t.debugLevel = 0;
        e.hasClass("filetree-callbacks") && (t.onActivate = function (e) {
            console.log(e.data);
            $(".activeFolder").text(e.data.title);
            $(".additionalInformation").html("<ul style='margin-bottom:0;'><li>Key: " + e.data.key + "</li><li>is folder: " + e.data.isFolder + "</li></ul>")
        });
        if (e.hasClass("filetree-checkboxes")) {
            t.checkbox = !0;
            t.onSelect = function (e, t) {
                var n = t.tree.getSelectedNodes(),
                    r = $.map(n, function (e) {
                        return "[" + e.data.key + "]: '" + e.data.title + "'"
                    });
                $(".checkboxSelect").text(r.join(", "))
            }
        }
        e.dynatree(t)
    });
    $(".colorbox-image").length > 0 && $(".colorbox-image").colorbox({
        maxWidth: "90%",
        maxHeight: "90%",
        rel: $(this).attr("rel")
    });
    if ($("#user").length > 0) {
        $.mockjaxSettings.responseTime = 500;
        $.mockjax({
            url: "/post",
            response: function (e) {}
        });
        $.mockjax({
            url: "/error",
            status: 400,
            statusText: "Bad Request",
            response: function (e) {
                this.responseText = "Please input correct value"
            }
        });
        $.mockjax({
            url: "/status",
            status: 500,
            response: function (e) {
                this.responseText = "Internal Server Error"
            }
        });
        $.mockjax({
            url: "/groups",
            response: function (e) {
                this.responseText = [{
                    value: 0,
                    text: "Guest"
                }, {
                    value: 1,
                    text: "Service"
                }, {
                    value: 2,
                    text: "Customer"
                }, {
                    value: 3,
                    text: "Operator"
                }, {
                    value: 4,
                    text: "Support"
                }, {
                    value: 5,
                    text: "Admin"
                }]
            }
        })
    }
    if ($(".plupload").length > 0) {
        $(".plupload").pluploadQueue({
            runtimes: "html5,gears,flash,silverlight,browserplus",
            url: "js/plupload/upload.php",
            max_file_size: "10mb",
            chunk_size: "1mb",
            unique_names: !0,
            resize: {
                width: 320,
                height: 240,
                quality: 90
            },
            filters: [{
                title: "Image files",
                extensions: "jpg,gif,png"
            }, {
                title: "Zip files",
                extensions: "zip"
            }],
            flash_swf_url: "js/plupload/plupload.flash.swf",
            silverlight_xap_url: "js/plupload/plupload.silverlight.xap"
        });
        $(".plupload_header").remove();
        $(".plupload_progress_container").addClass("progress").addClass("progress-striped");
        $(".plupload_progress_bar").addClass("bar");
        $(".plupload_button").each(function () {
            $(this).hasClass("plupload_add") ? $(this).attr("class", "btn pl_add btn-primary").html("<i class='icon-plus-sign'></i> " + $(this).html()) : $(this).attr("class", "btn pl_start btn-success").html("<i class='icon-cloud-upload'></i> " + $(this).html())
        })
    }
    $(".form-wizard").length > 0 && $(".form-wizard").formwizard({
        formPluginEnabled: !0,
        validationEnabled: !0,
        focusFirstInput: !1,
        disableUIStyles: !0,
        validationOptions: {
            errorElement: "span",
            errorClass: "help-block error",
            errorPlacement: function (e, t) {
                t.parents(".controls").append(e)
            },
            highlight: function (e) {
                $(e).closest(".control-group").removeClass("error success").addClass("error")
            },
            success: function (e) {
                e.addClass("valid").closest(".control-group").removeClass("error success").addClass("success")
            }
        },
        formOptions: {
            success: function () {},
            beforeSubmit: function () {},
            dataType: "json",
            resetForm: !0
        }
    });
    $(".form-validate").length > 0 && $(".form-validate").each(function () {
        var e = $(this).attr("id");
        $("#" + e).validate({
            errorElement: "span",
            errorClass: "help-block error",
            errorPlacement: function (e, t) {
                t.parents(".controls").append(e)
            },
            highlight: function (e) {
                $(e).closest(".control-group").removeClass("error success").addClass("error")
            },
            success: function (e) {
                e.addClass("valid").closest(".control-group").removeClass("error success").addClass("success")
            }
        })
    });
    $(".dataTable").length > 0 && $(".dataTable").each(function () {
        var e = {
            sPaginationType: "full_numbers",
            oLanguage: {
                sSearch: "<span>Buscar:</span> ",
                sInfo: "Mostrando <span>_START_</span> até <span>_END_</span> no total de <span>_TOTAL_</span> registro(s)",
                sLengthMenu: "_MENU_ <span>quantidade de registros por página</span>"
            }
           

        };
        if ($(this).hasClass("dataTable-noheader")) {
            e.bFilter = !1;
            e.bLengthChange = !1
        }
        if ($(this).hasClass("dataTable-nofooter")) {
            e.bInfo = !1;
            e.bPaginate = !1
        }
        if ($(this).hasClass("dataTable-nosort")) {
            var t = $(this).data("nosort");
            t = t.split(",");
            for (var n = 0; n < t.length; n++) t[n] = parseInt(t[n]);
            e.aoColumnDefs = [{
                bSortable: !1,
                aTargets: t
            }]
        }
        if ($(this).hasClass("dataTable-scroll-x")) {
            e.sScrollX = "100%";
            e.bScrollCollapse = !0
        }
        if ($(this).hasClass("dataTable-scroll-y")) {
            e.sScrollY = "300px";
            e.bPaginate = !1;
            e.bScrollCollapse = !0
        }
        $(this).hasClass("dataTable-reorder") && (e.sDom = "Rlfrtip");
        if ($(this).hasClass("dataTable-colvis")) {
            e.sDom = 'C<"clear">lfrtip';
            e.oColVis = {
                buttonText: "Change columns <i class='icon-angle-down'></i>"
            }
        }
        if ($(this).hasClass("dataTable-tools")) {
            e.sDom = 'T<"clear">lfrtip';
            e.oTableTools = {
                sSwfPath: "js/plugins/datatable/swf/copy_csv_xls_pdf.swf"
            }
        }
        if ($(this).hasClass("dataTable-scroller")) {
            e.sScrollY = "300px";
            e.bDeferRender = !0;
            e.sDom = "frtiS";
            e.sAjaxSource = "js/plugins/datatable/demo.txt"
        }
        var r = $(this).dataTable(e);
        $(".dataTables_filter input").attr("placeholder", "Busque aqui...");
        $(".dataTables_length select").wrap("<div class='input-mini'></div>").chosen({
            disable_search_threshold: 9999999
        });
        $(this).hasClass("dataTable-fixedcolumn") && new FixedColumns(r)
    });
    resize_chosen();
    $(".file-manager").length > 0 && $(".file-manager").elfinder({
        url: "js/plugins/elfinder/php/connector.php"
    });
    $(".slider").length > 0 && $(".slider").each(function () {
        var e = $(this),
            t = parseInt(e.attr("data-min")),
            n = parseInt(e.attr("data-max")),
            r = parseInt(e.attr("data-step")),
            i = e.attr("data-range"),
            s = parseInt(e.attr("data-rangestart")),
            o = parseInt(e.attr("data-rangestop")),
            u = {
                min: t,
                max: n,
                step: r,
                slide: function (t, n) {
                    e.find(".amount").html(n.value)
                }
            };
        if (i !== undefined) {
            u.range = !0;
            u.values = [s, o];
            u.slide = function (t, n) {
                e.find(".amount").html(n.values[0] + " - " + n.values[1])
            }
        }
        e.slider(u);
        if (i !== undefined) {
            var a = e.slider("values");
            e.find(".amount").html(a[0] + " - " + a[1])
        } else e.find(".amount").html(e.slider("value"))
    });
    $(".ckeditor").length > 0 && CKEDITOR.replace("ck");
});
$(window).resize(function () {
    resize_chosen()
});