using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;

using System.Collections.ObjectModel;
using System.ComponentModel;


namespace GestPharmaEF
    {
    public class ViewModelArmoiresContenus : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<ArmoiresContenu>? _ListArmoiresContenus;

        public ObservableCollection<ArmoiresContenu> ListArmoiresContenus
            {
            get
                {
                return _ListArmoiresContenus!;
                }
            set
                {
                if (_ListArmoiresContenus != value)
                    {
                    _ListArmoiresContenus = value!;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListArmoiresContenus)));
                    }
                }
            }
        public ViewModelArmoiresContenus()
            {
            ListArmoiresContenus.Clear();
            ArmoiresContenuRepository armoiresContenuRepository = new();
            ListArmoiresContenus = new ObservableCollection<ArmoiresContenu>(armoiresContenuRepository.GetAll());
            }
        }
    }

