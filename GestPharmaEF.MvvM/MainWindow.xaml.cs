using System.Windows;

namespace GestPharmaEF
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        public MainWindow()
            {
            // ViewModelPharmacies VMPharmacies = new();
            ViewModelMedecins VMMedecins = new();
            InitializeComponent();
            ListMedecins.ItemsSource = VMMedecins.ListMedecins;
            //ListPharmacies.ItemsSource = VMPharmacies.ListPharmacies;
            }
        }
    }
