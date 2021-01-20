using DTO;
using Interface.Bussines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHogwarts.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IStudentService studentService,
            ILogger<HomeController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        /// <summary>
        /// Create a new record for the request
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response<RequestDTO>>> CreateAsync([FromBody] RequestDTO dto)
        {
            try
            {
                return new Response<RequestDTO>
                {
                    IsSuccess = true,
                    Message = "La solicitud de ingreso se ha creado correctamente",
                    Result = await _studentService.CreateAsync(dto)
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return new Response<RequestDTO>
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }

        [HttpDelete]
        public async Task<Response<int>> Delete(int id)
        {
            try
            {
                int result = await _studentService.DeleteAsync(id);

                if (result > 0)
                {
                    return new Response<int>
                    {
                        IsSuccess = true,
                        Result = result
                    };
                }
                else
                {
                    return new Response<int>
                    {
                        IsSuccess = false,
                        Message = "No records deleted."
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return new Response<int>
                {
                    IsSuccess = false,
                    Message = e.Message,
                    Result = 0
                };
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RequestDTO> Get(int id)
        {
            return Ok(_studentService.Get(id));
        }

        [HttpGet]
        public ActionResult<Response<ICollection<RequestDTO>>> Get()
        {
            return new Response<ICollection<RequestDTO>>
            {
                IsSuccess = true,
                Result = _studentService.Get()
            };
        }



        [HttpPut]
        public async Task<ActionResult<Response<RequestDTO>>> UpdateAsync([FromBody] RequestDTO dto)
        {
            RequestDTO result = await _studentService.UpdateAsync(dto);

            if (result == null)
            {
                return new Response<RequestDTO>
                {
                    IsSuccess = false,
                    Message = "No record found"
                };
            }

            return new Response<RequestDTO>
            {
                IsSuccess = true,
                Result = result
            };
        }

    }


}
