﻿using Kindr.Models;
using Nancy;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace Kindr.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule() : base("/")
        {
            Get["/"] = x => GetHome();
            Get["/business_login"] = x => GetBusinessLogin();
            Get["/charity_details/{id}"] = x => GetCharityDetails(x.id);
        }

        public dynamic GetHome()
        {
            return this.View["Home"];
        }

        public dynamic GetBusinessLogin()
        {
            return this.View["BusinessLogin"];
        }

        public dynamic GetCharityDetails(int id)
        {
            var model = GetResultsData(id);
            return this.View["CharityDetails"].WithModel(model);
        }

        private CharityModel GetResultsData(int id)
        {
            var charities = (IList<CharityModel>)HttpContext.Current.Application["CharityModels"];
            var charity = charities.FirstOrDefault(e => e.Id == id);
            return charity;
        }
    }
}