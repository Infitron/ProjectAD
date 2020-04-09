<?php
    
include('gettoken.php');
$ctime = date("Y-m-d",time());
function callAPI($method, $url, $data, $authuser){
   $curl = curl_init();
   switch ($method){
      case "POST":
         curl_setopt($curl, CURLOPT_POST, 1);
         if ($data)
            curl_setopt($curl, CURLOPT_POSTFIELDS, $data);
         break;
      case "PUT":
         curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "PUT");
         if ($data)
            curl_setopt($curl, CURLOPT_POSTFIELDS, $data);			 					
         break;
    case "GET":
         curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "GET");
         if ($data)
            curl_setopt($curl, CURLOPT_POSTFIELDS, $data);			 					
         break;
      default:
         if ($data)
            $url = sprintf("%s?%s", $url, http_build_query($data));
   }
   // OPTIONS:
   curl_setopt($curl, CURLOPT_URL, $url);
   curl_setopt($curl, CURLOPT_HTTPHEADER, array(
      $authuser,
      'Content-Type: application/json'
   ));
    curl_setopt($curl,CURLOPT_FOLLOWLOCATION,1);
    curl_setopt($curl,CURLOPT_HTTP_VERSION,CURL_HTTP_VERSION_1_1);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
   // EXECUTE:
   $result = curl_exec($curl);
    //$response = curl_exec($curl);
   if(!$result){die("Connection Failure");}
   curl_close($curl);
   return $result;
   
    
}


function getCategory(){
	$url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI("GET", $url, false, $_SESSION["mauth"]);
    $response = json_decode($get_data, true);
    $errors = $response['status'];
    if ($errors == 200){

       $data = $response['message'];
    
    }else{
        echo "Unable to get Categories";
    }    
    
    return $data;
}

// Display the Categories
$showCat = getCategory();
function getLocation(){
$url = "http://api.bluecollarhub.com.ng/api/v1/Location";
$get_data = callAPI("GET", $url, false, $_SESSION["mauth"]);
$response = json_decode($get_data, true);
$errors = $response['status'];
if ($errors == 200){

$data = $response['message'];

}else{
echo "Unable to Get Location";
}

return $data;
}

$showLGA = getLocation();

$lgaList = array();
$lgaList = array_column($showLGA, 'lga');
$lgaList = array_unique($lgaList);

// Filter Area
$myArea = array_filter($showLGA, function ($value) use ($lga) {
//$sLGA = $_POST['sloc'];
$sLGA = "Ajeromi-Ifelodun";
$pLGA = $sLGA;
return ($value["lga"] == $pLGA);

});


function getBank(){
$url = "http://api.bluecollarhub.com.ng/api/v1/BankCode";
$get_data = callAPI('GET', $url, false,$_SESSION["mauth"]);
$response = json_decode($get_data, true);
$errors = $response['status'];
$data = $response['message'];
return $data;
}
//list the Bank
$tBank = getBank();
/*foreach ($tBank as $key => $value) {
echo $value["bankcode"] . ", " . $value["bankName"] . "<br>";
}*/


function getSearchList(){
echo "New Search";
    //return $data;
}

if (isset($_POST['getSearch'])) {
$inploc = $POST_['sloca'];
$inpcat = $POST_['scat'];
$url = "http://api.bluecollarhub.com.ng/api/v1/Search/?CatId=".$inpcat."&LocationId=".$inpcat."\"";
$get_data = callAPI('GET', $url, false,$_SESSION["mauth"]);
$response = json_decode($get_data, true);
$errors = $response['status'];
$data = $response['message'];
echo "good one";
header('location: listings.php');

}

if (isset($_POST['reg_user'])) {
$data_array = array(
"EmailAddress" => $_POST['email'],
"Password" => $_POST['password'],
"RoleId" => $_POST['roleId'],
"CreationDate" => $ctime,
"UserName" => $_POST['username']
);

/*$data_array = array(
"EmailAddress" => "NewMember3@goinghome.com",
"Password" => "Testin321.",
"RoleId" => "1",
"CreationDate" => $ctime,
"UserName" => "GraciousB21"
);*/

$roleid = $_POST['roleId'];
$url = "http://api.bluecollarhub.com.ng/api/Account/Register";
$make_call = callAPI('POST', $url, json_encode($data_array),$_SESSION["mauth"]);
$response = json_decode($make_call, true);
$dstatus = $response['success'];
echo "new status is".$dstatus;
$derror = $response['errorMessage']; 
if ($dstatus){
$utoken = $response['token'];
$uuid= $response['userId'];
$_SESSION["uuID"] = $uuid;
$_SESSION["uuauth"] = "Authorization: bearer " . $utoken;
$_SESSION["username"] = $_POST['username'];
$_SESSION["message"] = "You have registered successfully message, Dear ".$_SESSION["username"];
   //echo "<script>alert('$message');</script>";
      if($roleid == 1){
       header('location: nprofilea.php');
    }else{
       header('location: nprofilec.php');
    } 
    
}else{
$message = $derror;
    foreach ($derror as $errorMessage => $val) {
   echo "Registration Failed: " .$val;
    
}
    
}
}


