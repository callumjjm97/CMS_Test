var OxO9905=["0123456789ABCDEF","0000","all","getElementById","","|","fond","\x3Cimg src=\x22Load.ashx?type=image\x26file=multiclavier.gif\x22 width=404 height=152 border=\x220\x22\x3E\x3Cbr /\x3E","sign","car","simpledia","simple","majus","\x26nbsp;","double","minus","doubledia","kb-","kb+","Delete","Clear","Back","CapsLock","Enter","Shift","\x3C|\x3C","Space","\x3E|\x3E","clavscroll(-3)","clavscroll(3)","faire(\x22del\x22)","RAZ()","faire(\x22bck\x22)","bloq()","faire(\x22\x5Cn\x22)","haut()","faire(\x22ar\x22)","faire(\x22 \x22)","faire(\x22av\x22)","act","action","clav","clavier","masque","\x3Cimg src=\x22Load.ashx?type=image\x26file=1x1.gif\x22 width=404 height=152 border=\x220\x22 usemap=\x22#clavier\x22\x3E","\x3Cmap name=\x22clavier\x22\x3E","\x3Carea coords=\x22",",","\x22 href=\x22javascript:void(0)\x22 onClick=\x27javascript:ecrire(",")\x27\x3E","\x22 href=\x22javascript:void(0)\x22 onClick=\x27javascript:","\x27\x3E","\x22 href=\x27javascript:charger(","\x3C/map\x3E","length"," ","%0D%0A","av","ar","bck","del","\x3Cspan class=","\x3E","\x3C/span\x3E","\x3Cdiv id=\x22","\x22 \x3E","\x3C/div\x3E","left","style","px","top","innerHTML","act0","act1","langue=","cookie",";","langue","=","; ","expires="];var caps=0,lock=0,hexchars=OxO9905[0],accent=OxO9905[1],clavdeb=0;var clav= new Array();j=0;for(i in Maj){clav[j]=i;j++;} ;var ns6=((!document[OxO9905[2]])&&(document[OxO9905[3]]));var ie=document[OxO9905[2]];var langue=getCk();if(langue==OxO9905[4]){langue=clav[clavdeb];} ;CarMaj=Maj[langue].split(OxO9905[5]);CarMin=Min[langue].split(OxO9905[5]);var posClavierLeft=0,posClavierTop=0;if(ns6){posClavierLeft=0;posClavierTop=80;} else {if(ie){posClavierLeft=0;posClavierTop=80;} ;} ;tracer(OxO9905[6],posClavierLeft,posClavierTop,OxO9905[7],OxO9905[8]);var posX= new Array(0,28,56,84,112,140,168,196,224,252,280,308,336,42,70,98,126,154,182,210,238,266,294,322,350,50,78,106,134,162,190,218,246,274,302,330,64,92,120,148,176,204,232,260,288,316,28,56,84,294,322,350);var posY= new Array(14,14,14,14,14,14,14,14,14,14,14,14,14,42,42,42,42,42,42,42,42,42,42,42,42,70,70,70,70,70,70,70,70,70,70,70,98,98,98,98,98,98,98,98,98,98,126,126,126,126,126,126);var nbTouches=52;for(i=0;i<nbTouches;i++){CarMaj[i]=((CarMaj[i]!=OxO9905[1])?(fromhexby4tocar(CarMaj[i])):OxO9905[4]);CarMin[i]=((CarMin[i]!=OxO9905[1])?(fromhexby4tocar(CarMin[i])):OxO9905[4]);if(CarMaj[i]==CarMin[i].toUpperCase()){cecar=((lock==0)&&(caps==0)?CarMin[i]:CarMaj[i]);tracer(OxO9905[9]+i,posClavierLeft+6+posX[i],posClavierTop+3+posY[i],cecar,((dia[hexa(cecar)]!=null)?OxO9905[10]:OxO9905[11]));tracer(OxO9905[12]+i,posClavierLeft+15+posX[i],posClavierTop+1+posY[i],OxO9905[13],OxO9905[14]);tracer(OxO9905[15]+i,posClavierLeft+3+posX[i],posClavierTop+9+posY[i],OxO9905[13],OxO9905[14]);} else {tracer(OxO9905[9]+i,posClavierLeft+6+posX[i],posClavierTop+3+posY[i],OxO9905[13],OxO9905[11]);cecar=CarMin[i];tracer(OxO9905[15]+i,posClavierLeft+3+posX[i],posClavierTop+9+posY[i],cecar,((dia[hexa(cecar)]!=null)?OxO9905[16]:OxO9905[14]));cecar=CarMaj[i];tracer(OxO9905[12]+i,posClavierLeft+15+posX[i],posClavierTop+1+posY[i],cecar,((dia[hexa(cecar)]!=null)?OxO9905[16]:OxO9905[14]));} ;} ;var actC1= new Array(0,371,364,0,378,0,358,0,344,0,112,378);var actC2= new Array(0,0,14,42,42,70,70,98,98,126,126,126);var actC3= new Array(32,403,403,39,403,47,403,61,403,25,291,403);var actC4= new Array(11,11,39,67,67,95,95,123,123,151,151,151);var act= new Array(OxO9905[17],OxO9905[18],OxO9905[19],OxO9905[20],OxO9905[21],OxO9905[22],OxO9905[23],OxO9905[24],OxO9905[24],OxO9905[25],OxO9905[26],OxO9905[27]);var effet= new Array(OxO9905[28],OxO9905[29],OxO9905[30],OxO9905[31],OxO9905[32],OxO9905[33],OxO9905[34],OxO9905[35],OxO9905[35],OxO9905[36],OxO9905[37],OxO9905[38]);var nbActions=12;for(i=0;i<nbActions;i++){tracer(OxO9905[39]+i,posClavierLeft+1+actC1[i],posClavierTop-1+actC2[i],act[i],OxO9905[40]);} ;var clavC1= new Array(35,119,203,287);var clavC2= new Array(0,0,0,0);var clavC3= new Array(116,200,284,368);var clavC4= new Array(11,11,11,11);for(i=0;i<4;i++){tracer(OxO9905[41]+i,posClavierLeft+5+clavC1[i],posClavierTop-1+clavC2[i],clav[i],OxO9905[42]);} ;tracer(OxO9905[43],posClavierLeft,posClavierTop,OxO9905[44]);document.write(OxO9905[45]);for(i=0;i<nbTouches;i++){document.write(OxO9905[46]+posX[i]+OxO9905[47]+posY[i]+OxO9905[47]+(posX[i]+25)+OxO9905[47]+(posY[i]+25)+OxO9905[48]+i+OxO9905[49]);} ;for(i=0;i<nbActions;i++){document.write(OxO9905[46]+actC1[i]+OxO9905[47]+actC2[i]+OxO9905[47]+actC3[i]+OxO9905[47]+actC4[i]+OxO9905[50]+effet[i]+OxO9905[51]);} ;for(i=0;i<4;i++){document.write(OxO9905[46]+clavC1[i]+OxO9905[47]+clavC2[i]+OxO9905[47]+clavC3[i]+OxO9905[47]+clavC4[i]+OxO9905[52]+i+OxO9905[49]);} ;document.write(OxO9905[53]);function ecrire(i){txt=rechercher()+OxO9905[5];subtxt=txt.split(OxO9905[5]);ceci=(lock==1)?CarMaj[i]:((caps==1)?CarMaj[i]:CarMin[i]);if(test(ceci)){subtxt[0]+=cardia(ceci);distinguer(false);} else {if(dia[accent]!=null&&dia[hexa(ceci)]!=null){distinguer(false);accent=hexa(ceci);distinguer(true);} else {if(dia[accent]!=null){subtxt[0]+=fromhexby4tocar(accent)+ceci;distinguer(false);} else {if(dia[hexa(ceci)]!=null){accent=hexa(ceci);distinguer(true);} else {subtxt[0]+=ceci;} ;} ;} ;} ;txt=subtxt[0]+OxO9905[5]+subtxt[1];afficher(txt);if(caps==1){caps=0;MinusMajus();} ;} ;function faire(Oxb2c){txt=rechercher()+OxO9905[5];subtxt=txt.split(OxO9905[5]);l0=subtxt[0][OxO9905[54]];l1=subtxt[1][OxO9905[54]];c1=subtxt[0].substring(0,(l0-2));c2=subtxt[0].substring(0,(l0-1));c3=subtxt[1].substring(0,1);c4=subtxt[1].substring(0,2);c5=subtxt[0].substring((l0-2),l0);c6=subtxt[0].substring((l0-1),l0);c7=subtxt[1].substring(1,l1);c8=subtxt[1].substring(2,l1);if(dia[accent]!=null){if(Oxb2c==OxO9905[55]){Oxb2c=fromhexby4tocar(accent);} ;distinguer(false);} ;switch(Oxb2c){case (OxO9905[57]):if(escape(c4)!=OxO9905[56]){txt=subtxt[0]+c3+OxO9905[5]+c7;} else {txt=subtxt[0]+c4+OxO9905[5]+c8;} ;break ;;case (OxO9905[58]):if(escape(c5)!=OxO9905[56]){txt=c2+OxO9905[5]+c6+subtxt[1];} else {txt=c1+OxO9905[5]+c5+subtxt[1];} ;break ;;case (OxO9905[59]):if(escape(c5)!=OxO9905[56]){txt=c2+OxO9905[5]+subtxt[1];} else {txt=c1+OxO9905[5]+subtxt[1];} ;break ;;case (OxO9905[60]):if(escape(c4)!=OxO9905[56]){txt=subtxt[0]+OxO9905[5]+c7;} else {txt=subtxt[0]+OxO9905[5]+c8;} ;break ;;default:txt=subtxt[0]+Oxb2c+OxO9905[5]+subtxt[1];break ;;} ;afficher(txt);} ;function RAZ(){txt=OxO9905[4];if(dia[accent]!=null){distinguer(false);} ;afficher(txt);} ;function haut(){caps=1;MinusMajus();} ;function bloq(){lock=(lock==1)?0:1;MinusMajus();} ;function tracer(Oxb31,Oxb32,haut,Oxb2c,Oxb33){Oxb2c=OxO9905[61]+Oxb33+OxO9905[62]+Oxb2c+OxO9905[63];document.write(OxO9905[64]+Oxb31+OxO9905[65]+Oxb2c+OxO9905[66]);if(ns6){document.getElementById(Oxb31)[OxO9905[68]][OxO9905[67]]=Oxb32+OxO9905[69];document.getElementById(Oxb31)[OxO9905[68]][OxO9905[70]]=haut+OxO9905[69];} else {if(ie){document.all(Oxb31)[OxO9905[68]][OxO9905[67]]=Oxb32;document.all(Oxb31)[OxO9905[68]][OxO9905[70]]=haut;} ;} ;} ;function retracer(Oxb31,Oxb2c,Oxb33){Oxb2c=OxO9905[61]+Oxb33+OxO9905[62]+Oxb2c+OxO9905[63];if(ns6){document.getElementById(Oxb31)[OxO9905[71]]=Oxb2c;} else {if(ie){doc=document.all(Oxb31);doc[OxO9905[71]]=Oxb2c;} ;} ;} ;function clavscroll(Ox27){clavdeb+=Ox27;if(clavdeb<0){clavdeb=0;} ;if(clavdeb>clav[OxO9905[54]]-4){clavdeb=clav[OxO9905[54]]-4;} ;for(i=clavdeb;i<clavdeb+4;i++){retracer(OxO9905[41]+(i-clavdeb),clav[i],OxO9905[42]);} ;if(clavdeb==0){retracer(OxO9905[72],OxO9905[13],OxO9905[40]);} else {retracer(OxO9905[72],act[0],OxO9905[40]);} ;if(clavdeb==clav[OxO9905[54]]-4){retracer(OxO9905[73],OxO9905[13],OxO9905[40]);} else {retracer(OxO9905[73],act[1],OxO9905[40]);} ;} ;function charger(i){langue=clav[i+clavdeb];setCk(langue);accent=OxO9905[1];CarMaj=Maj[langue].split(OxO9905[5]);CarMin=Min[langue].split(OxO9905[5]);for(i=0;i<nbTouches;i++){CarMaj[i]=((CarMaj[i]!=OxO9905[1])?(fromhexby4tocar(CarMaj[i])):OxO9905[4]);CarMin[i]=((CarMin[i]!=OxO9905[1])?(fromhexby4tocar(CarMin[i])):OxO9905[4]);if(CarMaj[i]==CarMin[i].toUpperCase()){cecar=((lock==0)&&(caps==0)?CarMin[i]:CarMaj[i]);retracer(OxO9905[9]+i,cecar,((dia[hexa(cecar)]!=null)?OxO9905[10]:OxO9905[11]));retracer(OxO9905[15]+i,OxO9905[13]);retracer(OxO9905[12]+i,OxO9905[13]);} else {retracer(OxO9905[9]+i,OxO9905[13]);cecar=CarMin[i];retracer(OxO9905[15]+i,cecar,((dia[hexa(cecar)]!=null)?OxO9905[16]:OxO9905[14]));cecar=CarMaj[i];retracer(OxO9905[12]+i,cecar,((dia[hexa(cecar)]!=null)?OxO9905[16]:OxO9905[14]));} ;} ;} ;function distinguer(Oxb38){for(i=0;i<nbTouches;i++){if(CarMaj[i]==CarMin[i].toUpperCase()){cecar=((lock==0)&&(caps==0)?CarMin[i]:CarMaj[i]);if(test(cecar)){retracer(OxO9905[9]+i,Oxb38?(cardia(cecar)):cecar,Oxb38?OxO9905[10]:OxO9905[11]);} ;} else {cecar=CarMin[i];if(test(cecar)){retracer(OxO9905[15]+i,Oxb38?(cardia(cecar)):cecar,Oxb38?OxO9905[16]:OxO9905[14]);} ;cecar=CarMaj[i];if(test(cecar)){retracer(OxO9905[12]+i,Oxb38?(cardia(cecar)):cecar,Oxb38?OxO9905[16]:OxO9905[14]);} ;} ;} ;if(!Oxb38){accent=OxO9905[1];} ;} ;function MinusMajus(){for(i=0;i<nbTouches;i++){if(CarMaj[i]==CarMin[i].toUpperCase()){cecar=((lock==0)&&(caps==0)?CarMin[i]:CarMaj[i]);retracer(OxO9905[9]+i,(test(cecar)?cardia(cecar):cecar),((dia[hexa(cecar)]!=null||test(cecar))?OxO9905[10]:OxO9905[11]));} ;} ;} ;function test(Oxb3a){return (dia[accent]!=null&&dia[accent][hexa(Oxb3a)]!=null);} ;function cardia(Oxb3a){return (fromhexby4tocar(dia[accent][hexa(Oxb3a)]));} ;function fromhex(Oxb3d){out=0;for(a=Oxb3d[OxO9905[54]]-1;a>=0;a--){out+=Math.pow(16,Oxb3d[OxO9905[54]]-a-1)*hexchars.indexOf(Oxb3d.charAt(a));} ;return out;} ;function fromhexby4tocar(Oxb2c){out4= new String();for(l=0;l<Oxb2c[OxO9905[54]];l+=4){out4+=String.fromCharCode(fromhex(Oxb2c.substring(l,l+4)));} ;return out4;} ;function tohex(Oxb3d){return hexchars.charAt(Oxb3d/16)+hexchars.charAt(Oxb3d%16);} ;function tohex2(Oxb3d){return tohex(Oxb3d/256)+tohex(Oxb3d%256);} ;function hexa(Oxb2c){out=OxO9905[4];for(k=0;k<Oxb2c[OxO9905[54]];k++){out+=(tohex2(Oxb2c.charCodeAt(k)));} ;return out;} ;function getCk(){fromN=document[OxO9905[75]].indexOf(OxO9905[74])+0;if((fromN)!=-1){fromN+=7;toN=document[OxO9905[75]].indexOf(OxO9905[76],fromN)+0;if(toN==-1){toN=document[OxO9905[75]][OxO9905[54]];} ;return unescape(document[OxO9905[75]].substring(fromN,toN));} ;return OxO9905[4];} ;function setCk(Oxb3d){if(Oxb3d!=null){exp= new Date();time=365*60*60*24*1000;exp.setTime(exp.getTime()+time);document[OxO9905[75]]=escape(OxO9905[77])+OxO9905[78]+escape(Oxb3d)+OxO9905[79]+OxO9905[80]+exp.toGMTString();} ;} ;