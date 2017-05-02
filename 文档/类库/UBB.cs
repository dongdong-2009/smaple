using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace YxzjLib
{
    public class UBB
    {
        #region ������̬����
        /// <summary>
        /// UBB���봦����
        /// </summary>
        /// <param name="sDetail">�����ַ���</param>
        /// <returns>����ַ���</returns>
        public static string UBBToHTML(string sDetail)
        {
            Regex r;
            Match m;
            #region ����ո�
            sDetail = sDetail.Replace(" ", "&nbsp;");
            #endregion
            #region ��������
            sDetail = sDetail.Replace("'", "��");
            #endregion
            #region ����˫����
            sDetail = sDetail.Replace("\"", "&quot;");
            #endregion
            #region html��Ƿ�
            sDetail = sDetail.Replace("<", "&lt;");
            sDetail = sDetail.Replace(">", "&gt;");

            #endregion
            #region ������
            //�����У���ÿ�����е�ǰ���������ȫ�ǿո�
            r = new Regex(@"(\r\n((&nbsp;)|��)+)(?<����>\S+)", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<BR>����" + m.Groups["����"].ToString());
            }
            //�����У���ÿ�����е�ǰ���������ȫ�ǿո�
            sDetail = sDetail.Replace("\r\n", "<BR>");
            #endregion
            #region ��[b][/b]���
            r = new Regex(@"(\[b\])([ \S\t]*?)(\[\/b\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<B>" + m.Groups[2].ToString() + "</B>");
            }
            #endregion
            #region ��[i][/i]���
            r = new Regex(@"(\[i\])([ \S\t]*?)(\[\/i\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<I>" + m.Groups[2].ToString() + "</I>");
            }
            #endregion
            #region ��[u][/u]���
            r = new Regex(@"(\[U\])([ \S\t]*?)(\[\/U\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<U>" + m.Groups[2].ToString() + "</U>");
            }
            #endregion
            #region ��[p][/p]���
            //��[p][/p]���
            r = new Regex(@"((\r\n)*\[p\])(.*?)((\r\n)*\[\/p\])", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<P class=\"pstyle\">" + m.Groups[3].ToString() + "</P>");
            }
            #endregion
            #region ��[sup][/sup]���
            //��[sup][/sup]���
            r = new Regex(@"(\[sup\])([ \S\t]*?)(\[\/sup\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<SUP>" + m.Groups[2].ToString() + "</SUP>");
            }
            #endregion
            #region ��[sub][/sub]���
            //��[sub][/sub]���
            r = new Regex(@"(\[sub\])([ \S\t]*?)(\[\/sub\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<SUB>" + m.Groups[2].ToString() + "</SUB>");
            }
            #endregion
            #region ��[url][/url]���
            //��[url][/url]���
            r = new Regex(@"(\[url\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[2].ToString() + "</A>");
            }
            #endregion
            #region ��[url=xxx][/url]���
            //��[url=xxx][/url]���
            r = new Regex(@"(\[url=([ \S\t]+)\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[3].ToString() + "</A>");
            }
            #endregion
            #region ��[email][/email]���
            //��[email][/email]���
            r = new Regex(@"(\[email\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"mailto:" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[2].ToString() + "</A>");
            }
            #endregion
            #region ��[email=xxx][/email]���
            //��[email=xxx][/email]���
            r = new Regex(@"(\[email=([ \S\t]+)\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"mailto:" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[3].ToString() + "</A>");
            }
            #endregion
            #region ��[size=x][/size]���
            //��[size=x][/size]���
            r = new Regex(@"(\[size=([1-7])\])([ \S\t]*?)(\[\/size\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<FONT SIZE=" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</FONT>");
            }
            #endregion
            #region ��[color=x][/color]���
            //��[color=x][/color]���
            r = new Regex(@"(\[color=([\S]+)\])([ \S\t]*?)(\[\/color\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<FONT COLOR=" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</FONT>");
            }
            #endregion
            #region ��[face=x][/face]���
            //��[font=x][/font]���
            r = new Regex(@"(\[face=([\S]+)\])([ \S\t]*?)(\[\/face\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<FONT FACE=" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</FONT>");
            }
            #endregion
            #region ����ͼƬ����
            //����ͼƬ����
            r = new Regex("\\[picture\\](\\d+?)\\[\\/picture\\]", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"ShowImage.aspx?Type=ALL&Action=forumImage&ImageID=" + m.Groups[1].ToString() +
                 "\" target=\"_blank\"><IMG border=0 Title=\"������´��ڲ鿴\" src=\"ShowImage.aspx?Action=forumImage&ImageID=" + m.Groups[1].ToString() +
                 "\"></A>");
            }
            #endregion
            #region ����[align=x][/align]
            //����[align=x][/align]
            r = new Regex(@"(\[align=([\S]+)\])([ \S\t]*?)(\[\/align\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<P align=" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</P>");
            }
            #endregion
            #region ��[H=x][/H]���
            //��[H=x][/H]���
            r = new Regex(@"(\[H=([1-6])\])([ \S\t]*?)(\[\/H\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<H" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</H" + m.Groups[2].ToString() + ">");
            }
            #endregion
            #region ����[list=x][*][/list]
            //����[list=x][*][/list]
            r = new Regex(@"(\[list(=(A|a|I|i| ))?\]([ \S\t]*)\r\n)((\[\*\]([ \S\t]*\r\n))*?)(\[\/list\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                string strLI = m.Groups[5].ToString();
                Regex rLI = new Regex(@"\[\*\]([ \S\t]*\r\n?)", RegexOptions.IgnoreCase);
                Match mLI;
                for (mLI = rLI.Match(strLI); mLI.Success; mLI = mLI.NextMatch())
                {
                    strLI = strLI.Replace(mLI.Groups[0].ToString(), "<LI>" + mLI.Groups[1]);
                }
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<UL TYPE=\"" + m.Groups[3].ToString() + "\"><B>" + m.Groups[4].ToString() + "</B>" +
                 strLI + "</UL>");
            }

            #endregion
            #region ��[SHADOW=x][/SHADOW]���
            //��[SHADOW=x][/SHADOW]���
            r = new Regex(@"(\[SHADOW=)(\d*?),(#*\w*?),(\d*?)\]([\S\t]*?)(\[\/SHADOW\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<TABLE WIDTH=" + m.Groups[2].ToString() + "  STYLE=FILTER:SHADOW(COLOR=" + m.Groups[3].ToString() + ", STRENGTH=" + m.Groups[4].ToString() + ")>" +
                 m.Groups[5].ToString() + "</TABLE>");
            }
            #endregion
            #region ��[glow=x][/glow]���
            //��[glow=x][/glow]���
            r = new Regex(@"(\[glow=)(\d*?),(#*\w*?),(\d*?)\]([\S\t]*?)(\[\/glow\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<TABLE WIDTH=" + m.Groups[2].ToString() + "  STYLE=FILTER:GLOW(COLOR=" + m.Groups[3].ToString() + ", STRENGTH=" + m.Groups[4].ToString() + ")>" +
                 m.Groups[5].ToString() + "</TABLE>");
            }
            #endregion
            #region ��[center][/center]���
            r = new Regex(@"(\[center\])([ \S\t]*?)(\[\/center\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<CENTER>" + m.Groups[2].ToString() + "</CENTER>");
            }
            #endregion
            #region ��[IMG][/IMG]���
            r = new Regex(@"(\[IMG\])(http|https|ftp):\/\/([ \S\t]*?)(\[\/IMG\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<br><a onfocus=this.blur() href=" + m.Groups[2].ToString() + "://" + m.Groups[3].ToString() + " target=_blank><IMG SRC=" + m.Groups[2].ToString() + "://" + m.Groups[3].ToString() + " border=0 alt=�������´������ͼƬ onload=javascript:if(screen.width-333<this.width)this.width=screen.width-333></a>");
            }
            #endregion
            #region ��[em]���
            r = new Regex(@"(\[em([\S\t]*?)\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<img src=/images/em" + m.Groups[2].ToString() + ".gif border=0 align=middle>");
            }
            #endregion
            #region ��[flash=x][/flash]���
            //��[mp=x][/mp]���
            r = new Regex(@"(\[flash=)(\d*?),(\d*?)\]([\S\t]*?)(\[\/flash\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<a href=" + m.Groups[4].ToString() + " TARGET=_blank><IMG SRC=/images/swf.gif border=0 alt=������´������͸�FLASH����!> [ȫ������]</a><br><br><OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "><PARAM NAME=movie VALUE=" + m.Groups[4].ToString() + "><PARAM NAME=quality VALUE=high><param name=menu value=false><embed src=" + m.Groups[4].ToString() + " quality=high menu=false pluginspage=http://www.macromedia.com/go/getflashplayer type=application/x-shockwave-flash width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + ">" + m.Groups[4].ToString() + "</embed></OBJECT>");
            }
            #endregion
            #region ��[dir=x][/dir]���
            //��[dir=x][/dir]���
            r = new Regex(@"(\[dir=)(\d*?),(\d*?)\]([\S\t]*?)(\[\/dir\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<object classid=clsid:166B1BCA-3F9C-11CF-8075-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/director/sw.cab#version=7,0,2,0 width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "><param name=src value=" + m.Groups[4].ToString() + "><embed src=" + m.Groups[4].ToString() + " pluginspage=http://www.macromedia.com/shockwave/download/ width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "></embed></object>");
            }
            #endregion
            #region ��[rm=x][/rm]���
            //��[rm=x][/rm]���
            r = new Regex(@"(\[rm=)(\d*?),(\d*?)\]([\S\t]*?)(\[\/rm\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "><PARAM NAME=SRC VALUE=" + m.Groups[4].ToString() + "><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=32 id=video2 width=" + m.Groups[2].ToString() + "><PARAM NAME=SRC VALUE=" + m.Groups[4].ToString() + "><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>");
            }
            #endregion
            #region ��[mp=x][/mp]���
            //��[mp=x][/mp]���
            r = new Regex(@"(\[mp=)(\d*?),(\d*?)\]([\S\t]*?)(\[\/mp\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<object align=middle classid=CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95 class=OBJECT id=MediaPlayer width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + " ><param name=ShowStatusBar value=-1><param name=Filename value=" + m.Groups[4].ToString() + "><embed type=application/x-oleobject codebase=http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701 flename=mp src=" + m.Groups[4].ToString() + "  width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "></embed></object>");
            }
            #endregion
            #region ��[qt=x][/qt]���
            //��[qt=x][/qt]���
            r = new Regex(@"(\[qt=)(\d*?),(\d*?)\]([\S\t]*?)(\[\/qt\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<embed src=" + m.Groups[4].ToString() + " width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + " autoplay=true loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>");
            }
            #endregion
            #region ��[QUOTE][/QUOTE]���
            r = new Regex(@"(\[QUOTE\])([ \S\t]*?)(\[\/QUOTE\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<table cellpadding=0 cellspacing=0 border=1 WIDTH=94% bordercolor=#000000 bgcolor=#F2F8FF align=center  style=FONT-SIZE: 9pt><tr><td  ><table width=100% cellpadding=5 cellspacing=1 border=0><TR><TD >" + m.Groups[2].ToString() + "</table></table><br>");
            }
            #endregion
            #region ��[move][/move]���
            r = new Regex(@"(\[move\])([ \S\t]*?)(\[\/move\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<MARQUEE scrollamount=3>" + m.Groups[2].ToString() + "</MARQUEE>");
            }
            #endregion
            #region ��[FLY][/FLY]���
            r = new Regex(@"(\[FLY\])([ \S\t]*?)(\[\/FLY\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<MARQUEE width=80% behavior=alternate scrollamount=3>" + m.Groups[2].ToString() + "</MARQUEE>");
            }
            #endregion
            #region ��[image][/image]���
            //��[image][/image]���
            r = new Regex(@"(\[image\])([ \S\t]*?)(\[\/image\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<img src=\"" + m.Groups[2].ToString() + "\" border=0 align=middle><br>");
            }
            #endregion

            sDetail = Regex.Replace(sDetail, "&lt;br&gt;", "<br>", RegexOptions.IgnoreCase);

            return sDetail;
        }

