<?php
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
	//header('Content-Type: text/html');
	if (!isset($_POST['scene']) || empty($_POST['scene'])) {
		exit(0);
	}

	$scene = filterAlphanumeric($_POST["scene"]);
	$loa=filterAlphanumeric($_POST["loa"]);
	$los=filterAlphanumeric($_POST["los"]);
	$homo=filterAlphanumeric($_POST["homo"]);

	// create XML file for current scvene if it doesn't yet exist
	if (!file_exists("./XMLDocs/". $scene . ".xml"))	{
		createXMLFile($scene);
	}

	$xmlfile = fopen("./XMLDocs/". $scene . ".xml", "r");
	$xmlstring = fread($xmlfile,filesize("./XMLDocs/" . $scene . ".xml"));

	$mintime=PHP_INT_MAX;
	$leader="";
        $loadedxml=simplexml_load_file("./XMLDocs/" . $scene . ".xml");
	$minXML = "";

	foreach ($loadedxml as $userdata):
	        $telap=floatval($userdata->{"Time-Elapsed"});
		$tlos=$userdata->{"LevelOfService"};
		$thomo=$userdata->{"Homogeneity"};
		$tloa=$userdata->{"LevelOfAggression"};
echo "<h1>"."hello".$tlos.$los."</h1>";
		if($telap<=$mintime && $tloa===$loa && $tlos===$los && $homo===$thomo) {
			$mintime=$telap;
			$minXML = $userdata;
		}
	endforeach;

	if($mintime!=PHP_INT_MAX){
echo $minXML->asXML();}
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
