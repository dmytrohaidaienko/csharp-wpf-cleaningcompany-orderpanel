using System;
using SkiaSharp;
using System.Linq;
using LiveChartsCore;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using csharp_wpf_cleaningcompany_orderpanel.ViewModels.AppContext;

namespace csharp_wpf_cleaningcompany_orderpanel.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private Int32 _rowCount;
        private Int32 _totalProfit;
        private Int32 _workedAreaCount;
        private Int32 _rowCountByDate;
        private Int32 _totalProfitByDate;
        private Int32 _workedAreaCountByDate;

        public Int32 rowCount
        {
            get { return _rowCount; }
            set
            {
                _rowCount = value;
                OnPropertyChanged(nameof(rowCount));
            }
        }

        public Int32 totalProfit
        {
            get { return _totalProfit; }
            set
            {
                _totalProfit = value;
                OnPropertyChanged(nameof(totalProfit));
            }
        }

        public Int32 workedAreaCount
        {
            get { return _workedAreaCount; }
            set
            {
                _workedAreaCount = value;
                OnPropertyChanged(nameof(workedAreaCount));
            }
        }

        public Int32 totalProfitByDate
        {
            get { return _totalProfitByDate; }
            set
            {
                _totalProfitByDate = value;
                OnPropertyChanged(nameof(totalProfitByDate));
            }
        }

        public Int32 workedAreaCountByDate
        {
            get { return _workedAreaCountByDate; }
            set
            {
                _workedAreaCountByDate = value;
                OnPropertyChanged(nameof(workedAreaCountByDate));
            }
        }

        public Int32 rowCountByDate
        {
            get { return _rowCountByDate; }
            set
            {
                _rowCountByDate = value;
                OnPropertyChanged(nameof(rowCountByDate));
            }
        }

        public DashboardViewModel()
        {
            RowCount();
            TotalProfit();
            WorkedAreaCount();
            RowCountByDate();
            TotalProfitByDate();
            WorkedAreaCountByDate();
            PieChartSeries();
        }

        public void RowCount()
        {
            using (var closedRequestContext = new ClosedRequestContext())
            {
                rowCount = closedRequestContext.ClosedRequests.Count();
            }
        }

        public void TotalProfit()
        {
            using (var closedRequestContext = new ClosedRequestContext())
            {
                totalProfit = closedRequestContext.ClosedRequests.Sum(e => e.WorkPrice);
            }
        }

        public void WorkedAreaCount()
        {
            using (var closedRequestContext = new ClosedRequestContext())
            {
                workedAreaCount = closedRequestContext.ClosedRequests.Sum(e => e.AppartmentSize);
            }
        }

        public void RowCountByDate()
        {
            using (var closedRequestContext = new ClosedRequestContext())
            {
                DateTime currentDate = DateTime.Now;
                DateTime startDateOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
                DateTime endDateOfMonth = startDateOfMonth.AddMonths(1).AddDays(-1);

                rowCountByDate = closedRequestContext.ClosedRequests.Count(e => e.AppointmentDate >= startDateOfMonth && e.AppointmentDate <= endDateOfMonth);
            }
        }

        public void TotalProfitByDate()
        {
            using (var closedRequestContext = new ClosedRequestContext())
            {
                DateTime currentDate = DateTime.Now;
                DateTime startDateOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
                DateTime endDateOfMonth = startDateOfMonth.AddMonths(1).AddDays(-1);

                totalProfitByDate = closedRequestContext.ClosedRequests
                    .Where(e => e.AppointmentDate >= startDateOfMonth && e.AppointmentDate <= endDateOfMonth)
                    .Sum(e => e.WorkPrice);
            }
        }

        public void WorkedAreaCountByDate()
        {
            using (var closedRequestContext = new ClosedRequestContext())
            {
                DateTime currentDate = DateTime.Now;
                DateTime startDateOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
                DateTime endDateOfMonth = startDateOfMonth.AddMonths(1).AddDays(-1);

                workedAreaCountByDate = closedRequestContext.ClosedRequests
                    .Where(e => e.AppointmentDate >= startDateOfMonth && e.AppointmentDate <= endDateOfMonth)
                    .Sum(e => e.AppartmentSize);
            }
        }

        public void PieChartSeries()
        {
            using (var closedRequestContext = new ClosedRequestContext())
            {
                Int32 countKyiv = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Kyiv");
                Int32 countOdesa = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Odesa");
                Int32 countKharkov = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Kharkov");
                Int32 countDnipro = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Dnipro");
                Int32 countZaporozhye = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Zaporozhye");
                Int32 countLviv = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Lviv");
                Int32 countKryvyiPih = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Kryvyi Pih");
                Int32 countMykolaiv = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Mykolaiv");
                Int32 countVinnitsa = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Vinnitsa");
                Int32 countSumy = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "Sumy");
                Int32 countETC = closedRequestContext.ClosedRequests.Count(e => e.CustomersCity == "etc.");

                Series = new ISeries[]
                {
                    new PieSeries<Int32> { Values = new Int32[] { countKyiv }, Name = "Kyiv" },
                    new PieSeries<Int32> { Values = new Int32[] { countOdesa }, Name = "Odesa" },
                    new PieSeries<Int32> { Values = new Int32[] { countKharkov }, Name = "Kharkov" },
                    new PieSeries<Int32> { Values = new Int32[] { countDnipro }, Name = "Dnipro" },
                    new PieSeries<Int32> { Values = new Int32[] { countZaporozhye }, Name = "Zaporozhye" },
                    new PieSeries<Int32> { Values = new Int32[] { countLviv }, Name = "Lviv" },
                    new PieSeries<Int32> { Values = new Int32[] { countKryvyiPih }, Name = "Kryvyi Pih" },
                    new PieSeries<Int32> { Values = new Int32[] { countMykolaiv }, Name = "Mykolaiv" },
                    new PieSeries<Int32> { Values = new Int32[] { countVinnitsa }, Name = "Vinnitsa" },
                    new PieSeries<Int32> { Values = new Int32[] { countSumy }, Name = "Sumy" },
                    new PieSeries<Int32> { Values = new Int32[] { countETC }, Name = "etc." },
                };
            }
        }

        public IEnumerable<ISeries> Series { get; set; }

        public LabelVisual Title { get; set; } =
            new LabelVisual
            {
                Text = "Count of request by cities",
                TextSize = 25,
                Padding = new LiveChartsCore.Drawing.Padding(15),
                Paint = new SolidColorPaint(SKColors.DarkSlateGray)
            };
    }
}
