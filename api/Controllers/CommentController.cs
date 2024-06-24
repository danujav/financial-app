using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    public CommentController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepository.GetAllAsync();

        var commentDto = comments.Select(c => c.ToCommentDto());

        return Ok(commentDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var commentModel = await _commentRepository.GetByIdAsync(id);
        if (commentModel == null) return NotFound();

        return Ok(commentModel.ToCommentDto());
    }
}
