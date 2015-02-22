using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.XamForms.UserDialogs;
using Blacksun.Mvvm;
using Blacksun.XamForms.Sample.Core.Model;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace Blacksun.XamForms.Sample.Core.ViewModels
{
    public class MainViewModel : ViewModel
    {

        private readonly IUserDialogService dialogService;

        public MainViewModel()
        {
            dialogService = DependencyService.Get<IUserDialogService>();
            Customers = new ObservableCollection<Customer>();
            Customers.Add(new Customer(3780,"Angel Calvas"));
            Customers.Add(new Customer(1987,"Adrian Santiago"));
            Customers.Add(new Customer(1598,"Yamilet Contreras"));
            Customers.Add(new Customer(1234,"Alexis Enriquez"));
            Customers.Add(new Customer(4730,"Alex Lopez"));
            
        }

        private string _lorem = "Lorem ipsum dolor sit amet,";
        public string Lorem
        {
            get { return _lorem; }
            set
            {
                _lorem = value;
                OnPropertyChanged();
            }
        }

        

        private string _property = "Lorem Ipsum Dolorem";
        public string Property
        {
            get { return _property; }
            set { _property = value; OnPropertyChanged();}
        }

        private string _watermarkProperty = "";
        public string WatermarkProperty
        {
            get { return _watermarkProperty; }
            set { _watermarkProperty = value; OnPropertyChanged(); }
        }

        public ICommand LoadingCommand { 
             get { 
                 return new Command(async () => {
                     using (dialogService.Loading("Loading..."))  
                         await Task.Delay(TimeSpan.FromSeconds(3)); 
                 }); 
             } 
         } 

        public ICommand ProgressCommand { 
             get { 
                 return new Command(async () => { 
                     var cancelled = false; 
 
 
                     using (var dlg = dialogService.Progress("Test Progress")) { 
                         dlg.SetCancel(() => cancelled = true); 
                         while (!cancelled && dlg.PercentComplete < 100) { 
                             await Task.Delay(TimeSpan.FromMilliseconds(100)); 
                             dlg.PercentComplete += 2; 
                         } 
                     } 
                                       
                 }); 
             } 
         }


        private int _customerID;
        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        public ImageSource ImageSource
        {
            get
            {

                return ImageSource.FromResource("Blacksun.XamForms.Sample.Core.Images.bioshock.jpg");

            }
        }

        private int _sliderValue;
        public int SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                OnPropertyChanged();
            }
        }


    }
}
