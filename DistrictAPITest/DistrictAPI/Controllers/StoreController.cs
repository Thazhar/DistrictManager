using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DistrictAPITest.Data;
using DistrictAPITest.Dtos;
using DistrictAPITest.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DistrictAPITest.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepo _repository;
        private readonly IMapper _mapper;

        public StoreController(IStoreRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/store
        [HttpGet]
        public ActionResult<IEnumerable<StoreReadDto>> GetAllStores()
        {
            var storeItems = _repository.GetAllStores();
            return Ok(_mapper.Map<IEnumerable<StoreReadDto>>(storeItems));
        }

        //GET api/store/5
        [HttpGet("{id}", Name = "GetStoreById")]
        public ActionResult<StoreReadDto> GetStoreById(int id)
        {
            var storeItem = _repository.GetStoreById(id);
            if (storeItem != null)
            {
                return Ok(_mapper.Map<StoreReadDto>(storeItem));
            }
            return NotFound();
        }

        //POST api/store
        [HttpPost]
        public ActionResult<StoreReadDto> CreateStore(StoreCreateDto storeCreateDto)
        {
            var storeModel = _mapper.Map<Store>(storeCreateDto);
            _repository.CreateStore(storeModel);

            var storeReadDto = _mapper.Map<StoreReadDto>(storeModel);

            return CreatedAtRoute(nameof(GetStoreById), new { Id = storeReadDto.StoreId }, storeReadDto);
        }

        //PUT api/store/5
        [HttpPut("{id}")]
        public ActionResult UpdateStore(int id, StoreUpdateDto storeUpdateDto)
        {
            var storeModelFromRepo = _repository.GetStoreById(id);
            if (storeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(storeUpdateDto, storeModelFromRepo);

            _repository.UpdateStore(id, storeModelFromRepo);

            return NoContent();
        }

        //PATCH api/store/5
        [HttpPatch("{id}")]
        public ActionResult PartialStoreUpdate(int id, JsonPatchDocument<StoreUpdateDto> patchDoc)
        {
            var storeModelFromRepo = _repository.GetStoreById(id);
            if (storeModelFromRepo == null)
            {
                return NotFound();
            }

            var storeToPatch = _mapper.Map<StoreUpdateDto>(storeModelFromRepo);
            patchDoc.ApplyTo(storeToPatch, ModelState);
            if (!TryValidateModel(storeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(storeToPatch, storeModelFromRepo);

            _repository.UpdateStore(id, storeModelFromRepo);

            return NoContent();
        }

        //DELETE api/store/5
        [HttpDelete("{id}")]
        public ActionResult<StoreReadDto> DeleteStore(int id)
        {
            var storeModelFromRepo = _repository.GetStoreById(id);
            if (storeModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteStore(storeModelFromRepo);

            return Ok(_mapper.Map<StoreReadDto>(storeModelFromRepo));
        }
    }
}