//        public static string HTMLToUBB(string sDetail)
//        {
//            Regex r;
//            Match m;
//            #region ����ո�
//            sDetail = sDetail.Replace(" ", "&nbsp;");
//            #endregion
//            #region ��������
//            sDetail = sDetail.Replace("'", "��");
//            #endregion
//            #region ����˫����
//            sDetail = sDetail.Replace("\"", "&quot;");
//            #endregion
//            #region html��Ƿ�
//            sDetail = sDetail.Replace("<", "&lt;");
//            sDetail = sDetail.Replace(">", "&gt;");

//            #endregion
//            #region ������
//            //�����У���ÿ�����е�ǰ���������ȫ�ǿո�
//            r = new Regex(@"(\r\n((&nbsp;)|��)+)(?<����>\S+)", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<BR>����" + m.Groups["����"].ToString());
//            }
//            //�����У���ÿ�����е�ǰ���������ȫ�ǿո�
//            sDetail = sDetail.Replace("\r\n", "<BR>");
//            #endregion
//            #region ��[b][/b] [i][/i] [u][/u] [p][/p] [sup][/sup] [sub][/sub] [center][/center]���
//            r = new Regex(@"(\[sub\])([ \S\t]*?)(\[\/sub\])", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<SUB>" + m.Groups[2].ToString() + "</SUB>");
//            }
//            #endregion
//            #region ��[url][/url]���
//            //��[url][/url]���
//            r = new Regex(@"(\[url\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "<A href=\"" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
//                 m.Groups[2].ToString() + "</A>");
//            }
//            #endregion
//            #region ��[url=xxx][/url]���
//            //��[url=xxx][/url]���
//            r = new Regex(@"(\[url=([ \S\t]+)\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "<A href=\"" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
//                 m.Groups[3].ToString() + "</A>");
//            }
//            #endregion
//            #region ��[email][/email]���
//            //��[email][/email]���
//            r = new Regex(@"(\[email\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "<A href=\"mailto:" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
//                 m.Groups[2].ToString() + "</A>");
//            }
//            #endregion                    
                   
