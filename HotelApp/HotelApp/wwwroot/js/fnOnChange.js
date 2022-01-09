function changed(textBoxId, e) {
    let mainTextBoxId = "main";
    let tabKeyCode = 9;
    let element = document.getElementById(textBoxId);
    let allCities = document.getElementsByClassName("city");

    if (element.id !== mainTextBoxId && element.value.length === 0 && e.keyCode !== tabKeyCode) {
        removeEmpty(textBoxId);
    }
    else {
        addNewTextBox();
    }
    if (allCities.length === 1 && document.getElementById("main").value.length === 0) {
        if (allCities[0].value.length === 0) {
            removeEmpty(allCities[0].id);
        }
    }
    
}

function addNewTextBox() {
    let citiesTable = document.getElementById("cities");
    let mainTB = document.getElementById("main");
    let allTBs = document.getElementsByClassName("city");
    let addNewTb = false;
    let newId;

    if (mainTB.value.length > 0) {
        if (allTBs.length === 0) {
            addNewTb = true;
            newId = "city" + 1;
        }
        else {
            if (allTBs[allTBs.length - 1].value.length > 0) {
                let oldId = allTBs[allTBs.length - 1].id;

                addNewTb = true;
                newId = "city" + (1 + Number(oldId.replace("city", "")));
            }
        }
    }

    if (addNewTb) {
        let tr = document.createElement("tr");
        tr.setAttribute("class", "citiesTr");

        let td = document.createElement("td");

        let textBox = document.createElement("input");
        textBox.setAttribute("id", newId);
        textBox.setAttribute("class", "city");
        textBox.setAttribute("type", "text");
        textBox.setAttribute("value", "");
        textBox.setAttribute("placeholder", "Enter city name");
        textBox.setAttribute("onkeyup", "changed(this.id, event)");

        td.appendChild(textBox);
        tr.appendChild(td);
        citiesTable.appendChild(tr);
    }
}

function removeEmpty(textBoxId) {
    let inputElement = document.getElementById(textBoxId);
    let rowToDelete = inputElement.parentElement.parentElement;
    let allCities;
    rowToDelete.remove();

    allCities = document.getElementsByClassName("city");
    if (allCities.length === 0) {
        document.getElementById("main").focus();
    }
    else {
        allCities[allCities.length - 1].focus();
    }
}