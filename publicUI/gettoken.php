<?php
session_start(); 
$curl = curl_init();
$ctime = date("Y-m-d",time());
curl_setopt_array($curl, array(
  CURLOPT_URL => "http://api.bluecollarhub.com.ng/api/Account/Login",
  CURLOPT_RETURNTRANSFER => true,
  CURLOPT_ENCODING => "",
  CURLOPT_MAXREDIRS => 10,
  CURLOPT_TIMEOUT => 0,
  CURLOPT_FOLLOWLOCATION => true,
  CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
  CURLOPT_CUSTOMREQUEST => "POST",
  CURLOPT_POSTFIELDS =>"{ \"username\": \"odubela.tolulope@gmail.com\", \"password\": \"Destiny321.\" }",
  CURLOPT_HTTPHEADER => array(
    "Content-Type: application/json"
  ),
));

$response = curl_exec($curl);
$err = curl_error($curl);
curl_close($curl);
//echo $err;
//echo "This is the response".$response;
$datam = json_decode($response);   
$mid= $datam->userId; 
$mrole= $datam->userRole;
$mtoken = $datam->token;
$dstatus = $datam->success;
$derror = $datam->errorMessage;
//echo "This is the Status ".$dstatus. "<br>Role: " .$mrole."<br> Error(If any): ".$derror."<br>UserId: ".$mid;
//echo "<br>";

if (is_null($derror)){
	$_SESSION["mID"] = $mid;
	$_SESSION["mtoken"] = $mtoken;
    $_SESSION["mauth"] = "Authorization: bearer " . $mtoken;
	$autht = "Authorization: bearer " . $mtoken;
   //echo $_SESSION["mtoken"];
    }else  {
  foreach ($derror as $errorMessage => $val) {
   echo "unable to start aplication: " .$val;

  }
   }
//echo "<br>This is the Authorization Code ".$_SESSION["mauth"]. "<br>Session Token: " .$_SESSION["mtoken"]."<br> Error(If any): ".$derror."<br>UserId: ".$mid;

?>
