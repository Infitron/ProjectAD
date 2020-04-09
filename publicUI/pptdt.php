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
      default:
         if ($data)
            $url = sprintf("%s?%s", $url, http_build_query($data));
   }
   // OPTIONS:
   curl_setopt($curl, CURLOPT_URL, $url);
   curl_setopt($curl, CURLOPT_HTTPHEADER, array(
      $authuser,
      'Content-Type: application/json',
   ));
   curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
   // curl_setopt($curl, CURLOPT_HTTPAUTH, CURLAUTH_BASIC);
   // EXECUTE:
   $result = curl_exec($curl);
   if(!$result){die("Connection Failure");}
   curl_close($curl);
   return $result;
}

function userLogin {
    $url = "http://api.bluecollarhub.com.ng/api/Account/Login";
    $data_array =  array(
      "FirstName" => $_POST['fname'],
	  "LastName" => $_POST['lname']);
    $make_call = callAPI('POST', $url, json_encode($data_array), $autht);
    $response = json_decode($make_call, true);
	$errors   = $response['response']['status'];
	$datan     = $response['response']['message'][0];
   
    $rsucess= $datan->success;
    $rerror = $datan->error;
    $utoken = $datan->token;
     
	if ($rsuccess == "false") {
	echo "Login Failed " . $rerror;
	} else {
       //save the varriables
        
        header('location: index.php');
	   }
}

function createUser(){
	$url = "http://api.bluecollarhub.com.ng/api/Account/Register";
    $RoleId = $_POST['roleId'];
	/*$emailaddress ="";
	$password = "";
	$RoleId = 0;
	$username = "";
	$rolename = "";
	$emailaddress = $_POST['email'];
    $password = $_POST['password'];
    $Creationdate = $ctime;
    
    $username = $_POST['username'];                           
    $field_data = "{\r\n  \"EmailAddress\": \"".$emailaddress."\",\r\n  \"Password\": \"".$password."\",\r\n  \"CreationDate\": \"".$ctime."\",\r\n  \"RoleId\": \"".$RoleId."\",\r\n  \"UserName\": \"".$username."\"\r\n}";
	*/
	// make the api callAPI
	
	$data_array =  array(
      "EmailAddress"        => $_POST['email'],
	  "Password"        => $_POST['password'],
	  "CreationDate"        => $ctime,
	  "RoleId"        => $_POST['roleId'],
	  "UserName"        => $_POST['username']
	  );
	$make_call = callAPI('POST', $url, json_encode($data_array), $autht);
	$response = json_decode($make_call, true);
	$errors   = $response['response']['status'];
	$datan     = $response['response']['message'][0]; 
    $rsucess= $datan->success;
    $rerror = $datan->error;
     
	if ($rsuccess == "false") {
	echo "Account Creation Failed " . $rerror;
	} else {
     $uid= $datan->userId; 
	$utoken = $datan->token;
      
    $_SESSION['susername'] = $username;
    $_SESSION['suserId'] = $uid;
    $_SESSION['sutoken'] = $utoken;
    $_SESSION['suroleiId'] = $RoleId;
    $_SESSION['suath'] = "Authorization: Bearer ".$utoken;
  
    $message = "\"Welcome to Blue Collar Hub, ".$susername.". Registeration is Successful; \n Proceed to set your profile.\"";

    //echo "<script>alert('$message');</script>";
        if ($RoleId == 1) {
  	header('location: nprofilea.php');
        }else{
            header('location: nprofileb.php');
        }
		}
	}

function createArtisan{
	$url = "http://api.bluecollarhub.com.ng/api/v1/artisan";
	$data_array =  array(
      "FirstName" => $_POST['fname'],
	  "LastName" => $_POST['lname'],
	  "PhoneNumber" => $_POST['phone'],
	"AreaLocation" => $_POST['laarea'],
    "IdcardNo": => $_POST['email'],
    "PicturePath" => $_POST['ppath'],
    "Address"=> $_POST['address'],
    "ArtisanCategoryId"=> $_POST['jcat'],
    "StateId" => $_POST['lstate'],
    "AboutMe" => $_POST['adesc'],
	 "UserId" => $uid
	  );
	$make_call = callAPI('POST', $url, json_encode($data_array), $autht);
	$response = json_decode($make_call, true);
	$errors   = $response['response']['status'];
	$datan     = $response['response']['message'][0];
   
    $rsucess= $datan->success;
    $rerror = $datan->error;
    $utoken = $datan->token;
     
	if ($rsuccess == "false") {
	echo "Profile Creation Failed " . $rerror;
	} else {
       //save the varriables
        
        header('location: nprofileb.php');
	   }
}

function createClient{
	$url = "http://api.bluecollarhub.com.ng/api/v1/Client";
    $data_array =  array(
      "FirstName" => $_POST['fname'],
	  "LastName" => $_POST['lname'],
	  "PhoneNumber" => $_POST['phone'],
    "IdcardNo": => $_POST['email'],
    "PicturePath" => $_POST['ppath'],
    "Address"=> $_POST['address'],
    "StateId" => $_POST['lstate'],
	 "UserId" => $uid
	  );
	$make_call = callAPI('POST', $url, json_encode($data_array), $autht);
	$response = json_decode($make_call, true);
	$errors   = $response['response']['status'];
	$datan     = $response['response']['message'][0];
   
    $rsucess= $datan->success;
    $rerror = $datan->error;
    $utoken = $datan->token;
     
	if ($rsuccess == "false") {
	echo "Profile Creation Failed " . $rerror;
	} else {
       //save the varriables
        $message = "Profile created";
        header('location: index.php');
	   }
	
}

