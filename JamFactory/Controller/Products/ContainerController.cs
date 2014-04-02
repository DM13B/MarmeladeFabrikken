using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Products;
using Common.Interfaces;
using DataAccess.Products.Entities;
using Model.Products;
using AutoMapper;
namespace Controller.Products
{
    public class ContainerController
    {
        ContainerDataAccess dataAccess;
        public ContainerController()
        {
            dataAccess = new ContainerDataAccess();
        }

        public IContainer GetContainerById(int id)
        {
            ContainerEntity entity = dataAccess.GetContainerById(id);
            Container container = Mapper.DynamicMap<Container>(entity);
            return container as IContainer;    
        }

        public IContainer SaveContainer(IContainer icontainer)
        {
            var containerEntity = Mapper.DynamicMap<ContainerEntity>(icontainer);
            Container container = Mapper.DynamicMap<Container>(dataAccess.CreateContainer(containerEntity));
            return container as IContainer;      
        }
        public List<IContainer> GetAllContainers()
        {
            List<ContainerEntity> entities = dataAccess.GetAllContainers();
            List<Container> containerList = ListMapper<Container>.map<ContainerEntity>(entities);
            return containerList.Cast<IContainer>().ToList();    
        }
        public IContainer NewContainer()
        {
            return new Container() as IContainer;
        }
    }
}
