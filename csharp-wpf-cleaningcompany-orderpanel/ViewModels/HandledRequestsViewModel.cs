using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using csharp_wpf_cleaningcompany_orderpanel.Models;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels.AppContext;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    class HandledRequestsViewModel : ViewModelBase
    {
        private ObservableCollection<HandledRequest> handledRequests;

        public ObservableCollection<HandledRequest> HandledRequests
        {
            get { return handledRequests; }
            set
            {
                handledRequests = value;
                OnPropertyChanged(nameof(HandledRequests));
            }
        }

        public async Task FillDataGrid()
        {
            using (var context = new HandledRequestContext())
            {
                var requests = await Task.Run(() =>
                    context.HandledRequests.OrderByDescending(cr => cr.Id).ToList());
                HandledRequests = new ObservableCollection<HandledRequest>(requests);
            }
        }

        public void CloseRequest(HandledRequest item)
        {
            try
            {
                using (var closedRequestContext = new ClosedRequestContext())
                {
                    var closedRequest = new ClosedRequest()
                    {
                        Id = item.Id,
                        CustomersName = item.CustomersName,
                        CustomersPhone = item.CustomersPhone,
                        CustomersCity = item.CustomersCity,
                        CustomersAddress = item.CustomersAddress,
                        CustomersPlace = item.CustomersPlace,
                        AppartmentSize = item.AppartmentSize,
                        WorkPrice = item.WorkPrice,
                        HandledDate = item.HandledDate,
                        AppointmentDate = item.AppointmentDate,
                    };
                    closedRequestContext.ClosedRequests.Add(closedRequest);
                    closedRequestContext.SaveChanges();
                }
                using (var deleteRequestContext = new HandledRequestContext())
                {
                    var deleteRequest = deleteRequestContext.HandledRequests.Find(item.Id);
                    if (deleteRequest != null)
                    {
                        deleteRequestContext.Remove(deleteRequest);
                        deleteRequestContext.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Error to reject request.");
                    }
                }
                    MessageBox.Show("You successfully closed this request!");
            }
            catch 
            { 
                MessageBox.Show("Error! Try close request later!");
            }
        }
    }
}
