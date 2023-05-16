using System;
using System.Windows;
using csharp_wpf_cleaningcompany_orderpanel.Models;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    internal class CustomersRequestsDialogViewModel
    {
        private Object row;

        public CustomersRequestsDialogViewModel(Object row)
        {
            this.row = row;
        }

        public void RejectRequest()
        {
            dynamic rejectRow = row;
            using (var rejectRequestContext = new CustomerRequestContext())
            {
                var rejectRequest = rejectRequestContext.CustomersRequests.Find(rejectRow.Id);
                if (rejectRequest != null)
                {
                    rejectRequestContext.Remove(rejectRequest);
                    rejectRequestContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Error to reject request.");
                }
            }
        }

        public void HandleRequest(String size, String price, DateTime todayDate, DateTime selectedDate)
        {
            dynamic handledRow = row;
            using (var handleReguestContext = new HandledRequestContext())
            {
                var handledRequest = new HandledRequest()
                {
                    Id = handledRow.Id,
                    CustomersName = handledRow.CustomersName,
                    CustomersPhone = handledRow.CustomersPhone,
                    CustomersCity = handledRow.CustomersCity,
                    CustomersAddress = handledRow.CustomersAddress,
                    CustomersPlace = handledRow.CustomersPlace,
                    AppartmentSize = Int32.Parse(size),
                    WorkPrice = Int32.Parse(price),
                    HandledDate = todayDate,
                    AppointmentDate = selectedDate,
                };
                handleReguestContext.HandledRequests.Add(handledRequest);
                handleReguestContext.SaveChanges();
                RejectRequest();
            }
        }
    }
}
