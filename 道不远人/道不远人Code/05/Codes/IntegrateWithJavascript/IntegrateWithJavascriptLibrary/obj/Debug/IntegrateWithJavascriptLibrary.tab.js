function tabsOnCallback(tabControlID,selectedIndex){
    $("#"+tabControlID + " .ajax__tab_active").removeClass("ajax__tab_active");
    $("#"+tabControlID + " .ajax__tab_header/span:eq("+selectedIndex+")").addClass("ajax__tab_active");
    $("#"+tabControlID).attr('disabled','disabled');
}

function tabsOnResult(result,controlID){
    $("#"+controlID + " .ajax__tab_panel").html(result);
    $("#"+controlID).removeAttr('disabled');
}

