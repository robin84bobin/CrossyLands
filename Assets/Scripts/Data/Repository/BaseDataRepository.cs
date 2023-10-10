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

        protected IDataProxyService DBProxyService;


        protected BaseDataRepository(IDataProxyService dbProxyService)
        {
            DBProxyService = dbProxyService;
            InitStoragesCommands = new List<Command>();
        }

        public void Init()
        {
            //TODO initialize data proxy by separate command outside of repository
            
            DBProxyService.OnInitialized += OnDbInitComplete;
            DBProxyService.Init();
        }

        private void OnDbInitComplete()
        {
            DBProxyService.OnInitialized -= OnDbInitComplete;
            
            OnDataProxyInitialised();
            CreateStorages();
            InitStorages();
        }

        protected abstract void CreateStorages();


        protected DataStorage<T> CreateStorage<T>(string collectionName) where T : DataItem, new()
        {
            var dataStorage = new DataStorage<T>(collectionName, DBProxyService);
            _storages.Add(collectionName, dataStorage);
            
            InitStorageCommand<T> command = new InitStorageCommand<T>(dataStorage, DBProxyService);
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
            return DBProxyService.GetConfigObject<T>(name);
        }
    }



}