using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class DirectionRepositoryFixture : AbstractRepositoryFixture<Direction>
    {
        public DirectionRepositoryFixture() :
            base(typeof(DirectionRepository))
        {
        }

        protected override void InitDatabase()
        {
            var entry = Context.Directions.Add(new Direction
                                               {
                                                   Name = "Test Direction",
                                                   Description = "Test Description"
                                               });
            EntityId = entry.Entity.DirectionId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }

    }
}