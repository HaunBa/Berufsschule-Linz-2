<?php
function makeTable($query){
    global $con;
try {
    $stmt = $con->prepare($query);
    $stmt-> execute();

    $meta = array();
    echo    '<table class="table">
            <tr>';
    $colCount = $stmt->columnCount();
    for ($i=0; $i < $colCount; $i++) { 
        $meta[] = $stmt->getColumnMeta($i);
        echo '<th>'.$meta[$i]['name'].'</th>';
    }
    echo    '</tr>';
    while($row = $stmt->fetch(PDO::FETCH_NUM)){
        echo '<tr>';
        foreach ($row as $r) {
            echo '<td>'.$r.'</td>';
        }
        '</tr>';
    }
    echo '</table>';
} catch (Exception $e) {
    echo 'Error - Tabelle Adressen: '.$e->getCode().
    ': '.$e->getMessage().'<br>';
}
}

function makeStatement($query, $paramArray = null)
{
    global $con;
    $stmt = $con->prepare($query);
    $stmt->execute($paramArray);
    $strid = $con->lastInsertId();
    return array($strid);
}

?>