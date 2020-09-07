using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassicalGuitarAPI.DataServices;
using ClassicalGuitarAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassicalGuitarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarController : ControllerBase
    {
        [HttpGet]
        public async Task<GuitarResponse> Get()
        {
            var response = new GuitarResponse();
            try
            {
                response.Guitars = await ReadAllGuitarsAsync();
                response.Message = "Success";
                response.Status = 1;
            } catch(Exception e)
            {
                response.Message = e.Message;
                response.Status = 0;
            }
            return response;
        }

        // GET api/<GuitarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GuitarController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GuitarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GuitarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<List<Guitar>> ReadAllGuitarsAsync()
        {
            using (var context = new ClassicalGuitarContext())
            {
                List<Guitar> guitars = await context.Guitar.ToListAsync();
                
                return guitars;
            }
        }
    }
}
