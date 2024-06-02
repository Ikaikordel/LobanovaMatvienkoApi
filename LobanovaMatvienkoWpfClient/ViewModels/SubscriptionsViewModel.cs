

using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApiHttpClient;
using System.Collections.ObjectModel;
using System.Net;



namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class SubscriptionsViewModel : BaseViewModel
    {
        private SubscriptionHttpClient _HttpClient;
        public SubscriptionsViewModel(SubscriptionHttpClient HttpClient)
        {
            _HttpClient = HttpClient;
            GetSubscriptions();
        }
        private ObservableCollection<Subscription> _Subscriptions;
        public ObservableCollection<Subscription> Subscriptions
        {
            get { return _Subscriptions; }
            set { _Subscriptions = value; OnPropertyChanged(); }
        }
        private async void GetSubscriptions()
        {
            Subscriptions = new ObservableCollection<Subscription>(await _HttpClient.GetAllAsync());
        }



        private Subscription _CurrentSubscription;
        public Subscription CurrentSubscription
        {
            get { return _CurrentSubscription; }
            set { _CurrentSubscription = value; OnPropertyChanged(); }
        }


        //добавление
        public DelegateCommand AddSubscriptionCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    AddSubscription();
                });
            }
        }
        private async void AddSubscription()
        {
            await _HttpClient.CreateAsync(CurrentSubscription);
        }


        //Удаление
        public DelegateCommand DeleteSubscriptionCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    DeleteSubscription();
                });
            }

        }
        private async void DeleteSubscription()
        {

            await _HttpClient.DeleteAsync(CurrentSubscription.SubscriptionId);
        }

    }
}
