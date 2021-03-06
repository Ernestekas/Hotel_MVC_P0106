function submitForm() {
    let firstCityElement = document.getElementById("main");
    let allCitiesElements = document.getElementsByClassName("city");
    let countryElement = document.getElementById("countryName");

    let name = countryElement.value;
    let allCities = [];

    allCities.push(firstCityElement.value);

    for (let i = 0; i < allCitiesElements.length; i++) {
        allCities.push(allCitiesElements[i].value);
    }

    var model = Object();
    model.Id = 0;
    model.Name = name;
    model.CitiesNames = allCities;

    if (model.Name.length < 4) {
        let errorMsg = document.createElement("p");
        let main = document.getElementById("errorContainer");
        errorMsg.innerHTML = "Country name is too short.";
        errorMsg.setAttribute("style", "color: red");
        main.appendChild(errorMsg);
        
        return;
    }

    $.ajax({
        type: 'POST',
        data: model,
        url: '/Locations/AddCountry',
        success: function () {
            window.location.href = "/Locations/Manage"
        }
    });

    
}