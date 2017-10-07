using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stack.DBContext.Entities
{
    public class AppUser :IdentityUser
    {
        public AppUser():base()
        {

        }
        public AppUser(string Username):
            base(Username)
        {

        }
    }
}