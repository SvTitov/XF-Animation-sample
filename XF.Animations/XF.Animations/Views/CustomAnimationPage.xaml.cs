using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Animations.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomAnimationPage : ContentPage
	{
        Animation _animation;
        bool _isAnimPlay;
        public CustomAnimationPage ()
		{
			InitializeComponent ();

            Task.Factory.StartNew(AfterLoad);
		}

        private  void AfterLoad()
        {
            _animation = new Animation
            {
                // time in animation (0..1)
                { 0, 0.5, new Animation(callback => _img.Rotation = callback, 0, 360) },
                { 0, 0.5, new Animation(callback => _img.Scale = callback , 2, 1) },
                { 0.5, 1, new Animation(callback => _img.Scale = callback, 1, 2)},
                { 0.5, 1, new Animation(callback => _img.Rotation = callback, 360, 0)}
            };

            CommitAnimation();
        }

        private void CommitAnimation()
        {
            _animation.Commit(this, "ctnm", 16, 3000, Easing.Linear, (v, c) =>
            {
                //new Animation(callback: d => _img.Scale = d, start: 1, end: 2, easing: Easing.Linear)
                //    .Commit(_img, "Update", 16, 2000, Easing.Linear, null, () => true);
            }, () => true);
            _isAnimPlay = true;
        }

        private void StopAnimation()
        {
            this.AbortAnimation("ctnm");
            _isAnimPlay = false;
        }

        protected override bool OnBackButtonPressed()
        {
            StopAnimation();
            return base.OnBackButtonPressed();
        }

        void OnImageTapped(object sender, EventArgs args)
        {
            if (_isAnimPlay)
                StopAnimation();
            else
                CommitAnimation();
        }
    }
}