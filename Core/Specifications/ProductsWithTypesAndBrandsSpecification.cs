namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseProductSpecification
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams) : base(productParams)
        {
            AddIncludes();

            AddOrderBy(x => x.Name);

            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (string.IsNullOrEmpty(productParams.Sort))
            {
                return;
            }

            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
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
