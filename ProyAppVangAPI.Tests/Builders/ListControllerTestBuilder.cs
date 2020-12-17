using Moq;
using ProyAppVangAPI.Controllers;
using ProyAppVangAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyAppVangAPI.Tests.Builders
{
    public class ListControllerTestBuilder
    {
        public Mock<IListService> GetService()
        {
            return new Mock<IListService>();
        }

        public ListsController Build(IListService service)
        {
            return new ListsController(service);
        }
    }
}
