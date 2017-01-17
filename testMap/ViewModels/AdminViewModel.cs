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
    class AdminViewModel : INotifyPropertyChanged
    {
        StringServices<Admin> u = new StringServices<Admin>("http://takwira.azurewebsites.net/api/Admins");
        private List<Admin> _AdminsList;
        public List<Admin> AdminsList
        {
            get
            {
                return _AdminsList;
            }
            set
            {
                _AdminsList = value;
                OnPropertyChanged();
            }
        }
        private Admin _AdminsAdd = new Admin();
        public Admin AdminsAdd
        {
            get
            {
                return _AdminsAdd;
            }
            set
            {
                _AdminsAdd = value;
                OnPropertyChanged();
            }
        }
        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                  await u.PostAsync(_AdminsAdd);
                   // NavigationPage _navPage = new NavigationPage(new InscriptionAdmin());
                    //await _navPage.PushAsync(new AjouterTerrain());
                });
            }
        }
        public AdminViewModel()
        {
            InitializerDataASYNC();
        }

        private async Task InitializerDataASYNC()
        {

            AdminsList = await u.getModelsAsync();

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

                    await u.PutModelsAsync(_AdminsAdd.Email, _AdminsAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteModelsAsync(_AdminsAdd.Email);
                });
            }
        }

    }
}
