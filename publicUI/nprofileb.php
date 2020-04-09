<?php include('hnav.php'); ?>


<div class="site-blocks-cover inner-page-cover overlay" style="background-image: url(images/banner2.png);" data-aos="fade" data-stellar-background-ratio="0.5">
    <div class="container">
        <div class="row align-items-center justify-content-center text-center">

            <div class="col-md-10" data-aos="fade-up" data-aos-delay="400">


                <div class="row justify-content-center mt-5">
                    <div class="col-md-8 text-center">
                        <h1>Sign Up</h1>
                        <p class="mb-0">Update Your Bank Account Details Here</p>
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
                <h2 class="mb-5 text-black">Artisan Bank Details</h2>
                <form action="#" class="p-5 bg-white" method="post">
                    <div>
                        <p>
                            <? php echo $_SESSION["message"]; ?>
                        </p>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <label class="text-black" for="bname">Bank Name</label>
                            <select class="form-control slectpicker" id="bname" name="bname" data-live-search="true" required>
                                <option selected>Select Bank...</option>
                                <?php 
                            foreach ($tBank as $key => $value) {
                                echo "<option value=\"".$value["id"]."\">".$value["bankName"]."</option>";
                            }          
                            ?>
                            </select>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <label class="text-black" for="accname">Account Name</label>
                            <input type="text" id="accname" name="accname" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <label class="text-black" for="accnum">Account Number</label>
                            <input type="text" id="accnum" name="accnum" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <label class="text-black" for="bvn">Bank Verification Number(BVN)</label>
                            <input type="text" id="bvn" name="bvn" class="form-control">
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-12">
                            <input type="submit" value="Save" class="btn btn-primary py-2 px-4 text-white" name="bankfsub" id="bankfsub">
                        </div>
                    </div>

                </form>
            </div>

        </div>
    </div>
</div>
<?php include('lfooter.php'); ?>
