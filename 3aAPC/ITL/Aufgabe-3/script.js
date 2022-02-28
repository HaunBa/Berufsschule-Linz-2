window.onload = function () { getStateOfSwitch();  }


function getStateOfSwitch() {
    if (document.getElementById('switchInput').checked == false) {
        document.getElementById('list').style.display = 'none';
        document.getElementById('blogtable').style.display = 'inline';
    } else {
        document.getElementById('list').style.display = 'inline';
        document.getElementById('blogtable').style.display = 'none';
    }
}