using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Viewpagerindicator;
using XamarinAwesomeBannerSlider.Adapter;
using XamarinAwesomeBannerSlider.Entities;
using XamarinAwesomeBannerSlider.Interfaces;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace XamarinAwesomeBannerSlider.Fragments
{
    class FragmentViewPagerHandler : Fragment, IConfigoration, IControlComponent, Android.Support.V4.View.ViewPager.IOnPageChangeListener
    {
        public ViewPager mPager;
        public static AdapterPagerSlide mAdapter;
        public IPageIndicator mIndicator;

        private int mCurrentPosition;
        private int mScrollState;

        private List<FragmentTemplate> mSlides = new List<FragmentTemplate>();

        private TextView     mTvTitle;
        private TextView     mTvDiscription;

        //Animation
        Animation mAnimationLTR;
        Animation mAnimationRTL;

        //TextView Contanier
        LinearLayout mContainer;

        //Timer For Auto Slider
        Timer mTimer = new Timer(5000);

        //اخرین ایندکس برای رفتن به صفحه بعدی
        int priviuesIndex = 0;

        //برای ثبت تغییرات لازم
        Entities.Config mConfig = null;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
            mTimer.Elapsed += TimerTick;
           // mTimer.Enabled = true;
           // mTimer.Stop();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_base_view, container, false);

            init(view);

            return view;
        }

        void init(View view)
        {
            mContainer = view.FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            mTvTitle= view.FindViewById<TextView>(Resource.Id.textView1);
            mTvDiscription = view.FindViewById<TextView>(Resource.Id.textView2);

            mAnimationLTR = AnimationUtils.LoadAnimation(Activity,Resource.Animation.left_to_right);
            mAnimationRTL = AnimationUtils.LoadAnimation(Activity, Resource.Animation.right_to_left);

            // رویداد کلیک روی عنوان
            mTvTitle.Click += delegate { RunAction(); };

            //رویداد کلیک روی توضیحات عکس
            mTvDiscription.Click += delegate { RunAction(); };


            mAdapter = new AdapterPagerSlide(Activity.SupportFragmentManager, mSlides);

            mPager = view.FindViewById<ViewPager>(Resource.Id.pager);
            mPager.Adapter = mAdapter;
            mPager.AddOnPageChangeListener(this);

            

            CirclePageIndicator indicator = view.FindViewById<CirclePageIndicator>(Resource.Id.indicator);
            mIndicator = indicator;
            indicator.SetViewPager(mPager);
            indicator.SetBackgroundColor(Android.Graphics.Color.Transparent);

            SetConfig(mConfig);
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            ShowNext();
        }

        public void OnPageSelected(int position)
        {
            
            mCurrentPosition = position;

            ShowContainer();
        }

        enum CurrentShowTextContainer
        {
            Show,
            Hide
        }

        CurrentShowTextContainer ContainerState= CurrentShowTextContainer.Show;
        public void OnPageScrollStateChanged(int state)
        {
            StopTimer();

            handleScrollState(state);
            mScrollState = state;

            if (ContainerState == CurrentShowTextContainer.Show)
            {
                mContainer.StartAnimation(mAnimationLTR);
                ContainerState = CurrentShowTextContainer.Hide;
            }

            
        }

        void ShowContainer()
        {
            new Handler().PostDelayed(delegate {
                Activity.RunOnUiThread(delegate {
                    if (ContainerState == CurrentShowTextContainer.Hide)
                    {
                        
                        var slide = mSlides[mCurrentPosition].Slide;
                        mTvTitle.Text = slide.Title;
                        mTvDiscription.Text = slide.Decription;
                        mContainer.StartAnimation(mAnimationRTL);
                        ContainerState = CurrentShowTextContainer.Show;
                        StartTimer();
                    }
                });
            }, 1000);
        }
        private void handleScrollState( int state)
        {
            if (state == ViewPager.ScrollStateIdle)
            {
                if(mCurrentPosition == mPager.CurrentItem)
                {
                    priviuesIndex = mCurrentPosition;
                    //priviuesIndex--;
                    ShowContainer();
                }
                //setNextItemIfNeeded();
            }
        }

        private void setNextItemIfNeeded()
        {
            if (!isScrollStateSettling())
            {
                handleSetNextItem();
            }
        }

        private Boolean isScrollStateSettling()
        {
            return mScrollState == ViewPager.ScrollStateSettling;
        }

        private void handleSetNextItem()
        {
            int lastPosition = mPager.Adapter.Count - 1;
            if (mCurrentPosition == 0)
            {
                mPager.Post(delegate { mPager.SetCurrentItem(lastPosition, true); });
            }
            else if (mCurrentPosition == lastPosition)
            {
                mPager.Post(delegate { mPager.SetCurrentItem(0, true); });
            }
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            if (OnFirstTime)
            {
                var slide = mSlides[position].Slide;
                mTvTitle.Text = slide.Title;
                mTvDiscription.Text = slide.Decription;
                OnFirstTime = false;
            }
            
        }

        bool OnFirstTime = true;

        /// <summary>
        /// اضافه کردن اسلاید جدید
        /// </summary>
        /// <param name="slide"></param>
        public void AddSlide(Slide slide)
        {
            try
            {
                
                var fragment = new FragmentTemplate(Activity, slide);
                mSlides.Add(fragment);
                mAdapter.AddSlide(fragment);
            }
            catch { }
            
        }


        public void RemoveSlide(int position)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        
        /// <summary>
        /// رفتن به اسلاید بعدی
        /// </summary>
        public void ShowNext()
        {
                try
            {

                int pos = mPager.CurrentItem;
                if (pos < (priviuesIndex - 1) || (pos > priviuesIndex && pos != mSlides.Count - 1))
                {
                    priviuesIndex = pos;
                    priviuesIndex++;
                }
                mPager.Post(delegate { mPager.SetCurrentItem(priviuesIndex, true); });

                priviuesIndex++;
                if (priviuesIndex >= mSlides.Count)
                    priviuesIndex = 0;
            }
            catch
            {

            }
        }

        public void ShowPriviuse()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// شروع تایمر برای تغییر خودکار اسلاید ها
        /// </summary>
        public void StartTimer()
        {
                
                mTimer.Enabled = true;
                mTimer.Start();
                
            
        }


        /// <summary>
        /// متوقف سازی تایمیر برای تغییر خودکار اسلاید ها
        /// </summary>
        public void StopTimer()
        {
            mTimer.Stop();
            mTimer.Enabled = false;
        }

        /// <summary>
        /// تغییر سرعت حرکت
        /// </summary>
        /// <param name="miliseconed"> min = 5000 </param>
        public void SetTimer(int miliseconed)
        {
            if (miliseconed < 5000)
                miliseconed = 5000;

            mTimer.Interval = miliseconed;
        }

        public int GetTimer()
        {
            return (int)mTimer.Interval;
        }

        /// <summary>
        /// این متد برای اجرا Action در نظر گرفته شده در کلاس slide است. 
        /// </summary>
        public void RunAction()
        {
            try
            {
                mSlides[mCurrentPosition].Slide.Action();
            }
            catch
            {

            }

        }

        
        public void ConfigSlide(Entities.Config config)
        {
            mConfig = config;
        }

        private void SetConfig(Entities.Config config)
        {
            if (config == null)
                return;

            mTvTitle.SetTextColor(config.TitleColor ?? Android.Graphics.Color.White);
            mTvDiscription.SetTextColor(config.DescriptionColor ?? Android.Graphics.Color.White);

            if (config.TitleTypeFace != null)
                mTvTitle.Typeface = config.TitleTypeFace;
            if (config.DescriptionTypeFace != null)
                mTvDiscription.Typeface = config.DescriptionTypeFace;
        }
    }
}