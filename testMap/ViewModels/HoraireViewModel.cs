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
    public class HoraireViewModel : INotifyPropertyChanged
    {
        Services<Horaire> u = new Services<Horaire>("http://takwira.azurewebsites.net/api/Horaires/");
        private List<Horaire> _HorairesList;


        public List<Horaire> HorairesList
        {
            get
            {
                return _HorairesList;
            }

            set
            {
                _HorairesList = value;
                OnPropertyChanged();
            }
        }

        private Horaire _HorairesAdd = new Horaire();

        public Horaire GetHorairesAdd()
        {
            return _HorairesAdd;
        }

        public void SetHorairesAdd(Horaire value)
        {
            _HorairesAdd = value;
            OnPropertyChanged();
        }

        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PostModelsAsync(_HorairesAdd);

                });
            }
        }
        public HoraireViewModel()
        {
            InitializerDataASYNC();
        }

        public async Task InitializerDataASYNC()
        {

            HorairesList = await u.getModelsAsync();

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

                    await u.PutModelsAsync(_HorairesAdd.Id, _HorairesAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteModelsAsync(_HorairesAdd.Id);
                });
            }
        }

    }
}
