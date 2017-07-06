﻿using System.Web.Http;
using DAL.DTO;
using DAL.Exceptions;
using DAL.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebUI.Infrastructure.Auth;
using WebUI.Models;

namespace WebUI.Controllers
{
    [RoutePrefix("api/candidate")]
    public class CandidateController : ApiController
    {
        private CandidateService service;
        private IAuthContainer<string> authContainer;
        private static JsonSerializerSettings BOT_SERIALIZER_SETTINGS = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public CandidateController(CandidateService service, IAuthContainer<string> authContainer)
        {
            this.service = service;
            this.authContainer = authContainer;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Get(new CandidateSearchModel());
        }

        // GET api/<controller>
        [HttpPost]
        [Route("search")]
        public IHttpActionResult Get([FromBody]CandidateSearchModel searchParameters)
        {
            if (ModelState.IsValid)
            {
                var tupleResult = service.Get(
                    searchParameters.FirstName,
                    searchParameters.LastName,
                    searchParameters.RelocationAgreement,
                    searchParameters.IsMale,
                    searchParameters.MinAge,
                    searchParameters.MaxAge,
                    searchParameters.StartExperience,
                    searchParameters.MinSalary,
                    searchParameters.MaxSalary,
                    searchParameters.CurrencyId,
                    searchParameters.IndustryId,
                    searchParameters.Position,
                    searchParameters.Technology,
                    searchParameters.LanguageSkills,
                    searchParameters.CitiesIds,
                    searchParameters.Current,
                    searchParameters.Size,
                    searchParameters.SortBy,
                    searchParameters.SortAsc,
                    searchParameters.SearchString
                    );

                var candidatesQuerryResult = tupleResult.Item1;
                var total = tupleResult.Item2;

                var ret = new
                {
                    Candidate = candidatesQuerryResult,
                    Current = searchParameters.Current,
                    Size = searchParameters.Size,
                    Total = total,
                    SortBy = searchParameters.SortBy,
                    SortAsc = searchParameters.SortAsc
                };
                return Json(ret, BOT_SERIALIZER_SETTINGS);
            }
            return BadRequest(ModelState);
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var foundedEntity = service.Get(id);
            if (foundedEntity == null)
            {
                ModelState.AddModelError("Candidate", "Candidate with id " + id + " not founded.");
                return BadRequest(ModelState);
            }
            return Json(foundedEntity, BOT_SERIALIZER_SETTINGS);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]CandidateDTO newCandidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedCandidate = service.Add(newCandidate, authContainer.Get(this.ActionContext.Request.Headers.Authorization.Parameter).Item1.Id);
            return Json(addedCandidate, BOT_SERIALIZER_SETTINGS);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody]CandidateDTO changedCandidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedCandidate = service.Update(changedCandidate, authContainer.Get(this.ActionContext.Request.Headers.Authorization.Parameter).Item1.Id);
            return Json(updatedCandidate, BOT_SERIALIZER_SETTINGS);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("duplicates")]
        public IHttpActionResult Get([FromBody]CandidateDTO patternCandidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var duplicates = service.GetDuplicates(patternCandidate);
            return Json(duplicates, BOT_SERIALIZER_SETTINGS);
        }
    }
}
