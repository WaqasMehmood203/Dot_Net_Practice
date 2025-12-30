using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    public class Calculations : ControllerBase
    {
        private IConfiguration _config;
        public Calculations(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet("GetEnvironment")]
        public IActionResult Environmemt()
        {
            return Ok(_config["Environment"]);
        }

        [HttpPost]
        public IActionResult Add(int a, int b)
        {
            int Result = a + b;
            return Ok(Result);
        }

        [HttpPost("Subtract")]
        public IActionResult Subtract(int a, int b)
        {
            int Result = a - b;
            return StatusCode(200, new
            {
                result = Result,
                Message = "The answer is Correct"
            });
        }

        [HttpPost("Multiply")]
        public int Multiply(int a, int b)
        {
            int Result = a * b;
            return Result;
        }
        [HttpPost("Factorial")]
        public IActionResult Factorial(int number)
        {
            try
            {
                if (number < 0)
                {
                    return StatusCode(400, new
                    {
                        Status = 400,
                        Message = "Number must be non-negative."
                    });
                }

                long fact = 1;
                for (int i = 1; i <= number; i++)
                {
                    fact = fact * i;
                }

                return StatusCode(200, new
                {
                    Status = 200,
                    Message = "Factorial calculated successfully.",
                    Result = fact
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Status = 500,
                    Message = "Internal Server Error",
                    Error = ex.Message
                });
            }
        }


        [HttpPost("Greater")]
        public ActionResult<int> Greater(int firstnumber, int secondnumber)
        {
            try
            {
                if (firstnumber < secondnumber)
                {
                    return StatusCode(200, new
                    {
                        Message = "Second Number is Greater"
                    });

                }
                else if (firstnumber > secondnumber)
                {
                    return StatusCode(200, new
                    {
                        Message = "First number is Greater"
                    });
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Message = "Internal Server Error",
                    Error = e.Message
                });
            }
        }
        [HttpPost("ArraySum")]
        public IActionResult ArraySum(int[] array)
        {
            if (array == null || array.Length!=5)
            {
                return BadRequest("Input array must contain exactly 5 integers and should not be null.");
            }

            int sum = 0;
            for(int i = 0; i<array.Length; i++)
            {
                sum = sum + array[i];

            }
            return StatusCode(200, new
            {
                Result = sum,
                Message = "Sum calculated successfully."
            });
        }
    }
}
