﻿namespace api;

public static class StockMapper
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            Lastdiv = stockModel.Lastdiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap
        };
    }
}
