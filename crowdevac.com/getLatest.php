<?php
$value = file_put_contents("web demo.unity3d", fopen("https://github.com/MysticStudios/Crowd-Evacuation-Game/raw/master/crowdevac.com/web%20demo.unity3d", 'r'));
if ($value === false || $value === 0) {
        echo "<pre>Download FAILED</pre>";
}
else {
        echo "<pre>Download was successful!</pre>";
        echo "<pre>File size: " . round($value/1000000, 1) . "MB</pre>";
}
?>
