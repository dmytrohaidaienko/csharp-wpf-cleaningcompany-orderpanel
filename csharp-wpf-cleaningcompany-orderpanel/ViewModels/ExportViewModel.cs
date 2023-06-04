using System;
using System.Linq;
using ClosedXML.Excel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using csharp_wpf_cleaningcompany_orderpanel.Models;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels.AppContext;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    class ExportViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerRequest> customersRequests;

        private ObservableCollection<HandledRequest> handledRequests;

        private ObservableCollection<ClosedRequest> closedRequests;

        public ObservableCollection<CustomerRequest> CustomersRequests
        {
            get { return customersRequests; }
            set
            {
                customersRequests = value;
                OnPropertyChanged(nameof(CustomersRequests));
            }
        }

        public ObservableCollection<HandledRequest> HandledRequests
        {
            get { return handledRequests; }
            set
            {
                handledRequests = value;
                OnPropertyChanged(nameof(HandledRequests));
            }
        }

        public ObservableCollection<ClosedRequest> ClosedRequests
        {
            get { return closedRequests; }
            set
            {
                closedRequests = value;
                OnPropertyChanged(nameof(ClosedRequests));
            }
        }

        public async Task FillCollections()
        {
            using (var context = new CustomerRequestContext())
            {
                var requests = await Task.Run(() =>
                    context.CustomersRequests.OrderByDescending(cr => cr.Id).ToList());
                CustomersRequests = new ObservableCollection<CustomerRequest>(requests);
            }

            using (var context = new HandledRequestContext())
            {
                var requests = await Task.Run(() =>
                    context.HandledRequests.OrderByDescending(cr => cr.Id).ToList());
                HandledRequests = new ObservableCollection<HandledRequest>(requests);
            }

            using (var context = new ClosedRequestContext())
            {
                var requests = await Task.Run(() =>
                    context.ClosedRequests.OrderByDescending(cr => cr.Id).ToList());
                ClosedRequests = new ObservableCollection<ClosedRequest>(requests);
            }
        }

        public void ExportCustomersRequests()
        {
            String[] columnNames = { "Id", "Full name", "Phone number", "City", "Address", "Type of place" };

            var dataToExport = CustomersRequests.ToList();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Customers requests");

            var headerStyle = workbook.Style;
            headerStyle.Font.Bold = true;
            headerStyle.Fill.BackgroundColor = XLColor.LightGray;

            for (Int32 j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cell(1, j + 1).Value = columnNames[j];
                worksheet.Cell(1, j + 1).Style = headerStyle;
            }

            for (Int32 i = 0; i < dataToExport.Count; i++)
            {
                var customersRequest = dataToExport[i];
                var properties = customersRequest.GetType().GetProperties();

                for (Int32 j = 0; j < properties.Length; j++)
                {
                    var property = properties[j];
                    var value = property.GetValue(customersRequest);

                    if (value != null)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = value.ToString();
                    }
                    else
                    {
                        worksheet.Cell(i + 2, j + 1).Clear();
                    }
                }
            }

            worksheet.Columns().AdjustToContents();

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл Excel";

            if (saveFileDialog.ShowDialog() == true)
            {
                String filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
            }
        }

        public void ExportHandledRequests()
        {
            String[] columnNames = {"Id", "Full name", "Phone number", "City", "Address", "Type of place",
                "Appartment Size", "Work price", "Handled Date", "Appointment Date"};

            var dataToExport = HandledRequests.ToList();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Handled requests");

            var headerStyle = workbook.Style;
            headerStyle.Font.Bold = true;
            headerStyle.Fill.BackgroundColor = XLColor.LightGray;

            for (Int32 j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cell(1, j + 1).Value = columnNames[j];
                worksheet.Cell(1, j + 1).Style = headerStyle;
            }

            for (Int32 i = 0; i < dataToExport.Count; i++)
            {
                var handledRequest = dataToExport[i];
                var properties = handledRequest.GetType().GetProperties();

                for (Int32 j = 0; j < properties.Length; j++)
                {
                    var property = properties[j];
                    var value = property.GetValue(handledRequest);

                    if (value != null)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = value.ToString();
                    }
                    else
                    {
                        worksheet.Cell(i + 2, j + 1).Clear();
                    }
                }
            }

            worksheet.Columns().AdjustToContents();

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл Excel";

            if (saveFileDialog.ShowDialog() == true)
            {
                String filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
            }
        }

        public void ExportClosedRequests()
        {
            String[] columnNames = {"Id", "Full name", "Phone number", "City", "Address", "Type of place",
                "Appartment Size", "Work price", "Handled Date", "Appointment Date"};

            var dataToExport = ClosedRequests.ToList();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Closed requests");

            var headerStyle = workbook.Style;
            headerStyle.Font.Bold = true;
            headerStyle.Fill.BackgroundColor = XLColor.LightGray;

            for (Int32 j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cell(1, j + 1).Value = columnNames[j];
                worksheet.Cell(1, j + 1).Style = headerStyle;
            }

            for (Int32 i = 0; i < dataToExport.Count; i++)
            {
                var closedRequest = dataToExport[i];
                var properties = closedRequest.GetType().GetProperties();

                for (Int32 j = 0; j < properties.Length; j++)
                {
                    var property = properties[j];
                    var value = property.GetValue(closedRequest);

                    if (value != null)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = value.ToString();
                    }
                    else
                    {
                        worksheet.Cell(i + 2, j + 1).Clear();
                    }
                }
            }

            worksheet.Columns().AdjustToContents();

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл Excel";

            if (saveFileDialog.ShowDialog() == true)
            {
                String filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
            }
        }

        public void GroupAllExports()
        {
            String[] customersRequestsColumnNames = { "Id", "Full name", "Phone number", "City", "Address", "Type of place" };
            String[] handledRequestsColumnNames = {"Id", "Full name", "Phone number", "City", "Address", "Type of place",
                "Appartment Size", "Work price", "Handled Date", "Appointment Date"};
            String[] closedRequestsColumnNames = {"Id", "Full name", "Phone number", "City", "Address", "Type of place",
                "Appartment Size", "Work price", "Handled Date", "Appointment Date"};

            var workbook = new XLWorkbook();

            var customersRequestsWorksheet = workbook.Worksheets.Add("Customers requests");
            var customersRequestsData = CustomersRequests.ToList();

            for (Int32 j = 0; j < customersRequestsColumnNames.Length; j++)
            {
                customersRequestsWorksheet.Cell(1, j + 1).Value = customersRequestsColumnNames[j];
            }

            for (Int32 i = 0; i < customersRequestsData.Count; i++)
            {
                var customerRequest = customersRequestsData[i];
                var properties = customerRequest.GetType().GetProperties();

                for (int j = 0; j < properties.Length; j++)
                {
                    var property = properties[j];
                    var value = property.GetValue(customerRequest);

                    if (value != null)
                    {
                        customersRequestsWorksheet.Cell(i + 2, j + 1).Value = value.ToString();
                    }
                    else
                    {
                        customersRequestsWorksheet.Cell(i + 2, j + 1).Clear();
                    }
                }
            }

            customersRequestsWorksheet.Columns().AdjustToContents();

            var handledRequestsWorksheet = workbook.Worksheets.Add("Handled requests");
            var handledRequestsData = HandledRequests.ToList();

            for (Int32 j = 0; j < handledRequestsColumnNames.Length; j++)
            {
                handledRequestsWorksheet.Cell(1, j + 1).Value = handledRequestsColumnNames[j];
            }

            for (Int32 i = 0; i < handledRequestsData.Count; i++)
            {
                var handledRequest = handledRequestsData[i];
                var properties = handledRequest.GetType().GetProperties();

                for (int j = 0; j < properties.Length; j++)
                {
                    var property = properties[j];
                    var value = property.GetValue(handledRequest);

                    if (value != null)
                    {
                        handledRequestsWorksheet.Cell(i + 2, j + 1).Value = value.ToString();
                    }
                    else
                    {
                        handledRequestsWorksheet.Cell(i + 2, j + 1).Clear();
                    }
                }
            }

            handledRequestsWorksheet.Columns().AdjustToContents();

            var closedRequestsWorksheet = workbook.Worksheets.Add("Closed requests");
            var closedRequestsData = ClosedRequests.ToList();

            for (Int32 j = 0; j < closedRequestsColumnNames.Length; j++)
            {
                closedRequestsWorksheet.Cell(1, j + 1).Value = closedRequestsColumnNames[j];
            }

            for (Int32 i = 0; i < closedRequestsData.Count; i++)
            {
                var closedRequest = closedRequestsData[i];
                var properties = closedRequest.GetType().GetProperties();

                for (int j = 0; j < properties.Length; j++)
                {
                    var property = properties[j];
                    var value = property.GetValue(closedRequest);

                    if (value != null)
                    {
                        closedRequestsWorksheet.Cell(i + 2, j + 1).Value = value.ToString();
                    }
                    else
                    {
                        closedRequestsWorksheet.Cell(i + 2, j + 1).Clear();
                    }
                }
            }

            closedRequestsWorksheet.Columns().AdjustToContents();

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл Excel";

            if (saveFileDialog.ShowDialog() == true)
            {
                String filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
            }
        }
    }
}
