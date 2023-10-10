using Data.Catalog;
using UnityEngine;
using Zenject;

namespace Data.User
{
    public class UserDataRepository : Repository.BaseDataRepository, IFixedTickable
    {
        public const string CURRENCY = "currency";
        public const string SHOP = "shop";
        public const string PRODUCTS = "products";
        public const string FARM_ITEMS = "farmItems";
        public const string CELLS = "cells";
        public const string GRID = "grid";

        public  DataStorage<UserCurrency> Currency;

        public UserDataRepository(IDataBaseProxy dbProxy, CatalogDataRepository catalogDataRepository) : base(dbProxy) 
        {
            _catalogDataRepository = catalogDataRepository;
        }

        private CatalogDataRepository _catalogDataRepository;

        public override void Init()
        {
            Currency = CreateStorage<UserCurrency>(CURRENCY);

            _dbProxy.OnInitialized += OnDbInitComplete;
            _dbProxy.Init();

            if (!_dbProxy.CheckSourceExist())
            {
                InitStartValuesFrom(_catalogDataRepository);
            }
        }

        private void InitStartValuesFrom(CatalogDataRepository catalogData)
        {
            foreach (Currency currency in catalogData.Currency.GetAll())
            {
                UserCurrency c = new UserCurrency(){Type = currency.Type, CatalogDataId = currency.Id, Value = currency.Value};
                this.Currency.Set(c, currency.Id, true);
            }
            
            SaveAll();
        }

        private static bool _needSave;

        public static void Save()
        {
            _needSave = true;
        }

        private float deltaTime;

        public void FixedTick()
        {
            deltaTime += Time.fixedDeltaTime;
            if (deltaTime < 1f)
                return;
            deltaTime = 0f;
            
            if (_needSave)
            {
                _needSave = false;
                SaveAll();
            }
        }
        
        protected void SaveAll()
        {
            Currency.SaveData();
            // ShopItems.SaveData();
            // FarmItems.SaveData();
            // Products.SaveData();
            // Cells.SaveData();
        }
    }
}