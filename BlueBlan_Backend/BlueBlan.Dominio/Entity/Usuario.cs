using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBlan.Dominio.Entity
{
    public class User:  IdentityUser
    {
        public string Name { get; set; }
    }
}
