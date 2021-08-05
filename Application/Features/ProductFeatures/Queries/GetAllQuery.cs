using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    using MediatR; //for irequest
    using Domain.Entities;//for products
                          //using for ireuest handler interface
    using System.Threading;
    using Application.Interfaces;//for iaplication db context
    using Microsoft.EntityFrameworkCore;

    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

        
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();//using microsoft net framework
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
