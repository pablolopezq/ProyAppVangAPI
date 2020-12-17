using Xunit;
using ProyAppVangAPI.Core.Interfaces;
using ProyAppVangAPI.Core.Services;
using ProyAppVangAPI.Core.Entities;
using ProyAppVangAPI.Infrastructure.Repositories;
using ProyAppVangAPI.Infrastructure;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyAppVangAPI.Tests.Builders;
using ProyAppVangAPI.Core;

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
            var builder = new ListControllerTestBuilder();
            var service = builder.GetService();
            service.Setup(s => s.Create(mockList))
                .Returns(ServiceResult<Lista>.SuccessResult(new Lista
                {
                    Id = 1,
                    Name = "Lista1",
                    Items = new List<string>()
                }));
            var result = service.Object.Create(mockList);

            Assert.Equal(result.Result, mockList);
        }

        [Fact]
        public void AddItemTest()
        {
            var builder = new ListControllerTestBuilder();
            var service = builder.GetService();
            service.Setup(s => s.Create(mockList))
                .Returns(ServiceResult<Lista>.SuccessResult(new Lista
                {
                    Id = 1,
                    Name = "Lista1",
                    Items = new List<string>()
                }));

            service.Object.Create(mockList);
            var result = service.Object.AddItem("flour", 1);

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
            var builder = new ListControllerTestBuilder();
            var service = builder.GetService();
            service.Setup(s => s.Create(mockList))
                .Returns(ServiceResult<Lista>.SuccessResult(new Lista
                {
                    Id = 1,
                    Name = "Lista1",
                    Items = new List<string>()
                }));

            service.Object.Create(mockList);
            var result = service.Object.AddItem("flour", 1);

            var l = new List<string>();
            l.Add("flour");
            var comp = new Lista
            {
                Id = 1,
                Name = "Lista1",
                Items = l
            };

            Assert.Equal(result.Result, comp);

            result = service.Object.RemoveItem("flour", 1);
            Assert.Equal(result.Result, mockList);
        }

        [Fact]
        public void ClearListTest()
        {
            var builder = new ListControllerTestBuilder();
            var service = builder.GetService();
            service.Setup(s => s.Create(mockList))
                .Returns(ServiceResult<Lista>.SuccessResult(new Lista
                {
                    Id = 1,
                    Name = "Lista1",
                    Items = new List<string>()
                }));

            service.Object.Create(mockList);
            var result = service.Object.AddItem("flour", 1);

            var l = new List<string>();
            l.Add("flour");
            var comp = new Lista
            {
                Id = 1,
                Name = "Lista1",
                Items = l
            };

            Assert.Equal(result.Result, comp);

            result = service.Object.CleanList(1);
            Assert.Equal(result.Result, mockList);
        }
    }
}
