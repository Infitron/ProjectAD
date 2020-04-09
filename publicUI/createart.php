<?php
include('gettoken.php');
$ctime = date("Y-m-d",time());
$curl = curl_init();

$ifname = "Aladeyomi";
$ilname = "Philip Grace";
$iphone ="4758686897";
$iarea= 16;
$iidc="243546yer1";
$icat= 17;
$ipath = "newtest2.png";
$iadd = "120, Grace Randle, Lagos Island";
$istate = "Lagos";
$ime ="Join fellow beginners and I for a fun night of code, pizza, and diving into the fundamentals of programming. And, because we want to encourage you to keep the momentum going, we'll send you home with a bunch of BONUS videos to help reinforce and expand upon what you've learned. It's a great way to kick off your learn to code journey.";
$iuid = 22;
/*$ifname = $_POST['fname'];
$ilname = $_POST['lname'];
$iphone =$_POST['phone'];
$iarea= $_POST['laarea'];
$iidc= $_POST['idnum'];
$icat=$_POST['jcat'];
$ipath = $_POST['ppath'];
$iadd = $_POST['address'];
$istate = $_POST['lstate'];
$ime =$_POST['adesc'];
$iuid = $_SESSION["uuid"];*/
    
$data_array = array(
"firstName" => $ifname,
  "lastName" => $ilname,
  "phoneNumber" => $iphone,
  "areaLocationId" => $iarea,
  "idcardNo" => $iidc ,
  "picturePath" => $ipath,
  "address" => $iadd,
  "artisanCategoryId" => $icat,
  "state" => $istate,
  "aboutMe" => $ime,
   "userId" =>$iuid 
  
);

$ddata = json_encode($data_array);
echo "The data is ".$ddata."<br>";
curl_setopt_array($curl, array(
  CURLOPT_URL => "http://api.bluecollarhub.com.ng/api/v1/artisan",
  CURLOPT_RETURNTRANSFER => true,
  CURLOPT_ENCODING => "",
  CURLOPT_MAXREDIRS => 10,
  CURLOPT_TIMEOUT => 0,
  CURLOPT_FOLLOWLOCATION => true,
  CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
  CURLOPT_CUSTOMREQUEST => "POST",
  CURLOPT_POSTFIELDS =>$ddata,
  CURLOPT_HTTPHEADER => array(
    "Content-Type: application/json",$_SESSION["mauth"]
  ),
));

$response = curl_exec($curl);
$err = curl_error($curl);
curl_close($curl);
echo $response."<br>";
$datam = json_decode($response,true);
echo "decoded message".$datam."<br>";
$dstatus= $datam['status']; 
$dmessage= $datam['message'];
$derror = $err;
echo "The response is ".$response."<br>";
echo "The data is ".$datam."<br>";
echo "The status is ".$dstatus."<br>";
echo "The message is ".$dmessage."<br>";
echo "The error is ".$derror."<br>";
echo "We are Good";
?>
