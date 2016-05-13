<?php

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
	if (!isset($_GET['scene']) || empty($_GET['scene'])) {
		exit(0);
	}
	
	$scene = filterAlphanumeric($_GET["scene"]);
	$loa = filterAlphanumeric($_GET["loa"]);
	$los = filterAlphanumeric($_GET["los"]);
	$homo = filterAlphanumeric($_GET["homo"]);
	
	// create XML file for current scvene if it doesn't yet exist
	if (!file_exists("./XMLDocs/". $scene . ".xml"))	{
		createXMLFile($scene);
	}
	
	$xmlfile = fopen("./XMLDocs/". $scene . ".xml", "r");
	$xmlstring = fread($xmlfile,filesize("./XMLDocs/" . $scene . ".xml"));
	
	$mintime=PHP_INT_MAX;
	$leader="";
	$loadedxml=simplexml_load_file("./XMLDocs/" . $scene . ".xml");
	
	foreach ($loadedxml as $userdata):
        $player_id=$userdata->{"Player-ID"};
        $telap=floatval($userdata->{"Time-Elapsed"});
		$tlos=$userdata->{"LevelOfService"};
		$thomo=$userdata->{"Homogeneity"};
		$tloa=$userdata->{"LevelOfAggression"};
		
		if($telap<=$mintime && $tloa===$loa && $tlos===$los && $homo===$thomo)
		{
			$mintime=$telap;
			$leader=$player_id;
		}
    endforeach;
	
	if($mintime!=PHP_INT_MAX){
	echo $leader . "+" . $mintime;
	}
}
else if ($_SERVER['REQUEST_METHOD'] === 'POST') {
	4if (!isset($_POST['scene']) || empty($_POST['scene'])) {
		exit(0);
	}
	if (!isset($_POST['querystring']) || empty($_POST['querystring'])){
		exit(0);
	}
	
	$scene = filterAlphanumeric($_POST['scene']);
	$xmlstring = $_POST['querystring'];
	
	// create XML file for current scvene if it doesn't yet exist
	if (!file_exists("./XMLDocs/". $scene . ".xml"))	{
		createXMLFile($scene);
	}
	
	$xmlfile = fopen("./XMLDocs/" . $scene . ".xml", "rw+");
	fseek($xmlfile,-12,SEEK_END);
	
	// get the XML data within the <document></document> block
	$pos1 = strpos($xmlstring, "<document>") + 10;
	$pos2 = strpos($xmlstring, "</document>");
	$between = substr($xmlstring, $pos1, $pos2 - $pos1);
	fwrite($xmlfile,$between);
	fclose($xmlfile);
	
	$xmlfile1 = fopen("./XMLDocs/" . $scene . ".xml", "a");
	fwrite($xmlfile1,"</document>");
	fclose($xmlfile1);
}

// removes all non-alphanumeric characters
function filterAlphanumeric($str) {
	return preg_replace("/[^a-zA-Z0-9]+/", "", $str);
}

function createXMLFile($scene) {
	$newfile = fopen("./XMLDocs/". $scene . ".xml", "w");
	$writestring = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<document>\n</document>";
	// write the data to the appropriate XML file
	fwrite($newfile,$writestring);
	fclose($newfile);
}

?>
