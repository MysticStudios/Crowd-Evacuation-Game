<?php

if ($_SERVER['REQUEST_METHOD'] === 'POST')
{
	if(!isset($_POST['scene']) || empty($_POST['scene'])){
		exit(0);
	}
	if(!isset($_POST['runid']) || empty($_POST['runid'])){
		exit(0);
	}

	
	$scene=$_POST['scene'];
	$runid=$_POST['runid'];
	$myFile = $_FILES["fileUpload"]["tmp_name"];
	$content = '';
	$fh = fopen($myFile, 'r') or die("can't open file");
	while (!feof($fh)) {
		$content .= fgets($fh);
	}
	fclose($fh);
	
	mkdir("./" . $scene,0777);
	$myFile = "./" . $scene . "/" . $runid . ".png";
	$fh = fopen($myFile, 'w') or die("can't open file");
	$stringData = $content;//"START:\n" . join(',\n',headerCustom()) . ' \END';
	fwrite($fh, $stringData);
	fclose($fh);
	echo "done";
}

?>
