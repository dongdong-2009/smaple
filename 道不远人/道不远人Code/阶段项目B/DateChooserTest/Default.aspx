<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>
    <!--[if lt IE 7]>
     <style type="text/css">
      .calendar img { behavior: url(iepngfix.htc) }
     </style>
    <![endif]-->
    <link href="CSS/DateChooser.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/MicrosoftAjax.debug.js"></script>
    <script type="text/javascript" src="js/jquery.debug.js"></script>
    <script type="text/javascript" src="js/interface.js"></script>
    <script type="text/javascript" src="js/Globalization/zh-CN.js"></script>
    <script type="text/javascript" src="js/datechooser.js"></script>
    <script type="text/javascript">
        var dateChooser1;
        var dateChooser2;
        
        $(function(){
            dateChooser1 = new DateChooser('calendar1','dateChooser1','yyyy/MM/dd','2007/05/21','2008/05/21');
            dateChooser1.initiate();
            
            dateChooser2 = new DateChooser('calendar2','dateChooser2','yyyy年MM月dd日',null,null,'BlindRight("fast")','BlindLeft("fast")');
            dateChooser2.initiate();
            
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="calendar1" class="calendar">
            <div class='calendarInputView'>
                <a class='calendarDropDownButton'>
                    <img /></a>
                <input class='calendarInput' value='2007/05/17' id='calendar1_input' name='calendar1$input' />
                <a class='calendarAddButton'>
                    <img /></a> <a class='calendarReduceButton'>
                        <img /></a>
            </div>
            <div id="calendar1_panel" class='calendarView'>
                <div class="calendarMonthView">
                    <table class="calendarMonthTable" cellpadding='0' cellspacing='0'>
                        <thead class="calendarMonthHearder">
                            <th class='calendarSunday'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarSaturday'>
                            </th>
                        </thead>
                        <tbody class="calendarMonthDay">
                        </tbody>
                    </table>
                </div>
                <div class="calendarYearView">
                    <table class="calendarYearTable" cellpadding="0" cellspacing="0">
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="calendarNavigator">
                    <a class="calendarPrev">
                        <img src="Images/bPrev.png" />
                    </a><a class="calendarNext">
                        <img src="Images/bNext.png" />
                    </a><a class="calendarTitle"></a>
                </div>
            </div>
        </div>
        <div id="calendar2" class="calendar">
            <div class='calendarInputView'>
                <a class='calendarDropDownButton'>
                    <img /></a>
                <input class='calendarInput' value='2008年05月17日' />
                <a class='calendarAddButton'>
                    <img /></a> <a class='calendarReduceButton'>
                        <img /></a>
            </div>
            <div class='calendarView'>
                <div class="calendarMonthView">
                    <table class="calendarMonthTable" cellpadding='0' cellspacing='0'>
                        <thead class="calendarMonthHearder">
                            <th class='calendarSunday'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarDay'>
                            </th>
                            <th class='calendarSaturday'>
                            </th>
                        </thead>
                        <tbody class="calendarMonthDay">
                        </tbody>
                    </table>
                </div>
                <div class="calendarYearView">
                    <table class="calendarYearTable" cellpadding="0" cellspacing="0">
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="calendarNavigator">
                    <a class="calendarPrev">
                        <img src="Images/bPrev.png" />
                    </a><a class="calendarNext">
                        <img src="Images/bNext.png" />
                    </a><a class="calendarTitle"></a>
                </div>
            </div>
        </div>
        <div>
            <select>
                <option>123</option>
            </select>
            <hr />
            <textarea style="width: 80%; height: 500px; border: solid 1px blue;" id="TraceConsole"></textarea>
        </div>
    </form>
</body>
</html>
