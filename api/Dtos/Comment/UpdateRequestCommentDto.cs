using System.ComponentModel.DataAnnotations;

namespace api;

public class UpdateRequestCommentDto
{
    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 characters minimum")]
    [MaxLength(300, ErrorMessage = "Title can't be over 300 character")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MinLength(5, ErrorMessage = "Content must be 5 characters minimum")]
    [MaxLength(300, ErrorMessage = "Content can't be over 300 character")]
    public string Content { get; set; } = string.Empty;
}
