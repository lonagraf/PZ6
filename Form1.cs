using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        private WeatherDatabase _weather;

        public WeatherForm()
        {
            InitializeComponent();

            _weather = new WeatherDatabase();
            _weather.Initialize();

            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e) {
            List<Weather> CityName = _weather.Weathers.Where(x => x.CityName.Contains(textBox1.Text)).ToList();
            WeatherDataGrid.DataSource = CityName;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, System.EventArgs e) {
            string a = comboBox1.Text;
            List<Weather> _MeasureUnits = _weather.Weathers.Where(x => x.MeasureUnit.ToString() == a).ToList(); ;
            WeatherDataGrid.DataSource = _MeasureUnits;
        }

        private void button1_Click(object sender, System.EventArgs e) {
      
            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void button2_Click(object sender, System.EventArgs e) {

            List<Weather> Temperature = _weather.Weathers.Where(x => x.Temperature > 0).ToList();
            WeatherDataGrid.DataSource = Temperature;
        }

        private void button3_Click(object sender, System.EventArgs e) {

            List<Weather> Temperature = _weather.Weathers.OrderBy(x => x.Temperature).ToList();
            WeatherDataGrid.DataSource=Temperature;
        }
    }
}