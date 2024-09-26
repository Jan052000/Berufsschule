
function submitClick() {
    startRequest();
}

function startRequest() {
    const form = document.querySelector("form");
    const inputs = Array.from(form.querySelectorAll("input"));

    if (inputs.map(input => input.value).includes("")) {
        alert("Bittle alle Felder ausfüllen.");
        return;
    }

    const dataElements = inputs
        .map(input => `${input.name}=${input.value}`)
        .join("&");
    
    sendRequest(dataElements);
}

function sendRequest(dataString) {
    const xhr = new XMLHttpRequest();
    const urlString = 'localhost:6969?'+dataString;
    xhr.open("POST", urlString); 
    console.log("POST", urlString);
    xhr.onload = function(event){ 
        alert("Success " + xhr.status + ", server responded with: " + event.target.response);
    }; 
    xhr.onerror = function (event){
        alert("Error " + xhr.status + ", server responded with: " + event.target.response);
    }
    xhr.send();
}