if (isset($_POST['ulogin'])) {
$url = "http://api.bluecollarhub.com.ng/api/Account/Login";
    $emailid = $_POST['email'];
$data_array = array(
"username" => $_POST['email'],
"Password" => $_POST['password']
);  
$make_call = callAPI('POST', $url, json_encode($data_array),$_SESSION["mauth"]);
$response = json_decode($make_call,true); 
$uuid= $response['userId'];
$urole= $response['userRole'];
$utoken = $response['token'];
$dstatus = $response['success'];
$derror = $response['errorMessage'];    
if ($dstatus){
	$_SESSION["uuID"] = $uuid;
	$_SESSION["uRole"] = $urole;
    $_SESSION["uuauth"] = "Authorization: bearer " . $utoken;
    $_SESSION["username"] = $emailid;
    $message = "You have logged in successfully, Dear ".$emailid."<br>";
   echo "<script>alert('$message');</script>";
    if($urole == "Artisan"){
    
      echo "You are an artisan";  
    }else{
        echo "You are a client";
    }
    
    }else  {
    echo "Unable to login";
  foreach ($derror as $errorMessage => $val) {
   echo "Login failed: " .$val;

  }
   }  
    
}

if (isset($_POST['reg_artisan'])) {
$ifname = "";
$ilname = "";
$iphone ="";
$iarea="";
$iidc="";
$icat="";
$ipath = "";
$iadd = "";
$istate = "";
$ime ="";
$iuid = "";
$ifname = $_POST['fname'];
$ilname = $_POST['lname'];
$iphone =$_POST['phone'];
$iarea= $_POST['sloca'];
$iidc= $_POST['idnum'];
$icat=$_POST['jcat'];
$ipath = $_POST['ppath'];
$iadd = $_POST['address'];
$istate = $_POST['lstate'];
$ime =$_POST['adesc'];
$iuid = $_SESSION["uuID"];
    
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
   "userId" =>$iuid );
  echo  json_encode($data_array);  
$url = "http://api.bluecollarhub.com.ng/api/v1/artisan"; 
$make_call = callAPI('POST', $url, json_encode($data_array),$_SESSION["mauth"]);
    //$err = curl_error($curl);
$response = json_decode($make_call, true);
$dstatus = $response['status'];
$ddata = $response['message']; 
$derror = $response['message']; 
if ($dstatus === "201"){
$_SESSION["message"] = "Profile Saved message. Kindly update Bank Details";
       header('location: nprofileb.php'); 
    
}else{
$message = $derror;
/*   foreach ($derror as $errorMessage => $val) {
   echo "Cannot create Profile: " .$val; 
}*/
    
}
}

if (isset($_POST['bankfsub'])) {
$data_array = array(
   
  "accountName"=> $_POST['bname'],
  "accountNumber"=> $_POST['accname'],
  "bankCode"=> $_POST['acnum'],
  "bvn"=> $_POST['bvn'],
  "createdDate"=> $ctime,
  "userId" => $_SESSION["uuID"]
);
   
$url = "http://api.bluecollarhub.com.ng/api/v1/BankDetail";
$make_call = callAPI('POST', $url, json_encode($data_array),$_SESSION["mauth"]);
$response = json_decode($make_call, true);
$dstatus = $response['success'];
$derror = $response['errorMessage']; 
if ($dstatus){
$message = "Bank Details Saved, Thank you";
   echo "<script>alert('$message');</script>";
       header('location: artisan.php'); 
    
}else{
$message = $derror;
    
}
    
}

if (isset($_POST['reg_client'])) {
$data_array = array(
"firstName" => $_POST['fname'],
  "lastName" => $_POST['lname'],
  "phoneNumber" => $_POST['phone'],
  "idcardNo" => $_POST['idnum'],
  "picturePath" => $_POST['ppath'],
  "address" => $_POST['address'],
  "state" => $_POST['lstate'],
  "userId" => $_SESSION["uuID"]

);
    
$url = "http://api.bluecollarhub.com.ng/api/v1/Client";
    echo $_SESSION["uuID"]."SessionId";
$make_call = callAPI('POST', $url, json_encode($data_array),$_SESSION["uuauth"]);
$response = json_decode($make_call, true);
$dstatus = $response['success'];
$derror = $response['errorMessage']; 
if ($dstatus){
$message = "Profile Saved, Thank You";
   echo "<script>alert('$message');</script>";
       header('location: index.php'); 
    
}else{
$message = $derror;
/*    foreach ($derror as $errorMessage => $val) {
    echo "Cannot Create profile: " .$val;
    }*/
    
}

}

?>
