using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Animations.Views;

namespace XF.Animations
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _animationItems;

        #region INotifyPropertyChanged
        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public MainPageViewModel()
        {
            this.AnimationItems = new ObservableCollection<Item>
            {
                new Item(0,"Simply animation") {NavigationAction = NavigateList(0)},
                new Item(1,"Custom animation") {NavigationAction = NavigateList(1)},
                new Item(2,"Follow to cursor") {NavigationAction = NavigateList(2)}
            };

        }

        private Action NavigateList(int index)
        {
            switch (index)
            {
                case 0:
                    return () => Navigation.PushAsync(new SimpleAnimation());
                case 1:
                    return () => Navigation.PushAsync(new CustomAnimationPage());
                case 2:
                    return () => Navigation.PushAsync(new CursorFollowPage());
                default:
                    return null;
            }
        }

        public ObservableCollection<Item> AnimationItems
        {
            get => _animationItems;
            set
            {
                _animationItems = value;
                NotifyPropertyChanged(nameof(AnimationItems));
            }
        }

        public INavigation Navigation { get; set; }

        public string Title => "Animation";

    }

    #region Item model
    internal class Item
    {
        public int Item1 { get; set; }
        public string Item2 { get; set; }
        public ICommand ItemCommand { get; set; }
        public Action NavigationAction { get; set; }

        public Item(int item1, string item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            ItemCommand = new Command<int>(ItemClick);
        }

        private void ItemClick(int obj)
        {
            NavigationAction?.Invoke();
        }
    }
    #endregion
}
