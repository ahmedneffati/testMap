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
    public class MatchViewModel : INotifyPropertyChanged
    {
        Services<Match> u = new Services<Match>("http://takwira.azurewebsites.net/api/Matchs/");
        private List<Match> _MatchsList;


        public List<Match> MatchsList
        {
            get
            {
                return _MatchsList;
            }

            set
            {
                _MatchsList = value;
                OnPropertyChanged();
            }
        }

        private Match _MatchsAdd = new Match();

        public Match GetMatchsAdd()
        {
            return _MatchsAdd;
        }

        public void SetMatchsAdd(Match value)
        {
            _MatchsAdd = value;
            OnPropertyChanged();
        }

        public Command PostCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.PostModelsAsync(_MatchsAdd);

                });
            }
        }
        public MatchViewModel()
        {
            InitializerDataASYNC();
        }

        public async Task InitializerDataASYNC()
        {

            MatchsList = await u.getModelsAsync();

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

                    await u.PutModelsAsync(_MatchsAdd.Id, _MatchsAdd);
                });
            }
        }
        public Command DeletetCommand
        {
            get
            {

                return new Command(async () =>
                {

                    await u.DeleteModelsAsync(_MatchsAdd.Id);
                });
            }
        }

    }
}
