using System;
using System.Collections.Generic;
using Commands;
using Commands.Data;

namespace Data.Repository
{
    public abstract class BaseDataRepository 
    {
        public List<Command> InitStoragesCommands { get; }
        private readonly Dictionary<string, IDataStorage> _storages = new Dictionary<string, IDataStorage>();
        public event Action<float> OnInitProgress;
        public event Action OnInitComplete = delegate { };

        protected IDataBaseProxy _dbProxy;


        protected BaseDataRepository(IDataBaseProxy dbProxy)
        {
            _dbProxy = dbProxy;
            InitStoragesCommands = new List<Command>();
        }

        public void Init()
        {
            //TODO initialize data proxy by separate command outside of repository
            
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


        protected DataStorage<T> CreateStorage<T>(string collectionName) where T : DataItem, new()
        {
            var dataStorage = new DataStorage<T>(collectionName, _dbProxy);
            _storages.Add(collectionName, dataStorage);
            
            InitStorageCommand<T> command = new InitStorageCommand<T>(dataStorage, _dbProxy);
            InitStoragesCommands.Add(command);
            
            return dataStorage;
        }

        protected virtual void OnDataProxyInitialised(){}


        private void InitStorages()
        {
            CommandSequence sequence = new CommandSequence(InitStoragesCommands.ToArray());
            sequence.OnProgress += OnInitProgress;
            sequence.OnComplete += () =>
            {
                OnInitComplete.Invoke();
            };
            sequence.Execute();
        }

        public T GetSetting<T>(string name)
        {
            return _dbProxy.GetConfigObject<T>(name);
        }
    }



}