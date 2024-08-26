using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.Interface;
using api.mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var comment = await _commentRepo.GetAll();
            var cmt = comment.Select(m => m.ToCommentDto());
            return Ok(cmt);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var comment = await _commentRepo.GetById(id);
            if (comment == null)
            {
                return NotFound("Can't find Comment");
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> Create([FromRoute] int id, CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _stockRepo.StockExist(id))
            {
                return BadRequest("Stock does not exist!!!");
            }

            var comment = commentDto.ToCommentFromCreate(id);
            await _commentRepo.Create(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto UpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepo.Update(id, UpdateDto);

            if (comment == null)
            {
                return BadRequest("Can't Update the Comment!!!");
            }

            return Ok(comment.ToCommentDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var comment = await _commentRepo.Delete(id);

            if (comment == null)
            {
                return NotFound("Comment not Found!!!");
            }

            return NoContent();
        }

    }
}