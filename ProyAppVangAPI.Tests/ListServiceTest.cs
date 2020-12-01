using Xunit;
using ProyAppVangAPI.Core.Interfaces;
using ProyAppVangAPI.Core.Services;
using ProyAppVangAPI.Core.Entities;
using ProyAppVangAPI.Infrastructure.Repositories;
using ProyAppVangAPI.Infrastructure;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyAppVangAPI.Tests
{
    public class ListServiceTest
    {
        private readonly Lista mockList = new Lista
        {
            Id = 1,
            Name = "Lista1",
            Items = new List<string>()
        };

        [Fact]
        public void CreateTest()
        {
            DbContextOptions options;
            ProyAppVangAPIDbContext context = new ProyAppVangAPIDbContext(options);
            IRepository<Lista> repository = new EntityFrameworkRepository<Lista>(context);
            IListService service = new ListService(repository);

            var result = service.Create(mockList);

            Assert.Equal(result.Result, mockList);
        }

        [Fact]
        public void AddItemTest()
        {
            DbContextOptions options;
            ProyAppVangAPIDbContext context = new ProyAppVangAPIDbContext(options);
            IRepository<Lista> repository = new EntityFrameworkRepository<Lista>(context);
            IListService service = new ListService(repository);

            service.Create(mockList);
            var result = service.AddItem("flour", 1);

            var l = new List<string>();
            l.Add("flour");
            var comp = new Lista
            {
                Id = 1,
                Name = "Lista1",
                Items = l
            };

            Assert.Equal(result.Result, comp);
        }

        [Fact]
        public void DeleteItemTest()
        {
            DbContextOptions options;
            ProyAppVangAPIDbContext context = new ProyAppVangAPIDbContext(options);
            IRepository<Lista> repository = new EntityFrameworkRepository<Lista>(context);
            IListService service = new ListService(repository);

            service.Create(mockList);
            var result = service.AddItem("flour", 1);

            var l = new List<string>();
            l.Add("flour");
            var comp = new Lista
            {
                Id = 1,
                Name = "Lista1",
                Items = l
            };

            Assert.Equal(result.Result, comp);

            result = service.RemoveItem("flour", 1);
            Assert.Equal(result.Result, mockList);
        }

        [Fact]
        public void ClearListTest()
        {
            DbContextOptions options;
            ProyAppVangAPIDbContext context = new ProyAppVangAPIDbContext(options);
            IRepository<Lista> repository = new EntityFrameworkRepository<Lista>(context);
            IListService service = new ListService(repository);

            service.Create(mockList);
            var result = service.AddItem("flour", 1);

            var l = new List<string>();
            l.Add("flour");
            var comp = new Lista
            {
                Id = 1,
                Name = "Lista1",
                Items = l
            };

            Assert.Equal(result.Result, comp);

            result = service.CleanList(1);
            Assert.Equal(result.Result, mockList);
        }
    }
}
