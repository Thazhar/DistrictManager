using System.Collections.Generic;
using AutoMapper;
using DistrictAPITest.Data;
using DistrictAPITest.Dtos;
using DistrictAPITest.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DistrictAPITest.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")] //Route for how to get to the end-point ([controller] changes the route if the controller name is changed, maybe be wanted, maybe not)
    [ApiController] //Decorated for some default behaviour
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictRepo _repository;
        private readonly IMapper _mapper;

        public DistrictsController(IDistrictRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/Districts
        [HttpGet]
        public ActionResult<IEnumerable<District>> GetAllDistricts()
        {
            var districtItems = _repository.GetAllDistricts();
            return Ok(_mapper.Map<IEnumerable<DistrictsReadDto>>(districtItems));
        }

        //GET api/Districts/5
        [HttpGet("{id}", Name="GetDistrictById")]
        public ActionResult<DistrictsReadDto> GetDistrictById(int id)
        {
            var districtItem = _repository.GetDistrictById(id);
            if (districtItem != null)
            {
                return Ok(_mapper.Map<DistrictsReadDto>(districtItem)); //Map to DistrictsReadDto from source districtItem
            }
            return NotFound();
        }

        //POST api/Districts
        [HttpPost]
        public ActionResult<DistrictsReadDto> CreateDistrict(DistrictsCreateDto districtsCreateDto)
        {
            var districtModel = _mapper.Map<District>(districtsCreateDto); //Map to District from source districtsCreateDto
            _repository.CreateDistrict(districtModel);

            var districtsReadDto = _mapper.Map<DistrictsReadDto>(districtModel);

            return CreatedAtRoute(nameof(GetDistrictById), new {Id = districtsReadDto.DistrictId}, districtsReadDto); //TODO: Always returns route to id 0
        }

        //PUT api/Districts/5
        [HttpPut("{id}")]
        public ActionResult UpdateDistrict(int id, DistrictsUpdateDto districtUpdateDto)
        {
            var districtModelFromRepo = _repository.GetDistrictById(id);
            if (districtModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(districtUpdateDto, districtModelFromRepo);

            _repository.UpdateDistrict(id, districtModelFromRepo);

            //_repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/Districts/5
        [HttpPatch("{id}")]
        public ActionResult PartialDistrictUpdate(int id, JsonPatchDocument<DistrictsUpdateDto> patchDoc)
        {
            var districtModelFromRepo = _repository.GetDistrictById(id);
            if (districtModelFromRepo == null)
            {
                return NotFound();
            }

            var districtToPatch = _mapper.Map<DistrictsUpdateDto>(districtModelFromRepo);
            patchDoc.ApplyTo(districtToPatch, ModelState);
            if (!TryValidateModel(districtToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(districtToPatch, districtModelFromRepo);

            _repository.UpdateDistrict(id, districtModelFromRepo);

            return NoContent();
        }

        //DELETE api/Districts/5
        [HttpDelete("{id}")]
        public ActionResult<DistrictsReadDto> DeleteDistrict(int id)
        {
            var districtModelFromRepo = _repository.GetDistrictById(id);
            if (districtModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDistrict(districtModelFromRepo);

            return Ok(_mapper.Map<DistrictsReadDto>(districtModelFromRepo));
        }
    }
}
