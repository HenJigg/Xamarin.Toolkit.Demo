using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinToolKit.Interfaces;
using XamarinToolKit.Model;

namespace XamarinToolKit.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly IToolkitService service;
        public MainViewModel()
        {
            service = DependencyService.Get<IToolkitService>();
            SelectionChangedCommand = new RelayCommand<ToolkitMaster>(OpenDetail);
        }

        public RelayCommand<ToolkitMaster> SelectionChangedCommand { get; set; }

        private ObservableCollection<ToolkitMaster> gridModelList;

        /// <summary>
        /// 首页的分组列表
        /// </summary>
        public ObservableCollection<ToolkitMaster> GridModelList
        {
            get { return gridModelList; }
            set { gridModelList = value; RaisePropertyChanged(); }
        }

        async void OpenDetail(ToolkitMaster master)
        {
            if (master != null)
            {
                //设置我们分组当中所有的数据, 以便于打开详细页面的时候保存这个信息
                ToolkitInfo inf = new ToolkitInfo();
                inf.master = master;
                inf.details = new ObservableCollection<ToolkitDetail>();
                var result = await service.GetToolkitDetailsAsync(master.Id);
                result?.ForEach(item =>
                {
                    inf.details.Add(item);
                });
                Messenger.Default.Send(inf, "OpenDetailView");
            }
        }

        public async Task InitMasterDataAsync()
        {
            var result = await service.GetToolkitMaterListAsync();
            GridModelList = new ObservableCollection<ToolkitMaster>();
            result?.ForEach(item =>
            {
                GridModelList.Add(item);
            });
        }
    }
}
