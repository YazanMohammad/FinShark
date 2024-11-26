using FinShark.Api.Dtos.Comment;
using FinShark.Api.Interfaces;
using FinShark.Api.Mappers;
using FinShark.Api.Repos;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IStockRepository _stockRepo;
        private readonly CommentRepository _commentRepo;
        public CommentController(CommentRepository comment, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _commentRepo = comment;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(p => p.ToCommentDto());
            return Ok(commentDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null) { return NotFound(); }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
        {
            if (!await _stockRepo.StockExists(stockId)) { return BadRequest("Stock Does't Exist"); }
            var commentModel = commentDto.ToCommentFromCreatedDTO(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentReqDto updateDto)
        {
            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdateDTO());
            if (comment == null) { return NotFound("Comment Not found!"); }
            return Ok(comment.ToCommentDto());
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var commentD = await _commentRepo.DeleteAsync(id);
            if (commentD == null) { return NotFound("Comment Not Found"); }
            return NoContent();

        }
    }
}
