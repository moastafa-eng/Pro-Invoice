using AutoMapper;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Products;

namespace ProInvoice.Application.Features.Products;
public class ProductResponse : IResult
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public decimal UnitPrice { get; set; }

}

public class ProductResponseCollection : IResult
{
    public IReadOnlyCollection<ProductResponse> Products { get; set; } = null!;
}

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product,ProductResponse>()
            .ForMember(dto=>dto.Description, opt => opt.MapFrom(ent=>ent.Description.Value))
            .ForMember(dto=>dto.UnitPrice, opt => opt.MapFrom(ent=>ent.UnitPrice.Value));
    }
}
