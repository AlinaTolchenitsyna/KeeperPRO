using KeeperPRO.UI.Cls;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeeperPRO.UI.Wnds
{
    /// <summary>
    /// Логика взаимодействия для DiagramWindow.xaml
    /// </summary>
    public partial class DiagramWindow : Window
    {
        
        
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public DiagramWindow()
        {
            InitializeComponent();


            var today = DB.KeeperPROEntities.GetContext().Application.ToList();
            today = today.Where(c => c.appointedDate.Equals(DateTime.Today)).ToList();
            int count = today.Count();
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<int> { count }
                }
            };

            

            //Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            Formatter = value => value.ToString("N");

            DataContext = this;

        




        Labels = new[]
            {

                DateTime.Now.Date.AddDays(-6).ToShortDateString().ToString(),
                DateTime.Now.Date.AddDays(-5).ToShortDateString().ToString(),
                DateTime.Now.Date.AddDays(-4).ToShortDateString().ToString(),
                DateTime.Now.Date.AddDays(-3).ToShortDateString().ToString(),
                DateTime.Now.Date.AddDays(-2).ToShortDateString().ToString(),
                DateTime.Now.Date.AddDays(-1).ToShortDateString().ToString(),
                DateTime.Now.Date.ToShortDateString().ToString()

            };
            Formatter = value => value.ToString("N");


            //ApplicationCount = GetCountDay(DateTime.Now.AddDays(-1));
        }

        /*public SeriesCollection SeriesCollectionData
        {
            get => _seriesCollection;
            set
            {
                _seriesCollection = value;
            }
        }

        public Func<double, string> Formatter
        {
            get => _formatter;
            set
            {
                _formatter = value;
            }
        }

        public string[] Labels
        {
            get => _labels;
            set
            {
                _labels = value;
            }
        }

        public int GetCount()
        {
            return DB.KeeperPROEntities.GetContext().Application.ToList().Count();
        }

        public int ApplicationCount
        {
            get { return _applicationCount; }
            set
            {
                _applicationCount = value;
            }
        }


        /*public int GetCountDay(DateTime date)
        {
            int result = 0;
            DateTime from = date.Date;
            DateTime to = date.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(59);
            using (var command = new SqlCommand())
            {
                command.CommandText = "select * from [Application] where appointedDate BETWEEN @from AND @to;";
                command.Parameters.Add("@from", System.Data.SqlDbType.DateTime).Value = from;
                command.Parameters.Add("@to", System.Data.SqlDbType.DateTime).Value = to;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result++;
                    }
                }
            }
            return result;
        }*/

        /*public ChartValues<double> GetCountLastWeek()
        {
            ChartValues<double> result = new ChartValues<double>();
            DateTime cc = DateTime.Now.Date.AddDays(-6);
            for (int i = 0; i <= 6; i++)
            {
                result.Add(GetCountDay(cc));
                cc = cc.AddDays(1);
            }
            return result;
        }*/

        
        
        

    }
}
