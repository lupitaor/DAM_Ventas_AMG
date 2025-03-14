﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.API.Data;
using Ventas.Shared.Entities;

namespace Ventas.API.Controllers
{
    [ApiController]
    [Route("api/countries")]

    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;
        public CountriesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Getasync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            _context.Update(country);

            await _context.SaveChangesAsync();
            return Ok(country);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return Ok(PostAsync(country));
        }

       

    }
}
