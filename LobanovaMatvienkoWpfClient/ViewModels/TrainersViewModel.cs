

using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApiHttpClient;
using System.Collections.ObjectModel;
using System.Net;



namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class TrainersViewModel : BaseViewModel
    {
        private TrainerHttpClient _HttpClient;
        public TrainersViewModel(TrainerHttpClient HttpClient)
        {
            _HttpClient = HttpClient;
            GetTrainers();
        }
        private ObservableCollection<Trainer> _Trainers;
        public ObservableCollection<Trainer> Trainers
        {
            get { return _Trainers; }
            set { _Trainers = value; OnPropertyChanged(); }
        }
        private async void GetTrainers()
        {
            Trainers = new ObservableCollection<Trainer>(await _HttpClient.GetAllAsync());
        }



        private Trainer _CurrentTrainer;
        public Trainer CurrentTrainer
        {
            get { return _CurrentTrainer; }
            set { _CurrentTrainer = value; OnPropertyChanged(); }
        }


        //добавление
        public DelegateCommand AddTrainerCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    AddTrainer();
                });
            }
        }
        private async void AddTrainer()
        {
            await _HttpClient.CreateAsync(CurrentTrainer);
        }


        //Удаление
        public DelegateCommand DeleteTrainerCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    DeleteTrainer();
                });
            }

        }
        private async void DeleteTrainer()
        {

            await _HttpClient.DeleteAsync(CurrentTrainer.TrainerId);
        }

    }
}
