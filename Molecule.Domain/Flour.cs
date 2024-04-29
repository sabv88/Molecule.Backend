namespace Molecule.Domain
{
    public class Flour
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Bouquet> Bouquets { get; set; } = new();

    }
}
