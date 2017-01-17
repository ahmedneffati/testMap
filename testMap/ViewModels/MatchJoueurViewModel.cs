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
    public class MatchJoueurViewModel : INotifyPropertyChanged
    {
        Services<MatchJoueur> u = new Services<MatchJoueur>("http://takwira.azurewebsites.net/api/MatchJoueurs/");
        private List<MatchJoueur> _MatchJoueursList;


        public List<MatchJoueur> MatchJoueursList
        {
            get
            {
                return _MatchJoueursList;
            }

            set
            {
                _MatchJoueursList = value;
                OnPropertyChanged();
            }
        }

        private MatchJoueur _MatchJoueursAdd = new MatchJoueur();

        public MatchJoueur GetMatchJoueursAdd()
        {
            return _MatchJoueursAdd;
        }

        public void SetMatchJoueursAdd(MatchJoueur value)
        {
            _MatchJoueursAdd = value;
            OnPropertyChanged();
        }

        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PostModelsAsync(_MatchJoueursAdd);

                });
            }
        }
        public MatchJoueurViewModel()
        {
            InitializerDataASYNC();
        }

        public async Task InitializerDataASYNC()
        {

            MatchJoueursList = await u.getModelsAsync();

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

                    await u.PutModelsAsync(_MatchJoueursAdd.Id, _MatchJoueursAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteModelsAsync(_MatchJoueursAdd.Id);
                });
            }
        }

    }
}
