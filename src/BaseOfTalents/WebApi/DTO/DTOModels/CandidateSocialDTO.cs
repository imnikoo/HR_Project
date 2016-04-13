using Domain.Entities.Enum;
using System;

namespace WebApi.DTO.DTOModels
{
    public class CandidateSocialDTO
    {
        public int Id { get; set; }
        public DateTime EditTime { get; set; }
        public EntityState State { get; set; }
        public int SocialNetworkId { get; set; }
        public string Path { get; set; }
    }
}