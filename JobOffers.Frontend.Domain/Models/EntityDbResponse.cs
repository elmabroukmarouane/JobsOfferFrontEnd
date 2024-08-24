using System.Net;

namespace JobOffers.Frontend.Domain.Models
{
    public class EntityDbResponse<TEntityViewModel> where TEntityViewModel : Entity
    {
        public bool IsSuccess { get; set; }
        public MessageStatus? MessageStatus { get; set; }
        public TEntityViewModel? Entity { get; set; }
    }

    public class MessageStatus
    {
        public HttpStatusCode? StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
