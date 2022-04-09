using GestPharmaEF.DAL.Repositories;
using GestPharmaEF.Models.Concretes;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace GestPharmaEF
    {
    public class ViewModelOrdonnances : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Ordonnances>? _ListOrdonnances;

        public ObservableCollection<Ordonnances> ListOrdonnances
            {
            get
                {
                return _ListOrdonnances!;
                }
            set
                {
                if (_ListOrdonnances != value)
                    {
                    _ListOrdonnances = value!;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListOrdonnances)));
                    }
                }
            }
        public ViewModelOrdonnances()
            {
            ListOrdonnances.Clear();
            OrdonnanceRepository ordonnanceRepository = new();
            ListOrdonnances = new ObservableCollection<Ordonnances>(ordonnanceRepository.GetAll());
            }
        }
    }