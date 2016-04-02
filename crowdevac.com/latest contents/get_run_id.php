<?php

if ($_SERVER['REQUEST_METHOD'] === 'GET')
{
	if(!file_exists("run_data.txt"))
	{
		$newfile=fopen("run_data.txt", "w");
		fwrite($newfile,"1");
		fclose($newfile);
	}
	
	$datafile=fopen("run_data.txt", "r");

	$datacount=intval(fread($datafile,filesize("run_data.txt")));
	fclose($datafile);
	
	echo $datacount;
	
	$datacount=$datacount+1;
	
	$writefile=fopen("run_data.txt", "w");
	fwrite($writefile,strval($datacount));
	fclose($writefile);
	
}

?>
