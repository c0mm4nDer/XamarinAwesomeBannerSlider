using System;
using Android.Graphics.Drawables;

namespace XamarinAwesomeBannerSlider.Entities
{
    public class Slide
    {
        public Drawable Image { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public Action Action { get; set; }
    }
}