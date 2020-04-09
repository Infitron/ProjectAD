<?php include('hnav.php'); ?>

<div class="site-blocks-cover overlay" style="background-image: url(images/banner1.png);" data-aos="fade" data-stellar-background-ratio="0.5">
    <div class="container">
        <div class="row align-items-center justify-content-center text-center">
            <div class="col-md-12">

                <div class="row justify-content-center mb-4">
                    <div class="col-md-8 text-center">
                        <h1 class="" data-aos="fade-up">Welcome to Blue Collar Hub</h1>
                        <p data-aos="fade-up" data-aos-delay="100">No matter where you live, just enter the service you looking for and we'll find the right artisan for you.</p>
                    </div>
                </div>
                <div class="form-search-wrap mb-3" data-aos="fade-up" data-aos-delay="200">
                    <form method="post" action="#" id="searchl">
                        <div class="row align-items-center">
                            <div class="col-lg-12 mb-4 mb-xl-0 col-xl-3">
                                <div class="select-wrap">
                                    <span class="icon"><span class="icon-keyboard_arrow_down"></span></span>
                                    <select class="form-control rounded selectpicker" name="scat" id="scat" data-live-search="true" title="Select A Category">
                                        <?php foreach ($showCat as $key => $value) {
                                        echo "<option value=\"".$value["id"]."\">".$value["categoryName"] . "-" .$value["subCategories"]."</option>";

                                        }
                                        ?>

                                    </select>
                                </div>
                            </div>
                            <div class="col-lg-12 mb-4 mb-xl-0 col-xl-3">
                                <div class="wrap-icon">
                                    <span class="icon icon-room"></span>
                                    <select class="form-control rounded selectpicker" name="sloc" id="sloc" data-live-search="true" title="Select A Local Govt">
                                        <option value="">Select LGA</option>
                                        <?php 
                                        foreach ($lgaList as $value) {
                                        echo "<option value='".$value."'>".$value."</option>";
                                        }
                                        ?>

                                    </select>
                                </div>
                            </div>
                            <div class="col-lg-12 mb-4 mb-xl-0 col-xl-3">
                                <div class="wrap-icon">
                                    <span class="icon icon-room"></span>

                                    <select class="form-control" name="sloca" id="sloca">
                                        <option value="">Select LGA first</option>

                                    </select>
                                </div>
                            </div>

                            <div class="col-lg-12 col-xl-2 ml-auto text-right">
                                <input type="submit" class="btn btn-primary btn-block rounded" value="Search" id="getSearch" name="getSearch">
                            </div>
                        </div>
                    </form>
                </div>
                <div class="row text-left trending-search" data-aos="fade-up" data-aos-delay="300">
                    <div class="col-12">
                        <h2 class="d-inline-block">Trending Search:</h2>
                        <a href="#">Car Painting</a>
                        <a href="#">Tailoring</a>
                        <a href="#">House Painting</a>
                        <a href="#">Panel Beater</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="site-section bg-light">
    <div class="container">

        <div class="row">
            <div class="col-12">
                <h2 class="h5 mb-4 text-black">Featured Ads</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-12  block-13">
                <div class="owl-carousel nonloop-block-13">
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/mech.png')"></a>
                        <div class="lh-content">
                            <span class="category">Automobiles</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">Car Mechanics</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/tailor.png')"></a>
                        <div class="lh-content">
                            <span class="category">Fashion</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">Home Restoration</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/users.png')"></a>
                        <div class="lh-content">
                            <span class="category">Furniture</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">New Sofa</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/img_3.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Electronics</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">Phone Repairs</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/mech.png')"></a>
                        <div class="lh-content">
                            <span class="category">Automobiles</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">Car Mechanics</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/tailor.png')"></a>
                        <div class="lh-content">
                            <span class="category">Fashion</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">Home Restoration</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/users.png')"></a>
                        <div class="lh-content">
                            <span class="category">Furniture</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">Wooden Chair &amp; Table</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing vertical">
                        <a href="listings-single.php" class="img d-block" style="background-image: url('images/img_3.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Electronics</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.php">iPhone X gray</a></h3>
                            <address>28, Broad Str, Ikeja, Lagos</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>
