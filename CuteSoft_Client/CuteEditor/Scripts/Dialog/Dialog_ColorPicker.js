var OxOeb66=["=","; path=/;"," expires=",";","cookie","length","","#ffffff","CECC","onmouseover","event","srcElement","target","className","colordiv","style","onmouseout","onclick","CheckboxColorNames","checked","cname","backgroundColor","cvalue","[[_CuteEditorResource_]]Load.ashx?type=dialog\x26file=ColorPicker.Aspx\x26culture=[[_culture_]]","\x26[[DNN_Arg]]","dialogWidth:520px;dialogHeight:420px;help:0;status:0;resizable:1","dialogArguments","object","onchange","color","editor","divpreview","value","#","RecentColors","SPAN","[[ValidColor]]"];function SetCookie(name,Ox4f,Ox56){var Ox57=name+OxOeb66[0]+escape(Ox4f)+OxOeb66[1];if(Ox56){var Ox58= new Date();Ox58.setSeconds(Ox58.getSeconds()+Ox56);Ox57+=OxOeb66[2]+Ox58.toUTCString()+OxOeb66[3];} ;document[OxOeb66[4]]=Ox57;} ;function GetCookie(name){var Ox5a=document[OxOeb66[4]].split(OxOeb66[3]);for(var i=0;i<Ox5a[OxOeb66[5]];i++){var Ox5b=Ox5a[i].split(OxOeb66[0]);if(name==Ox5b[0].replace(/\s/g,OxOeb66[6])){return unescape(Ox5b[1]);} ;} ;} ;function GetCookieDictionary(){var Ox12b={};var Ox5a=document[OxOeb66[4]].split(OxOeb66[3]);for(var i=0;i<Ox5a[OxOeb66[5]];i++){var Ox5b=Ox5a[i].split(OxOeb66[0]);Ox12b[Ox5b[0].replace(/\s/g,OxOeb66[6])]=unescape(Ox5b[1]);} ;return Ox12b;} ;function GetCookieArray(){var arr=[];var Ox5a=document[OxOeb66[4]].split(OxOeb66[3]);for(var i=0;i<Ox5a[OxOeb66[5]];i++){var Ox5b=Ox5a[i].split(OxOeb66[0]);var Ox57={name:Ox5b[0].replace(/\s/g,OxOeb66[6]),value:unescape(Ox5b[1])};arr[arr[OxOeb66[5]]]=Ox57;} ;return arr;} ;var __defaultcustomlist=[OxOeb66[7],OxOeb66[7],OxOeb66[7],OxOeb66[7],OxOeb66[7],OxOeb66[7],OxOeb66[7],OxOeb66[7]];function GetCustomColors(){var Ox12f=__defaultcustomlist.concat();for(var i=0;i<18;i++){var Oxdc=GetCustomColor(i);if(Oxdc){Ox12f[i]=Oxdc;} ;} ;return Ox12f;} ;function GetCustomColor(Ox131){return GetCookie(OxOeb66[8]+Ox131);} ;function SetCustomColor(Ox131,Oxdc){SetCookie(OxOeb66[8]+Ox131,Oxdc,60*60*24*365);} ;var _origincolor=OxOeb66[6];document[OxOeb66[9]]=function (Ox1d0){Ox1d0=window[OxOeb66[10]]||Ox1d0;var Ox12=Ox1d0[OxOeb66[11]]||Ox1d0[OxOeb66[12]];if(Ox12[OxOeb66[13]]==OxOeb66[14]){firecolorchange(Ox12[OxOeb66[15]].backgroundColor);} ;} ;document[OxOeb66[16]]=function (Ox1d0){Ox1d0=window[OxOeb66[10]]||Ox1d0;var Ox12=Ox1d0[OxOeb66[11]]||Ox1d0[OxOeb66[12]];if(Ox12[OxOeb66[13]]==OxOeb66[14]){firecolorchange(_origincolor);} ;} ;document[OxOeb66[17]]=function (Ox1d0){Ox1d0=window[OxOeb66[10]]||Ox1d0;var Ox12=Ox1d0[OxOeb66[11]]||Ox1d0[OxOeb66[12]];if(Ox12[OxOeb66[13]]==OxOeb66[14]){var Ox29e=document.getElementById(OxOeb66[18])&&document.getElementById(OxOeb66[18])[OxOeb66[19]];if(Ox29e){do_select(Ox12.getAttribute(OxOeb66[20])||Ox12[OxOeb66[15]][OxOeb66[21]]);} else {do_select(Ox12.getAttribute(OxOeb66[22])||Ox12[OxOeb66[15]][OxOeb66[21]]);} ;} ;} ;var _editor;function firecolorchange(Ox2a1){} ;function ShowColorDialog(Ox235){var Ox13b=OxOeb66[23]+OxOeb66[24];var Ox2a3=OxOeb66[25];var Ox13e=showModalDialog(Ox13b,null,Ox2a3);if(Ox13e!=null&&Ox13e!==false){Ox235(Ox13e);} ;} ;if(top[OxOeb66[26]]){if( typeof (top[OxOeb66[26]])==OxOeb66[27]){if(top[OxOeb66[26]][OxOeb66[28]]){firecolorchange=top[OxOeb66[26]][OxOeb66[28]];_origincolor=top[OxOeb66[26]][OxOeb66[29]];_editor=top[OxOeb66[26]][OxOeb66[30]];} ;} ;} ;var _selectedcolor=null;function do_select(Oxdc){_selectedcolor=Oxdc;firecolorchange(Oxdc);var Ox2a6=document.getElementById(OxOeb66[31]);if(Ox2a6){Ox2a6[OxOeb66[32]]=Oxdc;} ;} ;function do_saverecent(Oxdc){if(!Oxdc){return ;} ;if(Oxdc[OxOeb66[5]]!=7){return ;} ;if(Oxdc.substring(0,1)!=OxOeb66[33]){return ;} ;var hex=Oxdc.substring(1,7);var Ox2a8=GetCookie(OxOeb66[34]);if(!Ox2a8){Ox2a8=OxOeb66[6];} ;if((Ox2a8[OxOeb66[5]]%6)!=0){Ox2a8=OxOeb66[6];} ;for(var i=0;i<Ox2a8[OxOeb66[5]];i+=6){if(Ox2a8.substr(i,6)==hex){Ox2a8=Ox2a8.substr(0,i)+Ox2a8.substr(i+6);i-=6;} ;} ;if(Ox2a8[OxOeb66[5]]>31*6){Ox2a8=Ox2a8.substr(0,31*6);} ;Ox2a8=hex+Ox2a8;SetCookie(OxOeb66[34],Ox2a8,60*60*24*365);} ;function do_insert(){var Oxdc;var divpreview=document.getElementById(OxOeb66[31]);if(divpreview){Oxdc=divpreview[OxOeb66[32]];} else {Oxdc=_selectedcolor;} ;if(!Oxdc){return ;} ;if(/^[0-9A-F]{6}$/ig.test(Oxdc)){Oxdc=OxOeb66[33]+Oxdc;} ;try{document.createElement(OxOeb66[35])[OxOeb66[15]][OxOeb66[29]]=Oxdc;do_saverecent(Oxdc);Window_SetDialogReturnValue(window,Oxdc);Window_CloseDialog(window);} catch(x){alert(OxOeb66[36]);divpreview[OxOeb66[32]]=OxOeb66[6];return false;} ;} ;