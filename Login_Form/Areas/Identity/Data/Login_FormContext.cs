using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login_Form.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login_Form.Data
{
    public class Login_FormContext : IdentityDbContext<Login_FormUser>
    {
        public Login_FormContext(DbContextOptions<Login_FormContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
