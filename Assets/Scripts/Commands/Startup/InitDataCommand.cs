using Data.Repository;

namespace Commands.Startup
{
    public class InitDataCommand : Command
    {
        private BaseDataRepository _baseDataRepository;

        public InitDataCommand(BaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
        }
        
        public override void Execute()
        {
            _baseDataRepository.OnInitComplete += OnInitComplete;
            _baseDataRepository.Init();
        }

        private void OnInitComplete()
        {
            _baseDataRepository.OnInitComplete -= OnInitComplete;
            Complete();
        }
    }
}