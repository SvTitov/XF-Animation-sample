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
	public partial class SimpleAnimation : ContentPage
	{
		public SimpleAnimation ()
		{
			InitializeComponent ();

            Task.Factory.StartNew(AfterLoading);
		}

        private async void AfterLoading()
        {
            await InitAbsoluteLayout();
            await InitStackLayout();
        }

        private async Task InitStackLayout()
        {
            await Task.WhenAll
                (
                    _img.RotateTo(180, 1000),

                    _img2.RelRotateTo(180, 1000),

                    _img3.ScaleTo(0.3, 500, Easing.Linear),

                    _img.TranslateTo(100, 100, 1000)
                );
        }

        private async Task InitAbsoluteLayout()
        {
            Image image = new Image()
            {
                Source = "fallout.png",
                HeightRequest = 50,
                WidthRequest = 50,
                Opacity = 0,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            Image image2 = new Image()
            {
                Source = "fallout.png",
                HeightRequest = 50,
                WidthRequest = 50,
                Opacity = 0,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            Image image3 = new Image()
            {
                Source = "fallout.png",
                HeightRequest = 50,
                WidthRequest = 50,
                Opacity = 0,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            Device.BeginInvokeOnMainThread(()=> 
            {
                _panel.Children.Add(image);
                _panel.Children.Add(image2);
                _panel.Children.Add(image3);
            });

            var screenWidth = Application.Current.MainPage.Width;
            var cellWidth = (int)(screenWidth / 3);
            var cellCenter = cellWidth / 2;
            var inc = cellCenter;
            const int time = 500;


            await Task.WhenAll
                (
                    image.TranslateTo(inc - (image.WidthRequest / 2), image.Y, time),
                    image.FadeTo(1, time)
                );
            inc += cellWidth;

            await Task.WhenAll
                (
                    image2.TranslateTo(inc - (image2.WidthRequest / 2), image2.Y, time * 2),
                    image2.FadeTo(1, time * 2)
                );
            inc += cellWidth;


            await Task.WhenAll
                (
                    image3.TranslateTo(inc - (image3.WidthRequest / 2), image3.Y, time * 3),
                    image3.FadeTo(1, time * 3)
                );
        }
    }
}