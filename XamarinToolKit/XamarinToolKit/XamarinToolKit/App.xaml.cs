using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToolKit.Interfaces;

namespace XamarinToolKit
{
    public partial class App : Application
    {
        public static ToolkitContext _context;

        /// <summary>
        /// App下面的一个全局的数据库上下文
        /// </summary>
        public static ToolkitContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new ToolkitContext(Constants.DataBasePath);
                }
                return _context;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IToolkitService, ToolkitService>();
            Constants.DataBaseInitAsync(Instance);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
