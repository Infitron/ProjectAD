<?php 


include('processd.php'); 


?>

<!DOCTYPE html>
<html lang="en">

<head>
    <title><?php 
if(isset($title) && !empty($title)) { 
   echo "Blue Collar Hub - ".$title; 
} 
else { 
   echo "Blue Collar Hub"; 
} ?></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="shortcut icon" href="images/icon.png" type="image/x-icon">
    <link href="https://fonts.googleapis.com/css?family=Nanum+Gothic:400,700,800" rel="stylesheet">
    <link rel="stylesheet" href="fonts/icomoon/style.css">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/magnific-popup.css">
    <link rel="stylesheet" href="css/jquery-ui.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <link rel="stylesheet" href="css/bootstrap-datepicker.css">
    <link rel="stylesheet" href="css/bootstrap-select.min.css">
    <link rel="stylesheet" href="fonts/flaticon/font/flaticon.css">
    <link rel="stylesheet" href="css/aos.css">
    <link rel="stylesheet" href="css/rangeslider.css">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/stylep.css">
    <link rel="stylesheet" href="css/picker.min.css">


</head>

<body>


    <div class="site-wrap">
        <div class="site-mobile-menu">
            <div class="site-mobile-menu-header">
                <div class="site-mobile-menu-close mt-3">
                    <span class="icon-close2 js-menu-toggle"></span>
                </div>
            </div>
            <div class="site-mobile-menu-body"></div>
        </div>
        <header class="site-navbar container py-0 " role="banner">
            <!-- <div class="container"> -->
            <div class="row align-items-center">
                <div class="col-6 col-xl-2">
                    <h1 class="mb-0 site-logo"><a href="index.php" class="text-white mb-0"><img src="images/logo1.png" /></a></h1>
                </div>
                <div class="col-12 col-md-10 d-none d-xl-block">
                    <nav class="site-navigation position-relative text-right" role="navigation">
                        <ul class="site-menu js-clone-nav mr-auto d-none d-lg-block">
                            <li class="active"><a href="index.php">Home</a></li>
                            <li><a href="about.php">How It Works</a></li>
                            <li class="has-children">
                                <a href="listings.php">Categories</a>
                                <ul class="dropdown">

                                    <?php 
                                     foreach ($showCat as $key => $value) {
                                    echo "<li><a href=\".\listings.php\\".$value["id"]."\">". $value["categoryName"] . "-" .$value["subCategories"] ."</a></li>";
                                        }
                                    ?>

                                    <!--<li><a href="#">Automobile</a></li>
                                    <li><a href="#">Home and Office</a></li>
                                    <li><a href="#">Electronics</a></li>
                                    <li><a href="#">Entertainment</a></li>-->
                                </ul>
                            </li>
                            <li class="has-children">
                                <a href="plans.php">Our Plans</a>
                                <ul class="dropdown">

                                    <li><a href="#">BlueCollar Basic Plan</a></li>
                                    <li><a href="#">BlueCollar Plus Plan</a></li>
                                    <li><a href="#">BlueCollar Premium Plan</a></li>

                                </ul>
                            </li>

                            <li><a href="blog.php">Posts</a></li>
                            <li class="mr-5"><a href="contact.php">Contact</a></li>
                            <li class="ml-xl-3 login"><a href="login.php"><span class="border-left pl-xl-4"></span>Log In</a></li>
                            <li><a href="register.php" class="cta"><span class="bg-primary text-white rounded">Register</span></a></li>
                        </ul>
                    </nav>
                </div>

                <div class="d-inline-block d-xl-none ml-auto py-3 col-6 text-right" style="position: relative; top: 3px;">
                    <a href="#" class="site-menu-toggle js-menu-toggle text-white"><span class="icon-menu h3"></span></a>
                </div>
            </div>
            <!-- </div> -->
        </header>
