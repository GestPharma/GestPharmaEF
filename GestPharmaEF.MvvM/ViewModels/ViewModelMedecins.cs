using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace GestPharmaEF
    {
    public class ViewModelMedecins : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Medecins>? _ListMedecins;

        public ObservableCollection<Medecins> ListMedecins
            {
            get
                {
                return _ListMedecins!;
                }
            set
                {
                if (_ListMedecins != value)
                    {
                    _ListMedecins = value!;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListMedecins)));
                    }
                }
            }
        public ViewModelMedecins()
            {
                //ListMedecins.Clear();
                MedecinRepository medecinRepository = new();
                ListMedecins = new ObservableCollection<Medecins>(medecinRepository.GetAll());
            }
        }
    }

