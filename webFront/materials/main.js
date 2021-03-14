const apikey = "330d91f01657af3c5749eccdf042fcad37d9c7c2";

function retrieveAllContracts(){
    var txtFromInput = document.getElementById("nik").value;
    if( txtFromInput==null | txtFromInput.length==0 ){
        txtFromInput=apikey;
    }
    console.log("apikey = "+txtFromInput);

    var callTxt="https://api.jcdecaux.com/vls/v3/contracts?&apiKey=" + txtFromInput;
    var request=new XMLHttpRequest();
    request.open("GET",callTxt,true);
    request.setRequestHeader("Accept","application/json");
    request.onload=contractsRetrieved;
    request.send();

}

function contractsRetrieved(){
    var response=JSON.parse(this.responseText)
    console.log(response)
    response.forEach(element => {
        var optionElement = document.createElement("option");
        optionElement.setAttribute("value",element.name);
        var list = document.getElementById("contract_list");
        list.appendChild(optionElement);
        //console.log(element.contract_name);
    });
    console.log(list);
}

function retrieveContractStations(){
    var txtFromInput = document.getElementById("nik").value;
    if( txtFromInput==null | txtFromInput.length==0 ){
        txtFromInput=apikey;
    }
    var contractFromInput = document.getElementById("list").value;
    if( contractFromInput==null | contractFromInput.length==0 ){
        console.log("Aucun contrat renseigné")
    }
    else{
        var callTxt="https://api.jcdecaux.com/vls/v1/stations?contract=" + contractFromInput + "&apiKey=" + txtFromInput;
        var request=new XMLHttpRequest();
        request.open("GET",callTxt,true);
        request.setRequestHeader("Accept","application/json");
        request.onload=contractStationRetrieved;
        request.send();
    }
}

function contractStationRetrieved(){
    var response=JSON.parse(this.responseText);
    console.log(response);
}