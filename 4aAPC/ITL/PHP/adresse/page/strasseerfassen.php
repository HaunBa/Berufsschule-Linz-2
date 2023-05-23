<?php

echo '<h2>Neue Straße erfassen</h2>';
// Straßennamen erfassen, Ort und PLZ aus Liste auswählen
// Sowohl das Formular als auch die Datenverarbeitung
// Werden auf dieser Seite behandelt

if (isset($_POST['save'])) {
    // Daten speichern
    $orplid = $_POST['orplid'];
    $strasse = $_POST['strasse'];
    $insertStmt1 = 'insert into strasse (str_name) values (?)';
    $insertStmt2 = 'insert into strasse_ort_plz values(?,?)';

    try {
        //code...
        $array1 = array($strasse);
        $returnArray = makeStatement($insertStmt1, $array1);
        array_push($returnArray, $orplid);
        makeStatement($insertStmt2, $returnArray);
    } catch (Exception $ex) {
        //throw $ex
        echo 'Error - Strasse: '.$ex->getCode().'';
    }
}else {
    // Formular anzeigen

?>
    <form method="post">
        <label for="strassenname">Straßenname:</label>
        <input type="text" id="strasse" name="strasse" placeholder="z.B.: Wiener Straße">
        <!-- TODO: Select option -->
        <?php
        global $con;
        $query = 'select orpl_id, plz_nr as "PLZ", ort_name as "Ort" from ort_plz natural join (ort, plz) order by Ort';
        $stmt = $con->prepare($query);
        $stmt->execute();
        echo '<br><label for="selectOrplid">Ort auswählen</label>';
        echo '<select id="selectOrplid"style="margin-top: 20px;" name="orplid">';
        while ($row = $stmt->fetch(PDO::FETCH_NUM)) {
            echo '<option value="'.$row[0].'">'.$row[1].' '.$row[2];
        }
        echo '</select>'
        ?>
        <br>
        <input style="margin-top: 20px" type="submit" name="save" value="speichern">
    </form>
    
<?php 
}
?>