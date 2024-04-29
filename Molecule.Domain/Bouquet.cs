
namespace Molecule.Domain
{
    public class Bouquet
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Flour> Flours { get; set; } = new();

    }
}