//            //------------------begin

//            #region ��[image][/image]���
//            r = new Regex("<img src=\"(.*?)\" border=0 align=middle><br>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "[image]" + m.Groups[2].ToString() + "[/image]");
//            }
//            #endregion

//            #region ��[FLY][/FLY]���
//            r = new Regex("<MARQUEE width=80% behavior=alternate scrollamount=3>(.*?)</MARQUEE>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                    "[fly]" + m.Groups[2].ToString() + "[/fly]");
//            }
//            #endregion

//            #region ��[move][/move]���
//            r = new Regex("<MARQUEE scrollamount=3>(.*?)</MARQUEE>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                    "[move]" + m.Groups[2].ToString() + "[/move]");
//            }
//            #endregion

//            #region ��[QUOTE][/QUOTE]���
//            r = new Regex("<table cellpadding=0 cellspacing=0 border=1 WIDTH=94% bordercolor=#000000 bgcolor=#F2F8FF align=center  style=FONT-SIZE: 9pt><tr><td  ><table width=100% cellpadding=5 cellspacing=1 border=0><TR><TD >(.*?)</table></table><br>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                    "[quote]" + m.Groups[2].ToString() + "[/quote]");
//            }
//            #endregion

//            #region ��[qt=x][/qt]���
//            r = new Regex(@"<embed src=([\S\t]*?) width=(\d*?) height=(\d*?) autoplay=true loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "<qt=" + m.Groups[3].ToString() + "," + m.Groups[4].ToString() + "]" + m.Groups[2].ToString() + "[/qt]");
//            }
//            #endregion

