

using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApiHttpClient;
using System.Collections.ObjectModel;
using System.Net;



namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private ClientHttpClient _httpClient;
        public ClientsViewModel(ClientHttpClient httpClient)
        {
            _httpClient = httpClient;
            GetClients();
        }
        private ObservableCollection<Client> _Clients;
        public ObservableCollection<Client> Clients
        {
            get { return _Clients; }
            set { _Clients = value; OnPropertyChanged(); }
        }
        private async void GetClients()
        {
            Clients = new ObservableCollection<Client>(await _httpClient.GetAllAsync());
        }



        private Client _CurrentClient;
        public Client CurrentClient
        {
            get { return _CurrentClient; }
            set { _CurrentClient = value; OnPropertyChanged(); }
        }


        //добавление
        public DelegateCommand AddClientCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    AddClient();
                });
            }
        }
        private async void AddClient()
        {
            await _httpClient.CreateAsync(CurrentClient);
        }


        //Удаление
        public DelegateCommand DeleteClientCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    DeleteClient();
                });
            }

        }
        private async void DeleteClient()
        {
            
            await _httpClient.DeleteAsync(CurrentClient.ClientId);
        }

    }
}
