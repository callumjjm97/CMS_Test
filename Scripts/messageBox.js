
// Fix 1: Use an <iframe> for the mask to cover <select> elements in IE <8
// Fix 2: Replaced hyphens with underscores in CSS class names
// Fix 3: WRAPPER should contain a valid id of a div or similar element which contains the page content

// New 1: Added support for standard and user-defined buttons
// New 2: Added support for width and height, (user-defined, default and auto)
// New 3: Added support for open-dialog-at-cursor
// New 4: Added support for non-modal dialogs
// New 5: Added support for click-background-mask-to-close
// New 6: Added a DLGRESULT variable set to true or false depending on which button clicked

// ToDo:  Fix the 40 pixel hack to set the correct mask height, (have no idea why?)

// width/height = null : Default Size
// width/height = 0    : Auto Size to contents 

// buttons == 0 : No Buttons
// buttons == 1 : "Ok"
// buttons == 2 : "Yes"/"No"
// buttons == 3 : "Accept"/"Cancel"
// buttons == 4 : "User defined 1"/"User defined 2"

// global variables //
var TIMER = 5;
var SPEED = 1000;
var WRAPPER = 'content';
var DLGRESULT = false;

// Add an onMouseMove event to track mouse position
if (window.attachEvent) document.attachEvent("onmousemove", MouseMv);
else document.addEventListener("mousemove", MouseMv, false);

function MouseMv(e) {
    if (!e) e = window.event;
    if (typeof e.pageX == "number") MouseMv.X = e.pageX;
    else MouseMv.X = e.clientX;

    if (typeof e.pageY == "number") MouseMv.Y = e.pageY;
    else MouseMv.Y = e.clientY;
}
MouseMv.X = 0;
MouseMv.Y = 0;

// check if argument is null, not defined, or of the specified type
function isDef(arg, argtype) {
    try {
        if (argtype === null || typeof (argtype) == 'undefined') return (arg !== null && typeof (arg) != 'undefined');
        return (arg !== null && typeof (arg) == argtype);
    }
    catch (e) { }
    return false;
}

// wrapper for getElementById
function el(id) {
    try {
        if (!isDef(id, 'string') || id == '') return null;
        return document.getElementById(id);
    }
    catch (e) { }
    return null;
}

// get an element's rendered visible content's width
function getWidth(elem) {
    try {
        if (!isDef(elem)) return 0;
        if (elem.style.display == 'none') return 0;
        return elem.innerWidth ? elem.innerWidth : elem.clientWidth ? elem.clientWidth : elem.offsetWidth;
    }
    catch (e) { }

    return 0;
}

// get an element's rendered visible content's height
function getHeight(elem) {
    try {
        if (!isDef(elem)) return 0;
        if (elem.style.display == 'none') return 0;
        return elem.innerHeight ? elem.innerHeight : elem.clientHeight ? elem.clientHeight : elem.offsetHeight;
    }
    catch (e) { }

    return 0;
}

// calculate the current window width //
function pageWidth() {
    return window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : document.body.clientWidth;
}

// calculate the current window height //
function pageHeight() {
    return window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.clientHeight;
}

// calculate the current window vertical offset //
function topPosition() {
    return typeof window.pageYOffset != 'undefined' ? window.pageYOffset : document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop ? document.body.scrollTop : 0;
}

// calculate the position starting at the left of the window //
function leftPosition() {
    return typeof window.pageXOffset != 'undefined' ? window.pageXOffset : document.documentElement && document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft ? document.body.scrollLeft : 0;
}

