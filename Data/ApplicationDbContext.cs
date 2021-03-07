using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PeopleBuyWebAPI.Models;

namespace PeopleBuyWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PeopleBuyWebAPI.Models.Login> Login { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.PhysicalPerson> PhysicalPerson { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.LegalPerson> LegalPerson { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.Localization> Localization { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.Category> Category { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.SubCategory> SubCategory { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.Image> Image { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.Favorite> Favorite { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.Assessment> Assessment { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.DailyOffer> DailyOffer { get; set; }
        public DbSet<PeopleBuyWebAPI.Models.Offer> Offer { get; set; }
    }
}
