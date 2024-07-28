namespace JobOffers.Frontend.Domain.Models
{
    public class JobViewModel : Entity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public string? Image { get; set; }
        public int IdDomainJob { get; set; }
        public DomainJobViewModel? DomainJob { get; set; } 
        public ICollection<FavoriViewModel>? Favoris { get; set; }
    }
}
