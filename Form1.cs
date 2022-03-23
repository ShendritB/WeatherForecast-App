using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace OOP_Detyra1F2_Projekti11_SH.B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Calculations c1;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
        }
        void getWeather()
        {
            c1 = new Calculations();
            c1.CityPicker(rdBtnPrishtin, rdBtnPrizren, rdBtnSkenderaj,
                       rdBtnObiliq, rdBtnGjilan, rdBtnGjakov,
                       rdBtnDrenas, rdBtnDragash, rdBtnPeja, rdBtnIstog, rdBtnCitySelect, txtBoxCity);
            c1.GetWeatherC(txtBoxCity, picBoxIcon, lblConditions, lblDetails, lblSunrise, lblSunset, lblWindSpeed, lblPressure, lblHum, lblFeelsLike);
            if(rdBtnWeekly.Checked)
            c1.getForecastWeekly(flp,lblHigestTemp,lblLowestTemp,lblAvgTemp,lblClear,lblSnow,lblRain,lblCloud,lblOther,lblForecast);
            else
            c1.getForecastHourly(flp,lblHigestTemp,lblLowestTemp,lblAvgTemp,lblClear,lblSnow,lblRain,lblCloud,lblOther,lblForecast);
        }
    }
}
