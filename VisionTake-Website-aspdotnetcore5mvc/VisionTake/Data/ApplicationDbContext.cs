using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VisionTake.Entities;

namespace VisionTake.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<TagNews> TagNewses { get; set; }
        public DbSet<TblAbout> TblAbouts { get; set; }
        public DbSet<TblCategory> TblCategories { get; set; }
        public DbSet<TblEvent> TblEvent { get; set; }
        public DbSet<TblNews> TblNewses { get; set; }
        public DbSet<TblPatent> TblPatents { get; set; }
        public DbSet<TblPartner> TblPartners { get; set; }
        public DbSet<TblProduct> TblProducts { get; set; }
        public DbSet<TblSubCategory> TblSubCategories { get; set; }
        public DbSet<TblTag> TblTags { get; set; }
        public DbSet<TblSlider> TblSliders { get; set; }
        public DbSet<TblContact> TblContacts { get; set; }
        public DbSet<TblAddress> TblAddresses { get; set; }
        public DbSet<TblReview> TblReviews { get; set; }
        public DbSet<TblTeam> TblTeams { get; set; }
        public DbSet<TblVision> TblVisions { get; set; }
        public DbSet<TblMission> TblMissions { get; set; }
        public DbSet<TblGallery> TblGallerys { get; set; }
        public DbSet<TblService> TblServices { get; set; }
        public DbSet<TblPartnerCategory> TblPartnerCategories { get; set; }
        public DbSet<TblUser> TblUsers { get; set; }
        public DbSet<TblSubscribe> TblSubscribes { get; set; }
    }
}
