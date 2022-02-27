window.onload = function(){
    document.getElementById("submit").onclick = submit;
}

function submit() {
    var saveErrors = "";

    var txt_vname = document.getElementById("vname");
    var txt_nname = document.getElementById("nname");
    var txt_email = document.getElementById("email");

    if (txt_vname.value == txt_nname.value) {
        AddError("First name cant be the same as the last name.");
    }else if (checkEmailAdress(txt_email.value) == false) {
        AddError("Email adress is invalid.");
    }else{
        alert("All good");
    }
}

function AddError(errorText) {
    alert(errorText);
    var p = document.createElement("p");
    var text = document.createTextNode(errorText);
    p.appendChild(text);
    document.getElementById("logs")[0].appendChild(p);
    
    saveErrors += errorText + "<br>";
    document.getElementById("logs").innerHTML = saveErrors;
}

function checkEmailAdress(value) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}