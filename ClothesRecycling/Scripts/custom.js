
//This function will be called from the on the 'onchnage' event of the ddlRecepient dropdown
function SetStatusValue(ddlObj)//ddlObj is the entire dropwdown object that will be passed from the ManageDonations.aspx , on the 'onchnage' event of the ddlRecepient dropdown
{
    var selectedVal = $(ddlObj).val();//Newly selected value of the dropdown ddlRecepient.
    var ddlRecptPreviousVal = $(ddlObj).attr("PreviousValue");// Storing the value of PreviousValue attribute into the variable.
    if (ddlRecptPreviousVal == '') {// check if the value is empty string i.e. the Select option of the dropdown.
        $(ddlObj).closest('tr').find('select[id *="ddlStatus"]').val("Allocated");// finding the Status dropdown ddlStatus from the row(tr) of the changed Recepient dropwdown ddlRecepient And set its value to Allocated.
        $(ddlObj).attr("PreviousValue", selectedVal);//Set the PreviousValue attribute of ddlRecepient dropdown to the newly selected value , so that this value will be useful to track the onchange event next time.
    }
    else {//if the value is NOT the empty string i.e NOT the Select option of the dropdown.
        $(ddlObj).attr("PreviousValue", selectedVal); //Set the PreviousValue attribute of ddlRecepient dropdown to the newly selected value , so that this value will be useful to track the onchange event next time.
    }
}
