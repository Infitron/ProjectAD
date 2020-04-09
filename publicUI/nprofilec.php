<?php include('hnav.php'); ?>


<div class="site-blocks-cover inner-page-cover overlay" style="background-image: url(images/banner2.png);" data-aos="fade" data-stellar-background-ratio="0.5">
    <div class="container">
        <div class="row align-items-center justify-content-center text-center">

            <div class="col-md-10" data-aos="fade-up" data-aos-delay="400">


                <div class="row justify-content-center mt-5">
                    <div class="col-md-8 text-center">
                        <h1>Sign Up</h1>
                        <p class="mb-0">Please Update Your profile below</p>
                    </div>
                </div>


            </div>
        </div>
    </div>
</div>


<div class="site-section bg-light">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-7 mb-5" data-aos="fade">

                <h2 class="mb-5 text-black">New Client Profile</h2>

                <form action="#" class="p-5 bg-white">

                    <div class="row form-group">
                        <?php
                        echo "<p>Welcome Dear ".$_SESSION["username"]."<br>"."You have Signed Up successfully.</p>"."<br>";
                         echo "This is the user token".$_SESSION["uuauth"]."<br> Your user Id is:".$_SESSION["uuID"] ;
                        echo "This is the Admin token".$_SESSION["mauth"]."<br> Your Admin Id is:".$_SESSION["mID"] ;
                        echo "<p>Kindly complete your profile details to continue</p>". ;
                        ?>
                        <div>
                            <p>
                                <? php echo $_SESSION["message"]; ?>
                            </p>
                        </div>
                        <div class="col-md-12">
                            <label class="text-black" for="fname">First name</label>
                            <input type="text" id="fname" name="fname" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">

                        <div class="col-md-12">
                            <label class="text-black" for="lname">Last name</label>
                            <input type="text" id="lname" name="lname" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">

                        <div class="col-md-12">
                            <label class="text-black" for="phone">Phone Number</label>
                            <input type="text" id="phone" name="phone" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">

                        <div class="col-md-12">
                            <label class="text-black" for="address">Address</label>
                            <input type="text" id="address" name="address" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">

                        <div class="col-md-12">
                            <label class="text-black" for="lstate">State</label>
                            <select class="form-control" id="lstate" name="lstate" required>
                                <option selected>Choose...</option>
                                <option value="Lagos">Lagos State</option>
                            </select>
                        </div>
                    </div>
                    <div class="row form-group">


                        <div class="col-md-12">
                            <label class="text-black" for="idnum">Identification Number</label>
                            <input type="text" id="idnum" name="idnum" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">

                        <div class="col-md-12">
                            <label class="text-black" for="ppath">Upload Picture</label>
                            <input type="file" id="ppath" name="ppath" class="form-control">
                        </div>
                    </div>


                    <div class="row form-group">
                        <div class="col-md-12">
                            <input type="submit" value="Update Profile" class="btn btn-primary py-2 px-4 text-white" id="reg_client" name="reg_client">
                        </div>
                    </div>

                </form>
            </div>

        </div>
    </div>
</div>

<?php include('lfooter.php'); ?>
