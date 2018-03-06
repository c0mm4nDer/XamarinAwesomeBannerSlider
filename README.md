
# XamarinAwesomeBannerSlider
Xamarin.Android Library for using as banner slider.

![enter image description here](https://raw.githubusercontent.com/c0mm4nDer/XamarinAwesomeBannerSlider/master/screenshots/my_xamarin_slider.gif)

# Usage
Add view to your xml file:

    <XamarinAwesomeBannerSlider.ImageAwesomeBanner
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:minWidth="25px"
        android:minHeight="25px"
        android:id="@+id/slider" />

Create instance of ***ImageAwesomeBanner*** :

    var slider = FindViewById<ImageAwesomeBanner>(Resource.Id.slider);
For add slide use ***AddSlide*** method:

    slider.AddSlide(new XamarinAwesomeBannerSlider.Entities.Slide() {
                Image = Resources.GetDrawable(Resource.Drawable.ic_test),
                Title = "title 1",
                Decription = "description 1"
            });
For customization using ***Config*** :

    slider.ConfigSlide(new XamarinAwesomeBannerSlider.Entities.Config()
	  {
	      DescriptionColor = Android.Graphics.Color.Aqua, //or set null default color. default->whi
	      TitleColor = Android.Graphics.Color.Bisque,  //or set null default color. default->white
	      DescriptionTypeFace = fontBYekanNormal,
	      TitleTypeFace = fontBYekanNormal
	  });

# version

 - 1.0.0.0
	 - 
	 - AutoSlider
	 - Change text title and text description with animation
	 - Infinity slides - for now not active for outside of library 

