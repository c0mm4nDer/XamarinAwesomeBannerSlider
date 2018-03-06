using Android;
using Android.Content;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using XamarinAwesomeBannerSlider.Entities;
using XamarinAwesomeBannerSlider.Fragments;
using XamarinAwesomeBannerSlider.Interfaces;
using Fragment = Android.Support.V4.App.Fragment;

namespace XamarinAwesomeBannerSlider
{
    public class ImageAwesomeBanner: FrameLayout, IControlComponent,IConfigoration
    {
        FragmentViewPagerHandler mFragmentBaseView;
        Timer mTimer;

        public ImageAwesomeBanner(Context context) : base(context) {
            MakeView(context, null);
        }

        public ImageAwesomeBanner(Context context,IAttributeSet attrs) 
            : base(context, attrs) {
            MakeView(context, attrs);
        }

        public ImageAwesomeBanner(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr) {
            MakeView(context, attrs);
        }



        private void MakeView(Context context, IAttributeSet attrs)
        {
            View view = LayoutInflater.From(context).Inflate(Resource.Layout.view_banner, this, true);
            mTimer = new Timer(1000);
           mTimer.Elapsed += TimerTick;
           mTimer.Enabled = false;
           mTimer.Stop();


             mFragmentBaseView = new FragmentViewPagerHandler();
            ShowFragment(mFragmentBaseView);
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            ShowNext();
        }

        private void ShowFragment(Fragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }

            var trans = ((AppCompatActivity)Context).SupportFragmentManager.BeginTransaction();
            trans.Replace(Resource.Id.fragment_holder, fragment, "banner1");

            trans.AddToBackStack(null);

            trans.Commit();
        }

        public void AddSlide(Slide slide)
        {
            mFragmentBaseView.AddSlide(slide);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int GetTimer()
        {
            return mFragmentBaseView.GetTimer();
        }

        public void RemoveSlide(int position)
        {
            throw new NotImplementedException();
        }

        public void SetTimer(int miliseconed)
        {
            mFragmentBaseView.SetTimer(miliseconed);
        }

        public void ShowNext()
        {
            mFragmentBaseView.ShowNext();
        }

        public void ShowPriviuse()
        {
            throw new NotImplementedException();
        }

        public void StartTimer()
        {
            mFragmentBaseView.StartTimer();
        }

        public void StopTimer()
        {
            mFragmentBaseView.StopTimer();
        }

        public void ConfigSlide(Entities.Config config)
        {
            mFragmentBaseView.ConfigSlide(config);
        }
    }
}