//            #region ��[mp=x][/mp]���
//            r = new Regex(@"<object align=middle classid=CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95 class=OBJECT id=MediaPlayer width=(\d*?) height=(\d*?) ><param name=ShowStatusBar value=-1><param name=Filename value=([\S\t]*?)><embed type=application/x-oleobject codebase=http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701 flename=mp src=([\S\t]*?)  width=(\d*?) height=(\d*?)></embed></object>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                    "[mp=" + m.Groups[2].ToString() + "," + m.Groups[3].ToString() + "]" + m.Groups[4].ToString() + "[/mp]");
//            }
//            #endregion

//            #region ��[rm=x][/rm]���
//            r = new Regex(@"<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=(\d*?) height=(\d*?)><PARAM NAME=SRC VALUE=([\S\t]*?)><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=32 id=video2 width=(\d*?)><PARAM NAME=SRC VALUE=([\S\t]*?)><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                    "[rm=" + m.Groups[2].ToString() + "," + m.Groups[3].ToString() + "]" + m.Groups[4].ToString() + "[/rm]");
//            }
//            #endregion

//            #region ��[dir=x][/dir]���
//            r = new Regex(@"<object classid=clsid:166B1BCA-3F9C-11CF-8075-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/director/sw.cab#version=7,0,2,0 width=(\d*?) height=(\d*?)><param name=src value=([\S\t]*?)><embed src=([\S\t]*?) pluginspage=http://www.macromedia.com/shockwave/download/ width=(\d*?) height=(\d*?)></embed></object>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                    "[dir=" + m.Groups[2].ToString() + "," + m.Groups[3].ToString() + "]" + m.Groups[4].ToString() + "[/dir]");
//            }
//            #endregion

