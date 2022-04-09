using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestPharmaEF
    {
    public class ViewModelPharmacies : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Pharmacies>? _ListPharmacies;

        public ObservableCollection<Pharmacies> ListPharmacies
            {
            get
                {
                return _ListPharmacies!;
                }
            set
                {
                if (_ListPharmacies != value)
                    {
                    _ListPharmacies = value!;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListPharmacies)));
                    }
                }
            }
        public ViewModelPharmacies()
            {
            ListPharmacies.Clear();
            PharmacieRepository pharmacieRepository = new();
            ListPharmacies = new ObservableCollection<Pharmacies>(pharmacieRepository.GetAll());
            }
        }

    }
