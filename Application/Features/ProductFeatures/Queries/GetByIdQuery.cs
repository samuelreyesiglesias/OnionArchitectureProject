using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Domain;
using Application;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>// using mediator
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>// irequesthandlers uses sys.threadingsu//uses domain
        {
            private readonly IApplicationDbContext _context;//uses aplication..
            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}
