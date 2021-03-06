﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.InheritanceModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Npgsql.EntityFrameworkCore.PostgreSQL.TestUtilities;

namespace Npgsql.EntityFrameworkCore.PostgreSQL.Query
{
    public class InheritanceQueryNpgsqlFixture : InheritanceQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory =>  NpgsqlTestStoreFactory.Instance;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

#pragma warning disable CS0618 // Type or member is obsolete
            modelBuilder.Entity<AnimalQuery>().HasNoKey().ToQuery(
                () => context.Set<AnimalQuery>().FromSqlRaw(@"SELECT * FROM ""Animals"""));
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
