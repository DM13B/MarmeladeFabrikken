using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Products
{
    internal static class ListMapper<toType>
    {
        public static List<toType> map<oldType>(List<oldType> list){
            List<toType> newList = new List<toType>();
            foreach(oldType ol in list){
                newList.Add(Mapper.DynamicMap<toType>(ol));
            }
            return newList;
        }
    }

}
