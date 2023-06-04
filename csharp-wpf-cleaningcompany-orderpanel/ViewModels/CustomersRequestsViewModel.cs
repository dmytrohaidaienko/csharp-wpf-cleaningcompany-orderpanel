using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using csharp_wpf_cleaningcompany_orderpanel.Models;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    public class CustomersRequestsViewModel : ViewModelBase
    {
        private ExportViewModel exportViewModel;

        public CustomersRequestsViewModel()
        {
            exportViewModel = new ExportViewModel();
            _ = exportViewModel.FillCollections();
        }

        private ObservableCollection<CustomerRequest> customersRequests;
        public ObservableCollection<CustomerRequest> CustomersRequests
        {
            get { return customersRequests; }
            set
            {
                customersRequests = value;
                OnPropertyChanged(nameof(CustomersRequests));
            }
        }

        public async Task FillDataGrid()
        {
            using (var context = new CustomerRequestContext())
            {
                var requests = await Task.Run(() =>
                    context.CustomersRequests.OrderByDescending(cr => cr.Id).ToList());
                CustomersRequests = new ObservableCollection<CustomerRequest>(requests);
            }
        }

        public void ExportData()
        {
            exportViewModel.ExportCustomersRequests();
        }
    }
}
