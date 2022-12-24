using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class DirectionRepositoryFixture : AbstractRepositoryFixture<DirectionRepository>
    {
        public int NewDirectionId { get; set; }

        protected override DirectionRepository CreateRepository()
        {
            return new(Context);
        }

        protected override async void InitDb()
        {
            NewDirectionId = (await Context.Directions.AddAsync(new Direction()
                                                                   {
                                                                       Name = "Direction Name",
                                                                       Description = "Direction Description"
                                                                   })).Entity.DirectionId;
            await Context.SaveChangesAsync();
        }
    }
}