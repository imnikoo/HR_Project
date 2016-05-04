﻿using Data.Infrastructure;
using Domain.DTO.DTOModels.SetupDTO;
using Domain.Entities.Setup;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Controllers
{
    public class StagesController : BoTController<Stage, StageDTO>
    {
        public StagesController(IDataRepositoryFactory repoFatory, IUnitOfWork unitOfWork)
            : base (repoFatory, unitOfWork)
        {

        }
    }
}