using Data.Repository;

namespace Data.Catalog
{
    public class CatalogDataRepository : BaseDataRepository
    {
        public DataStorage<Currency> Currency;
        public DataStorage<ShopItem> ShopItems;
        public DataStorage<Product> Products;
        public DataStorage<FarmItem> FarmItems;
        
        public CatalogDataRepository(IDataBaseProxy dbProxy) : base(dbProxy)
        {
        }

        public override void Init()
        {
            Currency = CreateStorage<Currency>("currency");
            ShopItems = CreateStorage<ShopItem>("shop");
            Products = CreateStorage<Product>("products");
            FarmItems = CreateStorage<FarmItem>("farmItems");

            _dbProxy.OnInitialized += OnDbInitComplete;
            _dbProxy.Init();
        }
    }
}