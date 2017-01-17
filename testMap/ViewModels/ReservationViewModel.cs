using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testMap.Models;
using testMap.Services;
using testMap.Views;
using Xamarin.Forms;

namespace testMap.ViewModels
{
    public class ReservationViewModel : INotifyPropertyChanged
    {
        Services<Reservation> u = new Services<Reservation>("http://takwira.azurewebsites.net/api/Reservations/");
        private List<Reservation> _ReservationsList;


        public List<Reservation> ReservationsList
        {
            get
            {
                return _ReservationsList;
            }

            set
            {
                _ReservationsList = value;
                OnPropertyChanged();
            }
        }

        private Reservation _ReservationsAdd = new Reservation();

        public Reservation GetReservationsAdd()
        {
            return _ReservationsAdd;
        }

        public void SetReservationsAdd(Reservation value)
        {
            _ReservationsAdd = value;
            OnPropertyChanged();
        }

        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PostModelsAsync(_ReservationsAdd);

                });
            }
        }
        public ReservationViewModel()
        {
            InitializerDataASYNC();
        }

        public async Task InitializerDataASYNC()
        {

            ReservationsList = await u.getModelsAsync();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public Command PutCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PutModelsAsync(_ReservationsAdd.Id, _ReservationsAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteModelsAsync(_ReservationsAdd.Id);
                });
            }
        }

    }
}
