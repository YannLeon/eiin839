const apikey = "330d91f01657af3c5749eccdf042fcad37d9c7c2";

function retrieveAllContracts(){
    var txtFromInput = document.getElementById("ntm")
    if( txtFromInput==null ){
        txtFromInput=apikey;
    }
    console.log("apikey = "+txtFromInput);

    var callTxt="https://api.jcdecaux.com/vls/v1/stations?&apiKey=" + txtFromInput;
    var request=new XMLHttpRequest();
    request.open("GET",callTxt);
    request.setRequestHeader("Accept","application/json");
    request.onload=contractsRetrieved;
    request.send();

}

function contractsRetrieved(){
    console.log(JSON.parse(this.responseText))
}