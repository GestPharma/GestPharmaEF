using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestPharmaEF
    {
    public class ViewModelArmoires : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Armoires>? _ListArmoires;

        public ObservableCollection<Armoires> ListArmoires
            {
            get
                {
                return _ListArmoires!;
                }
            set
                {
                if (_ListArmoires != value)
                    {
                    _ListArmoires = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListArmoires)));
                    }
                }
            }

        public ViewModelArmoires()
            {
            ListArmoires.Clear();
            ArmoireRepository ArmoireRepository = new();
            ListArmoires = new ObservableCollection<Armoires>(ArmoireRepository.GetAll());
            }
        }
    }
