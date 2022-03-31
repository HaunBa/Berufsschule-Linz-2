<?php

// plz_save.php
// Daten speichern
try {
    $plz = $_POST['plz'];

    // check if plz exists
    $query2 = 'select * from plz where plz_nr = ? and ort_id is null';
    $stmt2 = $con->prepare($query2);
    $stmt2->execute([$plz]);
    // insert plz into db
    if ($stmt2->rowCount() == 0) {
        $query1 = 'Insert into plz (plz_nr) values(?)';
        $stmt1 = $con->prepare($query1);
        $stmt1->execute([$plz]);
        echo "<span>Added $plz to db </span>";
    }else {
        echo "<span> Die PLZ $plz mit ort_id Null ist bereits vorhanden</span>";
    }
} catch (Exception $e) {
    echo $e->getCode().': '.$e->getMessage();
}
?>