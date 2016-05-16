using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationeryWebS.Models
{
    public class Stationery
    {
        //public Stationery(string name,int id, int stock)
        //{
        //    this.id=id;
        //    this.name = name;
        //    this.stock = stock;
        //}

        public string name{get;set;}
        public int stock { get; set; }
        public string colour { get; set; }

        public static Dictionary<int, List<Stationery>> getDico(List<Stationery> list)
        {
            Dictionary<int, List<Stationery>> stationeriesDic = new Dictionary<int, List<Stationery>>();
            stationeriesDic.Add(0, list);
            return stationeriesDic;

        }
    }

     



}