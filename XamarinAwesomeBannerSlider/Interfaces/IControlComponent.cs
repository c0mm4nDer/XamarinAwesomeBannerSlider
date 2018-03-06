using XamarinAwesomeBannerSlider.Entities;

namespace XamarinAwesomeBannerSlider.Interfaces
{
    public interface IControlComponent
    {
        /// <summary>
        /// اضافه کردن اسلاید جدید
        /// </summary>
        /// <param name="slide"></param>
        void AddSlide(Slide slide);

        /// <summary>
        /// حذف اسلاید
        /// </summary>
        /// <param name="position"></param>
        void RemoveSlide(int position);


        /// <summary>
        /// پاک کردن تمام اسلاید ها
        /// </summary>
        void Clear();

        /// <summary>
        /// رفتن به اسلاید بعدی
        /// </summary>
        void ShowNext();

        /// <summary>
        /// رفتن به اسلاید قبلی
        /// </summary>
        void ShowPriviuse();

        /// <summary>
        /// شروع حرکت اسلاید ها
        /// </summary>
        void StartTimer();

        /// <summary>
        /// متوقف کردن حرکت اسلاید ها
        /// </summary>
        void StopTimer();

        /// <summary>
        /// تنظیم سرعت حرکت اسلایت ها
        /// </summary>
        /// <param name="miliseconed">زمان ورودی به میلی ثاینه</param>
        void SetTimer(int miliseconed);

        /// <summary>
        /// خواندن تامیر فعلی
        /// </summary>
        int GetTimer();
    }
}