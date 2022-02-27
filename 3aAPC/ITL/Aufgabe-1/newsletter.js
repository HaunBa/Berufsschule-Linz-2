var saveErrors = "";

window.onload = function(){
    document.getElementById("submit").onclick = submit;

    document.querySelectorAll('.input').forEach(item => {
        item.addEventListener('mouseover', event => {
          addOnMouseOver(event);
          console.log("added");
        })
      })
}

function submit() {
    var errors = 0;

    var txt_vname = document.getElementById("vname");
    var txt_nname = document.getElementById("nname");
    var txt_email = document.getElementById("email");

    if (txt_vname.value == "") 
    {
        AddError("Vorname darf nicht leer sein");
        errors++;    
    }
    if (txt_nname.value == "") 
    {
        AddError("Nachname darf nicht leer sein");
        errors++;    
    }
    if (txt_vname.value == txt_nname.value && txt_vname.value != "") {
        AddError("Vor und Nachname dürfen nicht identisch sein.");
        errors++;
    }
    if (txt_email.value == "") 
    {
        AddError("Email darf nicht leer sein");   
        errors++;
    }else if (checkEmailAdress(txt_email.value) == false) {
        AddError("Email adresse ist ungültig");
        errors++;
    }
    
    if (errors != 0) {
        return false;
    }
}

function addOnMouseOver(evt){
    var text = "Der Mauszeiger befindet sich über dem Eingabefeld " + evt.target.name;

    saveErrors += text + "<br>";
    document.getElementById("logs").innerHTML = saveErrors;
}

function AddError(errorText) {
    
    saveErrors += errorText + "<br>";
    document.getElementById("logs").innerHTML = saveErrors;

    alert(errorText);
}

function checkEmailAdress(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}