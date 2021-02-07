using AllBackgroundStuff;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/ModelA")]
    public class ModelAv2Controller : ControllerBase
    {
        private readonly IModelARepo _modelARepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ModelAv2Controller(
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
        public async Task<ActionResult<List<ModelAReadDTO>>> GetAllModelAs()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            return Ok(_mapper.Map<List<ModelAReadDTO>>(_modelARepo.GetAll().Where(e => e.User == user.Id)));
        }
    }
}
