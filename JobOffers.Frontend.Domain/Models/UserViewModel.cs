﻿namespace JobOffers.Frontend.Domain.Models
{
    public class UserViewModel : Entity
    {
        public int? ProfilId { get; set; } 
        public required string Email { get; set; }
        public string? Password { get; set; }
        public bool? IsOnLine { get; set; }
        public ProfilViewModel? Profil { get; set; }
        public ICollection<FavoriViewModel>? Favoris { get; set; }
    }
}
