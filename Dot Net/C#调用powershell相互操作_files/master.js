/**
* 消息处理实例
* @class message
* @static
**/
var message = {
    /**
    * 消息显示对象
    * @property content 消息显示对象 span
    * @type Object
    **/
    content: $('<span class="jmMessage fixed"></span>'),
    animate: null,
    /**
    * 弹出消息框
    * @method show
    **/
    show: function (op) {
        if (this.animate) this.animate.stop();
        if (op.css) { this.content.removeClass(op.css); this.content.addClass(op.css); }
        if (op.style) { this.content.attr('style', op.style); }
        this.content.appendTo('body');
        if (op.html) this.content.html(op.html);
        else if (op.text) this.content.text(op.text);

        this.content.css('opacity', 1);
        this.content.show();
        if (op.timeout > 0) {
            //关闭
            this.animate = message.content.animate({ opacity: 0 }, op.timeout, function () {
                message.hide();
            });
        }
    },
    /**
    * 隐藏
    * @method hide
    **/
    hide: function () {
        this.content.hide();
    },
    /**
    * 显示等待窗口
    * @method waiting
    **/
    waiting: function (msg) {
        this.show({
            html: '<img src="' + $jm.rootUrl + '/images/waitinfo.gif"' + ' />&nbsp;' + msg,
            css: 'warning',
            timeout: 0
        });
    },
    /**
    * 显示警告窗口
    * @method warning
    **/
    warning: function (msg) {
        message.show({
            html: msg,
            timeout: 4000,
            css: 'warning'
        });
    }
};

//$(function () {
//    //加入低浏览器警告
//    if ($.browser.msie && $.browser.version < 9) {
//        message.show({
//        text:"请使用IE9及以上浏览器获得最佳效果",
//        timeout:4000,
//        css:'warning'
//        });
//    }
//});