function createArtisanBank{
	$url = "http://api.bluecollarhub.com.ng/api/v1/BankDetail";
    $data_array =  array(
      "AccountName" => $_POST['accname'],
	  "AccountNumber" => $_POST['accnum'],
	  "BankCode" => $_POST['bname'],
        "Bvn" => $_POST['bvn'],
        "CreatedDate" => $ctime,
	 "UserId" => $uid
	  );
	$make_call = callAPI('POST', $url, json_encode($data_array), $autht);
	$response = json_decode($make_call, true);
	$errors   = $response['response']['status'];
	$datan     = $response['response']['message'][0];
   
    $rsucess= $datan->success;
    $rerror = $datan->error;
     
	if ($rsuccess == "false") {
	echo "Profile Creation Failed " . $rerror;
	} else {
       $message = "Bank Details Saved";
        
        header('location: index.php');
	   }
}

function createServices{
	
    $url = "http://api.bluecollarhub.com.ng/api/v1/Service";
}

function createPost{
	
	echo "New Call Here4";
}

function createArtisanGallery{
	
	echo "New Call Here5";
}

function createArticle{
	echo "New Call Here6";
    $url = "http://api.bluecollarhub.com.ng/api/v1/Article";
}

function createBooking{
	echo "New Call Here7";
    $url = "http://api.bluecollarhub.com.ng/api/v1/Order";
}

function createQuote{
	echo "New Call Here8";
    $url = "http://api.bluecollarhub.com.ng/api/v1/Quote"
}

function createInvoice{
	echo "New Call Here9";
}

function createPayment{
	echo "New Call Here10";
    url
}

function createProject{
	echo "New Call Here11";
    $url = "http://api.bluecollarhub.com.ng/api/v1/Project";
}

function createArtisanRating{
	echo "New Call Here12";
   $url = "http://api.bluecollarhub.com.ng/api/v1/Project"; 
}

function getUser{
	echo "New Call Here13";
}

function getCategory{
	
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
   /* {
            "id": 1,
            "categoryName": "Auto",
            "subCategories": "Mechanic",
            "createdDate": null,
            "artisan": []
        }*/
    
}

function getLocation{
	echo "New Call Here15";
    $url = "http://api.bluecollarhub.com.ng/api/v1/Location";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    //$errors = $response['response']['status'];
    $data = $response['response'][0];
 /*   {
        "id": 1,
        "state": "Lagos",
        "lga": "Kosofe",
        "area": "Ogudu",
        "statusId": 1,
        "createdDate": "2020-02-05T02:42:38.29",
        "idNavigation": null,
        "artisan": []
    }*/
}

function getBankCode{
	echo "New Call Here16";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getSearch{
	echo "New Call Here17";
    $cat = $_POST['catid'];
    $loc = $_POST['locid'];
    $url = "http://api.bluecollarhub.com.ng/api/v1/Search/".$cat."//".$loc;
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
   // $errors = $response['response']['status'];
    $data = $response['response'][0];
 /*    {
       "id": 1,
        "userId": 2,
        "firstName": "Teslim",
        "lastName": "Bakare",
        "phoneNumber": "08029627147",
        "areaLocation": "1",
        "idcardNo": "string",
        "picturePath": "path",
        "address": "add",
        "artisanCategoryId": 1,
        "stateId": 1,
        "aboutMe": "about me",
        "createdDate": null,
        "artisanCategory": null,
        "state": null,
        "quote": null,
        "artisanServices": [],
        "bankDetails": [],
        "booking": [],
        "gallary": [],
        "paymentHistory": [],
        "projects": [],
        "rating": [],
        "services": []
    }*/
    
    
}

function getArtisanRating{
	echo "New Call Here18";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getArtisan{
	echo "New Call Here19";
    $url = "http://api.bluecollarhub.com.ng/api/v1/artisan";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
/*    {
            "id": 1,
            "userId": 2,
            "firstName": "Teslim",
            "lastName": "Bakare",
            "phoneNumber": "08029627147",
            "areaLocation": "1",
            "idcardNo": "string",
            "picturePath": "path",
            "address": "add",
            "artisanCategoryId": 1,
            "stateId": 1,
            "aboutMe": "about me",
            "createdDate": null,
            "artisanCategory": null,
            "state": null,
            "quote": null,
            "artisanServices": [],
            "bankDetails": [],
            "booking": [],
            "gallary": [],
            "paymentHistory": [],
            "projects": [],
            "rating": [],
            "services": []
        }*/
}

function getClient{
	echo "New Call Here20";
    $url = "http://api.bluecollarhub.com.ng/api/v1/Client";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
    
  /*  {
            "id": 1,
            "userId": 1,
            "firstName": "Teslim",
            "lastName": "Bakare",
            "phoneNumber": "08029627147",
            "picturePath": "/path/caption.png",
            "address": "djsdjks",
            "state": "lagos",
            "createdDate": "2020-01-30T00:00:00",
            "booking": [],
            "paymentHistory": [],
            "projects": [],
            "quote": [],
            "rating": []
        }*/
}

function getArtisanBank{
	echo "New Call Here21";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getServices{
	echo "New Call Here22";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getPost{
	echo "New Call Here23";
}

function getArtisanGallery{
	echo "New Call Here24";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getArticle{
	echo "New Call Here25";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getBooking{
	echo "New Call Here26";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getQuote{
	echo "New Call Here27";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getProjects{
	echo "New Call Here28";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getInvoice{
	echo "New Call Here29";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}

function getPayment{
	echo "New Call Here30";
    $url = "http://api.bluecollarhub.com.ng/api/v1/ACategory";
    $get_data = callAPI('GET', $url, false, $autht);
    $response = json_decode($get_data, true);
    $errors = $response['response']['status'];
    $data = $response['response']['message'][0];
}
?>
