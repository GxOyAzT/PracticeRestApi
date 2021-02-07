using AllBackgroundStuff;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/ModelA")]
    public class ModelAController : ControllerBase
    {
        private readonly IModelARepo _modelARepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ModelAController(
            IModelARepo modelARepo,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _modelARepo = modelARepo;
            _mapper = mapper;
            this.userManager = userManager;
        }

        // GET api/ModelA
        [HttpGet]
        public async Task<ActionResult <List<ModelAReadDTO>>> GetAllModelAs()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            return Ok(_mapper.Map<List<ModelAReadDTO>>(_modelARepo.GetAll()));
        }

        // GET api/ModelA/{id}
        [HttpGet("{propInt}", Name = "GetModelAByPropInt")]
        public async Task<ActionResult<ModelAReadDTO>>  GetModelAByPropInt(int propInt)
        {
            var result = _modelARepo.Get(propInt);

            var userId = await userManager.GetUserAsync(User);

            if (result != null) return Ok(_mapper.Map<ModelAReadDTO>(result));
            else return NotFound();
        }

        // POST api/ModelA
        [HttpPost]
        public ActionResult <ModelAReadDTO> CreateModelA(ModelACreateDTO modelACreateDTO)
        {
            var modelA = _mapper.Map<ModelA>(modelACreateDTO);

            modelA.PropDateTime = DateTime.Now.Date;

            _modelARepo.Create(modelA);

            var returnModelA = _mapper.Map<ModelAReadDTO>(modelA);

            return CreatedAtRoute(nameof(GetModelAByPropInt), new { propInt = returnModelA.PropInt }, returnModelA);
        }

        // PUT api/ModelA/{id}
        [HttpPut("{propInt}")]
        public ActionResult <ModelAReadDTO> UpdateModelA(int propInt, ModelAUpdateDTO modelAUpdateDTO)
        {
            var modelFromRepo = _modelARepo.Get(propInt);

            if (modelFromRepo == null)
                return NotFound();

            _mapper.Map(modelAUpdateDTO, modelFromRepo);

            _modelARepo.Update(modelFromRepo);

            return NoContent();
        }

        // PATCH api/ModelA/{propInt}
        [HttpPatch("{propInt}")]
        public ActionResult PartialCommandUpdate(int propInt, JsonPatchDocument<ModelAUpdateDTO> patchModA)
        {
            var modelAFromRepo = _modelARepo.Get(propInt);

            if (modelAFromRepo is null)
                return NotFound();

            var modelAToPatch = _mapper.Map<ModelAUpdateDTO>(modelAFromRepo);
            patchModA.ApplyTo(modelAToPatch, ModelState);

            if (!TryValidateModel(modelAToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(modelAToPatch, modelAFromRepo);

            _modelARepo.Update(modelAFromRepo);

            return NoContent();
        }

        // DELETE api/ModelA/{porpInt}
        [HttpDelete("{propInt}")]
        public ActionResult DeleteModelA(int propInt)
        {
            var modelToDelete = _modelARepo.Get(propInt);

            if (modelToDelete is null)
                return NotFound();

            _modelARepo.Delete(modelToDelete);

            return NoContent();
        }
    }
}
