var OxOc6a9=["inp_name","inp_cols","inp_rows","inp_value","sel_Wrap","inp_id","inp_access","inp_index","inp_Disabled","inp_Readonly","Name","value","name","id","cols","","rows","checked","disabled","readOnly","wrap","tabIndex","accessKey","textContent"];var inp_name=Window_GetElement(window,OxOc6a9[0],true);var inp_cols=Window_GetElement(window,OxOc6a9[1],true);var inp_rows=Window_GetElement(window,OxOc6a9[2],true);var inp_value=Window_GetElement(window,OxOc6a9[3],true);var sel_Wrap=Window_GetElement(window,OxOc6a9[4],true);var inp_id=Window_GetElement(window,OxOc6a9[5],true);var inp_access=Window_GetElement(window,OxOc6a9[6],true);var inp_index=Window_GetElement(window,OxOc6a9[7],true);var inp_Disabled=Window_GetElement(window,OxOc6a9[8],true);var inp_Readonly=Window_GetElement(window,OxOc6a9[9],true);UpdateState=function UpdateState_Textarea(){} ;SyncToView=function SyncToView_Textarea(){if(element[OxOc6a9[10]]){inp_name[OxOc6a9[11]]=element[OxOc6a9[10]];} ;if(element[OxOc6a9[12]]){inp_name[OxOc6a9[11]]=element[OxOc6a9[12]];} ;inp_id[OxOc6a9[11]]=element[OxOc6a9[13]];inp_value[OxOc6a9[11]]=element[OxOc6a9[11]];if(element[OxOc6a9[14]]){if(element[OxOc6a9[14]]==20){inp_cols[OxOc6a9[11]]=OxOc6a9[15];} else {inp_cols[OxOc6a9[11]]=element[OxOc6a9[14]];} ;} ;if(element[OxOc6a9[16]]){if(element[OxOc6a9[16]]==2){inp_rows[OxOc6a9[11]]=OxOc6a9[15];} else {inp_rows[OxOc6a9[11]]=element[OxOc6a9[16]];} ;} ;inp_Disabled[OxOc6a9[17]]=element[OxOc6a9[18]];inp_Readonly[OxOc6a9[17]]=element[OxOc6a9[19]];sel_Wrap[OxOc6a9[11]]=element[OxOc6a9[20]];if(element[OxOc6a9[21]]==0){inp_index[OxOc6a9[11]]=OxOc6a9[15];} else {inp_index[OxOc6a9[11]]=element[OxOc6a9[21]];} ;if(element[OxOc6a9[22]]){inp_access[OxOc6a9[11]]=element[OxOc6a9[22]];} ;} ;SyncTo=function SyncTo_Textarea(element){element[OxOc6a9[12]]=inp_name[OxOc6a9[11]];if(element[OxOc6a9[10]]){element[OxOc6a9[10]]=inp_name[OxOc6a9[11]];} else {if(element[OxOc6a9[12]]){element.removeAttribute(OxOc6a9[12],0);element[OxOc6a9[10]]=inp_name[OxOc6a9[11]];} else {element[OxOc6a9[10]]=inp_name[OxOc6a9[11]];} ;} ;element[OxOc6a9[13]]=inp_id[OxOc6a9[11]];element[OxOc6a9[11]]=inp_value[OxOc6a9[11]];if(!Browser_IsWinIE()){try{element[OxOc6a9[23]]=inp_value[OxOc6a9[11]];} catch(x){} ;} ;element[OxOc6a9[21]]=inp_index[OxOc6a9[11]];element[OxOc6a9[18]]=inp_Disabled[OxOc6a9[17]];element[OxOc6a9[19]]=inp_Readonly[OxOc6a9[17]];element[OxOc6a9[22]]=inp_access[OxOc6a9[11]];if(inp_cols[OxOc6a9[11]]==OxOc6a9[15]){element[OxOc6a9[14]]=20;} else {element[OxOc6a9[14]]=inp_cols[OxOc6a9[11]];} ;if(inp_rows[OxOc6a9[11]]==OxOc6a9[15]){element[OxOc6a9[16]]=2;} else {element[OxOc6a9[16]]=inp_rows[OxOc6a9[11]];} ;try{element[OxOc6a9[20]]=sel_Wrap[OxOc6a9[11]];} catch(e){element.removeAttribute(OxOc6a9[20]);} ;element[OxOc6a9[21]]=inp_index[OxOc6a9[11]];if(element[OxOc6a9[21]]==OxOc6a9[15]){element.removeAttribute(OxOc6a9[21]);} ;if(element[OxOc6a9[22]]==OxOc6a9[15]){element.removeAttribute(OxOc6a9[22]);} ;} ;