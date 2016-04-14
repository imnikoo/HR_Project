using AutoMapper;
using Domain.Entities;
using Domain.Entities.Setup;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DTO.DTOModels;

namespace WebApi
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure(ICandidateRepository _canRepo)
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Candidate, CandidateDTO>()
                    .ForMember(dest => dest.SkillsIds, opt => opt.MapFrom(src => src.Skills.Select(skill => skill.Id)))
                    .ForMember(dest => dest.ExperienceId, opt => opt.MapFrom(src => src.Experience.Id))
                    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City.Id))
                    .ForMember(dest => dest.SocialNetworks, opt => opt.MapFrom(src => src.SocialNetworks
                        .Select(sn => new CandidateSocialDTO()
                        {
                            EditTime = sn.EditTime,
                            Id = sn.Id,
                            Path = sn.Path,
                            SocialNetworkId = sn.SocialNetwork.Id,
                            State = sn.State
                        })))
                    .ForMember(dest => dest.LanguageSkills, opt => opt.MapFrom(src => src.LanguageSkills
                        .Select(ls => new LanguageSkillDTO()
                        {
                            EditTime = ls.EditTime,
                            Id = ls.Id,
                            LanguageId = ls.Language.Id,
                            LanguageLevel = ls.LanguageLevel,
                            State = ls.State
                        })));
                
                x.CreateMap<CandidateDTO, Candidate>();
                x.CreateMap<Vacancy, VacancyDTO>();
                x.CreateMap<VacancyDTO, Vacancy>();
                x.CreateMap<SocialNetwork, SocialNetworkDTO>();
                x.CreateMap<SocialNetworkDTO, SocialNetwork>();
            });
        }
    }
}