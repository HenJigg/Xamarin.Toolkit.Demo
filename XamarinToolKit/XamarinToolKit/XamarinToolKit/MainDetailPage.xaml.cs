using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinToolKit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDetailPage : ContentPage
    {
        public MainDetailPage()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, "OpenAddAccountView", OpenAddAccountView);
        }

        private async void OpenAddAccountView(string obj)
        {
            //负责打开新的页面, 编辑我们的数据
            //1.设置标题,
            //2.绑定一个上下文
            await Navigation.PushAsync(new AddAccountPage()
            {
                Title = obj,
                BindingContext = this.BindingContext
            });
        }
    }
}