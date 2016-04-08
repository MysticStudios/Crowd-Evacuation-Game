<?php

if ($_SERVER['REQUEST_METHOD'] === 'GET')
{
	$runID= $_GET["runid"];
	$scene= $_GET["scene"];
	$datafile=fopen("./heatmap/".$scene . "/" . $runID . ".png", "rb");

	$data=fread($datafile,filesize("./heatmap/".$scene . "/" . $runID . ".png"));

	fclose($datafile);
	
	echo $data;
	
}

?>
