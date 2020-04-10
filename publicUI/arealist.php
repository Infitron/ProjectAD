<?php
    
include('gettoken.php');
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

function getarea1($value)
{
    $lgan1 = $_POST['sloc'];
  return $value["lga"] == $lgan1;
}
$showArea = (array_filter($showLGA,"getarea1"));
    
foreach ($showArea as $key => $value) {
        echo "<option value=\"".$value["id"]."\">".$value["area"]."</option>";
       }



?>
