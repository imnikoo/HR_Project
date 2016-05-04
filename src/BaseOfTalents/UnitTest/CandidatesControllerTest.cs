using Data.DumbData;
using Data.DumbData.Repositories;
using Domain.Entities;
using Domain.Entities.Setup;
using NUnit.Framework;
using WebApi.Controllers;
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
using AutoMapper;
using Domain.DTO.DTOModels;
using System.Web.Http;
using WebApi;
using Data.Infrastructure;
using Autofac;
using System.Data.Entity.SqlServer;

namespace UnitTest
{
    [TestFixture]
    class CandidatesControllerTest
    {
        public IContainer Container { get; set; }
        private HttpConfiguration _configuration = null;

        [SetUp]
        public void StartTesting()
        {
            var instance = SqlProviderServices.Instance;

            AutoMapperWebConfiguration.Configure();
            _configuration = new HttpConfiguration();
            AutofacTestApiConfiguration.Initialize(_configuration);
        }


        [Test]
        public void Get_Candidate()
        {
            Debugger.Launch();

            using (var message = new HttpRequestMessage())
            {
                message.SetConfiguration(_configuration);
                var ds = message.GetDependencyScope();

                var factory = (IDataRepositoryFactory)ds.GetService(typeof(IDataRepositoryFactory));
                var uof = (IUnitOfWork)ds.GetService(typeof(IUnitOfWork));

                var _controller = new CandidatesController(factory, uof);

                var dto = new CandidateDTO()
                {
                    FirstName = "TESTNAME",
                    MiddleName = "MiddleName",
                    BirthDate = DateTime.Now,
                    Description = "desc",
                    Education = "edu",
                    Email = "email",
                    IsMale = true,
                    LastName = "lastname",
                    PositionDesired = "arc",
                    Practice = "good",
                    RelocationAgreement = true,
                    SalaryDesired = 100,
                    Skype = "skype",
                    LocationId = 0,
                    SocialNetworks = new List<CandidateSocialDTO>() { new CandidateSocialDTO() { Path = "path" } },
                    StartExperience = DateTime.Now,
                };

                var actionResult = _controller.Add(message, dto);
                var responseMessage = actionResult as OkNegotiatedContentResult<CandidateDTO>;

                Assert.AreEqual("TESTNAME", responseMessage.Content.FirstName);

            }

            
        }

        [Test]
        [TestCase(54235)]
        public async void Get_Candidate_BadId(int id)
        {
            /*var _controller = new CandidatesController(new DummyRepositoryFacade());
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            var result = _controller.Get(id);
            var response = await result.ExecuteAsync(new System.Threading.CancellationToken());

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);*/
        }


        [Test]
        public void Add_Candidate()
        {
            /*var _controller = new CandidatesController(new DummyRepositoryFacade());
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            #region Candidate
            Comment candidateComment = new Comment()
            {
                Message = "msg",
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
                Title = "name"
            };

            Location city = new Location()
            {
                Id = 1,
                Country = country,
                Title = "dnepr"
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
                
                Files = new List<File>() { candidateFile },
                Sources = new List<CandidateSource>() { candidateSource },
                FirstName = "TESTNAME",
                IsMale = true,
                LanguageSkills = new List<LanguageSkill>() { languageSkill },
                LastName = "lname",
                Location = city,
                MiddleName = "mname",
                PhoneNumbers = new List<PhoneNumber>() { new PhoneNumber { Number = "+380978762352" } },
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
        */

        }


        [Test]
        [TestCase(1)]
        public async void Delete_Candidate_OK(int id)
        {
           /* var _controller = new CandidatesController(new DummyRepositoryFacade());
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();

            var actionResponse = await _controller.Remove(id).ExecuteAsync(new System.Threading.CancellationToken());
            
            Assert.AreEqual(HttpStatusCode.OK, actionResponse.StatusCode);*/
        }

        [Test]
        [TestCase(1532)]
        public async void Delete_Candidate_NoContent(int id)
        {
            /*var _controller = new CandidatesController(new DummyRepositoryFacade());
            _controller.Request = new System.Net.Http.HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();


            var actionResponse = await _controller.Remove(id).ExecuteAsync(new System.Threading.CancellationToken());


            Assert.AreEqual(HttpStatusCode.NoContent, actionResponse.StatusCode);*/
        }

        [Test]
        [TestCase(1, "CHANGEDNAMETEST")]
        [TestCase(1, "DRUG")]
        public void Put_Candidate_OK(int id, string testname)
        {
             /*var _controller = new CandidatesController(new DummyRepositoryFacade());
             _controller.Request = new HttpRequestMessage();
             _controller.Configuration = new HttpConfiguration();

             var getResult = _controller.Get(id);
             var jsonGetResult = getResult as JsonResult<CandidateDTO>;
             var candidateDto = jsonGetResult.Content;

             candidateDto.FirstName = testname;

             var putResult = _controller.Put(id, candidateDto);
             var jsonPutResult = getResult as JsonResult<CandidateDTO>;
             var candidateAfterPut = jsonPutResult.Content;

             Assert.AreEqual(testname, candidateAfterPut.FirstName);*/
        }
    }
}