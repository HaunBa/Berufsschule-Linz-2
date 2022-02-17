window.onload = function(){
    document.getElementById("submit").onclick = submit;
}

function submit() {
    var saveErrors = "";
    var inputs = document.getElementsByName("textInput");
    inputs.forEach(element => {
        if (element.value == "") {
            alert(element.name + " | Eingabe falsch");
            AddError("Text eingeben");
        }else if(element.name == "email"){
            if (checkEmailAdress(element.value) == true) {                
                AddError("Email not valid");
            }
        }else{
            alert("everything ok");
        }
    });
}

function AddError(errorText) {
    alert(errorText);
    var p = document.createElement("p");
    var text = document.createTextNode(errorText);
    p.appendChild(text);
    document.getElementById("logs")[0].appendChild(p);
    
    //saveErrors += errorText + "<br>";
    //document.getElementById("logs").innerHTML = saveErrors;
}

function checkEmailAdress(value) {
    var suche = /^[\w\.\-]{2,}\@[äöüa-z0-9\-\.]{1,}\.[a-z]{2,4}$/i;
    return suche.test(value);
}