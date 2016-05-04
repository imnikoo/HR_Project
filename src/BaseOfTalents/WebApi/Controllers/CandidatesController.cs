﻿using Domain.Entities;
using Domain.Repositories;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DTO.DTOService;
using System;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Collections.Generic;
using Domain.DTO.DTOModels;
using Data.EFData.Extentions;
using Data.Infrastructure;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Domain.Entities.Setup;
using Domain.Entities.Enum.Setup;

namespace WebApi.Controllers
{
    public class CandidatesController : BoTController<Candidate, CandidateDTO>
    {
        public CandidatesController(IDataRepositoryFactory repoFatory, IUnitOfWork unitOfWork)
            : base(repoFatory, unitOfWork)
        {

        }

        public CandidatesController()
        {

        }

        public override IHttpActionResult All(HttpRequestMessage request)
        {
            return this.All(request);
        }

        [HttpGet]
        // GET: api/Entities/
        [Route("api/{controller}{pageNumber:int}")]
        private IHttpActionResult All(HttpRequestMessage request, int? pageNumber = 1)
        {
            var _currentRepo = _repoFactory.GetDataRepository<Candidate>(request);
            return CreateResponse(request, () =>
            {
                var entitiesQuery = _currentRepo.GetAll().OrderBy(x => x.Id);
                if (pageNumber.HasValue)
                {
                    var totalCount = _currentRepo.GetAll().Count();
                    var totalPages = Math.Ceiling((double)totalCount / ENTITIES_PER_PAGE);
                    var entities = entitiesQuery
                                        .Skip((pageNumber.Value - 1) * ENTITIES_PER_PAGE)
                                        .Take(ENTITIES_PER_PAGE)
                                        .ToList()
                                        .Select(x => DTOService.ToDTO<Candidate, CandidateDTO>(x));
                    return Json(new
                    {
                        totalCount = totalCount,
                        totalPages = totalPages,
                        queryResult = entities
                    }, BOT_SERIALIZER_SETTINGS);
                }
                return BadRequest();
            });
        }

        public override IHttpActionResult Add(HttpRequestMessage request, [FromBody]CandidateDTO candidate)
        {
            var _candidateRepo = _repoFactory.GetDataRepository<Candidate>(request);

            return CreateResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    StringBuilder errorString = new StringBuilder();
                    foreach (var error in ModelState.Keys.SelectMany(k => ModelState[k].Errors))
                    {
                        errorString.Append(error.ErrorMessage + '\n');
                    }
                    return BadRequest(errorString.ToString());
                }
                else
                {
                    if (candidate.Id != 0)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        Candidate _candidate = new Candidate();
                        _candidate.Update(candidate, _repoFactory.GetDataRepository<Skill>(request), _repoFactory.GetDataRepository<Tag>(request));
                        _candidateRepo.Add(_candidate);
                        _unitOfWork.Commit();
                        return Ok();
                    }
                }
            });
        }

        public override IHttpActionResult Put(HttpRequestMessage request, int id, [FromBody] CandidateDTO changedEntity)
        {
            var _candidateRepo = _repoFactory.GetDataRepository<Candidate>(request);

            return CreateResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    StringBuilder errorString = new StringBuilder();
                    foreach (var error in ModelState.Keys.SelectMany(k => ModelState[k].Errors))
                    {
                        errorString.Append(error.ErrorMessage + '\n');
                    }
                    return BadRequest(errorString.ToString());
                }
                else
                {
                    if (changedEntity.Id != id)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        Candidate _candidate = _candidateRepo.Get(id);
                        _candidate.Update(changedEntity, _repoFactory.GetDataRepository<Skill>(request), _repoFactory.GetDataRepository<Tag>(request));
                        _candidateRepo.Update(_candidate);
                        _unitOfWork.Commit();
                        return Json(_candidate, BOT_SERIALIZER_SETTINGS);
                    }
                }
            });
        }
    }
}

