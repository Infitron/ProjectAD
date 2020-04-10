<? php
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
 //  if(!$result){die("Connection Failure");}
   curl_close($curl);
   return $result; 
}

$data_array = array(
"FirstName" => "Teminola",
  "LastName" => "Ariyo",
  "PhoneNumber" => "0987868776",
  "AreaLocationId" => 34,
  "IdcardNo" => "536744",
  "PicturePath" => "newpath.jpg",
  "Address" => "45, The Lord is doing great str",
  "ArtisanCategoryId" => 16,
  "State" => "Lagos",
  "AboutMe" => "Let's go and see all the movies",
  "UserId" => 15
);
$url = "http://api.bluecollarhub.com.ng/api/v1/artisan"; 
$make_call = callAPI('POST', $url, json_encode($data_array),$_SESSION["muauth"]);
$response = json_decode($make_call, true);
$dstatus = $response['status'];
$derror = $response['Message']; 
if ($dstatus == 201){
$_SESSION["message"] = "Profile Saved message. Kindly update Bank Details";

       header('location: nprofileb.php'); 
    
}else{
$message = $derror;
/*   foreach ($derror as $errorMessage => $val) {
   echo "Cannot create Profile: " .$val; 
}*/
    
    
}
?>
