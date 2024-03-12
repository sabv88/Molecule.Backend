using Microsoft.EntityFrameworkCore;
using Molecule.Domain;
using Molecule.Persistence;

namespace Molecule.Tests.Common
{
    public class FloursContextFactory
    {
        public static Guid FlourAId = Guid.NewGuid();
        public static Guid FlourBId = Guid.NewGuid();

        public static Guid FlourIdForDelete = Guid.NewGuid();
        public static Guid FlourIdForUpdate = Guid.NewGuid();

        public static MoleculeDbContext Create()
        {
            var options = new DbContextOptionsBuilder<MoleculeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new MoleculeDbContext(options);
            context.Database.EnsureCreated();
            context.Flours.AddRange(
                new Flour
                {
                    Id = Guid.Parse("45492178-69F7-448A-96F5-7D4DDDB6F43F"),
                    Name = "Name1",
                },
                new Flour
                {
                    Id = Guid.Parse("A88661F1-5516-445E-8C28-BBC2549EDAB8"),
                    Name = "Name2",
                },
                new Flour
                {
                    Id = FlourIdForDelete,
                    Name = "Name3",
                },
                new Flour
                {
                    Id = FlourIdForUpdate,
                    Name = "Name4",
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(MoleculeDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
