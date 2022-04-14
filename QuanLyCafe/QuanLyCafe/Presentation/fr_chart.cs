using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCafe.Presentation
{
    public partial class fr_chart : Form
    {

        public string ReturnType { get; set; }
        public string ReturnTitle { get; set; }
        public DataTable ReturnData { get; set; }
        public fr_chart()
        {
            InitializeComponent();
        }

        private void SplineChart()
        {
            this.chart1.Series.Clear();
            this.chart1.Titles.Add(ReturnTitle);
            Series series = this.chart1.Series.Add(ReturnTitle);
            series.ChartType = SeriesChartType.Spline;
            for (int hang = 0; hang <= ReturnData.Rows.Count - 1; hang++)
            {
                if (ReturnTitle == "Bảng dữ liệu thống kê khách hàng" || ReturnTitle == "Bảng dữ liệu thống kê sản phẩm")
                {
                    var titleitem = ReturnData.Rows[hang][1].ToString();
                    float valueitem = float.Parse(ReturnData.Rows[hang][2].ToString());
                    series.Points.AddXY(titleitem, valueitem);
                }
                else
                {
                    var titleitem = ReturnData.Rows[hang][0].ToString();
                    float valueitem = float.Parse(ReturnData.Rows[hang][1].ToString());
                    series.Points.AddXY(titleitem, valueitem);
                }
                
            }
        }

        public void BarChart()
        {
            this.chart1.Series.Clear();
            this.chart1.Palette = ChartColorPalette.EarthTones;
            this.chart1.Titles.Add(ReturnTitle);
            for (int hang = 0; hang <= ReturnData.Rows.Count - 1; hang++)
            {
                if (ReturnTitle == "Bảng dữ liệu thống kê khách hàng" || ReturnTitle == "Bảng dữ liệu thống kê sản phẩm")
                {
                    var titleitem = ReturnData.Rows[hang][1].ToString();
                    string seriesname = titleitem;
                    chart1.Series.Add(seriesname);
                    chart1.Series[seriesname].IsValueShownAsLabel = true;
                    float valueitem = float.Parse(ReturnData.Rows[hang][2].ToString());
                    chart1.Series[seriesname].Points.AddXY(titleitem, valueitem);
                }
                else
                {
                    var titleitem = ReturnData.Rows[hang][0].ToString();
                    string seriesname = titleitem;
                    chart1.Series.Add(seriesname);
                    chart1.Series[seriesname].IsValueShownAsLabel = true;
                    float valueitem = float.Parse(ReturnData.Rows[hang][1].ToString());
                    chart1.Series[seriesname].Points.AddXY(titleitem, valueitem);
                }
            }
        }

        private void PieChart()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Legends.Add("MyLegend");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = ReturnTitle;
            chart1.Legends[0].BorderColor = Color.Black;
            string seriesname = "MySeriesName";
            chart1.Series.Add(seriesname);
            chart1.Series[seriesname].IsValueShownAsLabel = true;
            for (int hang = 0; hang <= ReturnData.Rows.Count - 1; hang++)
            {
                if (ReturnTitle == "Bảng dữ liệu thống kê khách hàng" || ReturnTitle == "Bảng dữ liệu thống kê sản phẩm")
                {
                    chart1.Series[seriesname].ChartType = SeriesChartType.Pie;
                    var titleitem = ReturnData.Rows[hang][1].ToString();
                    float valueitem = float.Parse(ReturnData.Rows[hang][2].ToString());
                    chart1.Series[seriesname].Points.AddXY(titleitem, valueitem);
                }
                else
                {
                    chart1.Series[seriesname].ChartType = SeriesChartType.Pie;
                    var titleitem = ReturnData.Rows[hang][0].ToString();
                    float valueitem = float.Parse(ReturnData.Rows[hang][1].ToString());
                    chart1.Series[seriesname].Points.AddXY(titleitem, valueitem);
                }
            }
        }

        private void fr_chart_Load(object sender, EventArgs e)
        {
            switch (ReturnType)
            {
                case "Line":
                    SplineChart();
                    break;
                case "Bar":
                    BarChart();
                    break;
                case "Pie":
                    PieChart();
                    break;
            }
        }
    }
}
