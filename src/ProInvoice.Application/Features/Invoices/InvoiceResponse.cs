using AutoMapper;
using ProInvoice.Application.Features.Customers;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Invoices;

namespace ProInvoice.Application.Features.Invoices;
public class InvoiceResponse : IResult
{
    public Guid Id { get; set; }

    public string PoNumber { get; set; } = null!;

    public CustomerResponse Customer { get; set; } = null!;

    public ICollection<InvoiceItemResponse> PurchasedProducts { get; set; } = null!;

    public decimal InvoiceBalance { get; set; }

}

public class InvoiceResponseCollection : IResult
{
    public IReadOnlyCollection<InvoiceResponse> Invoices { get; set; } = null!;
}

public class InvoiceMapper : Profile
{
    public InvoiceMapper()
    {
        CreateMap<Invoice, InvoiceResponse>()
            .ForMember(dto => dto.PoNumber, opt => opt.MapFrom(ent => ent.PoNumber.Value))
            .ForMember(dto => dto.Customer, opt => opt.MapFrom(ent => ent.Customer))
            .ForMember(dto => dto.InvoiceBalance, opt => opt.MapFrom(ent => ent.TotalBalance.Value));
    }
}