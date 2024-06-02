

using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApiHttpClient;
using System.Collections.ObjectModel;
using System.Net;



namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class WorkoutsViewModel : BaseViewModel
    {
        private WorkoutHttpClient _HttpClient;
        public WorkoutsViewModel(WorkoutHttpClient HttpClient)
        {
            _HttpClient = HttpClient;
            GetWorkouts();
        }
        private ObservableCollection<Workout> _Workouts;
        public ObservableCollection<Workout> Workouts
        {
            get { return _Workouts; }
            set { _Workouts = value; OnPropertyChanged(); }
        }
        private async void GetWorkouts()
        {
            Workouts = new ObservableCollection<Workout>(await _HttpClient.GetAllAsync());
        }



        private Workout _CurrentWorkout;
        public Workout CurrentWorkout
        {
            get { return _CurrentWorkout; }
            set { _CurrentWorkout = value; OnPropertyChanged(); }
        }


        //добавление
        public DelegateCommand AddWorkoutCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    AddWorkout();
                });
            }
        }
        private async void AddWorkout()
        {
            await _HttpClient.CreateAsync(CurrentWorkout);
        }


        //Удаление
        public DelegateCommand DeleteWorkoutCommand
        {
            get
            {
                return new DelegateCommand(o =>
                {
                    DeleteWorkout();
                });
            }

        }
        private async void DeleteWorkout()
        {

            await _HttpClient.DeleteAsync(CurrentWorkout.WorkoutId);
        }

    }
}
