﻿using System.Web;
using System.Web.Mvc;

namespace Lab_29_ASP_DOT_NET_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
