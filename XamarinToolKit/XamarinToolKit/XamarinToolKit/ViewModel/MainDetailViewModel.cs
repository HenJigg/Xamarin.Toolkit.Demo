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
    public class MainDetailViewModel : ViewModelBase
    {
        public MainDetailViewModel()
        {
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand<int>(Edit);
            DeleteCommand = new RelayCommand<int>(Delete);
            service = DependencyService.Get<IToolkitService>();
            Messenger.Default.Register<string>(this, "SaveAccount", Save);
        }

        #region 属性

        private ToolkitInfo toolkitInfo;

        public ToolkitInfo ToolkitInfo
        {
            get { return toolkitInfo; }
            set { toolkitInfo = value; }
        }

        private ObservableCollection<ToolkitDetail> gridModelDetailList;

        public ObservableCollection<ToolkitDetail> GridModelDetailList
        {
            get { return gridModelDetailList; }
            set { gridModelDetailList = value; RaisePropertyChanged(); }
        }

        private ToolkitDetail toolkitDetail;

        /// <summary>
        /// 绑定新增或者编辑的数据 (当前页面编辑或者删除的内容)
        /// </summary>
        public ToolkitDetail ToolkitDetail
        {
            get { return toolkitDetail; }
            set { toolkitDetail = value; RaisePropertyChanged(); }
        }

        #endregion

        #region 新增/编辑/删除

        public RelayCommand AddCommand { get; set; }
        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand<int> DeleteCommand { get; set; }

        #endregion


        private IToolkitService service;

        private void Add()
        {
            ToolkitDetail = new ToolkitDetail();
            ToolkitDetail.MasterId = ToolkitInfo.master.Id;
            Messenger.Default.Send("新建账号", "OpenAddAccountView");
        }

        async void Delete(int id)
        {
            var r = await App.Current.MainPage.DisplayAlert("警告", "确认删除该账号?", "确定", "取消");
            if (!r) return;

            //删除当前账号
            await service.DeleteToolkitDetail(id);
            await UpdateGridList();
        }

        async void Edit(int id)
        {
            ToolkitDetail = await service.GetToolkitDetailByIdAsync(id);
            Messenger.Default.Send("编辑账号", "OpenAddAccountView");
        }

        private async void Save(string obj)
        {
            if (ToolkitDetail.Id > 0)
                await service.UpdateToolkitDetail(ToolkitDetail);
            else
                await service.AddToolkitDetail(ToolkitDetail);

            await UpdateGridList();
        }

        /// <summary>
        /// 根据主表ID刷新明细页面的数据
        /// </summary>
        /// <returns></returns>
        async Task UpdateGridList()
        {
            var result = await service.GetToolkitDetailsAsync(ToolkitInfo.master.Id);
            GridModelDetailList = new ObservableCollection<ToolkitDetail>();
            result?.ForEach(item =>
            {
                GridModelDetailList.Add(item);
            });
        }
    }
}
