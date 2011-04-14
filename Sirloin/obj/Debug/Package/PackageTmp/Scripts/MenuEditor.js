/// <reference path="jquery-1.4.4.min.js" />

$(document).ready(function () {

    $("#menutree")
		.jstree({
		    "plugins": ["themes", "json_data", "ui", "crrm", "dnd"],
		    "json_data": {
		        "ajax": {
		            "url": currentUrl + "CurrentMenu",
		            "data": function (n) {
		                return { id: n.attr ? n.attr("id") : 0 };
		            }
		        }
		    },
		    "dnd": {
		        "drag_check": function (data) {
		            if (data.r.attr("id") == "phtml_1") {
		                return false;
		            }
		            return {
		                after: false,
		                before: false,
		                inside: true
		            };
		        },
		        "drag_finish": function (data) {
		            alert(data);
		        }
		    }
		});
    $.getJSON(currentUrl + "PagesNotInMenu", function (data) {
        var contenedor = $("#pageslist");
        for (var i = 0; i < data.length; i++) {
            contenedor.append("<div class=\"jstree-draggable\"><span>" + data[i].ShortID + "</span><span>" + data[i].Title + "</span></div>");
        }
    });

});