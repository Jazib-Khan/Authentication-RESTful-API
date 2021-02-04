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
          <!-- Information about the website-->
          <p>Data that has been collected over the course of 2016 with volunteers on a Citizen Science project at Poole Farm.
              This is specifically data gained from sampling woodland sites in the Bircham and Forder Valley.
              The data has been collected using a set methodology set out in bespoke booklets for this survey methodology.
              Source: Plymouth City Council</p>
      </div>
	<div class="thumbnail">

	</div>
	</div>


	<!-- Class that assigns the right hand side space that is still within the container of the website-->
	<div class="col-md-4">
	<div class="thumbnail">
        <p>To view the original dataset <a href="https://plymouth.thedata.place/dataset/woodland-sites/resource/87a2a4cc-3357-4e8f-9a62-234a1c8bed88">click here</a></p>
        <p>To inspect the data in JSON-LD format <a href="../JSON/index.php">click here</a></p>
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

