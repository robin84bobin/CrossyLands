using Data.Repository;

namespace Data.Catalog
{
    public class CatalogDataRepository : BaseDataRepository
    {
        public DataStorage<Currency> Currency;
        public DataStorage<ShopItem> ShopItems;
        public DataStorage<Product> Products;
        public DataStorage<FarmItem> FarmItems;
        
        public CatalogDataRepository(IDataProxyService dbProxyService) : base(dbProxyService)
        {
        }

        protected override void CreateStorages()
        {
            Currency = CreateStorage<Currency>("currency");
            ShopItems = CreateStorage<ShopItem>("shop");
            Products = CreateStorage<Product>("products");
            FarmItems = CreateStorage<FarmItem>("farmItems");
        }
    }
}