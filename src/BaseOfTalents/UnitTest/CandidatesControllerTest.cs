using Data.DumbData;
using Data.DumbData.Repositories;
using Domain.Entities;
using Domain.Entities.Setup;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.DTO.DTOModels;
using System.Web.Http.Results;
using Domain.Entities.Enum;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using WebApi.DTO.DTOService;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Linq;
using Domain.Repositories;

namespace UnitTest
{
    [TestFixture]
    class CandidatesControllerTest
    {
        [SetUp]
        public void StartTesting()
        {
            //    ISocialNetworkRepository _socRepo = new DummySocialNetworkRepository(new DummyBotContext());
            //    ILanguageRepository _lanRepo = new DummyLanguageRepository(new DummyBotContext());
            //    ISkillRepository _sklRepo = new DummySkillRepository(new DummyBotContext());
            //    IExperienceRepository _expRepo = new DummyExperienceRepository(new DummyBotContext());
            //    ICityRepository _cityRepo = new DummyCityRepository(new DummyBotContext());
            //    ITeamRepository _teamRepo = new DummyTeamRepository(new DummyBotContext());

            //    Mapper.Initialize(x =>
            //    {
            //        x.CreateMap<CandidateSocial, CandidateSocialDTO>()
            //            .ForMember(dest => dest.SocialNetworkId, opt => opt.MapFrom(src => src.SocialNetwork.Id));
            //        x.CreateMap<CandidateSocialDTO, CandidateSocial>()
            //            .ForMember(dest => dest.SocialNetwork, opt => opt.MapFrom(src => _socRepo.Get(src.SocialNetworkId)));

            //        x.CreateMap<LanguageSkill, LanguageSkillDTO>()
            //            .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.Language.Id));
            //        x.CreateMap<LanguageSkillDTO, LanguageSkill>()
            //            .ForMember(dest => dest.Language, opt => opt.MapFrom(src => _lanRepo.Get(src.LanguageId)));


            //        x.CreateMap<Skill, int>()
            //            .ConstructUsing(source => (source.SourceValue as Skill).Id);
            //        x.CreateMap<int, Skill>()
            //            .ConstructUsing(src => _sklRepo.Get(src));

            //        x.CreateMap<Team, int>()
            //            .ConstructUsing(source => (source.SourceValue as Team).Id);
            //        x.CreateMap<int, Team>()
            //            .ConstructUsing(src => _teamRepo.Get(src));

            //        x.CreateMap<Experience, int>()
            //            .ConstructUsing(source => (source.SourceValue as Experience).Id);
            //        x.CreateMap<int, Experience>()
            //            .ConstructUsing(src => _expRepo.Get(src));

            //        x.CreateMap<City, int>()
            //            .ConstructUsing(source => (source.SourceValue as City).Id);
            //        x.CreateMap<int, City>()
            //            .ConstructUsing(src => _cityRepo.Get(src));

            //        x.CreateMap<Candidate, CandidateDTO>()
            //            .ForMember(dest => dest.SkillsIds,          opt => opt.MapFrom(src => Mapper.Map<IEnumerable<Skill>, IEnumerable<int>>(src.Skills)))
            //            .ForMember(dest => dest.ExperienceId,       opt => opt.MapFrom(src => Mapper.Map<Experience, int>(src.Experience)))
            //            .ForMember(dest => dest.CityId,             opt => opt.MapFrom(src => Mapper.Map<City, int>(src.City)))
            //            .ForMember(dest => dest.SocialNetworks,     opt => opt.MapFrom(src => Mapper.Map<IEnumerable<CandidateSocial>, IEnumerable<CandidateSocialDTO>>(src.SocialNetworks)))
            //            .ForMember(dest => dest.LanguageSkills,     opt => opt.MapFrom(src => Mapper.Map<IEnumerable<LanguageSkill>, IEnumerable<LanguageSkillDTO>>(src.LanguageSkills)));
            //        x.CreateMap<CandidateDTO, Candidate>()
            //            .ForMember(dest => dest.Skills,             opt => opt.MapFrom(src => Mapper.Map<IEnumerable<int>, IEnumerable<Skill>>(src.SkillsIds)))
            //            .ForMember(dest => dest.Experience,         opt => opt.MapFrom(src => Mapper.Map<int, Experience>(src.ExperienceId)))
            //            .ForMember(dest => dest.City,               opt => opt.MapFrom(src => Mapper.Map<int, City>(src.CityId)))
            //            .ForMember(dest => dest.SocialNetworks,     opt => opt.MapFrom(src => Mapper.Map<IEnumerable<CandidateSocialDTO>, IEnumerable<CandidateSocial>>(src.SocialNetworks)))
            //            .ForMember(dest => dest.LanguageSkills,     opt => opt.MapFrom(src => Mapper.Map<IEnumerable<LanguageSkillDTO>, IEnumerable<LanguageSkill>>(src.LanguageSkills)));
            //        x.CreateMap<Vacancy, VacancyDTO>()
            //            .ForMember(dest => dest.TeamId,             opt => opt.MapFrom(src => Mapper.Map<Team, int>(src.Team)))
            //            .ForMember(dest => dest.CityId,             opt => opt.MapFrom(src => Mapper.Map<City, int>(src.City)))
            //            .ForMember(dest => dest.RequiredSkillsIds,  opt => opt.MapFrom(src => Mapper.Map<IEnumerable<Skill>, IEnumerable<int>>(src.RequiredSkills)))
            //            .ForMember(dest => dest.LanguageSkill,      opt => opt.MapFrom(src => Mapper.Map<LanguageSkill, LanguageSkillDTO>(src.LanguageSkill)));
            //        x.CreateMap<VacancyDTO, Vacancy>()
            //            .ForMember(dest => dest.Team,               opt => opt.MapFrom(src => Mapper.Map<int, Team>(src.TeamId)))
            //            .ForMember(dest => dest.City,               opt => opt.MapFrom(src => Mapper.Map<int, City>(src.CityId)))
            //            .ForMember(dest => dest.RequiredSkills,     opt => opt.MapFrom(src => Mapper.Map<IEnumerable<int>, IEnumerable<Skill>>(src.RequiredSkillsIds)))
            //            .ForMember(dest => dest.LanguageSkill,      opt => opt.MapFrom(src => Mapper.Map<LanguageSkillDTO, LanguageSkill>(src.LanguageSkill)));
            //    });
            //System.Diagnostics.Debugger.Launch();
        }



