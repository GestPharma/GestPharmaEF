using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;

using System.Collections.ObjectModel;
using System.ComponentModel;


namespace GestPharmaEF
    {
    public class ViewModelMedicamentsPrescrits : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<MedicamentsPrescrits>? _ListMedicamentsPrescrits;

        public ObservableCollection<MedicamentsPrescrits> ListMedicamentsPrescrits
            {
            get
                {
                return _ListMedicamentsPrescrits!;
                }
            set
                {
                if (_ListMedicamentsPrescrits != value)
                    {
                    _ListMedicamentsPrescrits = value!;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListMedicamentsPrescrits)));
                    }
                }
            }
        public ViewModelMedicamentsPrescrits()
            {
            ListMedicamentsPrescrits.Clear();
            MedicamentsPrescritRepository medicamentsPrescritRepository = new();
            ListMedicamentsPrescrits = new ObservableCollection<MedicamentsPrescrits>(medicamentsPrescritRepository.GetAll());
            }
        }
    }
