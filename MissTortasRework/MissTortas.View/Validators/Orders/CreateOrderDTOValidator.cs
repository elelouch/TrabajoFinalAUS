using FluentValidation;
using MissTortas.View.DTO.Orders;

namespace MissTortas.View.Validators.Orders
{
    public class CreateOrderDTOValidator : AbstractValidator<CreateOrder>
    {
        public long OrderManagerIdMax = long.MaxValue - 1024;
        public long ClientIdMax = long.MaxValue - 1024;
        public long OrderTypeIdMax = long.MaxValue - 1024;
        public long ConsultancyIdMax = long.MaxValue - 1024;
        public int DescriptionMax = 1024;
        public CreateOrderDTOValidator()
        {
            RuleFor(c => c.AskedProducts).NotEmpty();
            RuleForEach(c => c.AskedProducts).NotNull().SetValidator(new AskedProductDTOValidator());
            RuleFor(c => c.ClientGuid).NotEmpty().MaximumLength(512);
            RuleFor(c => c.OrderManagerGuid).MaximumLength(512);
            RuleFor(c => c.ConsultancyId).InclusiveBetween(0, ConsultancyIdMax);
            RuleFor(c => c.Description).MaximumLength(DescriptionMax);
        }

        public class AskedProductDTOValidator : AbstractValidator<AskedProduct>
        {
            public long SaleProductIdMax = long.MaxValue - 1024;
            public decimal MaxAskedQuantity = decimal.MaxValue - 1;
            public AskedProductDTOValidator()
            {
                RuleFor(ap => ap.SaleProductId).NotEmpty().InclusiveBetween(1, SaleProductIdMax);
                RuleFor(ap => ap.QuantityAsked).NotEmpty().InclusiveBetween(1, MaxAskedQuantity);
            }
        }
    }
}
