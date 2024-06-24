using System.ComponentModel.DataAnnotations;

namespace api;

public class UpdateStockRequestDto
{
    [Required]
    [MaxLength(15, ErrorMessage = "Symbol can't be over 15 characters")]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    [MaxLength(35, ErrorMessage = "Company Name can't be over 35 characters")]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [Range(1, 100000000)]
    public decimal Purchase { get; set; }

    [Required]
    [Range(0.001, 100)]
    public decimal Lastdiv { get; set; }

    [Required]
    [MaxLength(10, ErrorMessage = "Industry can't be over 10 characters")]
    public string Industry { get; set; } = string.Empty;

    [Required]
    [Range(1, 500000000)]
    public long MarketCap { get; set; }
}
