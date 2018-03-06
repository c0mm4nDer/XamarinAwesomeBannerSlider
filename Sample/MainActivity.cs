using Android.App;
using Android.Widget;
using Android.OS;
using XamarinAwesomeBannerSlider;
using Android.Support.V7.App;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var slider = FindViewById<ImageAwesomeBanner>(Resource.Id.slider);

            slider.AddSlide(new XamarinAwesomeBannerSlider.Entities.Slide() {
                Image = Resources.GetDrawable(Resource.Drawable.ic_test),
                Title = "عنوان 1",
                Decription = "توضیحات مورد نظر شما1"
            });

            slider.AddSlide(new XamarinAwesomeBannerSlider.Entities.Slide()
            {
                Image = Resources.GetDrawable(Resource.Drawable.ic_test1),
                Title = "عنوان 2",
                Decription = "توضیحات مورد نظر شما2"
            });

            slider.AddSlide(new XamarinAwesomeBannerSlider.Entities.Slide()
            {
                Image = Resources.GetDrawable(Resource.Drawable.ic_test2),
                Title = "عنوان 3",
                Decription = "توضیحات مورد نظر شما3"
            });

            slider.AddSlide(new XamarinAwesomeBannerSlider.Entities.Slide()
            {
                Image = Resources.GetDrawable(Resource.Drawable.ic_test3),
                Title = "عنوان 3",
                Decription = "توضیحات مورد نظر شما3"
            });

            slider.StartTimer();

            var fontBYekan = Android.Graphics.Typeface.CreateFromAsset(Assets, "MyFonts/BYekan.ttf");
            var fontBYekanNormal = Android.Graphics.Typeface.CreateFromAsset(Assets, "MyFonts/BYekan_0.ttf");
            

            slider.ConfigSlide(new XamarinAwesomeBannerSlider.Entities.Config()
            {
                //DescriptionColor = Android.Graphics.Color.Aqua,
                //TitleColor = Android.Graphics.Color.Bisque,
                DescriptionTypeFace = fontBYekanNormal,
                TitleTypeFace = fontBYekanNormal
            });

        }
    }
}

