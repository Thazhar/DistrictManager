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
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepo _repository;
        private readonly IMapper _mapper;

        public SellerController(ISellerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/seller
        [HttpGet]
        public ActionResult<IEnumerable<SellerReadDto>> GetAllSellers()
        {
            var sellerItems = _repository.GetAllSellers();
            return Ok(_mapper.Map<IEnumerable<SellerReadDto>>(sellerItems));
        }

        // GET api/seller/5
        [HttpGet("{id}", Name="GetSellerById")]
        public ActionResult<SellerReadDto> GetSellerById(int id)
        {
            var sellerItem = _repository.GetSellerById(id);
            if (sellerItem != null)
            {
                return Ok(_mapper.Map<SellerReadDto>(sellerItem));
            }

            return NotFound();
        }

        // POST api/seller
        [HttpPost]
        public ActionResult<SellerReadDto> CreateSeller(SellerCreateDto sellerCreateDto)
        {
            var sellerModel = _mapper.Map<Seller>(sellerCreateDto);
            _repository.CreateSeller(sellerModel);

            var sellerReadDto = _mapper.Map<SellerReadDto>(sellerModel);

            return CreatedAtRoute(nameof(GetSellerById), new { Id = sellerReadDto.SellerId }, sellerReadDto); 
        }

        // PUT api/seller/5
        [HttpPut("{id}")]
        public ActionResult UpdateSeller(int id, SellerUpdateDto sellerUpdateDto)
        {
            var sellerModelFromRepo = _repository.GetSellerById(id);
            if (sellerModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(sellerUpdateDto, sellerModelFromRepo);

            _repository.UpdateSeller(id, sellerModelFromRepo);

            return NoContent();
        }

        //PATCH api/seller/5
        [HttpPatch("{id}")]
        public ActionResult PartialSellerUpdate(int id, JsonPatchDocument<SellerUpdateDto> patchDoc)
        {
            var sellerModelFromRepo = _repository.GetSellerById(id);
            if (sellerModelFromRepo == null)
            {
                return NotFound();
            }

            var sellerToPatch = _mapper.Map<SellerUpdateDto>(sellerModelFromRepo);
            patchDoc.ApplyTo(sellerToPatch, ModelState);
            if (!TryValidateModel(sellerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(sellerToPatch, sellerModelFromRepo);

            _repository.UpdateSeller(id, sellerModelFromRepo);

            return NoContent();
        }

        // DELETE api/seller/5
        [HttpDelete("{id}")]
        public ActionResult<SellerReadDto> DeleteSeller(int id)
        {
            var sellerModelFromRepo = _repository.GetSellerById(id);
            if (sellerModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteSeller(sellerModelFromRepo);

            return Ok(_mapper.Map<SellerReadDto>(sellerModelFromRepo));
        }
    }
}
