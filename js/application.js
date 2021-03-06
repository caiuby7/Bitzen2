function slimScrollUpdate(e, t) {
    if (e.length > 0) {
        var n = parseInt(e.attr("data-height")),
            r = e.attr("data-visible") == "true" ? !0 : !1,
            i = e.attr("data-start") == "bottom" ? "bottom" : "top",
            s = {
                height: n,
                color: "#666",
                start: i
            };
        if (r) {
            s.alwaysVisible = !0;
            s.disabledFadeOut = !0
        }
        t !== undefined && (s.scrollTo = t + "px");
        e.slimScroll(s)
    }
}

function destroySlimscroll(e) {
    e.parent().replaceWith(e)
}

function checkLeftNav() {
    var e = $(window);
    if (e.width() <= 767) {
        $("#left").hide();
        $("#main").css("margin-left", 0);
        $(".toggle-mobile").length == 0 && $("#navigation .user").after('<a href="#" class="toggle-mobile"><i class="icon-reorder"></i></a>');
        $(".mobile-nav").length == 0 && createSubNav();
        if (!$("#content").hasClass("nav-fixed")) {
            $("#content").addClass("nav-fixed forced-fixed");
            $("#navigation").addClass("navbar-fixed-top")
        }
    } else {
        if (!$("#left").is(":visible") && !$("#left").hasClass("forced-hide")) {
            $("#left").show();
            $("#main").css("margin-left", $("#left").width())
        }
        $(".toggle-mobile").remove();
        $(".mobile-nav").removeClass("open");
        if ($("#content").hasClass("forced-fixed")) {
            $("#content").removeClass("nav-fixed");
            $("#navigation").removeClass("navbar-fixed-top")
        }
        e.width() < 1200 && $("#navigation .container").length > 0 && $(".version-toggle .set-fluid").trigger("click")
    }
}

function resizeHandlerHeight() {
    var e = $(window).height(),
        t = $(window).scrollTop() == 0 ? 40 : 0;
    $("#left .ui-resizable-handle").height(e - t)
}

function toggleMobileNav() {
    var e = $(".mobile-nav");
    e.toggleClass("open")
}

