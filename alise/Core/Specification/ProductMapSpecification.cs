using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductMapSpecification : BaseSpecification<Product>
    {
        public ProductMapSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductMapSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}