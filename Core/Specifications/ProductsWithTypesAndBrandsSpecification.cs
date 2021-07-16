using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddIncludes();
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
