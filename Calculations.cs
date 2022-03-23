using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace OOP_Detyra1F2_Projekti11_SH.B
{
    class Calculations : Weather
    {
        private int minTemp = 100, maxTemp = -100, avgTemp = 0, totalMin = 0, totalMax = 0;
        private double lon, lat;
        string APIKey = "684beb29c98c2ea28a8de6c3f5c042b4";
        public void GetWeatherC(TextBox txtBoxCity, PictureBox picBoxIcon, Label lblConditions, Label lblDetails,
            Label lblSunrise, Label lblSunset, Label lblWindSpeed, Label lblPressure, Label lblHumidity, Label lblFeelsLike)
        {
            string url = string.Format($"https://api.openweathermap.org/data/2.5/weather?q={txtBoxCity.Text}&appid={APIKey}");
            using (WebClient web = new WebClient())
            {
                try
                {
                    //Creating the HttpWebRequest
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    //Getting the Web Response.
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    //Returns TRUE if the Status code == 200
                    response.Close();

                    var Json = web.DownloadString(url);
                    Weather.root Info = JsonConvert.DeserializeObject<Weather.root>(Json);

                    picBoxIcon.ImageLocation = $"https://openweathermap.org/img/w/{ Info.weather[0].icon}.png";

                    lblConditions.Text = Info.weather[0].main;
                    lblDetails.Text = Info.weather[0].description;
                    lblSunrise.Text = convertDate(Info.sys.sunrise).ToShortTimeString();
                    lblSunset.Text = convertDate(Info.sys.sunset).ToShortTimeString();

                    lblWindSpeed.Text = $"{Info.wind.speed}m/s";
                    lblPressure.Text = $"{Info.main.pressure}hpa";
                    lblHumidity.Text = $"{Info.main.humidity}%";
                    lblFeelsLike.Text = $"{(int)Info.main.feels_like - 273}°C";

                    lon = Info.coord.lon;
                    lat = Info.coord.lat;
                }
                catch
                {

                    MessageBox.Show("City name misspelled", "Note", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }
        public void getForecastWeekly(FlowLayoutPanel flp, Label lblMaxTemp, Label lblMinTemp, Label lblAvgTemp, Label lblClear, Label lblSnow, Label lblRain, Label lblCloudy, Label lblOther, Label lblForecast)
        {
            using (WebClient web = new WebClient())
            {

                string url = string.Format($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=minutely,hourly,alearts&appid={APIKey}");
                var Json = web.DownloadString(url);
                Weather.root Info = JsonConvert.DeserializeObject<Weather.root>(Json);
                Forecast.forecastInfo ForecastInfo = JsonConvert.DeserializeObject<Forecast.forecastInfo>(Json);

                ForecastDailyUC f1;
                flp.Controls.Clear();

                int temp1, temp2, clear = 0, snow = 0, rain = 0, cloudy = 0, other = 0, forecast = 0;
                for (int i = 1; i < 8; i++)
                {
                    f1 = new ForecastDailyUC();
                    f1.picBoxIcon.ImageLocation = $"https://openweathermap.org/img/w/{ForecastInfo.daily[i].weather[0].icon}.png";
                    f1.lblCon.Text = ForecastInfo.daily[i].weather[0].main;
                    f1.lblDes.Text = ForecastInfo.daily[i].weather[0].description;
                    f1.lblTemp.Text = $"↓{(int)(ForecastInfo.daily[i].temp.min - 273)} °C   ↑{(int)(ForecastInfo.daily[i].temp.max - 273)} °C";

                    f1.lblPressure.Text = ForecastInfo.daily[i].pressure + " hPa";
                    f1.lblWind.Text = ForecastInfo.daily[i].wind_speed + " m/s";
                    f1.lblDayTime.Text = convertDate(ForecastInfo.daily[i].dt).DayOfWeek.ToString();
                    flp.Controls.Add(f1);
                    forecast++;

                    temp1 = (int)(ForecastInfo.daily[i].temp.min - 273);
                    totalMin += temp1;
                    if (this.minTemp > temp1)
                        this.minTemp = temp1;

                    temp2 = (int)(ForecastInfo.daily[i].temp.max - 273);
                    totalMax += temp2;
                    if (this.maxTemp < temp2)
                        this.maxTemp = temp2;

                    Counter(f1.lblCon, ref clear, ref snow, ref rain, ref cloudy, ref other);
                }
                this.avgTemp = (totalMin + totalMax) / 14;
                lblMaxTemp.Text = this.maxTemp + " °C";
                lblMinTemp.Text = this.minTemp + " °C";
                lblAvgTemp.Text = this.avgTemp + " °C";
                lblClear.Text = clear.ToString();
                lblSnow.Text = snow.ToString();
                lblRain.Text = rain.ToString();
                lblCloudy.Text = cloudy.ToString();
                lblOther.Text = other.ToString();
                lblForecast.Text = $"Forecast for next {forecast} days";
            }
        }

        public void getForecastHourly(FlowLayoutPanel flp, Label lblMaxTemp, Label lblMinTemp, Label lblAvgTemp, Label lblClear, Label lblSnow, Label lblRain, Label lblCloudy, Label lblOther, Label lblForecast)
        {
            using (WebClient web = new WebClient())
            {

                string url = string.Format($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=current,minutely,daily,alearts&appid={APIKey}");
                var Json = web.DownloadString(url);
                HourlyFC.ForecastInfo hourlyFcInfo = JsonConvert.DeserializeObject<HourlyFC.ForecastInfo>(Json);
                //Forecast.forecastInfo ForecastInfo = JsonConvert.DeserializeObject<Forecast.forecastInfo>(Json);
                ForecastDailyUC f2;
                flp.Controls.Clear();

                int temp1, temp2, clear = 0, snow = 0, rain = 0, cloudy = 0, other = 0, forecast = 0;
                for (int i = 0; i < 24; i++)
                {
                    f2 = new ForecastDailyUC();
                    f2.picBoxIcon.ImageLocation = $"https://openweathermap.org/img/w/{hourlyFcInfo.hourly[i].weather[0].icon}.png";
                    f2.lblCon.Text = hourlyFcInfo.hourly[i].weather[0].main;
                    f2.lblDes.Text = hourlyFcInfo.hourly[i].weather[0].description;
                    f2.lblTemp.Text = $"temp: {(int)(hourlyFcInfo.hourly[i].temp - 273)} °C";

                    f2.lblPressure.Text = "Pres: " + hourlyFcInfo.hourly[i].pressure + " hPa";
                    f2.lblWind.Text = "wind: " + hourlyFcInfo.hourly[i].wind_speed + " m/s";
                    f2.lblDayTime.Text = "Clock: " + convertDate(hourlyFcInfo.hourly[i].dt).Hour + ":00";
                    flp.Controls.Add(f2);
                    forecast++;

                    temp1 = (int)(hourlyFcInfo.hourly[i].temp - 273);
                    if (this.minTemp > temp1)
                        this.minTemp = temp1;

                    temp2 = (int)(hourlyFcInfo.hourly[i].temp - 273);
                    totalMax += temp2;
                    if (this.maxTemp < temp2)
                        this.maxTemp = temp2;

                    Counter(f2.lblCon, ref clear, ref snow, ref rain, ref cloudy, ref other);
                }
                this.avgTemp = totalMax / 24;
                lblMaxTemp.Text = this.maxTemp + " °C";
                lblMinTemp.Text = this.minTemp + " °C";
                lblAvgTemp.Text = this.avgTemp + " °C";
                lblClear.Text = clear + "  hours";
                lblSnow.Text = snow + "  hours";
                lblRain.Text = rain + "  hours";
                lblCloudy.Text = cloudy + "  hours";
                lblOther.Text = other + "  hours";
                lblForecast.Text = $"Forecast for next {forecast} hours";
            }
        }
        private void Counter(Label Con, ref int clear, ref int snow, ref int rain, ref int cloudy, ref int other)
        {
            if (Con.Text == "Clear")
                clear++;
            else if (Con.Text == "Snow")
                snow++;
            else if (Con.Text == "Rain")
                rain++;
            else if (Con.Text == "Clouds")
                cloudy++;
            else
                other++;
        }
        DateTime convertDate(long seconds)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(seconds).ToLocalTime();
            return day;
        }
        public void CityPicker(RadioButton prishtina, RadioButton Prizreni, RadioButton Skenderaj,
                       RadioButton Obiliq, RadioButton Gjilan, RadioButton Gjakove,
                       RadioButton Drenas, RadioButton Dragash, RadioButton Peja, RadioButton istog,
                       RadioButton rdbtnCitySelect, TextBox City)
        {
            if (prishtina.Checked)
                City.Text = "Pristina";

            else if (Prizreni.Checked)
                City.Text = "Prizren";

            else if (Obiliq.Checked)
                City.Text = "Obiliq";

            else if (Skenderaj.Checked)
                City.Text = "Srbica";

            else if (Gjilan.Checked)
                City.Text = "Gjilan";

            else if (Gjakove.Checked)
                City.Text = "Đakovica";

            else if (Drenas.Checked)
                City.Text = "Drenas";

            else if (Dragash.Checked)
                City.Text = "Dragaš";

            else if (Peja.Checked)
                City.Text = "Peja";
            else if (istog.Checked)
                City.Text = "Istog";
            else
            {
                City.Text = City.Text;
            }
        }
    }
}
