﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }


        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] UpdateRestaurantDto dto, [FromRoute] int id)
        {
            _restaurantService.Update(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var id = _restaurantService.Create(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDto = _restaurantService.GetAll();
            return Ok(restaurantsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute]int id)
        {
            var restaurant = _restaurantService.GetById(id);
            return Ok(restaurant);
        }
    }
}
