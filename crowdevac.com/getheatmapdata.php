<?php
	if ($_SERVER['REQUEST_METHOD'] === 'POST') {
		if (!isset($_GET['scene']) || empty($_GET['scene'])) {
		exit(0);
	}
	
	$scene = filterAlphanumeric($_GET["scene"]);
	$loa=filterAlphanumeric($_GET["loa"]);
	$los=filterAlphanumeric($_GET["los"]);
	$homo=filterAlphanumeric($_GET["homo"]);
	
	// create XML file for current scvene if it doesn't yet exist
	if (!file_exists("./XMLDocs/". $scene . ".xml"))	{
		createXMLFile($scene);
	}
	
	$xmlfile = fopen("./XMLDocs/". $scene . ".xml", "r");
	$xmlstring = fread($xmlfile,filesize("./XMLDocs/" . $scene . ".xml"));
	
	$mintime=INF;
	$leader="";
	$loadedxml=simplexml_load_file("./XMLDocs/" . $scene . ".xml");
	
	foreach ($loadedxml as $userdata):
        $leaderdata=$userdata->{"User-Data"};
        $telap=floatval($userdata->{"Time-Elapsed"});
		$tlos=$userdata->{'LevelOfService'};
		$thomo=$userdata->{'Homogeneity'};
		$tloa=$userdata->{'LevelOfAggression'};
		
		if($telap<=$mintime && $tloa==$loa &&$tlos==$los && $homo==$thomo)
		{
			$mintime=$telap;
			$leader=$leaderdata;
		}
    endforeach;
	
	echo $leader;
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
