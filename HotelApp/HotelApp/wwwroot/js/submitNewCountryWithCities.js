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

    $.ajax({
        type: 'POST',
        data: model,
        url: '/Locations/AddCountry'
    });
}