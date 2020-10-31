using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinToolKit.ViewModel;

namespace XamarinToolKit
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm;
        MainDetailViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            //隐藏默认导航页的标题
            NavigationPage.SetHasNavigationBar(this, false);

            vm = new MainViewModel();
            viewModel = new MainDetailViewModel();
            this.BindingContext = vm;
            Messenger.Default.Register<ToolkitInfo>(this, "OpenDetailView", OpenDetailView);
        }

        async void OpenDetailView(ToolkitInfo obj)
        {
            //改变导航页的背景颜色
            (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex("#1E90FF");
            viewModel.ToolkitInfo = obj; //传递父子表相关的内容
            viewModel.GridModelDetailList = obj.details; //设置明细页的内容
            await Navigation.PushAsync(new MainDetailPage()
            {
                Title = obj.master.GroupName,
                BindingContext = viewModel
            });
            collectionView.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.InitMasterDataAsync();
        }
    }
}
