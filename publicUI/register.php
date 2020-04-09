<?php include('hnav.php'); ?>


<div class="site-blocks-cover inner-page-cover overlay" style="background-image: url(images/banner2.png);" data-aos="fade" data-stellar-background-ratio="0.5">
    <div class="container">
        <div class="row align-items-center justify-content-center text-center">

            <div class="col-md-10" data-aos="fade-up" data-aos-delay="400">


                <div class="row justify-content-center mt-5">
                    <div class="col-md-8 text-center">
                        <h1>Sign Up</h1>
                        <p class="mb-0">Thank you for your intrest in BlueCollar Hub. Complete the form below to get started</p>
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

                <h2 class="mb-5 text-black">Register</h2>

                <form action="#" method="POST" id="reguser-form" class="p-5 bg-white">

                    <div class="row form-group">

                        <div class="col-md-12">
                            <label class="text-black" for="username">Username</label>
                            <input type="text" id="username" name="username" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">

                        <div class="col-md-12">
                            <label class="text-black" for="email">Email</label>
                            <input type="email" id="email" name="email" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <label class="text-black" for="password">Password</label>
                            <input type="password" id="password" name="password" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <label class="text-black" for="password2">Re-type Password</label>
                            <input type="password" id="password2" name="password2" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-4 col-sm-4 control-label" for="roleId" required>Register As: </label>
                        <div class="col-md-4 col-sm-4">
                            <label class="radio-inline" for="roleId">
                                <input type="radio" name="roleId" id="roleId" value="1" checked="checked">An Artisan
                            </label>

                        </div>
                        <div class="col-md-4 col-sm-4">

                            <label class="radio-inline" for="roleId">
                                <input type="radio" name="roleId" id="roleId" value="2">A Client
                            </label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-12">
                            <p>Already have an account? <a href="login.php">Log In Here</a></p>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <input type="submit" value="Sign Up" name="reg_user" id="reg_user" class="btn btn-primary py-2 px-4 text-white">
                        </div>
                    </div>
                    <div>
                        <p>
                            <? php echo $message; ?>
                        </p>
                    </div>
                </form>
            </div>

        </div>
    </div>
</div>

<?php include('lfooter.php'); ?>
