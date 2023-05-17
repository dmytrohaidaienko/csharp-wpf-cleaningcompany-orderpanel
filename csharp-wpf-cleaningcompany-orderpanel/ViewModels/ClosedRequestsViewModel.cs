using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using csharp_wpf_cleaningcompany_orderpanel.Models;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels.AppContext;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    class ClosedRequestsViewModel : ViewModelBase
    {
        private ObservableCollection<ClosedRequest> closedRequests;

        public ObservableCollection<ClosedRequest> ClosedRequests
        {
            get { return closedRequests; }
            set
            {
                closedRequests = value;
                OnPropertyChanged(nameof(ClosedRequests));
            }
        }

        public async Task FillDataGrid()
        {
            using (var context = new ClosedRequestContext())
            {
                var requests = await Task.Run(() =>
                    context.ClosedRequests.OrderByDescending(cr => cr.Id).ToList());
                ClosedRequests = new ObservableCollection<ClosedRequest>(requests);
            }
        }
    }
}
