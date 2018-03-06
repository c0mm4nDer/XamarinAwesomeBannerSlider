using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinAwesomeBannerSlider.Entities;
using XamarinAwesomeBannerSlider.Interfaces;
using Fragment =   Android.Support.V4.App.Fragment;

namespace XamarinAwesomeBannerSlider.Fragments
{
    public class FragmentTemplate : Fragment, IConfigoration
    {
        public Slide Slide;
        private Context mContext;

        private ImageView    mImgView;
       

        public event EventHandler<EventArgs> Clicked;

        public FragmentTemplate(Context context,Slide slide)
        {
            this.mContext = context;
            this.Slide = slide;
        }
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_template, container, false);

            mImgView= view.FindViewById<ImageView>(Resource.Id.imageView1);
            

            EvnetConfig();
            

            UpdateSlide();

            return view;
        }

        /// <summary>
        /// پیاده سازی رویداد ها. بعد از رویداد کلیک اکشن مورد نظر ران خواهد شد.تمام رویداد های اکشن یکسان خواهند داشت.
        /// </summary>
        public void EvnetConfig()
        {
            //رویداد کلیک روی عکس
            mImgView.Click += delegate { RunAction(); };

            
        }

        /// <summary>
        /// بروزرسانی متن عنوان و متن توضیحات بهم راه عکس
        /// </summary>
        private void UpdateSlide()
        {
            
            mImgView.SetImageDrawable(Slide.Image);
        }

        /// <summary>
        /// این متد برای اجرا Action در نظر گرفته شده در کلاس slide است. 
        /// </summary>
        public void RunAction()
        {
            try
            {
                Slide.Action();
            }
            catch
            {

            }
            
        }


        /// <summary>
        /// اعمال تنظمات از قبیل : فونت ، رنگ ، اندازه
        /// </summary>
        public void ConfigSlide(Entities.Config config)
        {
            
        }

        

    }
}