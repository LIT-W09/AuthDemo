using AuthDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo.Web.Models
{
    public class HomePageViewModel
    {
        public bool IsAuthenticated { get; set; }
        public User CurrentUser { get; set; }
    }
}
