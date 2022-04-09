using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;

using System.Collections.ObjectModel;
using System.ComponentModel;


namespace GestPharmaEF
    {
    public class ViewModelMedicaments : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Medicaments>? _ListMedicaments;

        public ObservableCollection<Medicaments> ListMedicaments
            {
            get
                {
                return _ListMedicaments!;
                }
            set
                {
                if (_ListMedicaments != value)
                    {
                    _ListMedicaments = value!;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListMedicaments)));
                    }
                }
            }
        public ViewModelMedicaments()
            {
            ListMedicaments.Clear();
            MedicamentRepository medicamentRepository = new();
            ListMedicaments = new ObservableCollection<Medicaments>(medicamentRepository.GetAll());
            }
        }
    }
