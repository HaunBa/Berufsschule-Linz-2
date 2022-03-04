var text = "";

window.onload=function() {
    document.images[0].src="assets/img/features-1.png";
    text += "features-1.png <br>";
    WriteToGrid();
    document.getElementById("bild").onmouseover=function() {
    document.images[0].src="assets/img/features-2.png";
    text += "features-2.png <br>";
    WriteToGrid();
    }
        document.getElementById("bild").onmouseout=function() {
        document.images[0].src="assets/img/features-1.png";
        text += "features-1.png <br>";
        WriteToGrid();
    }
}    

function WriteToGrid() {
    document.getElementById('col-2').innerHTML = text;
}