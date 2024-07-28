namespace JobOffers.Frontend.Domain.Models
{
    public class DomainJobViewModel : Entity
    {
        public string? Domain { get; set; }
        public ICollection<JobViewModel>? Jobs { get; set; }
        public ICollection<ProfilDomainJobViewModel>? ProfilDomainJobs { get; set; }
    }
}
