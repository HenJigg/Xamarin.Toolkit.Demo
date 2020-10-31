using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XamarinToolKit.Model;

namespace XamarinToolKit
{
    public class Constants
    {
        public static string DataBasePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "toolkitnew.db");
            }
        }

        public static async void DataBaseInitAsync(ToolkitContext context)
        {
            context.Database.EnsureCreated();
            if (!context.ToolkitMasters.Any())
            {
                await context.ToolkitMasters.AddRangeAsync(new Model.ToolkitMaster[]
                {
                     new ToolkitMaster(){ GroupIcon="\xe605", GroupName="钱包", GroupDesc="存储与金钱相关的账号密码..."},
                     new ToolkitMaster(){ GroupIcon="\xe720", GroupName="游戏", GroupDesc="存储与游戏相关的账号密码..."},
                     new ToolkitMaster(){ GroupIcon="\xe61c", GroupName="社区", GroupDesc="存储与社区相关的账号密码..."},
                     new ToolkitMaster(){ GroupIcon="\xe601", GroupName="企业", GroupDesc="存储与企业相关的账号密码..."},
                     new ToolkitMaster(){ GroupIcon="\xe611", GroupName="其它", GroupDesc="存储其它的的账号密码..."},
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
