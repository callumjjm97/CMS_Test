var OxOe847=["onload","onclick","btnCancel","btnOK","onkeyup","txtHSB_Hue","onkeypress","txtHSB_Saturation","txtHSB_Brightness","txtRGB_Red","txtRGB_Green","txtRGB_Blue","txtHex","btnWebSafeColor","rdoHSB_Hue","rdoHSB_Saturation","rdoHSB_Brightness","pnlGradient_Top","onmousemove","onmousedown","onmouseup","pnlVertical_Top","pnlWebSafeColor","pnlWebSafeColorBorder","pnlOldColor","lblHSB_Hue","lblHSB_Saturation","lblHSB_Brightness","length","\x5C{","\x5C}","BadNumber","A number between {0} and {1} is required. Closest value inserted.","Title","Color Picker","SelectAColor","Select a color:","OKButton","OK","CancelButton","Cancel","Recent","WebSafeWarning","Warning: not a web safe color","WebSafeClick","Click to select web safe color","HsbHue","H:","HsbHueTooltip","Hue","HsbHueUnit","%","HsbSaturation","S:","HsbSaturationTooltip","Saturation","HsbSaturationUnit","HsbBrightness","B:","HsbBrightnessTooltip","Brightness","HsbBrightnessUnit","RgbRed","R:","RgbRedTooltip","Red","RgbGreen","G:","RgbGreenTooltip","Green","RgbBlue","RgbBlueTooltip","Blue","Hex","#","RecentTooltip","Recent:","lblSelectColorMessage","lblRecent","lblRGB_Red","lblRGB_Green","lblRGB_Blue","lblHex","lblUnitHSB_Hue","lblUnitHSB_Saturation","lblUnitHSB_Brightness","pnlHSB_Hue","pnlHSB_Saturation","pnlHSB_Brightness","pnlRGB_Red","pnlRGB_Green","pnlRGB_Blue","frmColorPicker","Color","","FFFFFF","value","checked","ColorMode","ColorType","RecentColors","pnlRecent","border","style","0px","backgroundColor","target","rgb","(",")",",","display","none","title","innerHTML","backgroundPosition","px ","px","pnlGradientHsbHue_Hue","pnlGradientHsbHue_Black","pnlGradientHsbHue_White","pnlVerticalHsbHue_Background","pnlVerticalHsbSaturation_Hue","pnlVerticalHsbSaturation_White","pnlVerticalHsbBrightness_Hue","pnlVerticalHsbBrightness_Black","pnlVerticalRgb_Start","pnlVerticalRgb_End","pnlGradientRgb_Base","pnlGradientRgb_Invert","pnlGradientRgb_Overlay1","pnlGradientRgb_Overlay2","src","imgGradient","Load.ashx?type=image\x26file=cpns_ColorSpace1.png","Load.ashx?type=image\x26file=cpns_ColorSpace2.png","Load.ashx?type=image\x26file=cpns_Vertical1.png","#000000","Load.ashx?type=image\x26file=cpns_Vertical2.png","#ffffff","01234567879","which","abcdef","01234567879ABCDEF","opener","closeeditordialog","close","pnlGradientPosition","pnlNewColor","0123456789ABCDEFabcdef","000000","0","id","top","pnlVerticalPosition","backgroundImage","url(Load.ashx?type=image\x26file=cpns_GradientPositionDark.gif)","url(Load.ashx?type=image\x26file=cpns_GradientPositionLight.gif)","cancelBubble","pageX","pageY","className","GradientNormal","GradientFullScreen","_isverdown","=","; path=/;"," expires=",";","cookie","search","location","\x26","00336699CCFF","0x","do_select","frm","__cphex"];var POSITIONADJUSTX=22;var POSITIONADJUSTY=52;var POSITIONADJUSTZ=48;var ColorMode=1;var GradientPositionDark= new Boolean(false);var frm= new Object();var msg= new Object();var _xmlDocs= new Array();var _xmlIndex=-1;var _xml=null;LoadLanguage();window[OxOe847[0]]=window_load;function initialize(){frm[OxOe847[2]][OxOe847[1]]=btnCancel_Click;frm[OxOe847[3]][OxOe847[1]]=btnOK_Click;frm[OxOe847[5]][OxOe847[4]]=Hsb_Changed;frm[OxOe847[5]][OxOe847[6]]=validateNumber;frm[OxOe847[7]][OxOe847[4]]=Hsb_Changed;frm[OxOe847[7]][OxOe847[6]]=validateNumber;frm[OxOe847[8]][OxOe847[4]]=Hsb_Changed;frm[OxOe847[8]][OxOe847[6]]=validateNumber;frm[OxOe847[9]][OxOe847[4]]=Rgb_Changed;frm[OxOe847[9]][OxOe847[6]]=validateNumber;frm[OxOe847[10]][OxOe847[4]]=Rgb_Changed;frm[OxOe847[10]][OxOe847[6]]=validateNumber;frm[OxOe847[11]][OxOe847[4]]=Rgb_Changed;frm[OxOe847[11]][OxOe847[6]]=validateNumber;frm[OxOe847[12]][OxOe847[4]]=Hex_Changed;frm[OxOe847[12]][OxOe847[6]]=validateHex;frm[OxOe847[13]][OxOe847[1]]=btnWebSafeColor_Click;frm[OxOe847[14]][OxOe847[1]]=rdoHsb_Hue_Click;frm[OxOe847[15]][OxOe847[1]]=rdoHsb_Saturation_Click;frm[OxOe847[16]][OxOe847[1]]=rdoHsb_Brightness_Click;document.getElementById(OxOe847[17])[OxOe847[1]]=pnlGradient_Top_Click;document.getElementById(OxOe847[17])[OxOe847[18]]=pnlGradient_Top_MouseMove;document.getElementById(OxOe847[17])[OxOe847[19]]=pnlGradient_Top_MouseDown;document.getElementById(OxOe847[17])[OxOe847[20]]=pnlGradient_Top_MouseUp;document.getElementById(OxOe847[21])[OxOe847[1]]=pnlVertical_Top_Click;document.getElementById(OxOe847[21])[OxOe847[18]]=pnlVertical_Top_MouseMove;document.getElementById(OxOe847[21])[OxOe847[19]]=pnlVertical_Top_MouseDown;document.getElementById(OxOe847[21])[OxOe847[20]]=pnlVertical_Top_MouseUp;document.getElementById(OxOe847[22])[OxOe847[1]]=btnWebSafeColor_Click;document.getElementById(OxOe847[23])[OxOe847[1]]=btnWebSafeColor_Click;document.getElementById(OxOe847[24])[OxOe847[1]]=pnlOldClick_Click;document.getElementById(OxOe847[25])[OxOe847[1]]=rdoHsb_Hue_Click;document.getElementById(OxOe847[26])[OxOe847[1]]=rdoHsb_Saturation_Click;document.getElementById(OxOe847[27])[OxOe847[1]]=rdoHsb_Brightness_Click;frm[OxOe847[5]].focus();window.focus();} ;function formatString(Ox2b2){Ox2b2= new String(Ox2b2);for(var i=1;i<arguments[OxOe847[28]];i++){Ox2b2=Ox2b2.replace( new RegExp(OxOe847[29]+(i-1)+OxOe847[30]),arguments[i]);} ;return Ox2b2;} ;function AddValue(Ox11a,Ox4f){Ox4f= new String(Ox4f).toLowerCase();for(var i=0;i<Ox11a[OxOe847[28]];i++){if(Ox11a[i]==Ox4f){return ;} ;} ;Ox11a[Ox11a[OxOe847[28]]]=Ox4f;} ;function SniffLanguage(Ox11){} ;function LoadNextLanguage(){} ;function LoadLanguage(){msg[OxOe847[31]]=OxOe847[32];msg[OxOe847[33]]=OxOe847[34];msg[OxOe847[35]]=OxOe847[36];msg[OxOe847[37]]=OxOe847[38];msg[OxOe847[39]]=OxOe847[40];msg[OxOe847[41]]=OxOe847[41];msg[OxOe847[42]]=OxOe847[43];msg[OxOe847[44]]=OxOe847[45];msg[OxOe847[46]]=OxOe847[47];msg[OxOe847[48]]=OxOe847[49];msg[OxOe847[50]]=OxOe847[51];msg[OxOe847[52]]=OxOe847[53];msg[OxOe847[54]]=OxOe847[55];msg[OxOe847[56]]=OxOe847[51];msg[OxOe847[57]]=OxOe847[58];msg[OxOe847[59]]=OxOe847[60];msg[OxOe847[61]]=OxOe847[51];msg[OxOe847[62]]=OxOe847[63];msg[OxOe847[64]]=OxOe847[65];msg[OxOe847[66]]=OxOe847[67];msg[OxOe847[68]]=OxOe847[69];msg[OxOe847[70]]=OxOe847[58];msg[OxOe847[71]]=OxOe847[72];msg[OxOe847[73]]=OxOe847[74];msg[OxOe847[75]]=OxOe847[76];} ;function AssignLanguage(){} ;function localize(){SetHTML(document.getElementById(OxOe847[77]),msg.SelectAColor,document.getElementById(OxOe847[78]),msg.Recent,document.getElementById(OxOe847[25]),msg.HsbHue,document.getElementById(OxOe847[26]),msg.HsbSaturation,document.getElementById(OxOe847[27]),msg.HsbBrightness,document.getElementById(OxOe847[79]),msg.RgbRed,document.getElementById(OxOe847[80]),msg.RgbGreen,document.getElementById(OxOe847[81]),msg.RgbBlue,document.getElementById(OxOe847[82]),msg.Hex,document.getElementById(OxOe847[83]),msg.HsbHueUnit,document.getElementById(OxOe847[84]),msg.HsbSaturationUnit,document.getElementById(OxOe847[85]),msg.HsbBrightnessUnit);SetValue(frm.btnCancel,msg.CancelButton,frm.btnOK,msg.OKButton);SetTitle(frm.btnWebSafeColor,msg.WebSafeWarning,document.getElementById(OxOe847[22]),msg.WebSafeClick,document.getElementById(OxOe847[86]),msg.HsbHueTooltip,document.getElementById(OxOe847[87]),msg.HsbSaturationTooltip,document.getElementById(OxOe847[88]),msg.HsbBrightnessTooltip,document.getElementById(OxOe847[89]),msg.RgbRedTooltip,document.getElementById(OxOe847[90]),msg.RgbGreenTooltip,document.getElementById(OxOe847[91]),msg.RgbBlueTooltip);} ;function window_load(Ox43){frm=document.getElementById(OxOe847[92]);localize();initialize();var hex=GetQuery(OxOe847[93]).toUpperCase();if(hex==OxOe847[94]){hex=OxOe847[95];} ;if(hex[OxOe847[28]]==7){hex=hex.substr(1,6);} ;frm[OxOe847[12]][OxOe847[96]]=hex;Hex_Changed(Ox43);hex=Form_Get_Hex();SetBg(document.getElementById(OxOe847[24]),hex);frm[OxOe847[99]][ new Number(GetCookie(OxOe847[98])||0)][OxOe847[97]]=true;ColorMode_Changed(Ox43);var Ox2a8=GetCookie(OxOe847[100])||OxOe847[94];var Ox2b8=msg[OxOe847[75]];for(var i=1;i<33;i++){if(Ox2a8[OxOe847[28]]/6>=i){hex=Ox2a8.substr((i-1)*6,6);var Ox2b9=HexToRgb(hex);var title=formatString(msg.RecentTooltip,hex,Ox2b9[0],Ox2b9[1],Ox2b9[2]);SetBg(document.getElementById(OxOe847[101]+i),hex);SetTitle(document.getElementById(OxOe847[101]+i),title);document.getElementById(OxOe847[101]+i)[OxOe847[1]]=pnlRecent_Click;} else {document.getElementById(OxOe847[101]+i)[OxOe847[103]][OxOe847[102]]=OxOe847[104];} ;} ;} ;function pnlRecent_Click(Ox43){var Oxdc=Ox43[OxOe847[106]][OxOe847[103]][OxOe847[105]];if(Oxdc.indexOf(OxOe847[107])!=-1){var Ox2b9= new Array();Oxdc=Oxdc.substr(Oxdc.indexOf(OxOe847[108])+1);Oxdc=Oxdc.substr(0,Oxdc.indexOf(OxOe847[109]));Ox2b9[0]= new Number(Oxdc.substr(0,Oxdc.indexOf(OxOe847[110])));Oxdc=Oxdc.substr(Oxdc.indexOf(OxOe847[110])+1);Ox2b9[1]= new Number(Oxdc.substr(0,Oxdc.indexOf(OxOe847[110])));Ox2b9[2]= new Number(Oxdc.substr(Oxdc.indexOf(OxOe847[110])+1));Oxdc=RgbToHex(Ox2b9);} else {Oxdc=Oxdc.substr(1,6).toUpperCase();} ;frm[OxOe847[12]][OxOe847[96]]=Oxdc;Hex_Changed(Ox43);} ;function pnlOldClick_Click(Ox43){frm[OxOe847[12]][OxOe847[96]]=document.getElementById(OxOe847[24])[OxOe847[103]][OxOe847[105]].substr(1,6).toUpperCase();Hex_Changed(Ox43);} ;function rdoHsb_Hue_Click(Ox43){frm[OxOe847[14]][OxOe847[97]]=true;ColorMode_Changed(Ox43);} ;function rdoHsb_Saturation_Click(Ox43){frm[OxOe847[15]][OxOe847[97]]=true;ColorMode_Changed(Ox43);} ;function rdoHsb_Brightness_Click(Ox43){frm[OxOe847[16]][OxOe847[97]]=true;ColorMode_Changed(Ox43);} ;function Hide(){for(var i=0;i<arguments[OxOe847[28]];i++){if(arguments[i]){arguments[i][OxOe847[103]][OxOe847[111]]=OxOe847[112];} ;} ;} ;function Show(){for(var i=0;i<arguments[OxOe847[28]];i++){if(arguments[i]){arguments[i][OxOe847[103]][OxOe847[111]]=OxOe847[94];} ;} ;} ;function SetValue(){for(var i=0;i<arguments[OxOe847[28]];i+=2){arguments[i][OxOe847[96]]=arguments[i+1];} ;} ;function SetTitle(){for(var i=0;i<arguments[OxOe847[28]];i+=2){arguments[i][OxOe847[113]]=arguments[i+1];} ;} ;function SetHTML(){for(var i=0;i<arguments[OxOe847[28]];i+=2){arguments[i][OxOe847[114]]=arguments[i+1];} ;} ;function SetBg(){for(var i=0;i<arguments[OxOe847[28]];i+=2){if(arguments[i]){arguments[i][OxOe847[103]][OxOe847[105]]=OxOe847[74]+arguments[i+1];} ;} ;} ;function SetBgPosition(){for(var i=0;i<arguments[OxOe847[28]];i+=3){arguments[i][OxOe847[103]][OxOe847[115]]=arguments[i+1]+OxOe847[116]+arguments[i+2]+OxOe847[117];} ;} ;function ColorMode_Changed(Ox43){for(var i=0;i<3;i++){if(frm[OxOe847[99]][i][OxOe847[97]]){ColorMode=i;} ;} ;SetCookie(OxOe847[98],ColorMode,60*60*24*365);Hide(document.getElementById(OxOe847[118]),document.getElementById(OxOe847[119]),document.getElementById(OxOe847[120]),document.getElementById(OxOe847[121]),document.getElementById(OxOe847[122]),document.getElementById(OxOe847[123]),document.getElementById(OxOe847[124]),document.getElementById(OxOe847[125]),document.getElementById(OxOe847[126]),document.getElementById(OxOe847[127]),document.getElementById(OxOe847[128]),document.getElementById(OxOe847[129]),document.getElementById(OxOe847[130]),document.getElementById(OxOe847[131]));switch(ColorMode){case 0:document.getElementById(OxOe847[133])[OxOe847[132]]=OxOe847[134];Show(document.getElementById(OxOe847[118]),document.getElementById(OxOe847[119]),document.getElementById(OxOe847[120]),document.getElementById(OxOe847[121]));Hsb_Changed(Ox43);break ;;case 1:document.getElementById(OxOe847[133])[OxOe847[132]]=OxOe847[135];document.getElementById(OxOe847[122])[OxOe847[132]]=OxOe847[136];Show(document.getElementById(OxOe847[118]),document.getElementById(OxOe847[122]));document.getElementById(OxOe847[118])[OxOe847[103]][OxOe847[105]]=OxOe847[137];Hsb_Changed(Ox43);break ;;case 2:document.getElementById(OxOe847[133])[OxOe847[132]]=OxOe847[135];document.getElementById(OxOe847[122])[OxOe847[132]]=OxOe847[138];Show(document.getElementById(OxOe847[118]),document.getElementById(OxOe847[122]));document.getElementById(OxOe847[118])[OxOe847[103]][OxOe847[105]]=OxOe847[139];Hsb_Changed(Ox43);break ;;default:break ;;} ;} ;function btnWebSafeColor_Click(Ox43){var Ox2b9=HexToRgb(frm[OxOe847[12]].value);Ox2b9=RgbToWebSafeRgb(Ox2b9);frm[OxOe847[12]][OxOe847[96]]=RgbToHex(Ox2b9);Hex_Changed(Ox43);} ;function checkWebSafe(){var Ox2b9=Form_Get_Rgb();if(RgbIsWebSafe(Ox2b9)){Hide(frm.btnWebSafeColor,document.getElementById(OxOe847[22]),document.getElementById(OxOe847[23]));} else {Ox2b9=RgbToWebSafeRgb(Ox2b9);SetBg(document.getElementById(OxOe847[22]),RgbToHex(Ox2b9));Show(frm.btnWebSafeColor,document.getElementById(OxOe847[22]),document.getElementById(OxOe847[23]));} ;} ;function validateNumber(Ox43){var Ox2ce=String.fromCharCode(Ox43.which);if(IgnoreKey(Ox43)){return ;} ;if(OxOe847[140].indexOf(Ox2ce)!=-1){return ;} ;Ox43[OxOe847[141]]=0;} ;function validateHex(Ox43){if(IgnoreKey(Ox43)){return ;} ;var Ox2ce=String.fromCharCode(Ox43.which);if(OxOe847[142].indexOf(Ox2ce)!=-1){return ;} ;if(OxOe847[143].indexOf(Ox2ce)!=-1){return ;} ;} ;function IgnoreKey(Ox43){var Ox2ce=String.fromCharCode(Ox43.which);var Ox2d1= new Array(0,8,9,13,27);if(Ox2ce==null){return true;} ;for(var i=0;i<5;i++){if(Ox43[OxOe847[141]]==Ox2d1[i]){return true;} ;} ;return false;} ;function btnCancel_Click(){if(window[OxOe847[144]]){window[OxOe847[144]].focus();} ;(top[OxOe847[145]]||top[OxOe847[146]])();} ;function btnOK_Click(){var hex= new String(frm[OxOe847[12]].value);if(window[OxOe847[144]]){try{window[OxOe847[144]].ColorPicker_Picked(hex);} catch(e){} ;window[OxOe847[144]].focus();} ;recent=GetCookie(OxOe847[100])||OxOe847[94];for(var i=0;i<recent[OxOe847[28]];i+=6){if(recent.substr(i,6)==hex){recent=recent.substr(0,i)+recent.substr(i+6);i-=6;} ;} ;if(recent[OxOe847[28]]>31*6){recent=recent.substr(0,31*6);} ;recent=frm[OxOe847[12]][OxOe847[96]]+recent;SetCookie(OxOe847[100],recent,60*60*24*365);(top[OxOe847[145]]||top[OxOe847[146]])();} ;function SetGradientPosition(Ox43,x,y){x=x-POSITIONADJUSTX+5;y=y-POSITIONADJUSTY+5;x-=7;y-=27;x=x<0?0:x>255?255:x;y=y<0?0:y>255?255:y;SetBgPosition(document.getElementById(OxOe847[147]),x-5,y-5);switch(ColorMode){case 0:var Ox2d5= new Array(0,0,0);Ox2d5[1]=x/255;Ox2d5[2]=1-(y/255);frm[OxOe847[7]][OxOe847[96]]=Math.round(Ox2d5[1]*100);frm[OxOe847[8]][OxOe847[96]]=Math.round(Ox2d5[2]*100);Hsb_Changed(Ox43);break ;;case 1:var Ox2d5= new Array(0,0,0);Ox2d5[0]=x/255;Ox2d5[2]=1-(y/255);frm[OxOe847[5]][OxOe847[96]]=Ox2d5[0]==1?0:Math.round(Ox2d5[0]*360);frm[OxOe847[8]][OxOe847[96]]=Math.round(Ox2d5[2]*100);Hsb_Changed(Ox43);break ;;case 2:var Ox2d5= new Array(0,0,0);Ox2d5[0]=x/255;Ox2d5[1]=1-(y/255);frm[OxOe847[5]][OxOe847[96]]=Ox2d5[0]==1?0:Math.round(Ox2d5[0]*360);frm[OxOe847[7]][OxOe847[96]]=Math.round(Ox2d5[1]*100);Hsb_Changed(Ox43);break ;;} ;} ;function Hex_Changed(Ox43){var hex=Form_Get_Hex();var Ox2b9=HexToRgb(hex);var Ox2d5=RgbToHsb(Ox2b9);Form_Set_Rgb(Ox2b9);Form_Set_Hsb(Ox2d5);SetBg(document.getElementById(OxOe847[148]),hex);SetupCursors(Ox43);SetupGradients();checkWebSafe();} ;function Rgb_Changed(Ox43){var Ox2b9=Form_Get_Rgb();var Ox2d5=RgbToHsb(Ox2b9);var hex=RgbToHex(Ox2b9);Form_Set_Hsb(Ox2d5);Form_Set_Hex(hex);SetBg(document.getElementById(OxOe847[148]),hex);SetupCursors(Ox43);SetupGradients();checkWebSafe();} ;function Hsb_Changed(Ox43){var Ox2d5=Form_Get_Hsb();var Ox2b9=HsbToRgb(Ox2d5);var hex=RgbToHex(Ox2b9);Form_Set_Rgb(Ox2b9);Form_Set_Hex(hex);SetBg(document.getElementById(OxOe847[148]),hex);SetupCursors(Ox43);SetupGradients();checkWebSafe();} ;function Form_Set_Hex(hex){frm[OxOe847[12]][OxOe847[96]]=hex;} ;function Form_Get_Hex(){var hex= new String(frm[OxOe847[12]].value);for(var i=0;i<hex[OxOe847[28]];i++){if(OxOe847[149].indexOf(hex.substr(i,1))==-1){hex=OxOe847[150];frm[OxOe847[12]][OxOe847[96]]=hex;alert(formatString(msg.BadNumber,OxOe847[150],OxOe847[95]));break ;} ;} ;while(hex[OxOe847[28]]<6){hex=OxOe847[151]+hex;} ;return hex;} ;function Form_Get_Hsb(){var Ox2d5= new Array(0,0,0);Ox2d5[0]= new Number(frm[OxOe847[5]].value)/360;Ox2d5[1]= new Number(frm[OxOe847[7]].value)/100;Ox2d5[2]= new Number(frm[OxOe847[8]].value)/100;if(Ox2d5[0]>1||isNaN(Ox2d5[0])){Ox2d5[0]=1;frm[OxOe847[5]][OxOe847[96]]=360;alert(formatString(msg.BadNumber,0,360));} ;if(Ox2d5[1]>1||isNaN(Ox2d5[1])){Ox2d5[1]=1;frm[OxOe847[7]][OxOe847[96]]=100;alert(formatString(msg.BadNumber,0,100));} ;if(Ox2d5[2]>1||isNaN(Ox2d5[2])){Ox2d5[2]=1;frm[OxOe847[8]][OxOe847[96]]=100;alert(formatString(msg.BadNumber,0,100));} ;return Ox2d5;} ;function Form_Set_Hsb(Ox2d5){SetValue(frm.txtHSB_Hue,Math.round(Ox2d5[0]*360),frm.txtHSB_Saturation,Math.round(Ox2d5[1]*100),frm.txtHSB_Brightness,Math.round(Ox2d5[2]*100));} ;function Form_Get_Rgb(){var Ox2b9= new Array(0,0,0);Ox2b9[0]= new Number(frm[OxOe847[9]].value);Ox2b9[1]= new Number(frm[OxOe847[10]].value);Ox2b9[2]= new Number(frm[OxOe847[11]].value);if(Ox2b9[0]>255||isNaN(Ox2b9[0])||Ox2b9[0]!=Math.round(Ox2b9[0])){Ox2b9[0]=255;frm[OxOe847[9]][OxOe847[96]]=255;alert(formatString(msg.BadNumber,0,255));} ;if(Ox2b9[1]>255||isNaN(Ox2b9[1])||Ox2b9[1]!=Math.round(Ox2b9[1])){Ox2b9[1]=255;frm[OxOe847[10]][OxOe847[96]]=255;alert(formatString(msg.BadNumber,0,255));} ;if(Ox2b9[2]>255||isNaN(Ox2b9[2])||Ox2b9[2]!=Math.round(Ox2b9[2])){Ox2b9[2]=255;frm[OxOe847[11]][OxOe847[96]]=255;alert(formatString(msg.BadNumber,0,255));} ;return Ox2b9;} ;function Form_Set_Rgb(Ox2b9){frm[OxOe847[9]][OxOe847[96]]=Ox2b9[0];frm[OxOe847[10]][OxOe847[96]]=Ox2b9[1];frm[OxOe847[11]][OxOe847[96]]=Ox2b9[2];} ;function SetupCursors(Ox43){var Ox2d5=Form_Get_Hsb();var Ox2b9=Form_Get_Rgb();if(RgbToYuv(Ox2b9)[0]>=0.5){SetGradientPositionDark();} else {SetGradientPositionLight();} ;if(Ox43[OxOe847[106]]!=null){if(Ox43[OxOe847[106]][OxOe847[152]]==OxOe847[17]){return ;} ;if(Ox43[OxOe847[106]][OxOe847[152]]==OxOe847[21]){return ;} ;} ;var x;var y;var z;if(ColorMode>=0&&ColorMode<=2){for(var i=0;i<3;i++){Ox2d5[i]*=255;} ;} ;switch(ColorMode){case 0:x=Ox2d5[1];y=Ox2d5[2];z=Ox2d5[0]==0?1:Ox2d5[0];break ;;case 1:x=Ox2d5[0]==0?1:Ox2d5[0];y=Ox2d5[2];z=Ox2d5[1];break ;;case 2:x=Ox2d5[0]==0?1:Ox2d5[0];y=Ox2d5[1];z=Ox2d5[2];break ;;} ;y=255-y;z=255-z;SetBgPosition(document.getElementById(OxOe847[147]),x-5,y-5);document.getElementById(OxOe847[154])[OxOe847[103]][OxOe847[153]]=(z+27)+OxOe847[117];} ;function SetupGradients(){var Ox2d5=Form_Get_Hsb();var Ox2b9=Form_Get_Rgb();switch(ColorMode){case 0:SetBg(document.getElementById(OxOe847[118]),RgbToHex(HueToRgb(Ox2d5[0])));break ;;case 1:SetBg(document.getElementById(OxOe847[122]),RgbToHex(HsbToRgb( new Array(Ox2d5[0],1,Ox2d5[2]))));break ;;case 2:SetBg(document.getElementById(OxOe847[122]),RgbToHex(HsbToRgb( new Array(Ox2d5[0],Ox2d5[1],1))));break ;;default:;} ;} ;function SetGradientPositionDark(){if(GradientPositionDark){return ;} ;GradientPositionDark=true;document.getElementById(OxOe847[147])[OxOe847[103]][OxOe847[155]]=OxOe847[156];} ;function SetGradientPositionLight(){if(!GradientPositionDark){return ;} ;GradientPositionDark=false;document.getElementById(OxOe847[147])[OxOe847[103]][OxOe847[155]]=OxOe847[157];} ;function pnlGradient_Top_Click(Ox43){Ox43[OxOe847[158]]=true;SetGradientPosition(Ox43,Ox43[OxOe847[159]]-5,Ox43[OxOe847[160]]-5);document.getElementById(OxOe847[17])[OxOe847[161]]=OxOe847[162];_down=false;} ;var _down=false;function pnlGradient_Top_MouseMove(Ox43){Ox43[OxOe847[158]]=true;if(!_down){return ;} ;SetGradientPosition(Ox43,Ox43[OxOe847[159]]-5,Ox43[OxOe847[160]]-5);} ;function pnlGradient_Top_MouseDown(Ox43){Ox43[OxOe847[158]]=true;_down=true;SetGradientPosition(Ox43,Ox43[OxOe847[159]]-5,Ox43[OxOe847[160]]-5);document.getElementById(OxOe847[17])[OxOe847[161]]=OxOe847[163];} ;function pnlGradient_Top_MouseUp(Ox43){_down=false;Ox43[OxOe847[158]]=true;SetGradientPosition(Ox43,Ox43[OxOe847[159]]-5,Ox43[OxOe847[160]]-5);document.getElementById(OxOe847[17])[OxOe847[161]]=OxOe847[162];} ;function Document_MouseUp(){e[OxOe847[158]]=true;document.getElementById(OxOe847[17])[OxOe847[161]]=OxOe847[162];} ;function SetVerticalPosition(Ox43,z){var z=z-POSITIONADJUSTZ;if(z<27){z=27;} ;if(z>282){z=282;} ;document.getElementById(OxOe847[154])[OxOe847[103]][OxOe847[153]]=z+OxOe847[117];z=1-((z-27)/255);switch(ColorMode){case 0:if(z==1){z=0;} ;frm[OxOe847[5]][OxOe847[96]]=Math.round(z*360);Hsb_Changed(Ox43);break ;;case 1:frm[OxOe847[7]][OxOe847[96]]=Math.round(z*100);Hsb_Changed(Ox43);break ;;case 2:frm[OxOe847[8]][OxOe847[96]]=Math.round(z*100);Hsb_Changed(Ox43);break ;;} ;} ;function pnlVertical_Top_Click(Ox43){SetVerticalPosition(Ox43,Ox43[OxOe847[160]]-5);Ox43[OxOe847[158]]=true;} ;function pnlVertical_Top_MouseMove(Ox43){if(!window[OxOe847[164]]){return ;} ;if(Ox43[OxOe847[141]]!=1){return ;} ;SetVerticalPosition(Ox43,Ox43[OxOe847[160]]-5);Ox43[OxOe847[158]]=true;} ;function pnlVertical_Top_MouseDown(Ox43){window[OxOe847[164]]=true;SetVerticalPosition(Ox43,Ox43[OxOe847[160]]-5);Ox43[OxOe847[158]]=true;} ;function pnlVertical_Top_MouseUp(Ox43){window[OxOe847[164]]=false;SetVerticalPosition(Ox43,Ox43[OxOe847[160]]-5);Ox43[OxOe847[158]]=true;} ;function SetCookie(name,Ox4f,Ox56){var Ox57=name+OxOe847[165]+escape(Ox4f)+OxOe847[166];if(Ox56){var Ox58= new Date();Ox58.setSeconds(Ox58.getSeconds()+Ox56);Ox57+=OxOe847[167]+Ox58.toUTCString()+OxOe847[168];} ;document[OxOe847[169]]=Ox57;} ;function GetCookie(name){var Ox5a=document[OxOe847[169]].split(OxOe847[168]);for(var i=0;i<Ox5a[OxOe847[28]];i++){var Ox5b=Ox5a[i].split(OxOe847[165]);if(name==Ox5b[0].replace(/\s/g,OxOe847[94])){return unescape(Ox5b[1]);} ;} ;} ;function GetCookieDictionary(){var Ox12b={};var Ox5a=document[OxOe847[169]].split(OxOe847[168]);for(var i=0;i<Ox5a[OxOe847[28]];i++){var Ox5b=Ox5a[i].split(OxOe847[165]);Ox12b[Ox5b[0].replace(/\s/g,OxOe847[94])]=unescape(Ox5b[1]);} ;return Ox12b;} ;function GetQuery(name){var i=0;while(window[OxOe847[171]][OxOe847[170]].indexOf(name+OxOe847[165],i)!=-1){var Ox4f=window[OxOe847[171]][OxOe847[170]].substr(window[OxOe847[171]][OxOe847[170]].indexOf(name+OxOe847[165],i));Ox4f=Ox4f.substr(name[OxOe847[28]]+1);if(Ox4f.indexOf(OxOe847[172])!=-1){if(Ox4f.indexOf(OxOe847[172])==0){Ox4f=OxOe847[94];} else {Ox4f=Ox4f.substr(0,Ox4f.indexOf(OxOe847[172]));} ;} ;return unescape(Ox4f);} ;return OxOe847[94];} ;function RgbIsWebSafe(Ox2b9){var hex=RgbToHex(Ox2b9);for(var i=0;i<3;i++){if(OxOe847[173].indexOf(hex.substr(i*2,2))==-1){return false;} ;} ;return true;} ;function RgbToWebSafeRgb(Ox2b9){var Ox2ef= new Array(Ox2b9[0],Ox2b9[1],Ox2b9[2]);if(RgbIsWebSafe(Ox2b9)){return Ox2ef;} ;var Ox2f0= new Array(0x00,0x33,0x66,0x99,0xCC,0xFF);for(var i=0;i<3;i++){for(var Ox25=1;Ox25<6;Ox25++){if(Ox2ef[i]>Ox2f0[Ox25-1]&&Ox2ef[i]<Ox2f0[Ox25]){if(Ox2ef[i]-Ox2f0[Ox25-1]>Ox2f0[Ox25]-Ox2ef[i]){Ox2ef[i]=Ox2f0[Ox25];} else {Ox2ef[i]=Ox2f0[Ox25-1];} ;break ;} ;} ;} ;return Ox2ef;} ;function RgbToYuv(Ox2b9){var Ox2f2= new Array();Ox2f2[0]=(Ox2b9[0]*0.299+Ox2b9[1]*0.587+Ox2b9[2]*0.114)/255;Ox2f2[1]=(Ox2b9[0]*-0.169+Ox2b9[1]*-0.332+Ox2b9[2]*0.500+128)/255;Ox2f2[2]=(Ox2b9[0]*0.500+Ox2b9[1]*-0.419+Ox2b9[2]*-0.0813+128)/255;return Ox2f2;} ;function RgbToHsb(Ox2b9){var Ox2f4= new Array(Ox2b9[0],Ox2b9[1],Ox2b9[2]);var Ox2f5= new Number(1);var Ox2f6= new Number(0);var Ox2f7= new Number(1);var Ox2d5= new Array(0,0,0);var Ox2f8= new Array();for(var i=0;i<3;i++){Ox2f4[i]=Ox2b9[i]/255;if(Ox2f4[i]<Ox2f5){Ox2f5=Ox2f4[i];} ;if(Ox2f4[i]>Ox2f6){Ox2f6=Ox2f4[i];} ;} ;Ox2f7=Ox2f6-Ox2f5;Ox2d5[2]=Ox2f6;if(Ox2f7==0){return Ox2d5;} ;Ox2d5[1]=Ox2f7/Ox2f6;for(var i=0;i<3;i++){Ox2f8[i]=(((Ox2f6-Ox2f4[i])/6)+(Ox2f7/2))/Ox2f7;} ;if(Ox2f4[0]==Ox2f6){Ox2d5[0]=Ox2f8[2]-Ox2f8[1];} else {if(Ox2f4[1]==Ox2f6){Ox2d5[0]=(1/3)+Ox2f8[0]-Ox2f8[2];} else {if(Ox2f4[2]==Ox2f6){Ox2d5[0]=(2/3)+Ox2f8[1]-Ox2f8[0];} ;} ;} ;if(Ox2d5[0]<0){Ox2d5[0]+=1;} else {if(Ox2d5[0]>1){Ox2d5[0]-=1;} ;} ;return Ox2d5;} ;function HsbToRgb(Ox2d5){var Ox2b9=HueToRgb(Ox2d5[0]);var Ox120=Ox2d5[2]*255;for(var i=0;i<3;i++){Ox2b9[i]=Ox2b9[i]*Ox2d5[2];Ox2b9[i]=((Ox2b9[i]-Ox120)*Ox2d5[1])+Ox120;Ox2b9[i]=Math.round(Ox2b9[i]);} ;return Ox2b9;} ;function RgbToHex(Ox2b9){var hex= new String();for(var i=0;i<3;i++){Ox2b9[2-i]=Math.round(Ox2b9[2-i]);hex=Ox2b9[2-i].toString(16)+hex;if(hex[OxOe847[28]]%2==1){hex=OxOe847[151]+hex;} ;} ;return hex.toUpperCase();} ;function HexToRgb(hex){var Ox2b9= new Array();for(var i=0;i<3;i++){Ox2b9[i]= new Number(OxOe847[174]+hex.substr(i*2,2));} ;return Ox2b9;} ;function HueToRgb(Ox2fd){var Ox2fe=Ox2fd*360;var Ox2b9= new Array(0,0,0);var Ox2ff=(Ox2fe%60)/60;if(Ox2fe<60){Ox2b9[0]=255;Ox2b9[1]=Ox2ff*255;} else {if(Ox2fe<120){Ox2b9[1]=255;Ox2b9[0]=(1-Ox2ff)*255;} else {if(Ox2fe<180){Ox2b9[1]=255;Ox2b9[2]=Ox2ff*255;} else {if(Ox2fe<240){Ox2b9[2]=255;Ox2b9[1]=(1-Ox2ff)*255;} else {if(Ox2fe<300){Ox2b9[2]=255;Ox2b9[0]=Ox2ff*255;} else {if(Ox2fe<360){Ox2b9[0]=255;Ox2b9[2]=(1-Ox2ff)*255;} ;} ;} ;} ;} ;} ;return Ox2b9;} ;function CheckHexSelect(){if(window[OxOe847[175]]&&window[OxOe847[176]]&&frm[OxOe847[12]]){var Oxdc=OxOe847[74]+frm[OxOe847[12]][OxOe847[96]];if(Oxdc[OxOe847[28]]==7){if(window[OxOe847[177]]!=Oxdc){window[OxOe847[177]]=Oxdc;window.do_select(Oxdc);} ;} ;} ;} ;setInterval(CheckHexSelect,10);