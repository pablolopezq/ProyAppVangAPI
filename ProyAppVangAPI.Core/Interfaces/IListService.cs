using ProyAppVangAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyAppVangAPI.Core.Interfaces
{
    public interface IListService
    {
        ServiceResult<Lista> Create(Lista list);

        ServiceResult<Lista> AddItem(string item, int id);

        ServiceResult<Lista> RemoveItem(string item, int id);

        ServiceResult<Lista> GetById(int id);

        ServiceResult<IEnumerable<Lista>> GetLists();

        ServiceResult<Lista> CleanList(int id);
    }
}
