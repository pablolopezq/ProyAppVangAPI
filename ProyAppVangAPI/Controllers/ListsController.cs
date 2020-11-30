using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyAppVangAPI.Core.Enums;
using ProyAppVangAPI.Core.Interfaces;
using ProyAppVangAPI.Models;

namespace ProyAppVangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly IListService _listService;

        public ListsController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListDto>> Get()
        {
            var serviceResult = _listService.GetLists();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(serviceResult.Result.Select(l => new ListDto
            {
                Id = l.Id,
                Items = l.Items,
                Name = l.Name
            }));
        }

        [HttpGet]
        [Route("{listId}")]
        public ActionResult<ListDto> Get(int listId)
        {
            var serviceResult = _listService.GetById(listId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var list = serviceResult.Result;
            return Ok(new ListDto
            {
                Name = list.Name,
                Id = list.Id,
                Items = list.Items
            });
        }

        [HttpPut]
        [Route("{listId}/add/{item}")]
        public ActionResult<ListDto> AddItem(int listId, string item)
        {
            var serviceResult = _listService.AddItem(item, listId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var list = serviceResult.Result;
            return Ok(new ListDto
            {
                Name = list.Name,
                Id = list.Id,
                Items = list.Items
            });
        }

        [HttpPut]
        [Route("{listId}/remove/{item}")]
        public ActionResult<ListDto> RemoveItem(int listId, string item)
        {
            var serviceResult = _listService.RemoveItem(item, listId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var list = serviceResult.Result;
            return Ok(new ListDto
            {
                Name = list.Name,
                Id = list.Id,
                Items = list.Items
            });
        }

        [HttpPut]
        [Route("{listId}/clean")]
        public ActionResult<ListDto> CleanList(int listId)
        {
            var serviceResult = _listService.CleanList(listId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var list = serviceResult.Result;
            return Ok(new ListDto
            {
                Name = list.Name,
                Id = list.Id,
                Items = list.Items
            });
        }
    }
}
