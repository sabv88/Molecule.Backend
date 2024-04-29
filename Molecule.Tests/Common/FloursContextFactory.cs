using Microsoft.EntityFrameworkCore;
using Molecule.Domain;
using Molecule.Persistence;

namespace Molecule.Tests.Common
{
    public class MoleculeContextFactory
    {
        public static Guid FlourAId = Guid.NewGuid();
        public static Guid FlourBId = Guid.NewGuid();
        public static Guid FlourIdForDelete = Guid.NewGuid();
        public static Guid FlourIdForUpdate = Guid.NewGuid();

        public static Guid BouquetAId = Guid.NewGuid();
        public static Guid BouquetBId = Guid.NewGuid();
        public static Guid BouquetIdForDelete = Guid.NewGuid();
        public static Guid BouquetIdForUpdate = Guid.NewGuid();

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

            context.Bouquets.AddRange(
                new Bouquet
                {
                    Id = Guid.Parse("0078E21D-B9B7-47F8-9B8D-9D38F694C5B3"),
                    Title = "Title1",
                    Description = "Description 1",
                    Flours = context.Flours.ToList()
                },
                new Bouquet
                {
                    Id = Guid.Parse("AC2818E0-FF27-46D7-9183-CC2D39E3130F"),
                    Title = "Title2",
                    Description = "Description 2",
                },
                new Bouquet
                {
                    Id = BouquetIdForDelete,
                    Title = "Title3",
                    Description = "Description 3",
                },
                new Bouquet
                {
                    Id = BouquetIdForUpdate,
                    Title = "Title4",
                    Description = "Description 4",
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
