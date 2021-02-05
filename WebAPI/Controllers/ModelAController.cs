using AllBackgroundStuff;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/ModelA")]
    [ApiController]
    public class ModelAController : ControllerBase
    {
        private readonly IModelARepo _modelARepo;
        private readonly IMapper _mapper;

        public ModelAController(
            IModelARepo modelARepo,
            IMapper mapper)
        {
            _modelARepo = modelARepo;
            _mapper = mapper;
        }

        // GET api/ModelA
        [HttpGet]
        public ActionResult <List<ModelAReadDTO>> GetAllModelAs()
        {
            return Ok(_mapper.Map<List<ModelAReadDTO>>(_modelARepo.GetAll()));
        }

        // GET api/ModelA/{id}
        [HttpGet("{propInt}", Name = "GetModelAByPropInt")]
        public ActionResult <ModelAReadDTO> GetModelAByPropInt(int propInt)
        {
            var result = _modelARepo.Get(propInt);

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
