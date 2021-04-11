using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteBank.Forum.Models
{
    public class UsuarioAplicacao :IdentityUser
    {
        public string NomeCompleto { get; set; }
    }
}
