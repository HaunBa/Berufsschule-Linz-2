var saveErrors = "";

window.onload = function(){
    document.getElementById("submit").onclick = submit;
}

function submit() {
    var errors = 0;

    var txt_vname = document.getElementById("vname");
    var txt_nname = document.getElementById("nname");
    var txt_email = document.getElementById("email");

    if (txt_vname.value == txt_nname.value) {
        AddError("First name cant be the same as the last name.");
        errors++;
    }else if (checkEmailAdress(txt_email.value) == false) {
        AddError("Email adress is invalid.");
        errors++;
    }else{
        alert("All good");
    }

    if (errors != 0) {
        event.defaultPrevented();
    }
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