function CountTextBox(textboxId, outputId, formatString, treatCRasOneChar)
{
    var textBox = document.getElementById(textboxId);
    var output = document.getElementById(outputId);
    
    var tbText = textBox.value;
    var totalWords = 0;
    var totalChars = 0;

    // Count the total number of words...    
    var uniformSpaces = tbText.replace(/\s/g, ' ');
    var pieces = uniformSpaces.split(' ');

    for (var i = 0; i < pieces.length; i++)
        if (pieces[i].length > 0)
            totalWords++;

    // Count the total number of characters...
    if (treatCRasOneChar)
    {        
        var removedExtraChar = tbText.replace('\r\n', '\n');
        totalChars = removedExtraChar.length;
    }
    else   
        totalChars = tbText.length;
    
    
    output.innerHTML = formatString.replace('{0}', totalWords).replace('{1}', totalChars);
}



function CheckCapsLock( e, warnId, dispTime ) {
	var myKeyCode = 0;
	var myShiftKey = e.shiftKey;
    
	if ( document.all ) {
    	// Internet Explorer 4+
		myKeyCode = e.keyCode;
	} else if ( document.getElementById ) {
    	// Mozilla / Opera / etc.
		myKeyCode = e.which;
	}
	
	if ((myKeyCode >= 65 && myKeyCode <= 90 ) || (myKeyCode >= 97 && myKeyCode <= 122)) {
		if ( 
    	    // Upper case letters are seen without depressing the Shift key, therefore Caps Lock is on
	        ( (myKeyCode >= 65 && myKeyCode <= 90 ) && !myShiftKey )

	        ||

    	    // Lower case letters are seen while depressing the Shift key, therefore Caps Lock is on
	        ( (myKeyCode >= 97 && myKeyCode <= 122 ) && myShiftKey )
    	   )
        {
		    ShowCapsWarning(warnId, dispTime);
	    }
	    else {
	        HideCapsWarning(warnId);
	    }
    }
}

function GetWarningElement(warnId)
{
	if ( document.all ) {
    	// Internet Explorer 4+
		return document.all[warnId];
	} else if ( document.getElementById ) {
    	// Mozilla / Opera / etc.
		return document.getElementById(warnId);
	}
}

var myTimers = new Array();

function ShowCapsWarning(warnId, dispTime)
{
    var warnElem = GetWarningElement(warnId);
    
    if (warnElem == null)
        return;
    else
    {
        warnElem.style.visibility = 'visible';
        warnElem.style.display = 'inline';
        
        if (dispTime > 0)
            myTimers.push(setTimeout('HideCapsWarning("' + warnId + '");', dispTime));
    }
}

function HideCapsWarning(warnId)
{
    var warnElem = GetWarningElement(warnId);
    
    if (warnElem == null)
        return;
    else
    {
        warnElem.style.visibility = 'hidden';
        warnElem.style.display = 'none';
        
        // Clear all timers
        while (myTimers.length > 0)
            clearTimeout(myTimers.pop());
    }
}
