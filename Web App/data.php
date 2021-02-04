<?php
?>
<!DOCTYPE html>
<html>

<head>
    <!-- Title of the website that appears on the tab naming -->
    <title>Plymouth Woodlands</title>
    <!-- Links to css pages for the design of the website -->
    <link href="http://s3.amazonaws.com/codecademy-content/courses/ltp/css/shift.css"  rel="stylesheet">
    <link rel="stylesheet" href="../CSS/style.css">
    <link rel="stylesheet" href="../CSS/main.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">
</head>

<body>
<!-- Class that creates the navigation bar -->
<div class="nav">
    <div class="container">
        <ul class="pull-left">
            <!-- Image of the logo that is in the navigation class that is contained to be shown on the left hand side for readability -->
            <li><img src = "../Images/logo.png" width = "100"></li>
        </ul>
        <ul class="pull-right">
            <!-- Links to other pages on the navigation bar but on the right hand side again for readability -->
            <li><a href="./index.php">Home</a></li>
            <li><a href="./data.php">Data</a></li>
        </ul>
    </div>
</div>

<!-- Class that assigns css to bootstrap that displays words onto an image for the design of the site -->
<div class="jumbotron">
    <div class="container">
        <h1>Sampling Woodland Sites In The Bircham and Forder Valley</h1>

    </div>
</div>

<!-- Class creating the formation/uniform of the website-->
<div class="Box">
    <div class="container">
        <!-- Class creating the formation/uniform of the website-->
        <div class="row">
            <div class="col-md-4">
                <div class="thumbnail">
                    <?php
                    $header=true;
                    $handle = fopen("../Data/woodlands.csv", "r");
                    echo '<table>';
                        //display header row if true
                        if ($header) {
                        $csvcontents = fgetcsv($handle);
                        echo '<tr>';
                            foreach ($csvcontents as $headercolumn) {
                            echo "<th>$headercolumn</th>";
                            }
                            echo '</tr>';
                        }
                        // displaying contents
                        while ($csvcontents = fgetcsv($handle)) {
                        echo '<tr>';
                            foreach ($csvcontents as $column) {
                            echo "<td>$column</td>";
                            }
                            echo '</tr>';
                        }
                        echo '</table>';
                    fclose($handle);

                    ?>
                </div>
                <div class="thumbnail">

                </div>
            </div>


            <!-- Class that assigns the right hand side space that is still within the container of the website-->
            <div class="col-md-4">
                <div class="thumbnail">

                </div>

                <!-- Class creating the formation/uniform of the website-->
                <div class="thumbnail">


                </div>
            </div>

            <!-- Class creating the formation/uniform of the website-->
            <div class="col-md-4">
                <div class="thumbnail">


                </div>
            </div>

            <!-- Class creating the formation/uniform of the website-->
            <div class="show_more">
                <div class="container">
                    <div class="row">
                        <div class="col-md-4">


                        </div>
                    </div>
                </div>
            </div>
</body>
</html>


