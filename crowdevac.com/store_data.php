<?php

if ($_SERVER['REQUEST_METHOD'] === 'GET')
{
	if(!isset($_GET['scene']) || empty($_GET['scene'])){
		exit(0);
	}
	$scene=$_GET["scene"];
	if(!file_exists("./XMLDocs/". $scene . ".xml"))
	{
		$newfile=fopen("./XMLDocs/". $scene . ".xml", "w");
		$writestring="<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<document>\n</document>";
		fwrite($newfile,$writestring);
		fclose($newfile);
	}
	
	$xmlfile=fopen("./XMLDocs/". $scene . ".xml", "r");

	$xmlstring=fread($xmlfile,filesize("./XMLDocs/" . $scene . ".xml"));

	echo $xmlstring;
	
}
if ($_SERVER['REQUEST_METHOD'] === 'POST')
{
	if(!isset($_POST['scene']) || empty($_POST['scene'])){
		exit(0);
	}
	if(!isset($_POST['querystring']) || empty($_POST['querystring'])){
		exit(0);
	}
	$scene=$_POST['scene'];
	$xmlstring=$_POST['querystring'];
	if(!file_exists("./XMLDocs/". $scene . ".xml"))
	{
		$newfile=fopen("./XMLDocs/". $scene . ".xml", "w");
		$writestring="<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<document>\n</document>";
		fwrite($newfile,$writestring);
		fclose($newfile);
	}
	$xmlfile=fopen("./XMLDocs/" . $scene . ".xml", "rw+");
	fseek($xmlfile,-12,SEEK_END);
	
	$temp_string="<document>";
	$temp_string1="</document>";
	$pos1=strpos($xmlstring,$temp_string);
	$pos1=$pos1+10;
	$pos2=strpos($xmlstring,$temp_string1);
	$length=$pos2-$pos1;
	$between = substr($xmlstring, $pos1, $length);
	fwrite($xmlfile,$between);
	fclose($xmlfile);
	$xmlfile1=fopen("./XMLDocs/" . $scene . ".xml", "a");
	fwrite($xmlfile1,"</document>");
	fclose($xmlfile1);
}

?>

