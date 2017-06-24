using App.Data.Common.Contracts;
using App.Data.Models;
using App.Services.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Services.Data.Common
{
    //public class FolderService : BaseDataService<Folder>, IFolderService
    //{
    //    private readonly IRepository<Folder> folder;

    //    public FolderService(IRepository<Folder> folder)
    //        :base(folder)
    //    {
    //        this.folder = folder;
    //    }

    //   public Folder GetRootFolder()
    //    {
    //        return folder.All.SingleOrDefault(f => f.Parent == null);
    //    }

    //    public IEnumerable<Folder> Folders(Folder parent)
    //    {
    //        return parent == null ? new Folder[] { } : parent.ChildFolders.Select(f => new Folder { Name = f.Name });
    //    }

    //    public IEnumerable<Folder> Folders(string path)
    //    {
    //        return Folders(GetFolderByPath(path));
    //    }

    //    public Folder GetFolderByPath(string path)
    //    {
    //        if (string.IsNullOrEmpty(path) || path == "/")
    //        {
    //            return GetRootFolder();
    //        }

    //        var name = GetFolderNames(path).Last().ToLower();

    //        if (!path.StartsWith("/"))
    //        {
    //            path = "/" + path;
    //        }

    //        path = NormalizePath(path, name);

    //        return folder.All.FirstOrDefault(f => f.Path.ToLower() == path && f.Name.ToLower() == name);
    //    }

    //    private string NormalizePath(string path, string name)
    //    {
    //        path = VirtualPathUtility.AppendTrailingSlash(path).Replace("\\", "/").ToLower();
    //        path = path.Remove(path.LastIndexOf(name));
    //        return path;
    //    }

    //    private IEnumerable<string> GetFolderNames(string path)
    //    {
    //        return path.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar },
    //                          StringSplitOptions.RemoveEmptyEntries);
    //    }
    //}
}