//            #region ��[flash=x][/flash]���
//            r = new Regex(@"<a href=([\S\t]*?) TARGET=_blank><IMG SRC=/images/swf.gif border=0 alt=������´������͸�FLASH����!> [ȫ������]</a><br><br>
//                 <OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width=(\d*?) height=(\d*?)><PARAM NAME=movie VALUE=([\S\t]*?)><PARAM NAME=quality VALUE=high><param name=menu value=false>
//                     <embed src=([\S\t]*?) quality=high menu=false pluginspage=http://www.macromedia.com/go/getflashplayer type=application/x-shockwave-flash width=(\d*?) height=(\d*?)>([\S\t]*?)</embed></OBJECT>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                    "[flash=" + m.Groups[3].ToString() + "," + m.Groups[4].ToString() + "]" + m.Groups[2].ToString() + "[/flash]");
//            }
//            #endregion

//            #region ��[em]���
//            r = new Regex(@"<img src=/images/em([\S\t]*?).gif border=0 align=middle>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(), "[em" + m.Groups[2].ToString() + "]");
//            }
//            #endregion

//            #region ��[IMG][/IMG]���
//            r = new Regex(@"<br><a onfocus=this.blur() href=(http|https|ftp):\/\/([ \S\t]*?) target=_blank><IMG SRC=(http|https|ftp):\/\/([ \S\t]*?) border=0 alt=�������´������ͼƬ onload=javascript:if(screen.width-333<this.width)this.width=screen.width-333></a>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),"[img]"+m.Groups[2].ToString()+"://"+m.Groups[3].ToString()+"[/img]");
//            }
//            #endregion

//            #region ��[glow=x][/glow]���
//            r = new Regex(@"<TABLE WIDTH=(\d*?)  STYLE=FILTER:GLOW(COLOR=(#*\w*?), STRENGTH=(\d*?))>([\S\t]*?)</TABLE>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "[glow=" + m.Groups[2].ToString() + "," + m.Groups[3].ToString() + "," + m.Groups[4].ToString() + "]"+m.Groups[5].ToString()+"[/glow]");
//            }
//            #endregion

//            #region ��[SHADOW=x][/SHADOW]���
//            r = new Regex(@"<TABLE WIDTH=(\d*?)  STYLE=FILTER:SHADOW(COLOR=(#*\w*?), STRENGTH=(\d*?))>([\S\t]*?)</TABLE>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "[shadow=" + m.Groups[2].ToString() + "," + m.Groups[3].ToString() + "," + m.Groups[4].ToString() + "]" + m.Groups[5].ToString() + "[/shadow]");
//            }
//            #endregion

