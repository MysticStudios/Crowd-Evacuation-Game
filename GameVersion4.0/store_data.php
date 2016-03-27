<?php

if ($_SERVER['REQUEST_METHOD'] === 'GET')
{
	$scene=$_GET['scene'];
	$xmlfile=fopen("./XMLDocs"+$scene+".xml", "w+");
	if(filesize("./XMLDocs"+$scene+".xml")==0)
	{
		$writestring="<?xml version=\"1.0\" encoding=\"utf-8\"?><document></document>";
		fwrite($xmlfile,$writestring);
	}
	$xmlstring=fread($xmlfile,filesize("./XMLDocs"+$scene+".xml"));
	echo $xmlstring;
}
if ($_SERVER['REQUEST_METHOD'] === 'POST')
{
	$scene=$_POST['scene'];
	$xmlstring=$_POST['querystring'];
	$xmlfile=fopen("./XMLDocs"+$scene+".xml", "a+");
	fseek($xmlfile,-10,SEEK_END);
	
	$temp_string="<document>"
	$temp_string="</document>"
	$pos1=strpos($xmlstring,$temp_string);
	$pos1=$pos1+10;
	$pos2=strpos($xmlstring,$temp_string1);
	$length=$pos1-$pos2;
	$between = substr($xmlstring, $pos1, $length);
	fwrite($xmlfile,$between);
}

?>