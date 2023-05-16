using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using csharp_wpf_cleaningcompany_orderpanel.Models;

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
    }
}
