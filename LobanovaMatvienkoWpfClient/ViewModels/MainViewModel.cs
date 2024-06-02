using LobanovaMatvienkoApi.Models;
using LobanovaMatvienkoApiHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        //Clients
        public ClientsViewModel clientsViewModel { get; }
        public MainViewModel(ClientsViewModel _clientsViewModel)
        {
            clientsViewModel = _clientsViewModel;
        }

        
        //Gyms
        public GymsViewModel gymsViewModel { get; }
        public MainViewModel(GymsViewModel _gymsViewModel)
        {
            gymsViewModel = _gymsViewModel;
        }
        

        //Subscriptions
        public SubscriptionsViewModel SubscriptionViewModel { get; }
        public MainViewModel(SubscriptionsViewModel _SubscriptionsViewModel)
        {
            SubscriptionViewModel = _SubscriptionsViewModel;
        }

        //Trainer
        public TrainersViewModel TrainerViewModel { get; }
        public MainViewModel(TrainersViewModel _TrainersViewModel)
        {  TrainerViewModel = _TrainersViewModel;}

        //Workouts
        public WorkoutsViewModel WorkoutViewModel { get; }
        public MainViewModel(WorkoutsViewModel _WorkoutsViewModel)
        {
            WorkoutViewModel = _WorkoutsViewModel;
        }

    }
    
}
