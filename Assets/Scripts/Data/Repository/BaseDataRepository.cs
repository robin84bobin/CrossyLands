using System;
using System.Collections.Generic;
using Commands;
using Commands.Data;

namespace Data.Repository
{
    public abstract class BaseDataRepository 
    {
        private readonly Dictionary<string, IDataStorage> _storages = new Dictionary<string, IDataStorage>();
        public event Action OnInitComplete = delegate { };

        private List<Command> _initStoragesCommands;
        protected IDataBaseProxy _dbProxy;

        public void Init()
        {
            _dbProxy.OnInitialized += OnDbInitComplete;
            _dbProxy.Init();
        }

        private void OnDbInitComplete()
        {
            _dbProxy.OnInitialized -= OnDbInitComplete;
            
            OnDataProxyInitialised();
            CreateStorages();
            InitStorages();
        }

        protected abstract void CreateStorages();

        public BaseDataRepository(IDataBaseProxy dbProxy)
        {
            _dbProxy = dbProxy;
            _initStoragesCommands = new List<Command>();
        }

        protected DataStorage<T> CreateStorage<T>(string collectionName) where T : DataItem, new()
        {
            var dataStorage = new DataStorage<T>(collectionName, _dbProxy);
            _storages.Add(collectionName, dataStorage);
            
            InitStorageCommand<T> command = new InitStorageCommand<T>(dataStorage, _dbProxy);
            _initStoragesCommands.Add(command);
            
            return dataStorage;
        }

        protected virtual void OnDataProxyInitialised(){}

        private void InitStorages()
        {
            CommandSequence sequence = new CommandSequence(_initStoragesCommands.ToArray());
            sequence.OnComplete += () =>
            {
                OnInitComplete.Invoke();
            };
            CommandManager.Execute(sequence);
        }

        public T GetSetting<T>(string name)
        {
            return _dbProxy.GetConfigObject<T>(name);
        }
    }



}