//----------------------------------------------------------------------------------------------------//
//Ex: onclick(PrintElement(<%= GridView1.ClientID %>);)
function CheckboxSelectAll(control, cellNo, grid) {
    //get reference of GridView control
    var grid = document.getElementById(grid);
    //var grid = document.forms[0].elements[id];
    //variable to contain the cell of the grid
    var cell;

    if (grid.rows.length > 0) {
        //loop starts from 1. rows[0] points to the header.
        for (i = 0; i < grid.rows.length; i++) {
            //get the reference of first column
            cell = grid.rows[i].cells[cellNo];

            //loop according to the number of childNodes in the cell
            for (j = 0; j < cell.childNodes.length; j++) {
                //if childNode type is CheckBox
                if (cell.childNodes[j].type == "checkbox") {
                    //assign the status of the Select All checkbox to the cell checkbox within the grid
                    cell.childNodes[j].checked = document.getElementById(control).checked;
                }
            }
        }
    }
}

function CheckboxSelectAll2(control, cellNo, cellNo2, grid) {
    //get reference of GridView control
    var grid = document.getElementById(grid);
    //var grid = document.forms[0].elements[id];
    //variable to contain the cell of the grid
    var cell;
    var cell2;

    if (grid.rows.length > 0) {
        //loop starts from 1. rows[0] points to the header.
        for (i = 1; i < grid.rows.length; i++) {
            
            //get the reference of first column
            cell = grid.rows[i].cells[cellNo];
            cell2 = grid.rows[i].cells[cellNo2];

            //loop according to the number of childNodes in the cell
            for (j = 0; j < cell.childNodes.length; j++) {
                //if childNode type is CheckBox
                if (cell.childNodes[j].type == "checkbox") {
                    //assign the status of the Select All checkbox to the cell checkbox within the grid
                    cell.childNodes[j].checked = document.getElementById(control).checked;
                }

            }
            for (j = 0; j < cell2.childNodes.length; j++) {
                if (cell2.childNodes[j].type == "checkbox") {
                    if (document.getElementById(control).checked) {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                        cell2.childNodes[j].checked = !document.getElementById(control).checked;
                    }
                }
            }
        }
    }
}


function SelectAllRow(control, rowIndex, grid) {
    var grid = document.getElementById(grid);
    var row;
    if (grid.rows.length > 0) {
        row = grid.rows[rowIndex];
        for (i = 1; i < row.cells.length; i++) {
            //cell = grid.rows[i].cells[CellNo];
            for (j = 0; j < row.cells[i].childNodes.length; j++) {
                if (row.cells[i].childNodes[j].type == "checkbox") {
                    row.cells[i].childNodes[j].checked = document.getElementById(control).checked;
                }
            }
        }
    }
}

function SelectUnSelect(row, col, grid) {
    var grid = document.getElementById(grid);
    var row;
    var selectRow = true;
    var selectCol = true;

    if (grid.rows.length > 0) {

        //loop starts from 1. rows[0] points to the header.
        for (i = 1; i < grid.rows.length; i++) {
            for (j = 0; j < grid.rows[i].cells.length; j++) {
                for (c = 0; c < grid.rows[i].cells[j].childNodes.length; j++) {
                    if (cell.childNodes[j].type == "checkbox") {
                        if (!cell.childNodes[j].checked && selectRow != false) {
                            selectRow = false;
                        }
                    }
                }
                grid.rows[i].cells[6].childNodes[1].checked = selectRow;
            }
        }
    }
}

//----------------------------------------------------------------------------------------------------//

//Ex: onclick(PrintElement(<%= GridView1.ClientID %>);) or onclick(PrintElement('DivID');)  onclick="PrintElement('TableID')"
function PrintElement(elemntID) {
    var prtContent = document.getElementById(elemntID);
    var WinPrint = window.open('', '', 'letf=0,top=0,width=400,height=400,toolbar=0,scrollbars=0,status=0');
    WinPrint.document.write(prtContent.innerHTML);
    WinPrint.document.close();
    WinPrint.focus();
    WinPrint.print();
    WinPrint.close();
}


//----------------------------------------------------------------------------------------------------//

//Ex: onclick = "return ConfirmOrder('Write the message here');"
function ConfirmOrder(strMsg) {

    if (confirm(strMsg) == true) {
        return true;
    }
    else {
        return false;
    }
}

//----------------------------------------------------------------------------------------------------//

//Show/Hide Element as accordion panel
////Ex: onclick(ShowHideElement(<%= GridView1.ClientID %>);) or onclick(ShowHideElement('DivID');) 
function ShowHideElement(elementID) {
    if (document.getElementById(elementID).style.visibility == "hidden") {
        document.getElementById(elementID).style.visibility = "visible";
        document.getElementById(elementID).style.display = "block";
    }
    else {
        document.getElementById(elementID).style.display = "none";
        document.getElementById(elementID).style.visibility = "hidden";
    }
}

//----------------------------------------------------------------------------------------------------//

//view element in popup window
function ViewInPopUp(elementID, width, height) {
    var viewContent = document.getElementById(elemntID);
    var WinPrint = window.open('', '', 'letf=0,top=0,width=' + width + ',height=' + height + ',toolbar=0,scrollbars=0,status=0');
    WinPrint.document.write(viewContent.innerHTML);
    WinPrint.document.close();
    WinPrint.focus();
}

// ckeck decimal
function isDecimalValidKey(textboxIn, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 45 || charCode == 47 || charCode > 57)) {
        return false;
    }
    if (charCode == 46 && textboxIn.value.indexOf(".") != -1) {
        return false;
    }
    return true;
}






