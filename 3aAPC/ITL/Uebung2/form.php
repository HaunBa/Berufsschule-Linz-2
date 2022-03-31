<?php
    $name = $_GET["nname"];
    $farbe = $_GET["farbe"];
    $land = $_GET["land"];

    echo "Name: $name<br>";
    echo "Farbe: $farbe<br>";
    echo "Land: $land<br>";

    if (isset($_GET["Filme"])) {            
        $filme = $_GET["filme"];
        for ($i=0; $i < sizeof($filme); $i++) { 
            echo "Filme: $filme[$i]<br>";
        }
    }
?>