// build/show the dialog box, populate the data and call the fadeDialog function //
function showMsg_Box(message, type) {

    var title = '';
    var width = null;
    var height = null;
    var autohide = false;
    //var autohide = 1.5;    //set to seconds if we want to auto hide the message box
    var atcursor = true;
    var modal = true;
    var buttons = 0;
    var button1;
    var button2;
    
    if (message.lastIndexOf("~") != -1) {
        var scrollheight = message.substring(message.lastIndexOf("~") + 1);

        message = message.substring(0, message.lastIndexOf("~"));
    }
    else {
        var scrollheight = 0;
    }

    var dialog;
    var dialogheader;
    var dialogclose;
    var dialogtitle;
    var dialogbody;
    var dialogcontent;
    var dialogbar;
    var dialogmask;

    if (!isDef(type)) { type = 'error'; }
    // if(!isDef(width)) {width = 0;}
    // if(!isDef(height)) {height = 0;}
    if (!isDef(autohide)) { autohide = false; }
    if (!isDef(atcursor)) { atcursor = false; }
    if (!isDef(buttons)) { buttons = 0; }
    if (!isDef(modal)) { modal = true; }

    switch (buttons) {
        case 1: button1 = 'Ok'; break;
        case 2: button1 = 'Yes'; button2 = 'No'; break;
        case 3: button1 = 'Ok'; button2 = 'Cancel'; break;
        case 4: if (!isDef(button1)) { button1 = 'Ok'; buttons = 1; } if (!isDef(button2)) { buttons = 1; } break;  // Accepts a single user-defined button, (defaults to "Ok")
        default: button1 = 'Yes'; button2 = 'No'; break;
    }

    DLGRESULT = false;

    if (!el('dialog')) {
        dialog = document.createElement('div');
        dialog.id = 'dialog';
        dialogheader = document.createElement('div');
        dialogheader.id = 'dialog_header';
        dialogtitle = document.createElement('div');
        dialogtitle.id = 'dialog_title';
        dialogclose = document.createElement('div');
        dialogclose.id = 'dialog_close'
        dialogbody = document.createElement('div');
        dialogbody.id = 'dialog_body';
        dialogcontent = document.createElement('div');
        dialogcontent.id = 'dialog_content';
        dialogbar = document.createElement('div');
        dialogbar.id = 'dialog_bar';

        if (modal) {
            dialogmask = document.createElement('iframe');  // Fix for IE bug not overlaying <select> tags
            dialogmask.id = 'dialog_mask';
            dialogmask.setAttribute('frameborder', 0);
            document.body.appendChild(dialogmask);
        }

        document.body.appendChild(dialog);
        dialog.appendChild(dialogheader);
        dialogheader.appendChild(dialogtitle);
        dialogheader.appendChild(dialogclose);
        dialog.appendChild(dialogbody);
        dialogbody.appendChild(dialogcontent);
        dialogbody.appendChild(dialogbar);

        dialogclose.setAttribute('onclick', 'hideDialog()');
        dialogclose.onclick = hideDialog;

        if (modal) {
            var doc = dialogmask.contentDocument || dialogmask.contentWindow.document;
            doc.open();
            doc.writeln('<html><head></head><body style="margin: 0px"></body></html>');  // Create some mask content so that it can support an onclick event handler
            doc.close();
            doc.body.onclick = hideDialog;
        }
    }
    else {
        dialog = el('dialog');
        dialogheader = el('dialog_header');
        dialogtitle = el('dialog_title');
        dialogclose = el('dialog_close');
        dialogbody = el('dialog_body');
        dialogcontent = el('dialog_content');
        dialogbar = el('dialog_bar');
        if (modal) {
            dialogmask = el('dialog_mask');
            dialogmask.style.visibility = "visible";
        }
        dialog.style.visibility = "visible";
    }

    dialogbar.style.display = ((buttons > 0) ? 'block' : 'none');

    dialog.style.opacity = .00;
    dialog.style.filter = 'alpha(opacity=0)';
    dialog.alpha = 0;
    
    var left = leftPosition();
    var top = topPosition();
    var dialogwidth = getWidth(dialog);
    var dialogheight = getHeight(dialog);
    var topposition, leftposition;

    // if (atcursor)
    // {
    //  topposition =  MouseMv.Y;
    //  leftposition = MouseMv.X;
    // }
    // else
    // {
    topposition = top + (pageHeight() / 3) - (dialogheight / 2) + parseInt(scrollheight);
    //leftposition = left + (pageWidth() / 2) - (dialogwidth / 2);
    //leftposition = (dialogwidth / 2);
    leftposition = (425 / 2);
    //}

    dialog.className = type + "border";
    dialog.style.top = topposition + "px";
    dialog.style.left = "-" + leftposition + "px";
    dialog.style.marginLeft = "50%";

    dialogheader.className = type + "header";
    dialogtitle.innerHTML = title;

    dialogbody.className = type + 'body';

    dialogbar.className = type + "border";

    dialogcontent.innerHTML = message;
    if (type == 'message') dialogcontent.style.overflow = 'auto';

    if (buttons > 0) {
        if (buttons == 1) { dialogbar.style.textAlign = 'center'; }
        else { dialogbar.style.textAlign = 'right'; }
        dialogbar.innerHTML = '<button type="button" onclick="DLGRESULT=true;hideDialog();">' + button1 + '</button>';
        if (buttons > 1) dialogbar.innerHTML += '&nbsp;&nbsp;<button type="button" onclick="DLGRESULT=true;hideDialog();">' + button2 + '</button>';
    }


    if (isDef(width)) {
        if (width == 0) dialog.style.width = 'auto';  // auto setting
        else dialog.style.width = width + 'px';
    }
    else dialog.style.width = '425px';  // default setting

    if (isDef(height)) {
        if (height == 0)  // auto setting
        {
            dialogcontent.style.height = 'auto';
            dialog.style.height = 'auto';
        }
        else {
            dialogcontent.style.height = (height - getHeight(dialogheader) - getHeight(dialogbar)) + 'px';
            dialog.style.height = (height + 13) + 'px';  // + 2 * 6px for content padding + 1px for IE Box Model error
        }
    }
    else  // default setting)
    {
        dialogcontent.style.height = '160px';
        dialog.style.height = (getHeight(dialogheader) + 173 + getHeight(dialogbar)) + 'px';  // 160 + 2 * 6px for content padding + 1px for IE Box Model error
    }

    if (modal) {
        var content = el(WRAPPER);
        if (!isDef(content)) {
            content = document.body;  // WRAPPER should contain a valid id of a div or similar element which contains the page content
        }
        dialogmask.style.height = (getHeight(content) + 40) + 'px';  // 40 pixel hack to set the correct mask height, (have no idea why?)
        var doc = dialogmask.contentDocument || dialogmask.contentWindow.document;
        doc.body.style.height = dialogmask.style.height;  // Resize dialog mask body to full height of window so that it will capture an onclick event
    }

    dialog.timer = setInterval("fadeDialog(1)", TIMER);

    if (autohide) {
        dialogclose.style.visibility = "hidden";
        window.setTimeout("hideDialog()", (autohide * 1000));
    }
    else { dialogclose.style.visibility = "visible"; }
}

// hide the dialog box //
function hideDialog() {
    var dialog = el('dialog');
    clearInterval(dialog.timer);
    dialog.timer = setInterval("fadeDialog(0)", TIMER);
}

// fade-in the dialog box //
function fadeDialog(flag) {
    var dialog = el('dialog');
    var value;

    if (!isDef(flag)) { flag = 1; }

    if (flag == 1) { value = dialog.alpha + SPEED; }
    else { value = dialog.alpha - SPEED; }

    dialog.alpha = value;
    dialog.style.opacity = (value / 100);
    dialog.style.filter = 'alpha(opacity=' + value + ')';

    if (value >= 99) {
        clearInterval(dialog.timer);
        dialog.timer = null;
    }
    else if (value <= 1) {
        dialog.style.visibility = "hidden";
        if (el('dialog_mask')) el('dialog_mask').style.visibility = "hidden";
        clearInterval(dialog.timer);
    }
}