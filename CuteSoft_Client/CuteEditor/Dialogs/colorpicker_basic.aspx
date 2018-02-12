<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<script runat="server">
string GetDialogQueryString;
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{	
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="colorpicker_basic.aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[MoreColors]]",FrameSrc);
		Context.Response.End();
	}
	}
	string s="";
	if(Context.Request.QueryString["Dialog"]=="Standard")	
		s="&Dialog=Standard";
	
	GetDialogQueryString="Theme="+Context.Request.QueryString["Theme"]+s;	
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=DialogHead.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&verfix=1006&file=Dialog_ColorPicker.js"></script>
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css"
			rel="stylesheet" />
		<style type="text/css">
			.colorcell
			{
				width:16px;
				height:17px;
				cursor:hand;
			}
			.colordiv,.customdiv
			{
				border:solid 1px #808080;
				width:16px;
				height:17px;
				font-size:1px;
			}
			#ajaxdiv{padding:10px;margin:0;text-align:center; background:#eeeeee;}
		</style>
		<title>[[NamedColors]]</title>
		<script>
								
		var OxO1d53=["Green","#008000","Lime","#00FF00","Teal","#008080","Aqua","#00FFFF","Navy","#000080","Blue","#0000FF","Purple","#800080","Fuchsia","#FF00FF","Maroon","#800000","Red","#FF0000","Olive","#808000","Yellow","#FFFF00","White","#FFFFFF","Silver","#C0C0C0","Gray","#808080","Black","#000000","DarkOliveGreen","#556B2F","DarkGreen","#006400","DarkSlateGray","#2F4F4F","SlateGray","#708090","DarkBlue","#00008B","MidnightBlue","#191970","Indigo","#4B0082","DarkMagenta","#8B008B","Brown","#A52A2A","DarkRed","#8B0000","Sienna","#A0522D","SaddleBrown","#8B4513","DarkGoldenrod","#B8860B","Beige","#F5F5DC","HoneyDew","#F0FFF0","DimGray","#696969","OliveDrab","#6B8E23","ForestGreen","#228B22","DarkCyan","#008B8B","LightSlateGray","#778899","MediumBlue","#0000CD","DarkSlateBlue","#483D8B","DarkViolet","#9400D3","MediumVioletRed","#C71585","IndianRed","#CD5C5C","Firebrick","#B22222","Chocolate","#D2691E","Peru","#CD853F","Goldenrod","#DAA520","LightGoldenrodYellow","#FAFAD2","MintCream","#F5FFFA","DarkGray","#A9A9A9","YellowGreen","#9ACD32","SeaGreen","#2E8B57","CadetBlue","#5F9EA0","SteelBlue","#4682B4","RoyalBlue","#4169E1","BlueViolet","#8A2BE2","DarkOrchid","#9932CC","DeepPink","#FF1493","RosyBrown","#BC8F8F","Crimson","#DC143C","DarkOrange","#FF8C00","BurlyWood","#DEB887","DarkKhaki","#BDB76B","LightYellow","#FFFFE0","Azure","#F0FFFF","LightGray","#D3D3D3","LawnGreen","#7CFC00","MediumSeaGreen","#3CB371","LightSeaGreen","#20B2AA","DeepSkyBlue","#00BFFF","DodgerBlue","#1E90FF","SlateBlue","#6A5ACD","MediumOrchid","#BA55D3","PaleVioletRed","#DB7093","Salmon","#FA8072","OrangeRed","#FF4500","SandyBrown","#F4A460","Tan","#D2B48C","Gold","#FFD700","Ivory","#FFFFF0","GhostWhite","#F8F8FF","Gainsboro","#DCDCDC","Chartreuse","#7FFF00","LimeGreen","#32CD32","MediumAquamarine","#66CDAA","DarkTurquoise","#00CED1","CornflowerBlue","#6495ED","MediumSlateBlue","#7B68EE","Orchid","#DA70D6","HotPink","#FF69B4","LightCoral","#F08080","Tomato","#FF6347","Orange","#FFA500","Bisque","#FFE4C4","Khaki","#F0E68C","Cornsilk","#FFF8DC","Linen","#FAF0E6","WhiteSmoke","#F5F5F5","GreenYellow","#ADFF2F","DarkSeaGreen","#8FBC8B","Turquoise","#40E0D0","MediumTurquoise","#48D1CC","SkyBlue","#87CEEB","MediumPurple","#9370DB","Violet","#EE82EE","LightPink","#FFB6C1","DarkSalmon","#E9967A","Coral","#FF7F50","NavajoWhite","#FFDEAD","BlanchedAlmond","#FFEBCD","PaleGoldenrod","#EEE8AA","Oldlace","#FDF5E6","Seashell","#FFF5EE","PaleGreen","#98FB98","SpringGreen","#00FF7F","Aquamarine","#7FFFD4","PowderBlue","#B0E0E6","LightSkyBlue","#87CEFA","LightSteelBlue","#B0C4DE","Plum","#DDA0DD","Pink","#FFC0CB","LightSalmon","#FFA07A","Wheat","#F5DEB3","Moccasin","#FFE4B5","AntiqueWhite","#FAEBD7","LemonChiffon","#FFFACD","FloralWhite","#FFFAF0","Snow","#FFFAFA","AliceBlue","#F0F8FF","LightGreen","#90EE90","MediumSpringGreen","#00FA9A","PaleTurquoise","#AFEEEE","LightCyan","#E0FFFF","LightBlue","#ADD8E6","Lavender","#E6E6FA","Thistle","#D8BFD8","MistyRose","#FFE4E1","Peachpuff","#FFDAB9","PapayaWhip","#FFEFD5"];var colorlist=[{n:OxO1d53[0],h:OxO1d53[1]},{n:OxO1d53[2],h:OxO1d53[3]},{n:OxO1d53[4],h:OxO1d53[5]},{n:OxO1d53[6],h:OxO1d53[7]},{n:OxO1d53[8],h:OxO1d53[9]},{n:OxO1d53[10],h:OxO1d53[11]},{n:OxO1d53[12],h:OxO1d53[13]},{n:OxO1d53[14],h:OxO1d53[15]},{n:OxO1d53[16],h:OxO1d53[17]},{n:OxO1d53[18],h:OxO1d53[19]},{n:OxO1d53[20],h:OxO1d53[21]},{n:OxO1d53[22],h:OxO1d53[23]},{n:OxO1d53[24],h:OxO1d53[25]},{n:OxO1d53[26],h:OxO1d53[27]},{n:OxO1d53[28],h:OxO1d53[29]},{n:OxO1d53[30],h:OxO1d53[31]}];var colormore=[{n:OxO1d53[32],h:OxO1d53[33]},{n:OxO1d53[34],h:OxO1d53[35]},{n:OxO1d53[36],h:OxO1d53[37]},{n:OxO1d53[38],h:OxO1d53[39]},{n:OxO1d53[40],h:OxO1d53[41]},{n:OxO1d53[42],h:OxO1d53[43]},{n:OxO1d53[44],h:OxO1d53[45]},{n:OxO1d53[46],h:OxO1d53[47]},{n:OxO1d53[48],h:OxO1d53[49]},{n:OxO1d53[50],h:OxO1d53[51]},{n:OxO1d53[52],h:OxO1d53[53]},{n:OxO1d53[54],h:OxO1d53[55]},{n:OxO1d53[56],h:OxO1d53[57]},{n:OxO1d53[58],h:OxO1d53[59]},{n:OxO1d53[60],h:OxO1d53[61]},{n:OxO1d53[62],h:OxO1d53[63]},{n:OxO1d53[64],h:OxO1d53[65]},{n:OxO1d53[66],h:OxO1d53[67]},{n:OxO1d53[68],h:OxO1d53[69]},{n:OxO1d53[70],h:OxO1d53[71]},{n:OxO1d53[72],h:OxO1d53[73]},{n:OxO1d53[74],h:OxO1d53[75]},{n:OxO1d53[76],h:OxO1d53[77]},{n:OxO1d53[78],h:OxO1d53[79]},{n:OxO1d53[80],h:OxO1d53[81]},{n:OxO1d53[82],h:OxO1d53[83]},{n:OxO1d53[84],h:OxO1d53[85]},{n:OxO1d53[86],h:OxO1d53[87]},{n:OxO1d53[88],h:OxO1d53[89]},{n:OxO1d53[90],h:OxO1d53[91]},{n:OxO1d53[92],h:OxO1d53[93]},{n:OxO1d53[94],h:OxO1d53[95]},{n:OxO1d53[96],h:OxO1d53[97]},{n:OxO1d53[98],h:OxO1d53[99]},{n:OxO1d53[100],h:OxO1d53[101]},{n:OxO1d53[102],h:OxO1d53[103]},{n:OxO1d53[104],h:OxO1d53[105]},{n:OxO1d53[106],h:OxO1d53[107]},{n:OxO1d53[108],h:OxO1d53[109]},{n:OxO1d53[110],h:OxO1d53[111]},{n:OxO1d53[112],h:OxO1d53[113]},{n:OxO1d53[114],h:OxO1d53[115]},{n:OxO1d53[116],h:OxO1d53[117]},{n:OxO1d53[118],h:OxO1d53[119]},{n:OxO1d53[120],h:OxO1d53[121]},{n:OxO1d53[122],h:OxO1d53[123]},{n:OxO1d53[124],h:OxO1d53[125]},{n:OxO1d53[126],h:OxO1d53[127]},{n:OxO1d53[128],h:OxO1d53[129]},{n:OxO1d53[130],h:OxO1d53[131]},{n:OxO1d53[132],h:OxO1d53[133]},{n:OxO1d53[134],h:OxO1d53[135]},{n:OxO1d53[136],h:OxO1d53[137]},{n:OxO1d53[138],h:OxO1d53[139]},{n:OxO1d53[140],h:OxO1d53[141]},{n:OxO1d53[142],h:OxO1d53[143]},{n:OxO1d53[144],h:OxO1d53[145]},{n:OxO1d53[146],h:OxO1d53[147]},{n:OxO1d53[148],h:OxO1d53[149]},{n:OxO1d53[150],h:OxO1d53[151]},{n:OxO1d53[152],h:OxO1d53[153]},{n:OxO1d53[154],h:OxO1d53[155]},{n:OxO1d53[156],h:OxO1d53[157]},{n:OxO1d53[158],h:OxO1d53[159]},{n:OxO1d53[160],h:OxO1d53[161]},{n:OxO1d53[162],h:OxO1d53[163]},{n:OxO1d53[164],h:OxO1d53[165]},{n:OxO1d53[166],h:OxO1d53[167]},{n:OxO1d53[168],h:OxO1d53[169]},{n:OxO1d53[170],h:OxO1d53[171]},{n:OxO1d53[172],h:OxO1d53[173]},{n:OxO1d53[174],h:OxO1d53[175]},{n:OxO1d53[176],h:OxO1d53[177]},{n:OxO1d53[178],h:OxO1d53[179]},{n:OxO1d53[180],h:OxO1d53[181]},{n:OxO1d53[182],h:OxO1d53[183]},{n:OxO1d53[184],h:OxO1d53[185]},{n:OxO1d53[186],h:OxO1d53[187]},{n:OxO1d53[188],h:OxO1d53[189]},{n:OxO1d53[190],h:OxO1d53[191]},{n:OxO1d53[192],h:OxO1d53[193]},{n:OxO1d53[194],h:OxO1d53[195]},{n:OxO1d53[196],h:OxO1d53[197]},{n:OxO1d53[198],h:OxO1d53[199]},{n:OxO1d53[200],h:OxO1d53[201]},{n:OxO1d53[202],h:OxO1d53[203]},{n:OxO1d53[204],h:OxO1d53[205]},{n:OxO1d53[206],h:OxO1d53[207]},{n:OxO1d53[208],h:OxO1d53[209]},{n:OxO1d53[210],h:OxO1d53[211]},{n:OxO1d53[212],h:OxO1d53[213]},{n:OxO1d53[214],h:OxO1d53[215]},{n:OxO1d53[216],h:OxO1d53[217]},{n:OxO1d53[218],h:OxO1d53[219]},{n:OxO1d53[220],h:OxO1d53[221]},{n:OxO1d53[156],h:OxO1d53[157]},{n:OxO1d53[222],h:OxO1d53[223]},{n:OxO1d53[224],h:OxO1d53[225]},{n:OxO1d53[226],h:OxO1d53[227]},{n:OxO1d53[228],h:OxO1d53[229]},{n:OxO1d53[230],h:OxO1d53[231]},{n:OxO1d53[232],h:OxO1d53[233]},{n:OxO1d53[234],h:OxO1d53[235]},{n:OxO1d53[236],h:OxO1d53[237]},{n:OxO1d53[238],h:OxO1d53[239]},{n:OxO1d53[240],h:OxO1d53[241]},{n:OxO1d53[242],h:OxO1d53[243]},{n:OxO1d53[244],h:OxO1d53[245]},{n:OxO1d53[246],h:OxO1d53[247]},{n:OxO1d53[248],h:OxO1d53[249]},{n:OxO1d53[250],h:OxO1d53[251]},{n:OxO1d53[252],h:OxO1d53[253]},{n:OxO1d53[254],h:OxO1d53[255]},{n:OxO1d53[256],h:OxO1d53[257]},{n:OxO1d53[258],h:OxO1d53[259]},{n:OxO1d53[260],h:OxO1d53[261]},{n:OxO1d53[262],h:OxO1d53[263]},{n:OxO1d53[264],h:OxO1d53[265]},{n:OxO1d53[266],h:OxO1d53[267]},{n:OxO1d53[268],h:OxO1d53[269]},{n:OxO1d53[270],h:OxO1d53[271]},{n:OxO1d53[272],h:OxO1d53[273]}];
		
		</script>
	</head>
	<body>
		<div id="ajaxdiv">
			<div class="tab-pane-control tab-pane" id="tabPane1">
				<div class="tab-row">
					<h2 class="tab">
						<a tabindex="-1" href='colorpicker.aspx?<%=GetDialogQueryString%>'>
							<span style="white-space:nowrap;">
								[[WebPalette]]
							</span>
						</a>
					</h2>
					<h2 class="tab selected">
							<a tabindex="-1" href='colorpicker_basic.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[NamedColors]]
								</span>
							</a>
					</h2>
					<h2 class="tab">
							<a tabindex="-1" href='colorpicker_more.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[CustomColor]]
								</span>
							</a>
					</h2>
				</div>
				<div class="tab-page">			
					<table class="colortable" align="center">
						<tr>
							<td colspan="16" height="16"><p align="left">Basic:
								</p>
							</td>
						</tr>
						<tr>
							<script>
								var OxOeffa=["length","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E",""];var arr=[];for(var i=0;i<colorlist[OxOeffa[0]];i++){arr.push(OxOeffa[1]);arr.push(colorlist[i].n);arr.push(OxOeffa[2]);arr.push(colorlist[i].n);arr.push(OxOeffa[3]);arr.push(colorlist[i].h);arr.push(OxOeffa[4]);arr.push(colorlist[i].n);arr.push(OxOeffa[5]);arr.push(colorlist[i].h);arr.push(OxOeffa[6]);} ;document.write(arr.join(OxOeffa[7]));
							</script>
						</tr>
						<tr>
							<td colspan="16" height="12"><p align="left"></p>
							</td>
						</tr>
						<tr>
							<td colspan="16"><p align="left">Additional:
								</p>
							</td>
						</tr>
						<script>
							var OxOdf14=["length","\x3Ctr\x3E","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E","\x3C/tr\x3E",""];var arr=[];for(var i=0;i<colormore[OxOdf14[0]];i++){if(i%16==0){arr.push(OxOdf14[1]);} ;arr.push(OxOdf14[2]);arr.push(colormore[i].n);arr.push(OxOdf14[3]);arr.push(colormore[i].n);arr.push(OxOdf14[4]);arr.push(colormore[i].h);arr.push(OxOdf14[5]);arr.push(colormore[i].n);arr.push(OxOdf14[6]);arr.push(colormore[i].h);arr.push(OxOdf14[7]);if(i%16==15){arr.push(OxOdf14[8]);} ;} ;if(colormore%16>0){arr.push(OxOdf14[8]);} ;document.write(arr.join(OxOdf14[9]));
						</script>
						<tr>
							<td colspan="16" height="8">
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
								<input checked id="CheckboxColorNames" style="width: 16px; height: 20px" type="checkbox">
								<span style="width: 118px;">Use color names</span>
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
							</td>
						</tr>
						<tr>
							<td colspan="16" valign="middle" height="24">
							<span style="height:24px;width:50px;vertical-align:middle;">Color : </span>&nbsp;
							<input type="text" id="divpreview" size="7" maxlength="7" style="width:180px;height:24px;border:#a0a0a0 1px solid; Padding:4;"/>
					
							</td>
						</tr>
				</table>
			</div>
		</div>
		<div id="container-bottom">
			<input type="button" id="buttonok" value="[[OK]]" class="formbutton" style="width:70px"	onclick="do_insert();" /> 
			&nbsp;&nbsp;&nbsp;&nbsp; 
			<input type="button" id="buttoncancel" value="[[Cancel]]" class="formbutton" style="width:70px"	onclick="do_Close();" />	
		</div>
	</div>
	</body>
</html>

