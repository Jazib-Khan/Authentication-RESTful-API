<?php
header("Content-Type: application/json");

$csv = array_map("str_getcsv", file("../Data/woodlands.csv"));
$json = json_encode($csv);

$i = 0;

echo "{" . '"@context"' . " : " . "{" . '"Place"' . " : " . '"http://schema.org/place"' . "}" . ", " . '"Place"' . " : " . "[" . "\n";
foreach ($csv as &$value){
    echo "{" . "\n";
    echo '"@type"' . " : " . '"Place"'. "," . "\n";
    echo '"i:name"' . " : " . '"' . "$value[0]". '"' . "," . "\n";
    echo '"i:area"' . " : " . '"' . "$value[1]". '"' . "," . "\n";
    echo '"i:description"' . " : " . '"' . "$value[2]". '"' . "\n";
    echo "}";
    if ($i < count($csv) - 1){
        echo "," . "\n";
        $i ++;
    }
}
echo "]" . "}";
