﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    private readonly IStockRepository _stockRepository;
    public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
    {
        _commentRepository = commentRepository;
        _stockRepository = stockRepository;
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

    [HttpPost("{stockId}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
    {
        if (!await _stockRepository.StockExists(stockId)) return BadRequest("Stock does not exists!");

        var commentModel = commentDto.ToCommentFromCreate(stockId);
        await _commentRepository.CreateAsync(commentModel);

        return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());
    }
}