        [Test]
        [TestCase(1)]
        public void Get_Candidate(int id)
        {
            var _controller = new CandidatesController(new DummyCandidateRepository(new DummyBotContext()));
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            var jsonResult = _controller.Get(id);
            var result = jsonResult as JsonResult<CandidateDTO>;
            Assert.AreEqual("TESTNAME", result.Content.FirstName);
            Assert.AreEqual(id, result.Content.Id);
        }

        [Test]
        [TestCase(54235)]
        public async void Get_Candidate_BadId(int id)
        {
            var _controller = new CandidatesController(new DummyCandidateRepository(new DummyBotContext()));
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            var result = _controller.Get(id);
            var response = await result.ExecuteAsync(new System.Threading.CancellationToken());

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Test]
        public void Add_Candidate()
        {
            var _controller = new CandidatesController(new DummyCandidateRepository(new DummyBotContext()));
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            #region Candidate
            Comment candidateComment = new Comment()
            {
                CommentType = CommentType.Candidate,
                Message = "msg",
                RelativeId = 0,
            };

            Experience experience = new Experience()
            {
                Id = 1,
                WorkExperience = DateTime.Now,
            };

            File candidateFile = new File()
            {
                Description = "description",
                FilePath = "path",
            };

            CandidateSource candidateSource = new CandidateSource()
            {
                Path = "Path",
                Source = Source.HeadHunter,
            };

            Language language = new Language()
            {
                Id = 1,
                Title = "language"
            };

            LanguageSkill languageSkill = new LanguageSkill()
            {
                Language = language,
                LanguageLevel = LanguageLevel.Fluent,
            };

            Country country = new Country()
            {
                Name = "name"
            };

            City city = new City()
            {
                Id = 1,
                Country = country,
                Name = "dnepr"
            };

            Photo photo = new Photo()
            {
                Description = "descr",
                ImagePath = "path"
            };

            Skill skill = new Skill()
            {
                Id = 1,
                Title = "C#"
            };

            SocialNetwork socialNetwork = new SocialNetwork()
            {
                Id = 1,
                ImagePath = "path",
                Title = "Path"
            };

            CandidateSocial candidateSocial = new CandidateSocial()
            {
                Path = "path",
                SocialNetwork = socialNetwork,
            };

            Candidate candidate = new Candidate()
            {
                Skype = "skype",
                BirthDate = DateTime.Now,
                Comments = new List<Comment>() { candidateComment },
                Description = "descrpition",
                Education = "High",
                Email = "email",
                Experience = experience,
                Files = new List<File>() { candidateFile },
                Sources = new List<CandidateSource>() { candidateSource },
                FirstName = "TESTNAME",
                IsMale = true,
                LanguageSkills = new List<LanguageSkill>() { languageSkill },
                LastName = "lname",
                City = city,
                MiddleName = "mname",
                PhoneNumbers = new List<string>() { "+380978762352" },
                Photo = photo,
                PositionDesired = "architecht",
                Practice = "best",
                RelocationAgreement = true,
                SalaryDesired = 10500,
                Skills = new List<Skill>() { skill },
                SocialNetworks = new List<CandidateSocial>() { candidateSocial },
                TypeOfEmployment = TypeOfEmployment.FullTime,
                VacanciesProgress = new List<VacancyStageInfo>() { }
            };
            #endregion
        

        }


        [Test]
        [TestCase(1)]
        public async void Delete_Candidate_OK(int id)
        {
            var _controller = new CandidatesController(new DummyCandidateRepository(new DummyBotContext()));
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            var actionResponse = await _controller.Remove(id).ExecuteAsync(new System.Threading.CancellationToken());

            Assert.AreEqual(HttpStatusCode.OK, actionResponse.StatusCode);
        }

        [Test]
        [TestCase(1532)]
        public async void Delete_Candidate_NoContent(int id)
        {
            var _controller = new CandidatesController(new DummyCandidateRepository(new DummyBotContext()));
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();


            var actionResponse = await _controller.Remove(id).ExecuteAsync(new System.Threading.CancellationToken());


            Assert.AreEqual(HttpStatusCode.NoContent, actionResponse.StatusCode);
        }

        [Test]
        [TestCase(1, "CHANGEDNAMETEST")]
        [TestCase(1, "DRUG")]
        public void Put_Candidate_OK(int id, string testname)
        {
            var _controller = new CandidatesController(new DummyCandidateRepository(new DummyBotContext()));
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            var getResult = _controller.Get(id);
            var jsonGetResult = getResult as JsonResult<CandidateDTO>;
            var candidateDto = jsonGetResult.Content;

            candidateDto.FirstName = testname;

            var putResult = _controller.Put(id, candidateDto);
            var jsonPutResult = getResult as JsonResult<CandidateDTO>;
            var candidateAfterPut = jsonPutResult.Content;

            Assert.AreEqual(testname, candidateAfterPut.FirstName);
        }
    }
}