function createSubNav() {
    if ($(".mobile-nav").length == 0) {
        var e = $("#navigation .main-nav");
        $("#navigation .main-nav").parent().after("<ul class='mobile-nav'></ul>");
        var t = $(".mobile-nav");
        e.find("> li > a").each(function (e) {
            var n = $(this),
                r = "",
                i = "";
            if (n.hasClass("dropdown-toggle")) {
                i = " <i class='icon-angle-left'></i>";
                r += "<ul>";
                n.parent().find(".dropdown-menu > li > a").each(function () {
                    r += "<li><a href='" + $(this).attr("href") + "'>" + $(this).text() + "</a></li>"
                });
                r += "</ul>"
            }
            t.append("<li><a href='" + n.attr("href") + "'>" + n.text() + i + "</a>" + r + "</li>")
        });
        $(".mobile-nav > li > a").click(function (e) {
            var t = $(this);
            if (t.next().length !== 0) {
                e.preventDefault();
                var n = t.next();
                t.parents(".mobile-nav").find(".open").not(n).each(function () {
                    var e = $(this);
                    e.removeClass("open");
                    e.prev().find("i").removeClass("icon-angle-down").addClass("icon-angle-left")
                });
                n.toggleClass("open");
                t.find("i").toggleClass("icon-angle-left").toggleClass("icon-angle-down")
            }
        })
    }
}
$(document).ready(function () {
    createSubNav();
    $(".breadcrumbs .close-bread > a").click(function (e) {
        e.preventDefault();
        $(".breadcrumbs").fadeOut()
    });
    $("#navigation").on("click", ".toggle-mobile", function (e) {
        e.preventDefault();
        console.log("asdf");
        toggleMobileNav()
    });
    $(".content-slideUp").click(function (e) {
        e.preventDefault();
        var t = $(this),
            n = t.parents(".box").find(".box-content");
        n.slideToggle("fast", function () {
            t.find("i").toggleClass("icon-angle-up").toggleClass("icon-angle-down");
            t.find("i").hasClass("icon-angle-up") ? n.hasClass("scrollable") && destroySlimscroll(n) : n.hasClass("scrollable") && slimScrollUpdate(n)
        })
    });
    $(".content-remove").click(function (e) {
        e.preventDefault();
        var t = $(this),
            n = t.parents("[class*=span]"),
            r = parseInt(n.attr("class").replace("span", "")),
            i = n.prev().length > 0 ? n.prev() : n.next();
        if (i.length > 0) var s = parseInt(i.attr("class").replace("span", ""));
        bootbox.animate(!1);
        bootbox.confirm("Do you really want to remove the widget <strong>" + t.parents(".box-title").find("h3").text() + "</strong>?", "Cancel", "Yes, remove", function (e) {
            if (e) {
                t.parents("[class*=span]").remove();
                i.length > 0 && i.removeClass("span" + s).addClass("span" + (s + r))
            }
        })
    });
    $(".content-refresh").click(function (e) {
        e.preventDefault();
        var t = $(this);
        t.find("i").addClass("icon-spin");
        setTimeout(function () {
            t.find("i").removeClass("icon-spin")
        }, 2e3)
    });
    $("#vmap").length > 0 && $("#vmap").vectorMap({
        map: "world_en",
        backgroundColor: null,
        color: "#ffffff",
        hoverOpacity: .7,
        selectedColor: "#2d91ef",
        enableZoom: !0,
        showTooltip: !1,
        values: sample_data,
        scaleColors: ["#8cc3f6", "#5c86ac"],
        normalizeFunction: "polynomial"
    });
    $(".custom-checkbox").each(function () {
        var e = $(this);
        e.hasClass("checkbox-active") && e.find("i").toggleClass("icon-check-empty").toggleClass("icon-check");
        e.bind("click", function (t) {
            t.preventDefault();
            e.find("i").toggleClass("icon-check-empty").toggleClass("icon-check");
            e.toggleClass("checkbox-active")
        })
    });
    $(".toggle-subnav").click(function (e) {
        e.preventDefault();
        var t = $(this);
        t.parents(".subnav").toggleClass("subnav-hidden").find(".subnav-menu").slideToggle("fast");
        t.find("i").toggleClass("icon-angle-down").toggleClass("icon-angle-right")
    });
    $(".scrollable").length > 0 && $(".scrollable").each(function () {
        var e = $(this),
            t = parseInt(e.attr("data-height")),
            n = e.attr("data-visible") == "true" ? !0 : !1,
            r = e.attr("data-start") == "bottom" ? "bottom" : "top",
            i = {
                height: t,
                color: "#666",
                start: r
            };
        if (n) {
            i.alwaysVisible = !0;
            i.disabledFadeOut = !0
        }
        e.slimScroll(i)
    });
    $("#message-form .text input").on("focus", function (e) {
        var t = $(this);
        t.parents(".messages").find(".typing").addClass("active").find(".name").html("John Doe");
        slimScrollUpdate(t.parents(".scrollable"), 1e5)
    });
    $("#message-form .text input").on("blur", function (e) {
        var t = $(this);
        t.parents(".messages").find(".typing").removeClass("active");
        slimScrollUpdate(t.parents(".scrollable"), 1e5)
    });
    $("#message-form").submit(function (e) {
        e.preventDefault();
        var t = $(this),
            n = new Array("Lorem ipsum incididunt dolor...", "Lorem ipsum velit in incididunt id consectetur commodo.", "Lorem ipsum voluptate dolore occaecat reprehenderit anim elit nostrud.", "Lorem ipsum in dolor Excepteur et non sunt elit non officia in qui deserunt cupidatat aliquip."),
            r = t.find("input[type=text]").val(),
            i = t.parents(".messages");
        if (t.find("button").attr("disabled") == undefined) {
            var s = i.find(".right").first().clone(),
                o = i.find(".left").first().clone();
            o.find(".message p").html(n[Math.floor(Math.random() * 4)]);
            o.find(".message .time").html("Just now");
            s.find(".message p").html(r);
            s.find(".message .time").html("Just now");
            i.find(".typing").before(s);
            slimScrollUpdate(i.parents(".scrollable"), 1e5);
            t.find("button").attr("disabled", "disabled");
            i.find(".typing").removeClass("active");
            setTimeout(function () {
                i.find(".typing").addClass("active");
                i.find(".typing .name").html("Jane Doe");
                slimScrollUpdate(i.parents(".scrollable"), 1e5)
            }, 300);
            setTimeout(function () {
                i.find(".typing").before(o);
                slimScrollUpdate(i.parents(".scrollable"), 1e5);
                t.find("button").removeAttr("disabled");
                i.find(".typing").removeClass("active")
            }, 1500)
        }
    });
    $("#left").resizable({
        minWidth: 60,
        handles: "e",
        resize: function (e, t) {
            var n = $(".search-form .search-pane input[type=text]"),
                r = $("#main");
            n.css({
                width: t.size.width - 55
            });
            if (Math.abs(200 - t.size.width) <= 20) {
                $("#left").css("width", 200);
                n.css("width", 145);
                r.css("margin-left", 200)
            } else r.css("margin-left", $("#left").width())
        },
        stop: function () {
            $("#left .ui-resizable-handle").css("background", "none")
        },
        start: function () {
            $("#left .ui-resizable-handle").css("background", "#aaa")
        }
    });

    $(".toggle-nav").click(function (e) {
        e.preventDefault();
        $("#left").toggle().toggleClass("forced-hide");
        $("#left").is(":visible") ? $("#main").css("margin-left", $("#left").width()) : $("#main").css("margin-left", 0)
    });
    $(".table-mail .sel-star").click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        var t = $(this);
        t.toggleClass("active")
    });
    $(".table .sel-all").change(function (e) {
        e.preventDefault();
        e.stopPropagation();
        var t = $(this);
        t.parents(".table").find("tbody .selectable").prop("checked", t.prop("checked"))
    });
    $(".table-mail > tbody > tr").click(function (e) {
        var t = $(this),
            n = t.find(".table-checkbox > input");
        t.toggleClass("warning");
        e.target.nodeName != "INPUT" && n.prop("checked", !n.prop("checked"))
    });
    resizeHandlerHeight();
    $(".table .alpha").click(function (e) {
        e.preventDefault();
        var t = $(this),
            n = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            r = "",
            i = [];
        t.parents().find(".alpha .alpha-val span").each(function () {
            i.push($(this).text())
        });
        for (var s = 0; s < n.length; s++) {
            var o = $.inArray(n.charAt(s), i) != -1 ? " class='active'" : "";
            r += "<li" + o + "><span>" + n.charAt(s) + "</span></li>"
        }
        t.parents(".table").before("<div class='letterbox'><ul class='letter'>" + r + "</ul></div>");
        $(".letterbox .letter > .active").click(function () {
            var e = $(this);
            slimScrollUpdate(e.parents(".scrollable"), 0);
            var t = e.parents(".box-content").find(".table .alpha:contains('" + e.text() + "')");
            slimScrollUpdate(e.parents(".scrollable"), t.position().top);
            e.parents(".letterbox").remove()
        })
    });
    $(".theme-colors > li > span").hover(function (e) {
        var t = $(this),
            n = $("body");
        n.attr("class", "").addClass("theme-" + t.attr("class"))
    }, function () {
        var e = $(this),
            t = $("body");
        t.attr("data-theme") !== undefined ? t.attr("class", "").addClass(t.attr("data-theme")) : t.attr("class", "")
    }).click(function () {
        var e = $(this);
        $("body").addClass("theme-" + e.attr("class")).attr("data-theme", "theme-" + e.attr("class"))
    });
    $(".version-toggle > a").click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        var t = $(this),
            n = t.parent();
        if (!t.hasClass("active")) {
            n.find(".active").removeClass("active");
            t.addClass("active")
        }
        if (t.hasClass("set-fixed")) {
            if ($(window).width() >= 1200) {
                $("#content").addClass("container").removeClass("container-fluid");
                $("#navigation .container-fluid").addClass("container").removeClass("container-fluid");
                $("#left").hasClass("sidebar-fixed") && $("#left").css("left", $("#content").offset().left)
            }
        } else {
            $("#content").addClass("container-fluid").removeClass("container");
            $("#navigation .container").addClass("container-fluid").removeClass("container");
            $("#left").css("left", 0)
        }
    });
    $(".topbar-toggle > a").click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        var t = $(this),
            n = t.parent();
        if (!t.hasClass("active")) {
            n.find(".active").removeClass("active");
            t.addClass("active")
        }
        if (t.hasClass("set-topbar-fixed")) {
            $("#content").addClass("nav-fixed");
            $("#navigation").addClass("navbar-fixed-top")
        } else {
            $("#content").removeClass("nav-fixed");
            $("#navigation").removeClass("navbar-fixed-top")
        }
    });
    $(".sidebar-toggle > a").click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        var t = $(this),
            n = t.parent();
        if (!t.hasClass("active")) {
            n.find(".active").removeClass("active");
            t.addClass("active")
        }
        $(".search-form .search-pane input").attr("style", "");
        $("#main").attr("style", "");
        if (t.hasClass("set-sidebar-fixed")) {
            $("#left").attr("style", "").addClass("sidebar-fixed");
            $("#left .ui-resizable-handle").css("top", 0);
            $("#content").hasClass("container") && $("#left").css("left", $("#content").offset().left)
        } else $("#left").removeClass("sidebar-fixed").attr("style", "")
    });
    $(".del-gallery-pic").click(function (e) {
        e.preventDefault();
        var t = $(this),
            n = t.parents("li");
        n.fadeOut(400, function () {
            n.remove()
        })
    });
    checkLeftNav();
    $("body").attr("data-layout") == "fixed" && $(".version-toggle .set-fixed").trigger("click");
    $("body").attr("data-layout-topbar") == "fixed" && $(".topbar-toggle .set-topbar-fixed").trigger("click");
    $("body").attr("data-layout-sidebar") == "fixed" && $(".sidebar-toggle .set-sidebar-fixed").trigger("click")
});
$.fn.scrollBottom = function () {
    return $(document).height() - this.scrollTop() - this.height()
};
$(window).scroll(function (e) {
    var t = 0;
    if ($(window).scrollTop() == 0 || $("#left").hasClass("sidebar-fixed")) $("#left .ui-resizable-handle").css("top", t);
    else {
        $(window).scrollTop() + $("#left .ui-resizable-handle").height() <= $(document).height() ? t = $(window).scrollTop() - 40 : t = $(document).height() - $("#left .ui-resizable-handle").height() - 40;
        $("#left .ui-resizable-handle").css("top", t)
    } !$("#content").hasClass("nav-fixed") && $("#left").hasClass("sidebar-fixed") && ($(window).scrollTop() < 40 ? $("#left").css("top", 40 - $(window).scrollTop()) : $("#left").css("top", 0));
    resizeHandlerHeight()
});
$(window).resize(function (e) {
    checkLeftNav()
});