<div class="site-section" data-aos="fade">
    <div class="container">
        <div class="row justify-content-center mb-5">
            <div class="col-md-7 text-center border-primary">
                <h2 class="font-weight-light text-primary">Popular Categories</h2>
                <p class="color-black-opacity-5">Lorem Ipsum Dolor Sit Amet</p>
            </div>
        </div>
        <div class="overlap-category mb-5">
            <div class="row align-items-stretch no-gutters">
                <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-2">
                    <a href="#" class="popular-category h-100">
                        <span class="icon"><span class="flaticon-car"></span></span>
                        <span class="caption mb-2 d-block">Automobiles</span>
                        <span class="number">1,921</span>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-2">
                    <a href="#" class="popular-category h-100">
                        <span class="icon"><span class="flaticon-closet"></span></span>
                        <span class="caption mb-2 d-block">Furniture</span>
                        <span class="number">2,339</span>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-2">
                    <a href="#" class="popular-category h-100">
                        <span class="icon"><span class="flaticon-home"></span></span>
                        <span class="caption mb-2 d-block">Fashion</span>
                        <span class="number">4,398</span>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-2">
                    <a href="#" class="popular-category h-100">
                        <span class="icon"><span class="flaticon-open-book"></span></span>
                        <span class="caption mb-2 d-block">Fabrications</span>
                        <span class="number">3,298</span>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-2">
                    <a href="#" class="popular-category h-100">
                        <span class="icon"><span class="flaticon-tv"></span></span>
                        <span class="caption mb-2 d-block">Electronics</span>
                        <span class="number">`2,932</span>
                    </a>
                </div>
                <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-2">
                    <a href="#" class="popular-category h-100">
                        <span class="icon"><span class="flaticon-pizza"></span></span>
                        <span class="caption mb-2 d-block">Other</span>
                        <span class="number">183</span>
                    </a>
                </div>
            </div>
        </div>

    </div>
</div>

<div class="site-section bg-light">
    <div class="container">
        <div class="row mb-5">
            <div class="col-md-7 text-left border-primary">
                <h2 class="font-weight-light text-primary">Trending Now</h2>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-lg-6">
                <div class="d-block d-md-flex listing">
                    <a href="listings-single.php" class="img d-block" style="background-image: url('images/tailor.png')"></a>
                    <div class="lh-content">
                        <span class="category">Fashion</span>
                        <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                        <h3><a href="listings-single.php">Home Restoration</a></h3>
                        <address>28, Broad Str, Ikeja, Lagos</address>
                        <p class="mb-0">
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-secondary"></span>
                            <span class="review">(3 Reviews)</span>
                        </p>
                    </div>
                </div>
                <div class="d-block d-md-flex listing">
                    <a href="listings-single.php" class="img d-block" style="background-image: url('images/users.png')"></a>
                    <div class="lh-content">
                        <span class="category">Furniture</span>
                        <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                        <h3><a href="listings-single.php">Wooden Chair &amp; Table</a></h3>
                        <address>28, Broad Str, Ikeja, Lagos</address>
                        <p class="mb-0">
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-secondary"></span>
                            <span class="review">(3 Reviews)</span>
                        </p>
                    </div>
                </div>
                <div class="d-block d-md-flex listing">
                    <a href="listings-single.php" class="img d-block" style="background-image: url('images/img_3.jpg')"></a>
                    <div class="lh-content">
                        <span class="category">Electronics</span>
                        <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                        <h3><a href="listings-single.php">iPhone X gray</a></h3>
                        <address>28, Broad Str, Ikeja, Lagos</address>
                        <p class="mb-0">
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-secondary"></span>
                            <span class="review">(3 Reviews)</span>
                        </p>
                    </div>
                </div>

            </div>
            <div class="col-lg-6">
                <div class="d-block d-md-flex listing">
                    <a href="listings-single.php" class="img d-block" style="background-image: url('images/mech.png')"></a>
                    <div class="lh-content">
                        <span class="category">Automobiles</span>
                        <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                        <h3><a href="listings-single.php">Car Mechanics</a></h3>
                        <address>28, Broad Str, Ikeja, Lagos</address>
                        <p class="mb-0">
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-secondary"></span>
                            <span class="review">(3 Reviews)</span>
                        </p>
                    </div>
                </div>
                <div class="d-block d-md-flex listing">
                    <a href="listings-single.php" class="img d-block" style="background-image: url('images/tailor.png')"></a>
                    <div class="lh-content">
                        <span class="category">Fashion</span>
                        <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                        <h3><a href="listings-single.php">Home Restoration</a></h3>
                        <address>28, Broad Str, Ikeja, Lagos</address>
                        <p class="mb-0">
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-secondary"></span>
                            <span class="review">(3 Reviews)</span>
                        </p>
                    </div>
                </div>
                <div class="d-block d-md-flex listing">
                    <a href="listings-single.php" class="img d-block" style="background-image: url('images/users.png')"></a>
                    <div class="lh-content">
                        <span class="category">Furniture</span>
                        <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                        <h3><a href="listings-single.php">Wooden Chair &amp; Table</a></h3>
                        <address>28, Broad Str, Ikeja, Lagos</address>
                        <p class="mb-0">
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-warning"></span>
                            <span class="icon-star text-secondary"></span>
                            <span class="review">(3 Reviews)</span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="site-section bg-white">
    <div class="container">
        <div class="row justify-content-center mb-5">
            <div class="col-md-7 text-center border-primary">
                <h2 class="font-weight-light text-primary">Testimonials</h2>
            </div>
        </div>

        <div class="slide-one-item home-slider owl-carousel">
            <div>
                <div class="testimonial">
                    <figure class="mb-4">
                        <img src="images/person_3.jpg" alt="Image" class="img-fluid mb-3">
                        <p>Jolade Abimbolu</p>
                    </figure>
                    <blockquote>
                        <p>&ldquo;Strange and beautiful things happen to each of us every day, and sometimes you just cannot keep silent about them. This is what inspired a special online project that allows people to share anonymously all the heart-warming, hilarious, sad, inspiring and wonderful stories from people’s lives that they overhear.&rdquo;</p>
                    </blockquote>
                </div>
            </div>
            <div>
                <div class="testimonial">
                    <figure class="mb-4">
                        <img src="images/person_2.jpg" alt="Image" class="img-fluid mb-3">
                        <p>Christine Ugheli</p>
                    </figure>
                    <blockquote>
                        <p>&ldquo;A little girl was decorating a box with a gold wrapping paper to put it under the Christmas tree. George was a driver and. George was a driver and he spent so much time at his work, that he could hardly have a meal together with his wife and three children.&rdquo;</p>
                    </blockquote>
                </div>
            </div>

            <div>
                <div class="testimonial">
                    <figure class="mb-4">
                        <img src="images/person_4.jpg" alt="Image" class="img-fluid mb-3">
                        <p>Tijani Bella</p>
                    </figure>
                    <blockquote>
                        <p>&ldquo;I'm an optimist in the sense that I believe humans are noble and honorable, and some of them are really smart. I have a very optimistic view of individuals.&rdquo;</p>
                    </blockquote>
                </div>
            </div>

            <div>
                <div class="testimonial">
                    <figure class="mb-4">
                        <img src="images/person_5.jpg" alt="Image" class="img-fluid mb-3">
                        <p>Adeyemi Brainard</p>
                    </figure>
                    <blockquote>
                        <p>&ldquo;A very elderly man with a large packet in his hands always comes by our apartment block every morning. The whole courtyard comes alive when he shows up; all the local cats and their kittens run up to him from all directions, purring and rubbing his legs. He tries to give some of his attention to each one of the animals, petting them, talking to them. Then he goes to their bowls scattered underneath the nearby trees, cleans them, ladles out some pet food from his packet, and pours some milk and fresh water. &rdquo;</p>
                    </blockquote>
                </div>
            </div>

        </div>
    </div>
</div>

<div class="site-section bg-light">
    <div class="container">
        <div class="row justify-content-center mb-5">
            <div class="col-md-7 text-center border-primary">
                <h2 class="font-weight-light text-primary">Our Blog</h2>
                <p class="color-black-opacity-5">See Our Daily News &amp; Updates</p>
            </div>
        </div>
        <div class="row mb-3 align-items-stretch">
            <div class="col-md-6 col-lg-4 mb-4 mb-lg-4">
                <div class="h-entry">
                    <img src="images/mech.png" alt="Image" class="img-fluid rounded">
                    <h2 class="font-size-regular"><a href="#" class="text-black">Many People Selling Online</a></h2>
                    <div class="meta mb-3">by Mark Spiker<span class="mx-1">&bullet;</span> Jan 18, 2019 <span class="mx-1">&bullet;</span> <a href="#">News</a></div>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Natus eligendi nobis ea maiores sapiente veritatis reprehenderit suscipit quaerat rerum voluptatibus a eius.</p>
                </div>
            </div>
            <div class="col-md-6 col-lg-4 mb-4 mb-lg-4">
                <div class="h-entry">
                    <img src="images/tailor.png" alt="Image" class="img-fluid rounded">
                    <h2 class="font-size-regular"><a href="#" class="text-black">Many People Selling Online</a></h2>
                    <div class="meta mb-3">by Mark Spiker<span class="mx-1">&bullet;</span> Jan 18, 2019 <span class="mx-1">&bullet;</span> <a href="#">News</a></div>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Natus eligendi nobis ea maiores sapiente veritatis reprehenderit suscipit quaerat rerum voluptatibus a eius.</p>
                </div>
            </div>
            <div class="col-md-6 col-lg-4 mb-4 mb-lg-4">
                <div class="h-entry">
                    <img src="images/users.png" alt="Image" class="img-fluid rounded">
                    <h2 class="font-size-regular"><a href="#" class="text-black">Many People Selling Online</a></h2>
                    <div class="meta mb-3">by Mark Spiker<span class="mx-1">&bullet;</span> Jan 18, 2019 <span class="mx-1">&bullet;</span> <a href="#">News</a></div>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Natus eligendi nobis ea maiores sapiente veritatis reprehenderit suscipit quaerat rerum voluptatibus a eius.</p>
                </div>
            </div>
            <div class="col-12 text-center mt-4">
                <a href="#" class="btn btn-primary rounded py-2 px-4 text-white">View All Posts</a>
            </div>
        </div>
    </div>
</div>
<section class="mbr-section--bg-adapted mbr-section--relative" id="pricing-table1-3" data-rv-view="0">
    <div class="pricing" id="pricing">
        <div class="container">
            <div class="section-head-lite text-center col-md-12 col-md-offset-2 space80">
                <h1 class="font-weight-light text-primary">BlueCollar Hub Membership Plans</h1>
                <p class="color-black-opacity-5">We engage artisans in the following categories</p>
            </div>
            <div class="row pricing1">


                <!-- Pricing Plan - 1 -->
                <div class="col-sm-4 price-styles" style="display: block;">
                    <div class="pricing__item price-four-el" data-hover="">
                        <h3 class="pricing__title mbr-title-font mbr-primary-color">BlueCollar Basic Plan</h3>
                        <p class="pricing__sentence">Perfect for starter</p>
                        <div class="pricing__price mbr-title-font">

                            <span>FREE</span>
                            <span class="pricing__period">/forever</span>
                        </div>
                        <div>
                            <ul class="pricing__feature-list mbr-text-font">
                                <li class="pricing__feature">Online Registeration</li>
                                <li class="pricing__feature">Regular listing</li>
                                <li class="pricing__feature">Basic Documentation</li>
                            </ul>
                        </div>
                        <div><a href="#" class="btn mbr-title-font btn-primary" target="_blank">Sign Up</a></div>
                    </div>
                </div>

                <!-- Pricing Plan - 2 -->
                <div class="col-sm-4 price-styles" data-hover="Most popular" style="display: block;">
                    <div class="popular mbr-title-font price-four-el"><strong>Most Popular</strong></div>
                    <div class="pricing__item pricing__item__popular price-four-el">

                        <h3 class="pricing__title mbr-title-font mbr-primary-color">BlueCollar Plus Plan</h3>
                        <p class="pricing__sentence">Be more visible</p>
                        <div class="pricing__price mbr-title-font">
                            <span class="pricing__currency">NGN</span>
                            <span>1000</span>
                            <span class="pricing__period">/year</span>
                        </div>
                        <div>
                            <p>Requirements</p>
                            <ul class="pricing__feature-list mbr-text-font">
                                <li class="pricing__feature">Verified Account</li>
                                <li class="pricing__feature">Skills Assessment</li>
                                <li class="pricing__feature">Bank Account Integration</li>
                            </ul>
                        </div>
                        <div>
                            <p>Benefits</p>
                            <ul class="pricing__feature-list mbr-text-font">
                                <li class="pricing__feature">Trainings</li>
                                <li class="pricing__feature">HMO</li>
                                <li class="pricing__feature">Insurance</li>
                                <li class="pricing__feature">Material Purchase</li>
                                <li class="pricing__feature">Articles</li>
                            </ul>
                        </div>
                        <div><a href="#" class="btn mbr-title-font btn-primary" target="_blank">Upgrade</a></div>
                    </div>
                </div>

                <!-- Pricing Plan - 3 -->
                <div class="col-sm-4 price-styles" style="display: block;">
                    <div class="pricing__item price-four-el">
                        <h3 class="pricing__title mbr-title-font mbr-primary-color">BlueCollar Premium Plan</h3>
                        <p class="pricing__sentence">Gain Elite Status</p>
                        <div class="pricing__price mbr-title-font">
                            <span class="pricing__currency">NGN</span>
                            <span>2000</span>
                            <span class="pricing__period">/year</span>
                        </div>
                        <p>Requirements</p>
                        <ul class="pricing__feature-list mbr-text-font">
                            <li class="pricing__feature">Verified Account</li>
                            <li class="pricing__feature">Skills Assessment</li>
                            <li class="pricing__feature">Bank Account Integration</li>
                            <li class="pricing__feature">Business Registeration</li>

                        </ul>
                        <div>
                            <p>Benefits</p>
                            <ul class="pricing__feature-list mbr-text-font">
                                <li class="pricing__feature">Trainings</li>
                                <li class="pricing__feature">HMO</li>
                                <li class="pricing__feature">Insurance</li>
                                <li class="pricing__feature">Material Purchase</li>
                                <li class="pricing__feature">Articles</li>
                                <li class="pricing__feature">Visible to HNI</li>
                                <li class="pricing__feature">Price Template</li>
                                <li class="pricing__feature">Access to equipment financing</li>
                            </ul>
                        </div>
                        <div><a href="#" class="btn mbr-title-font btn-primary" target="_blank">Upgrade</a></div>
                    </div>





                </div>
            </div>
        </div>
    </div>
</section>
<?php include('lfooter.php'); ?>
