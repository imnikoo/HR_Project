using Domain.Entities;
using Domain.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApi.DTO.DTOModels;
using WebApi.DTO.DTOService;

namespace WebApi.Controllers
{
    public abstract class BoTController<DomainEntity, ViewModel> : ApiController
        where DomainEntity : BaseEntity, new()
        where ViewModel : new()
    {
        protected IRepository<DomainEntity> _repo;
        private JsonSerializerSettings BotJsonSerializerSettings { get; set; }                                  

        [HttpGet]
        public virtual IHttpActionResult All()
        {
            var listiki = _repo.GetAll().ToList();
            var superListiki = listiki.Select(x => (ViewModel)Activator.CreateInstance(typeof(ViewModel), new object[] { x })).ToList();
            return Json(superListiki, BotJsonSerializerSettings);
        }

        [HttpGet]
        public virtual IHttpActionResult Get(int id)
        {
            var foundedEntity = _repo.Get(id);
            if (foundedEntity != null)
            {
                //var foundedEntityDto = DTOService.ToDTO<DomainEntity, ViewModel>(foundedEntity);
                //return Json(foundedEntity, BotJsonSerializerSettings);
            }
            return NotFound();
        }

        [HttpDelete]
        public virtual IHttpActionResult Remove(int id)
        {
            var entityToRemove = _repo.Get(id);
            if (entityToRemove != null)
            {
                _repo.Remove(entityToRemove);
                return Ok();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public virtual IHttpActionResult Add([FromBody]ViewModel entity)
        {
            if (ModelState.IsValid)
            {
                //var newEntity = DTOService.ToEntity<ViewModel, DomainEntity>(entity);
                //_repo.Add(newEntity);
                //return Json(DTOService.ToDTO<DomainEntity, ViewModel>(_repo.GetAll().Last()));
            }
            return BadRequest();
        }

        [HttpPut]
        public virtual IHttpActionResult Put(int id, [FromBody]ViewModel changedEntity)
        {
            if (ModelState.IsValid)
            {
                if (changedEntity != null)
                {
                //    var changedDomainEntity = DTOService.ToEntity<ViewModel, DomainEntity>(changedEntity);
                //    _repo.Update(changedDomainEntity);
                //    return Json(DTOService.ToDTO<DomainEntity, ViewModel>(_repo.Get(changedDomainEntity.Id)), BotJsonSerializerSettings);
                }
                return NotFound();
            }
            return BadRequest();
        }

        public BoTController()
        {
            BotJsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatString = "yyyy-MM-dd"
            };
        }

        public StringContent SerializeContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj, Formatting.Indented, BotJsonSerializerSettings));
        }
    }
}