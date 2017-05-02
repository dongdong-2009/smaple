/**
* 文章明细页处理
* 生成回复框，与处理用户回复等初始化
* @module content
* @class content
* @static
**/
var content = {
    /**
    * 当前文章的ID
    * @property projectId
    * @type Number   
    **/
    projectId: 0,

    /**
    * 回复类型,0表示项目,1表示文档，2表示IT
    * @property reType
    * @type Number   
    **/
    reType: 1,

    /**
    * 生成kindeditor回复框
    * @method createeditor
    * @param {String} id 编辑器所附加到的控件ID
    **/
    createEditor: function () {
        if (!$jm.browser.mobile && KE) {
            KE.show({
                id: content.reContent.reContentId,
                resizeMode: 1,
                allowPreviewEmoticons: false,
                allowUpload: false,
                items: [
				'fontname', 'fontsize', '|', 'textcolor', 'bgcolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });
        }
    },

    /**
    * 分享到其它网站，如腾讯微博等
    * @method postToWb
    * @param {String} url 分享到的地址
    * @param {String} title 分享标题 
    * @param {String} site 实分享的路径
    * @param {String} tourl URL地址
    * @param {String} key key的表示
    * @param {String} pic 图片路径
    * @param {String} cmd 备注
    **/
    postToWb: function (url, title, site, tourl, key, pic, cmd) {
        url = url || "http://v.t.qq.com/share/share.php";
        title = title || "title";
        tourl = tourl || "url";
        site = site || "site";
        key = key || "appkey";
        pic = pic || "pic";
        cmd = cmd || 'comment';
        var metas = document.getElementsByTagName("meta");
        var dctitle = document.title;
        var comment = '';
        for (var i = 0; i < metas.length; i++) {
            if (metas[i].name == 'description') { comment += " " + metas[i].content; }
        }
        dctitle = dctitle.replace(/c#/ig, 'csharp');
        var _t = encodeURI(dctitle);
        var _url = encodeURIComponent(document.location);
        var _appkey = encodeURI("b716cfc7fe464453ae1b67e2e1a6cda8"); //你从腾讯获得的appkey
        comment = encodeURI(comment);
        var picinfo = '';
        var cte = document.getElementById('ctl00_ContentPlaceHolder1__contentdiv');
        if (cte) {
            var imgs = cte.getElementsByTagName('img');
            if (imgs && imgs.length > 0) {
                for (var a = 0; a < imgs.length; i++) {
                    var src = imgs[a].src;
                    if (src.indexOf('http://') >= 0 || src.indexOf('https://') >= 0) {
                        picinfo += src;
                    }
                    else {
                        picinfo += rooturl + src;
                    }
                    picinfo += '|';
                }
            }
        }
        var _pic = encodeURI(picinfo); //（例如：var _pic='图片url1|图片url2|图片url3....）
        var _site = encodeURI($jm.rootUrl); //你的网站地址
        var _u = url + '?' + title + '=' + _t + '&' + tourl + '=' + _url + '&' + key + '=' + _appkey + '&' + site + '=' + _site + '&' + pic + '=' + _pic + '&' + cmd + '=' + comment;
        window.open(_u, '', 'top=0, left=0, toolbar=no, menubar=no, location=yes, status=no');
    },

    /**
    * 显示提示信息
    * @method showInfo
    **/
    showInfo: function (msg, t) {
        message.show({
            html: msg,
            timeout: 4000,
            css: 'warning'
        });
    },

    /**
    * 加载随机码
    * @method loadRnd
    **/
    loadRnd: function () {
        var img = $('#imgRnd');
        img.attr('src', '/Config/RndCode.aspx?id=JiaMao.JiaMaoCode.Web.Content.Rnd&r=' + Math.random());
        img.show();
    },

    /**
    * 文章评论
    * @property reContent
    * @type Object
    **/
    reContent: {
        /**
        * 当前评论页码
        * @property index
        * @type Number
        * @for reContent
        **/
        index: 1,
        /**
        * 回复输入框ID
        * @property reContentId
        * @type String
        * @for reContent
        **/
        reContentId: 'txtReContent',
        /**
        * 随机码输入框ID
        * @property reContentId
        * @type String
        * @for reContent
        **/
        rndInputId: 'txtRnd',

        /**
        * 加载评论的后台服务地址
        * @method handler
        * @type String
        * @for reContent
        **/
        handler: function () { return '/handler/Content.ashx' },

        /**
        * 获取回复的内容
        * @method content
        * @return String 内容
        * @for reContent
        **/
        content: function () {
            if (!$jm.browser.mobile && KE) return KE.html(this.reContentId)
            return $('#' + this.reContentId).val();
        },

        /**
        * 去除IP的后二位
        * @method handler
        * @param {String} ip ip地址
        * @return String 修改后的ip地址
        **/
        splitIp: function (ip) {
            var sp = ip.split('.');
            if (sp.length > 3) {
                sp[2] = '*';
                sp[3] = '*';
                ip = sp.join('.');
            }
            return ip;
        },

        /**
        * 加载评论的后台服务地址
        * @proerty pager
        * @type Object
        * @for reContent
        **/
        _pager: new $jm.paging({ change: function (index) {
            content.reContent.load(index);
        }, showCount: 1
        }),

        /**
        * 加载评论
        * @method load
        * @for reContent
        * @param
        **/
        load: function (p) {
            if (!p) p = this.index;
            $.ajax({
                url: this.handler(),
                cache: false,
                data: { 'cmd': 'get', 'id': content.projectId, 'p': p },
                success: function (h) {
                    var obj = $.parseJSON(h);
                    if ($jm.isNull(obj) || $jm.isNull(obj.Pojos)) {
                        $jm.out(h);
                    }
                    else {
                        var bg = $('#reContentList'); //显示回复区域                       
                        bg.html($jm.template("comment_tmpl", obj.Pojos));
                        content.reContent.index = obj.PageIndex;
                        content.reContent._pager.parent = bg;
                        content.reContent._pager.render({
                            index: obj.PageIndex,
                            count: obj.PageCount
                        });
                    }
                },
                error: function (e) {
                    $jm.out(e);
                }
            });
        },
        /**
        * 添加评论
        * @method load
        * @for reContent
        * @param
        **/
        insert: function () {
            var msg = this.content(); //输入的内容
            if ($.trim(msg) == '') {
                content.showInfo('请先输入要回复的内容');
                return;
            }
            var rnd = $('#' + this.rndInputId).val(); //输入的随机码
            if ($.trim(rnd) == '') {
                content.showInfo('请输入随机码');
                return;
            }
            if (rnd.length < 4) {
                content.showInfo('随机码输入不正确');
                return;
            }
            message.waiting('提交回复中...'); //显示等待
            msg = encodeURI(msg);
            $.ajax({
                url: this.handler(),
                type: 'post',
                data: { 'cmd': 'insert', 'id': content.projectId, 't': content.reType, 'content': msg, 'rnd': rnd },
                success: function (h) {
                    if (Number(h) > 0) {
                        content.showInfo('回复成功,感谢您的参与');
                        KE.html(content.reContent.reContentId, '')
                        content.reContent.load(); //重新加载回复
                    }
                    else {
                        content.showInfo(h);
                    }
                    content.loadRnd(); //重置随机码
                },
                error: function (e) {
                    $jm.out(e);
                }
            });
        }
    },

    /**
    * 初始化
    * @method init
    **/
    init: function () {
        //初始化分享
        var sharearea = $('#sharearea');
        if (sharearea && sharearea.length > 0) {
            var _url = encodeURIComponent(document.location);
            /**
            * 新浪分享参数
            **/
            var sn_param = {
                url: location.href,
                type: '3',
                count: '1', /**是否显示分享数，1显示(可选)*/
                appkey: '2857842297', /**您申请的应用appkey,显示分享来源(可选)*/
                title: document.title, /**分享的文字内容(可选，默认为所在页面的title)*/
                pic: '', /**分享图片的路径(可选)*/
                ralateUid: '1151195511', /**关联用户的UID，分享微博会@该用户(可选)*/
                rnd: new Date().valueOf()
            }
            var sn_temp = [];
            for (var p in sn_param) {
                sn_temp.push(p + '=' + encodeURIComponent(sn_param[p] || ''))
            }

            var html = '&nbsp;分享到:&nbsp;<a href="javascript:void(0)" onclick="content.postToWb();" style="height:16px;font-size:12px;line-height:16px;">' +
              '<img src="http://v.t.qq.com/share/images/s/weiboicon16.png" border="0" title="转播到腾讯微博" /></a>&nbsp;' +
             '<iframe allowTransparency="true" frameborder="0" scrolling="no" src="http://hits.sinajs.cn/A1/weiboshare.html?' + sn_temp.join('&') + '" width="16" height="16"></iframe>&nbsp;' +
              '<a href="http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url=' + _url +
               '" target="_blank" title="转播到QQ空间"><img border="0" src="/images/ico_Qzone.gif"></a>&nbsp;' +
               '<a href="javascript:void(0)" onclick="content.postToWb(\'http://share.renren.com/share/buttonshare.do\',null,null,\'link\');" style="height:16px;font-size:12px;line-height:16px;">' +
              '<img src="http://a.xnimg.cn/imgpro/chat/app_menu_logo.png" border="0" title="分享到人人" /></a>&nbsp;'; //+
            //'<a href="javascript:void(0)" onclick="content.postToWb(\'http://www.douban.com/recommend/\',null,null,null,null,null,\'comment\');" style="height:16px;font-size:12px;line-height:16px;">' +
            //'<img src="/images/dbangif.gif" border="0" title="分享到豆瓣" /></a>';
            sharearea.html(html);
        };
    }
}




