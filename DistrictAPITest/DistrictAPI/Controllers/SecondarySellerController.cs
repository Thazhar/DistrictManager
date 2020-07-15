using System.Collections.Generic;
using AutoMapper;
using DistrictAPITest.Data;
using DistrictAPITest.Dtos;
using DistrictAPITest.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DistrictAPITest.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecondarySellerController : ControllerBase
    {
        private readonly ISecondarySellerRepo _repository;
        private readonly IMapper _mapper;

        public SecondarySellerController(ISecondarySellerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/secondaryseller/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<SecondarySeller>> GetSecondarySellersByDistrictId(int id)
        {
            var secondarySellerItems = _repository.GetSecondarySellersByDistrictId(id);
            if (secondarySellerItems != null)
            {
                return Ok(secondarySellerItems);
            }
            return NotFound();
        }

        //get api/secondaryseller/5/5
        [HttpGet("{sellerId}/{districtId}")]
        public ActionResult<SecondarySeller> GetSecondarySellerByKey(int sellerId, int districtId)
        {
            var secondarySellerItem = _repository.GetSecondarySellerByKey(sellerId, districtId);
            if (secondarySellerItem != null)
            {
                return Ok(secondarySellerItem);
            }
            return NotFound();
        }


        //POST api/secondaryseller
        [HttpPost]
        public ActionResult<SecondarySeller> CreateSecondarySeller(SecondarySeller secondarySellerCreateDto)
        {
            var secondarySellerModel = _mapper.Map<SecondarySeller>(secondarySellerCreateDto);
            _repository.CreateSecondarySeller(secondarySellerModel);

            var districtsReadDto = _mapper.Map<SecondarySeller>(secondarySellerModel);

            return GetSecondarySellerByKey(secondarySellerModel.SellerId, secondarySellerModel.DistrictId);
        }

        //DELETE api/secondaryseller/5/5
        [HttpDelete("{sellerId}/{districtId}")]
        public ActionResult<SecondarySeller> DeleteSecondarySeller(int sellerId, int districtId)
        {
            var secondarySellerModelFromRepo = _repository.GetSecondarySellerByKey(sellerId, districtId);
            if (secondarySellerModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteSecondarySeller(secondarySellerModelFromRepo);

            return Ok(secondarySellerModelFromRepo);
        }
    }
}
