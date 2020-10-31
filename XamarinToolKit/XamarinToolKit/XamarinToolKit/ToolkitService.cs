using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XamarinToolKit.Interfaces;
using XamarinToolKit.Model;

namespace XamarinToolKit
{
    public class ToolkitService : IToolkitService
    {
        public async Task<bool> AddToolkitDetail(ToolkitDetail detail)
        {
            App.Instance.ToolkitDetails.Add(detail);
            return await App.Instance.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteToolkitDetail(int id)
        {
            var detail = await App.Instance.ToolkitDetails.FirstOrDefaultAsync(t => Equals(t.Id, id));
            if (detail != null)
            {
                App.Instance.ToolkitDetails.Remove(detail);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<ToolkitDetail> GetToolkitDetailByIdAsync(int id)
        {
            return await App.Instance.ToolkitDetails.FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<List<ToolkitDetail>> GetToolkitDetailsAsync(int masterid)
        {
            return await App.Instance.ToolkitDetails.Where(t => t.MasterId == masterid).ToListAsync();
        }

        public async Task<ToolkitMaster> GetToolkitMasterByIdAsync(int id)
        {
           return await App.Instance.ToolkitMasters.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<ToolkitMaster>> GetToolkitMaterListAsync()
        {
            return await App.Instance.ToolkitMasters.ToListAsync();
        }

        public async Task<bool> UpdateToolkitDetail(ToolkitDetail detail)
        {
            var model = await App.Instance.ToolkitDetails.FirstOrDefaultAsync(t => t.Id == detail.Id);
            if(model!=null)
            {
                model.Name = detail.Name;
                model.Account = detail.Account;
                model.PassWord = detail.PassWord;
            }
            return await App.Instance.SaveChangesAsync() > 0;
        }
    }
}
