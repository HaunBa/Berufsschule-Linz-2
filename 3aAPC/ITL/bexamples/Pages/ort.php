<h2>Daten erfassen</h2>

<?php
        $query = 'select plz_nr as "PLZ",
                        ort_name as "ORT",
                        str_name as "Strasse"
                        from ort natural join plz
                            natural join plz_strasse
                            natural join strasse
                        order by plz_nr, ort_name';

        $stmt = $con->prepare($query);
        $stmt->execute();

        $meta = array();
        echo '<table>

        <tr>';
            for ($i=0; $i < $stmt->columnCount(); $i++) {
                $meta[] = $stmt->getColumnMeta($i);
                echo '<th>'.$meta[$i]['name'].'</th>';
            }

            echo '</tr>';
            while($row = $stmt->fetch(PDO::FETCH_NUM))
            {
                echo '<tr>';
                foreach($row as $r)
                {
                    echo '<td>'.$r.'</td>';
                }
                echo '</tr>';
            }
            echo '</table>';
        ?>

<form method="POST">
    <label for="ort">Ort:</label>
    <input type="text" id="ort" name="ort" required placeholder="z.B. Linz">
    <br>
    <?php
        $query = 'select * from plz order by plz_id';
        $stmt = $con->prepare($query);
        $stmt->execute();

        echo '<label>PLZ<label>';
        echo '<select name="plz"';
        while($row = $stmt->fetch(PDO::FETCH_NUM)){
            echo '<option value"'.$row[0].'">'.$row[2];
        }
        echo '</select><br>';
    ?>
    <input type="submit" name="save" value="speichern">
</form>