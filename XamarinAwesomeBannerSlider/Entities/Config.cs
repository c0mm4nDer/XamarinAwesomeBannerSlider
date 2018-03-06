using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAwesomeBannerSlider.Entities
{
    public class Config
    {
        /// <summary>
        /// رنگ متن عنوان
        /// </summary>
        public Color? TitleColor { get; set; }

        /// <summary>
        /// رنگ متن توضیحات
        /// </summary>
        public Color? DescriptionColor { get; set; }

        /// <summary>
        /// فونت عنوان
        /// </summary>
        public Typeface TitleTypeFace { get; set; }

        /// <summary>
        /// فونت توضیحات
        /// </summary>
        public Typeface DescriptionTypeFace { get; set; }

        //public int TitleFontSize { get; set; }
        //public int DescriptionFontSize { get; set; }
    }
}