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
    class ProprietaireViewModel : INotifyPropertyChanged
    {
        StringServices<Proprietaire> u = new StringServices<Proprietaire>("http://takwira.azurewebsites.net/api/Proprietaires");
        private List<Proprietaire> _ProprietairesList;
        public List<Proprietaire> ProprietairesList
        {
            get
            {
                return _ProprietairesList;
            }
            set
            {
                _ProprietairesList = value;
                OnPropertyChanged();
            }
        }
        private Proprietaire _ProprietairesAdd = new Proprietaire();
        public Proprietaire ProprietairesAdd
        {
            get
            {
                return _ProprietairesAdd;
            }
            set
            {
                _ProprietairesAdd = value;
                OnPropertyChanged();
            }
        }
        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PostAsync(_ProprietairesAdd);
                    //NavigationPage _navPage = new NavigationPage(new InscriptionProprietaire());
                    // await _navPage.PushAsync(new AjouterTerrain());
                });
            }
        }
        public ProprietaireViewModel()
        {
            InitializerDataASYNC();
        }

        private async Task InitializerDataASYNC()
        {

            ProprietairesList = await u.getModelsAsync();

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

                    await u.PutModelsAsync(_ProprietairesAdd.Email, _ProprietairesAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteModelsAsync(_ProprietairesAdd.Email);
                });
            }
        }

    }
}
