using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StationeryWebS.Models;

namespace StationeryWebS.Controllers
{
    public class StationeryController : ApiController
    {
        static int control = 0;//to init dictionary then inc to prevent init and use again

        List<Stationery> stationeries = new List<Stationery>()
        {
            new Stationery { name="pencil",stock=5,colour="red"},
            new Stationery { name="ruler",stock=4,colour="blue"}
        };
        static Dictionary<int, List<Stationery>> stationeriesDic;
        

        public HttpResponseMessage Get()
        {
            if (control == 0)
            {
                stationeriesDic = Stationery.getDico(stationeries);
                control++;
            }
           

            return  Request.CreateResponse(HttpStatusCode.OK, stationeriesDic[0]);
        }

        public HttpResponseMessage Get(string name)
        {
            if (control == 0)
            {
                stationeriesDic = Stationery.getDico(stationeries);
                control++;
            }
            List<Stationery> l = stationeriesDic[0];

            //can be used to search for color also

            foreach (Stationery s in l)
            {
                if (s.name == name)
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                if (s.colour == name)
                    return Request.CreateResponse(HttpStatusCode.OK, s); ;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }


        public HttpResponseMessage Get(string name, int stock)
        {
            if (control == 0)
            {
                stationeriesDic = Stationery.getDico(stationeries);
                control++;
            }
            List<Stationery> l = stationeriesDic[0];

            //name or colour and stock
            foreach (Stationery s in l)
            {
                if ((s.name == name || s.colour == name) && s.stock == stock)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Get(string name, string colour)
        {
            if (control == 0)
            {
                stationeriesDic = Stationery.getDico(stationeries);
                control++;
            }
            List<Stationery> l = stationeriesDic[0];

            //name and colour
            foreach (Stationery s in l)
            {
                if (s.name == name && s.colour == colour)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        //public string Post(Stationery sta)
        public HttpResponseMessage Post(Stationery sta)
        {
            if (control == 0)
            {
                stationeriesDic = Stationery.getDico(stationeries);
                control++;
            }
            List<Stationery> l = stationeriesDic[0];

            foreach (Stationery s in l)
            {
                if (s.name == sta.name)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            stationeriesDic[0].Add(sta);

            return Request.CreateResponse(HttpStatusCode.OK, stationeriesDic[0]);
        }

        
        public HttpResponseMessage Put(string name = "", int stock = 0)
        {
            if (control == 0)
            {
                stationeriesDic = Stationery.getDico(stationeries);
                control++;
            }
            List<Stationery> l = stationeriesDic[0];

            foreach (Stationery s in l)
            {
                if (s.name == name)
                    s.stock = stock;

            }

            return Request.CreateResponse(HttpStatusCode.OK, stationeriesDic[0]);
        }

        
        public HttpResponseMessage Delete(string name)
        {
            if (control == 0)
            {
                stationeriesDic = Stationery.getDico(stationeries);
                control++;
            }
            List<Stationery> l = stationeriesDic[0];

            foreach (Stationery s in l)
            {
                if (s.name == name)
                {
                    stationeriesDic[0].Remove(s);
                    break;
                }

            }

            return Request.CreateResponse(HttpStatusCode.OK, stationeriesDic[0]);
        }

    }
}
