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
    public partial class AddAccountPage : ContentPage
    {
        public AddAccountPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //从导航堆栈异步删除最新的 Xamarin.Forms.Page。
            await Navigation.PopAsync();
            //触发保存命令保存我们编辑的数据
            Messenger.Default.Send("", "SaveAccount");
        }
    }
}