window.onload = function(){
    document.getElementById("submit").onclick = submit;

    document.getElementById("logs")
}

function submit() {
    var inputs = document.getElementsByName("textInput");
    inputs.forEach(element => {
        if (element.value == "") {
            AddError("Text eingeben");
        }else if(element.name == "email"){
            if (checkEmailAdress(element.value) == false) {
                
                AddError("Email not valid");
            }
        }
    });
}

function AddError(errorText) {
    alert(errorText);
    var p = document.createElement("p");
        var text = document.createTextNode(errorText);
        p.appendChild(text);
        document.getElementById("logs")[0].appendChild(p);
}

function checkEmailAdress(value) {
    var suche = /^[\w\.\-]{2,}\@[äöüa-z0-9\-\.]{1,}\.[a-z]{2,4}$/i;
    return suche.test(value);
}