using EpedimiologicReport.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpedimiologicReport.Dal.Models;

public class CoronaContext: DbContext
{
    public CoronaContext()
    {
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source = localhost\sqlexpress; Initial Catalog = ReportsCorona; Integrated Security = True");
    }
}
