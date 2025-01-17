﻿using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusTypeController : ControllerBase
    {
        private readonly IOrderStatusTypeService _OrderStatusTypeService;

        public OrderStatusTypeController(IOrderStatusTypeService OrderStatusTypeService)
        {
            _OrderStatusTypeService = OrderStatusTypeService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderStatusType>>> GetAllOrderStatusType()
        {
            var orderStatus = await _OrderStatusTypeService.GetAllOrderStatusTypeAsync();
            return Ok(orderStatus);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderStatusType>> GetOrderStatusTypeById(int id)
        {
            var orderStatus = await _OrderStatusTypeService.GetOrderStatusTypeByIdAsync(id);
            if (orderStatus == null)
                return NotFound();

            return Ok(orderStatus);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateOrderStatusType([FromBody] OrderStatusType orderStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _OrderStatusTypeService.CreateOrderStatusTypeAsync(orderStatus);
            return CreatedAtAction(nameof(GetOrderStatusTypeById), new { id = orderStatus.Id }, orderStatus);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderStatusType(int id, [FromBody] OrderStatusType orderStatus)
        {
            if (id != orderStatus.Id)
                return BadRequest();

            var existingOrderStatusType = await _OrderStatusTypeService.GetOrderStatusTypeByIdAsync(id);
            if (existingOrderStatusType == null)
                return NotFound();

            await _OrderStatusTypeService.UpdateOrderStatusTypeAsync(orderStatus);
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOrderStatusType(int id)
        {
            var orderStatus = await _OrderStatusTypeService.GetOrderStatusTypeByIdAsync(id);
            if (orderStatus == null)
                return NotFound();

            await _OrderStatusTypeService.SoftDeleteOrderStatusTypeAsync(id);
            return NoContent();
        }
    }
}
