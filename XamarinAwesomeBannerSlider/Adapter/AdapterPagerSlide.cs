using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Fragment = Android.Support.V4.App.Fragment;
using XamarinAwesomeBannerSlider.Fragments;

namespace XamarinAwesomeBannerSlider.Adapter
{
    class AdapterPagerSlide : FragmentPagerAdapter
    {
        List<FragmentTemplate> mSlides;
        public AdapterPagerSlide(FragmentManager fm , List<FragmentTemplate> slides) : base(fm)
        {
            mSlides = slides;
        }

        public void AddSlide(FragmentTemplate fragmentTemplate)
        {
            mSlides.Add(fragmentTemplate);
            NotifyDataSetChanged();
        }

        public override int Count
        {
            get { return mSlides.Count; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            //return (Fragment)mSlides[position];

            return mSlides[position];
        }
    }
}