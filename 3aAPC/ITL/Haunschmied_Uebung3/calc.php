<?php
    $number = $_POST["numberInput"];
    $action = $_POST["fibOrFak"];

    switch ($action) {
        case 'fibonacci':
            if($number >= 1){
                echo fibonacci($number);
            }else{
                echo "$number ist zu klein und kann nicht verwendet werden um die Fakultät zu berechnen";
            }
            break;
        case 'fakultaet':
            if($number > 0){                
                echo "Die fakultät von $number ist ";
                echo fakultaet($number);
            }else{
                echo "$number ist zu klein und kann nicht verwendet werden um die Fakultät zu berechnen";
            }
            break;
        default:
            break;
    }

function fibonacci($number)
{
    if ($number === 1 || $number === 2) {
        return 1;
    }
    return fibonacci($number - 1) + fibonacci($number - 2);
}

function fakultaet($number){
    $calc = 1;
    
    for ($i=1; $i <= $number; $i++) { 
        $calc = $calc * $i;
    }
    return $calc;
}
?>