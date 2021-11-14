using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification.ProductSpec
{
    public class ProductsWithBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithBrandsSpecification(ProductSpecParams productParams) : base(x =>
              (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
              (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
              &&
              (!productParams.TypeId.HasValue)
        )
        {
            AddInclude(c => c.ProductBrand);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithBrandsSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithBrandsSpecification(int id, string name) : base(x => x.Id == id && x.Name == name)
        {
            AddInclude(x => x.ProductBrand);
        }
    }
}
