var dragDropCatalogZone = function(catalogZoneId){
    this._catalogZoneId = catalogZoneId;
}

dragDropCatalogZone.prototype.initialize = function(){
    var catalogZone = document.getElementById(this._catalogZoneId);
    var draggable = document.getElementById(this._catalogZoneId + '_draggable');
    var images = draggable.getElementsByTagName('img');
    var inputs = draggable.getElementsByTagName('input');
    for (var i=0;i<images.length;i++)
    {
    　　//将图标变成可拖拉对象
        var catItem = new WebPart(images[i],images[i]);
        images[i].webPartId = inputs[i].value;
        //将dragend事件的响应改成自定义方法
        images[i].detachEvent("ondragend", WebPart_OnDragEnd);
        images[i].attachEvent("ondragend", this.createDragCompletedHandler());
    }
}


dragDropCatalogZone.prototype.createDragCompletedHandler = function (){
    var zoneId = this._catalogZoneId;
    return function(){
        dragDropCatalogZone.completeAddWebPartDragDrop.call(__wpm,zoneId);
    }
}

dragDropCatalogZone.completeAddWebPartDragDrop = function (zoneId) {
    //可从dragState对象中取得被拖动对象，及该对象的zone、part等信息
    var dragState = this.dragState;
    this.dragState = null;
    if (dragState.dropZoneElement != null) {
        dragState.dropZoneElement.__zone.ToggleDropCues(
            false, dragState.dropIndex, false);
    }
    document.body.detachEvent("ondragover", Zone_OnDragOver);
    for (var i = 0; i < __wpm.zones.length; i++) {
        __wpm.zones[i].allowDrop = false;
    }
    this.overlayContainerElement.removeChild(
        this.overlayContainerElement.firstChild);
    this.overlayContainerElement.style.display = "none";
    if ((dragState != null) && (dragState.dropped == true)) {
        var currentZone = dragState.webPartElement.__webPart.zone;
        var currentZoneIndex = dragState.webPartElement.__webPart.zoneIndex;
        if ((currentZone != dragState.dropZoneElement.__zone) ||
            ((currentZoneIndex != dragState.dropIndex) &&
             (currentZoneIndex != (dragState.dropIndex - 1)))) {            
            var eventTarget = zoneId;
            //提交事件参数格式：Add:被拖动的WebPart的Id:拖放到的区域Id:拖放到区域的位置
            var eventArgument = 'Add:' 
                + dragState.webPartElement.webPartId + ':' 
                + dragState.dropZoneElement.__zone.uniqueID + ':' 
                + dragState.dropIndex;
            this.SubmitPage(eventTarget, eventArgument);
        }
    }
}