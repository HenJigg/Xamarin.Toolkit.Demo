using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinToolKit.Model;

namespace XamarinToolKit.Interfaces
{
    public interface IToolkitService
    {
        Task<List<ToolkitMaster>> GetToolkitMaterListAsync();

        Task<ToolkitMaster> GetToolkitMasterByIdAsync(int id);

        Task<List<ToolkitDetail>> GetToolkitDetailsAsync(int masterid);

        Task<ToolkitDetail> GetToolkitDetailByIdAsync(int id);

        Task<bool> AddToolkitDetail(ToolkitDetail detail);

        Task<bool> UpdateToolkitDetail(ToolkitDetail detail);

        Task<bool> DeleteToolkitDetail(int id);
    }
}
