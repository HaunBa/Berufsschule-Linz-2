window.onload = function () { getStateOfSwitch();}

function fillOptions(){
    var fontFamilyOption = document.getElementById("select-font");
    

    var opt = document.createElement('option');
    opt.value = "test";
    opt.innerHTML = "test";
    fontFamilyOption.appendChild(opt);  

    opt = document.createElement('option');
    opt.value = "arial";
    opt.innerHTML = "Arial";
    fontFamilyOption.appendChild(opt);

    opt = document.createElement('option');
    opt.value = document.getElementById("theme-header").style.fontFamily;
    opt.innerHTML = document.getElementById("theme-header").style.fontFamily;
    fontFamilyOption.appendChild(opt);
}

function UpdateH2() {
    var h2 = document.getElementsByTagName('h2');

    h2.forEach(element => {
        element.style.fontFamily = document.getElementById('select-font').value;
    });
}

function getStateOfSwitch() {
    if (document.getElementById('switchInput').checked == false) {
        document.getElementById('list').style.display = 'none';
        document.getElementById('blogtable').style.display = 'inline';
    } else {
        document.getElementById('list').style.display = 'inline';
        document.getElementById('blogtable').style.display = 'none';
    }
}

function submit() {
    UpdateH2();
}