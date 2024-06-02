

using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApiHttpClient;
using System.Collections.ObjectModel;
using System.Net;



namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class GymsViewModel : BaseViewModel
    {
        private GymHttpClient _HttpClient;
        public GymsViewModel(GymHttpClient HttpClient)
        {
            _HttpClient = HttpClient;
            GetGyms();
        }
        private ObservableCollection<Gym> _Gyms;
        public ObservableCollection<Gym> Gyms
        {
            get { return _Gyms; }
            set { _Gyms = value; OnPropertyChanged(); }
        }
        private async void GetGyms()
        {
            Gyms = new ObservableCollection<Gym>(await _HttpClient.GetAllAsync());
        }



        private Gym _CurrentGym;
        public Gym CurrentGym
        {
            get { return _CurrentGym; }
            set { _CurrentGym = value; OnPropertyChanged(); }
        }


        //добавление
        public DelegateCommand AddGymCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    AddGym();
                });
            }
        }
        private async void AddGym()
        {
            await _HttpClient.CreateAsync(CurrentGym);
        }


        //Удаление
        public DelegateCommand DeleteGymCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    DeleteGym();
                });
            }

        }
        private async void DeleteGym()
        {

            await _HttpClient.DeleteAsync(CurrentGym.GymId);
        }

    }
}
