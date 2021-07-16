using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            AddIncludes();

            if (string.IsNullOrEmpty(sort))
            {
                AddOrderBy(x => x.Name);
                return;
            }

            switch(sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "descAsc":
                    AddOrderBy(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id)
            :base(x => x.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
