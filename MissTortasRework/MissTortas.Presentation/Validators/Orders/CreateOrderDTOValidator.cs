using FluentValidation;
using MissTortas.Presentation.DTO.Orders;

namespace MissTortas.Presentation.Validators.Orders
{
    public class CreateOrderDTOValidator : AbstractValidator<CreateOrderDTO>
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
            //            public long ClientId { get; set; }
            //public long OrderManagerId { get; set; }
            //public List<AskedProductDTO> AskedProducts { get; set; } = [];
            //public long OrderTypeId { get; set; }
            //public long ConsultancyId { get; set; }
            RuleFor(c => c.ClientId).NotEmpty().InclusiveBetween(1, ClientIdMax);
            RuleFor(c => c.OrderManagerId).NotEmpty().InclusiveBetween(1, OrderManagerIdMax);
            RuleFor(c => c.ConsultancyId).InclusiveBetween(0, ConsultancyIdMax);
            RuleFor(c => c.Description).MaximumLength(DescriptionMax);
        }

        public class AskedProductDTOValidator : AbstractValidator<AskedProductDTO>
        {
            public long SaleProductIdMax = long.MaxValue - 1024;
            public double MaxAskedQuantity = double.MaxValue - 1;
            public AskedProductDTOValidator()
            {
                RuleFor(ap => ap.SaleProductId).NotEmpty().InclusiveBetween(1, SaleProductIdMax);
                RuleFor(ap => ap.QuantityAsked).NotEmpty().InclusiveBetween(1, MaxAskedQuantity);
            }
        }
    }
}
