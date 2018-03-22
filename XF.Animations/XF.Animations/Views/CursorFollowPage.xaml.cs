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
	public partial class CursorFollowPage : ContentPage
	{
		public CursorFollowPage ()
		{
			InitializeComponent ();
		}

        private async void OnPanUpdated(object s, PanUpdatedEventArgs args)
        {
            Console.WriteLine(args.TotalX + "  " + args.TotalY);
            await _ball.TranslateTo(args.TotalX, args.TotalY, 500, Easing.Linear);
        }
    }
}