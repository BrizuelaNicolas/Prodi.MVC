//// -----------------------------------------------------------------------
//// <copyright file="DbContextLocal.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
////-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Prodi.Core.Repository.Models;
/// This is a test file created by Fluent Infrastructure in order to 
/// illustrate its operation.
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
namespace Prodi.Core.Repository.DataBase
{
    public class DbContextLocal : DbContext
    {
        //public DbContextLocal() : base(@"Data Source=DESKTOP-U5SJSE4;Initial Catalog=ProDi.Core.Repository; Integrated Security = true;") { }

        public DbSet<Forum> Forum { get; set; }
    }
}