﻿using System.Web.Http;
using DAL.DTO;
using DAL.Exceptions;
using DAL.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebUI.Filters;
using WebUI.Infrastructure.Auth;
using WebUI.Models;

namespace WebUI.Controllers
{
    [RoutePrefix("api/vacancy")]
    public class VacancyController : ApiController
    {
        private IAuthContainer<string> authContainer;
        private VacancyService service;
        private static JsonSerializerSettings BOT_SERIALIZER_SETTINGS = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public VacancyController(VacancyService service, IAuthContainer<string> authContainer)
        {
            this.service = service;
            this.authContainer = authContainer;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("search")]
        [Auth, PermissionAuthorization(Permissions = Domain.Entities.Enum.AccessRight.ViewListOfVacancies)]
        public IHttpActionResult Get([FromUri]VacancySearchParameters vacancyParams)
        {
            vacancyParams = vacancyParams ?? new VacancySearchParameters();
            if (ModelState.IsValid)
            {
                var tupleResult = service.Get(
                    vacancyParams.UserId,
                    vacancyParams.IndustryId,
                    vacancyParams.Title,
                    vacancyParams.VacancyState,
                    vacancyParams.TypeOfEmployment,
                    vacancyParams.LevelIds,
                    vacancyParams.CityIds,
                    vacancyParams.Current,
                    vacancyParams.Size,
                    vacancyParams.SortBy,
                    vacancyParams.SortAsc,
                    vacancyParams.DepartmentId
                    );

                var vacanciesViewModel = tupleResult.Item1;
                var total = tupleResult.Item2;

                var ret = new { Vacancies = vacanciesViewModel, Current = vacancyParams.Current, Size = vacancyParams.Size, Total = total };
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
                ModelState.AddModelError("Vacancy", "The entity with id: " + id + " not found.");
                return BadRequest(ModelState);
            }
            return Json(foundedEntity, BOT_SERIALIZER_SETTINGS);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("")]
        [Auth, PermissionAuthorization(Permissions = Domain.Entities.Enum.AccessRight.AddVacancy)]
        public IHttpActionResult Post([FromBody]VacancyDTO vacancy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedVacancy = service.Add(vacancy, authContainer.Get(this.ActionContext.Request.Headers.Authorization.Parameter).Item1.Id);
            return Json(updatedVacancy, BOT_SERIALIZER_SETTINGS);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("{id}")]
        [Auth, PermissionAuthorization(Permissions = Domain.Entities.Enum.AccessRight.EditVacancy)]
        public IHttpActionResult Put(int id, [FromBody]VacancyDTO vacancy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedVacancy = service.Update(vacancy, authContainer.Get(this.ActionContext.Request.Headers.Authorization.Parameter).Item1.Id);
            return Json(updatedVacancy, BOT_SERIALIZER_SETTINGS);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id:int}")]
        [Auth, PermissionAuthorization(Permissions = Domain.Entities.Enum.AccessRight.RemoveVacancy)]
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
    }
}