//            #region ����[list=x][*][/list]
//            //r = new Regex(@"(\[list(=(A|a|I|i| ))?\]([ \S\t]*)\r\n)((\[\*\]([ \S\t]*\r\n))*?)(\[\/list\])", RegexOptions.IgnoreCase);
//            //for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            //{
//            //    string strLI = m.Groups[5].ToString();
//            //    Regex rLI = new Regex(@"\[\*\]([ \S\t]*\r\n?)", RegexOptions.IgnoreCase);
//            //    Match mLI;
//            //    for (mLI = rLI.Match(strLI); mLI.Success; mLI = mLI.NextMatch())
//            //    {
//            //        strLI = strLI.Replace(mLI.Groups[0].ToString(), "<LI>" + mLI.Groups[1]);
//            //    }
//            //    sDetail = sDetail.Replace(m.Groups[0].ToString(),
//            //     "<UL TYPE=\"" + m.Groups[3].ToString() + "\"><B>" + m.Groups[4].ToString() + "</B>" +
//            //     strLI + "</UL>");
//            //}

//            #endregion

//            #region ��[H=x][/H]���
//            //��[H=x][/H]���
//            r = new Regex(@"<H([1-6])>([ \S\t]*?)</H([1-6])>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                "[H=" + m.Groups[2].ToString() + ">" +
//                m.Groups[3].ToString() + "[/H]");

//            }
//            #endregion          

//            #region ����[align=x][/align]
//            //����[align=x][/align]
//            r = new Regex(@"<P align=([\S]+)\])>([\S]+)\])</P>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                "[align=" + m.Groups[2].ToString() + ">" +
//                m.Groups[3].ToString() + "[/align]");
//            }
//            #endregion    
     
//            #region ����ͼƬ����[picture]
//            ////����ͼƬ����
//            //r = new Regex("\\[picture\\](\\d+?)\\[\\/picture\\]", RegexOptions.IgnoreCase);
//            //for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            //{
//            //    sDetail = sDetail.Replace(m.Groups[0].ToString(),
//            //     "<A href=\"ShowImage.aspx?Type=ALL&Action=forumImage&ImageID=" + m.Groups[1].ToString() +
//            //     "\" target=\"_blank\"><IMG border=0 Title=\"������´��ڲ鿴\" src=\"ShowImage.aspx?Action=forumImage&ImageID=" + m.Groups[1].ToString() +
//            //     "\"></A>");
//            //}
//            #endregion

//            #region ��[face=x][/face]���
//            //��[font=x][/font]���
//            r = new Regex(@"<FONT FACE=([\S]+)>([ \S\t]*?)</FONT>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "[face=" + m.Groups[2].ToString() + ">" +
//                 m.Groups[3].ToString() + "[/face]");
//            }
//            #endregion

//            #region ��[color=x][/color]���
//            //��[color=x][/color]���
//            r = new Regex(@"<FONT COLOR=([\S]+)>([ \S\t]*?)</FONT>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "[color=" + m.Groups[2].ToString() + ">" +
//                 m.Groups[3].ToString() + "[/color]");
//            }
//            #endregion

//            #region ��[size=x][/size]���
//            //��[size=x][/size]���
//            r = new Regex(@"<FONT SIZE=([1-7])>([ \S\t]*?)</FONT>", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "[size=" + m.Groups[2].ToString() + ">" +
//                 m.Groups[3].ToString() + "[/size]");
//            }
//            #endregion   

//            #region ��[email=xxx][/email]���
//            //��[email=xxx][/email]���
//            r = new Regex(@"(\[email=([ \S\t]+)\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
//            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
//            {
//                sDetail = sDetail.Replace(m.Groups[0].ToString(),
//                 "<A href=\"mailto:" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
//                 m.Groups[3].ToString() + "</A>");
//            }
//            #endregion                    



//            return sDetail;
//        }
        #endregion

        /// <summary>
        /// ��������˱�������
        /// </summary>
        /// <param name="s">����</param>
        /// <param name="pattern">���ʽ</param>
        /// <param name="re">λ��</param>
        /// <returns></returns>
        private string RegexReplace(string s,string pattern,string re)
        {
            return Regex.Replace(s, pattern, re, RegexOptions.IgnoreCase);
        }
    }
}
