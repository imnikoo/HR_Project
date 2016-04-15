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
        /*public static void Configure(
            ISocialNetworkRepository socRepo, 
            ILanguageRepository lanRepo, 
            ISkillRepository sklRepo, 
            ITeamRepository teamRepo, 
            IExperienceRepository expRepo,
            ICityRepository cityRepo)
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<CandidateSocial, CandidateSocialDTO>()
                    .ForMember(dest => dest.SocialNetworkId, opt => opt.MapFrom(src => src.SocialNetwork.Id));
                x.CreateMap<CandidateSocialDTO, CandidateSocial>()
                    .ForMember(dest => dest.SocialNetwork, opt => opt.MapFrom(src => socRepo.Get(src.SocialNetworkId)));

                x.CreateMap<LanguageSkill, LanguageSkillDTO>()
                    .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.Language.Id));
                x.CreateMap<LanguageSkillDTO, LanguageSkill>()
                    .ForMember(dest => dest.Language, opt => opt.MapFrom(src => lanRepo.Get(src.LanguageId)));


                x.CreateMap<Skill, int>()
                    .ConstructUsing(source => (source.SourceValue as Skill).Id);
                x.CreateMap<int, Skill>()
                    .ConstructUsing(src => sklRepo.Get(src));

                x.CreateMap<Team, int>()
                    .ConstructUsing(source => (source.SourceValue as Team).Id);
                x.CreateMap<int, Team>()
                    .ConstructUsing(src => teamRepo.Get(src));

                x.CreateMap<Experience, int>()
                    .ConstructUsing(source => (source.SourceValue as Experience).Id);
                x.CreateMap<int, Experience>()
                    .ConstructUsing(src => expRepo.Get(src));

                x.CreateMap<City, int>()
                    .ConstructUsing(source => (source.SourceValue as City).Id);
                x.CreateMap<int, City>()
                    .ConstructUsing(src => cityRepo.Get(src));

                x.CreateMap<Candidate, CandidateDTO>()
                    .ForMember(dest => dest.SkillsIds, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<Skill>, IEnumerable<int>>(src.Skills)))
                    .ForMember(dest => dest.ExperienceId, opt => opt.MapFrom(src => Mapper.Map<Experience, int>(src.Experience)))
                    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => Mapper.Map<City, int>(src.City)))
                    .ForMember(dest => dest.SocialNetworks, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<CandidateSocial>, IEnumerable<CandidateSocialDTO>>(src.SocialNetworks)))
                    .ForMember(dest => dest.LanguageSkills, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<LanguageSkill>, IEnumerable<LanguageSkillDTO>>(src.LanguageSkills)));
                x.CreateMap<CandidateDTO, Candidate>()
                    .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<int>, IEnumerable<Skill>>(src.SkillsIds)))
                    .ForMember(dest => dest.Experience, opt => opt.MapFrom(src => Mapper.Map<int, Experience>(src.ExperienceId)))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => Mapper.Map<int, City>(src.CityId)))
                    .ForMember(dest => dest.SocialNetworks, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<CandidateSocialDTO>, IEnumerable<CandidateSocial>>(src.SocialNetworks)))
                    .ForMember(dest => dest.LanguageSkills, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<LanguageSkillDTO>, IEnumerable<LanguageSkill>>(src.LanguageSkills)));
                x.CreateMap<Vacancy, VacancyDTO>()
                    .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => Mapper.Map<Team, int>(src.Team)))
                    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => Mapper.Map<City, int>(src.City)))
                    .ForMember(dest => dest.RequiredSkillsIds, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<Skill>, IEnumerable<int>>(src.RequiredSkills)))
                    .ForMember(dest => dest.LanguageSkill, opt => opt.MapFrom(src => Mapper.Map<LanguageSkill, LanguageSkillDTO>(src.LanguageSkill)));
                x.CreateMap<VacancyDTO, Vacancy>()
                    .ForMember(dest => dest.Team, opt => opt.MapFrom(src => Mapper.Map<int, Team>(src.TeamId)))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => Mapper.Map<int, City>(src.CityId)))
                    .ForMember(dest => dest.RequiredSkills, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<int>, IEnumerable<Skill>>(src.RequiredSkillsIds)))
                    .ForMember(dest => dest.LanguageSkill, opt => opt.MapFrom(src => Mapper.Map<LanguageSkillDTO, LanguageSkill>(src.LanguageSkill)));
            });*/
        }
    }
