using ProyAppVangAPI.Core.Entities;
using ProyAppVangAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyAppVangAPI.Core.Services
{
    public class ListService : IListService
    {
        private readonly IRepository<Lista> _listRepository;

        public ListService(IRepository<Lista> listRepository)
        {
            _listRepository = listRepository;
        }

        public ServiceResult<Lista> AddItem(string item, int id)
        {
            var list = _listRepository.GetById(id);
            list.Items.Add(item);
            return ServiceResult<Lista>.SuccessResult(_listRepository.Update(list));
        }

        public ServiceResult<Lista> CleanList(int id)
        {
            var list = _listRepository.GetById(id);
            list.Items.Clear();
            return ServiceResult<Lista>.SuccessResult(_listRepository.Update(list));
        }

        public ServiceResult<Lista> Create(Lista list)
        {
            return ServiceResult<Lista>.SuccessResult(_listRepository.Create(list));
        }

        public ServiceResult<Lista> GetById(int id)
        {
            var list = _listRepository.GetById(id);
            return list != null
                ? ServiceResult<Lista>.SuccessResult(list)
                : ServiceResult<Lista>.NotFoundResult(
                    $"No se encontro la lista con el id {id}");
        }

        public ServiceResult<IEnumerable<Lista>> GetLists()
        {
            return ServiceResult<IEnumerable<Lista>>.SuccessResult(_listRepository.GetAll());
        }

        public ServiceResult<Lista> RemoveItem(string item, int id)
        {
            var list = _listRepository.GetById(id);
            list.Items.Remove(item);
            return ServiceResult<Lista>.SuccessResult(_listRepository.Update(list));
        }
    }
}
