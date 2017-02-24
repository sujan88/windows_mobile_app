using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Visifire.Charts;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Serialization;

namespace Weightlifting.view
{
    public partial class chart : PhoneApplicationPage
    {
        public string id = "";
        public int action_value1, action_value2, action_value3, atm1, atm2, atm3, set1, set2, set3;
        public Day[] daylist = null;
        public chart()
        {
            InitializeComponent();
           

        }




        private void readXml() {
            List<Day> daylists =null;
               
            try
            {
                daylists = new List<Day>();
                
                string filename;
                for (int dayNo = 1; dayNo < 6; dayNo++)
                {
                    filename = "Week " + id + "_Day " + dayNo;
                    using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                       
                        if (ISF.FileExists(filename + ".xml"))
                        {
                            
                            using (IsolatedStorageFileStream str = ISF.OpenFile(filename + ".xml", FileMode.Open))
                            {

                                XmlSerializer serializer = new XmlSerializer(typeof(Day));
                                Day day = (Day)serializer.Deserialize(str);

                                daylists.Add(day);

                         
                              
                            }
                        }
                        else
                        {
                           
                            break;

                        }
                    }


                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }
             daylist = daylists.ToArray();
           
            createBarChart();
        }




        public void createBarChart()
        {
            try{



               
            // Create a new instance of Chart
            Chart chart = new Chart();
            chart.Theme = "Theme1";
            chart.View3D = true;
            chart.ScrollingEnabled = true;

           
           
            // Create a new instance of Title
            Title title = new Title();
 
            // Set title property
            title.Text = "Daily lifts progress";

            // Add title to Titles collection
            chart.Titles.Add(title);

            // Create a new instance of DataSeries
            DataSeries dataSeries = new DataSeries();
            DataSeries dataSeries2 = new DataSeries();
            // Set DataSeries property
            dataSeries.RenderAs = RenderAs.Column;
            dataSeries2.RenderAs = RenderAs.Column;
            dataSeries.LegendText = "Snatch or Clean & Jerk (kg)";
            dataSeries2.LegendText = "Squets (kg)";
            // Create a DataPoint
            DataPoint dataPoint, dataPoint2; 

            for (int i = 0; i < daylist.Length; i++)
            {

               
                // Create a new instance of DataPoint
               
                dataPoint = new DataPoint();
                dataPoint2 = new DataPoint();
                switch(i){
                    case 0:

                         dataPoint.AxisXLabel = "Day 1";
                         dataPoint.YValue = calculateLift(i);
                         dataPoint2.YValue = calculateSquet(i);

                        
                        break;
                    case 1:
                       
                       dataPoint.AxisXLabel = "Day 2";
                       dataPoint.YValue = calculateLift(i);
                       dataPoint2.YValue = calculateSquet(i) ;

                        break;
                    case 2:

                        
                       
                         dataPoint.AxisXLabel = "Day 3 \n  snatch \n C & J";
                         dataPoint.YValue = calculateLift(i);
                         
                         dataPoint2.YValue = calculateSquet(i);
                        
                         break;
                    case 3:
                         dataPoint.AxisXLabel = "Day 4";
                         dataPoint.YValue = calculateLift(i);
                         dataPoint2.YValue = calculateSquet(i);
                         break;
                    case 4: 
                         dataPoint.AxisXLabel = "Day 5";
                         dataPoint.YValue = calculateLift(i);
                         dataPoint2.YValue = calculateSquet(i);
                         break;
                    }
                dataSeries.DataPoints.Add(dataPoint);
                dataSeries2.DataPoints.Add(dataPoint2);

            }

            // Add dataSeries to Series collection.
            chart.Series.Add(dataSeries);
            chart.Series.Add(dataSeries2);

            // Add chart to LayoutRoot
            gridchartbar.Children.Add(chart);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }

            }



        public void createLineChart()
        {
            try
            {




                // Create a new instance of Chart
                Chart chart = new Chart();
                chart.Theme = "Theme2";
                chart.View3D = true;

                // Create a new instance of Title
                Title title = new Title();

                // Set title property
                title.Text = "Daily lifts progress";

                // Add title to Titles collection
                chart.Titles.Add(title);

                // Create a new instance of DataSeries
                DataSeries dataSeries = new DataSeries();
                DataSeries dataSeries2 = new DataSeries();

                // Set DataSeries property
                dataSeries.RenderAs = RenderAs.Spline;
                dataSeries2.RenderAs = RenderAs.Spline;

                // Create a DataPoint
                DataPoint dataPoint, dataPoint2; 
                double wieght = 0, squet=0;
                for (int i = 0; i < daylist.Length; i++)
                {


                    // Create a new instance of DataPoint
                    dataPoint = new DataPoint();
                    dataPoint2 = new DataPoint();
                    switch (i)
                    {
                        case 0:
                            dataPoint.AxisXLabel = "Day 1";
                            dataPoint.YValue = wieght += calculateLift(i);
                            dataPoint2.YValue = squet += calculateSquet(i);
                            break;
                        case 1:
                            dataPoint.AxisXLabel = "Day 2";
                            dataPoint.YValue = wieght += calculateLift(i);
                            dataPoint2.YValue = squet += calculateSquet(i);
                            break;
                        case 2:
                            dataPoint.AxisXLabel = "Day 3";
                            dataPoint.YValue = wieght += calculateLift(i);
                            dataPoint2.YValue = squet += calculateSquet(i);
                            break;
                        case 3:
                            dataPoint.AxisXLabel = "Day 4";
                            dataPoint.YValue = wieght += calculateLift(i);
                            dataPoint2.YValue = squet += calculateSquet(i);
                            break;
                        case 4:
                            dataPoint.AxisXLabel = "Day 5";
                            dataPoint.YValue = wieght += calculateLift(i);
                            dataPoint2.YValue = squet += calculateSquet(i);
                            break;
                    }
                    dataSeries.DataPoints.Add(dataPoint);
                    dataSeries2.DataPoints.Add(dataPoint2);
                }

                // Add dataSeries to Series collection.
                chart.Series.Add(dataSeries);
                chart.Series.Add(dataSeries2);

                // Add chart to LayoutRoot
                gridchartline.Children.Add(chart);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }

        }


        private void setValues(int no) {

            Day day = daylist[no];

            action_value1 = int.Parse(day.action1_value);
            action_value2 = int.Parse(day.action2_value);
            action_value3 = int.Parse(day.action3_value);

            atm1 = int.Parse(day.atm1);
            atm2 = int.Parse(day.atm2);
            atm3 = int.Parse(day.atm3);

            set1 = int.Parse(day.set1);
            set2 = int.Parse(day.set2);
            set3 = int.Parse(day.set3);
        }
        private double calculateLift(int no)
        {
            double lift = 0;
            try
            {
                setValues(no);
               
                lift = (action_value2 * atm2 * set2) ;
                if (no == 2) { lift = (action_value1 * atm1 * set1); }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }


            return lift;
        }
        private double calculateSquet(int no)
        {
            double lift = 0;
            try
            {
                setValues(no);

                lift = (action_value1 * atm1 * set1) + (action_value3 * atm3 * set3);
                if (no == 2) { lift = (action_value2 * atm2 * set2); }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }


            return lift;
        }

      
       

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
           
            id = NavigationContext.QueryString["id"];
            
             readXml();
        }

        
      

        private void back_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void closeHelp_Click(object sender, RoutedEventArgs e)
        {
            helpchart.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void help_Click(object sender, EventArgs e)
        {
            helpchart.Visibility = System.Windows.Visibility.Visible;
       
        }

        private void totalbtn_Click(object sender, RoutedEventArgs e)
        {
            totalbtn.IsEnabled = false;
            daybydaybtn.IsEnabled = true;
            gridchartbar.Visibility = System.Windows.Visibility.Collapsed;
            gridchartline.Visibility = System.Windows.Visibility.Visible;

            createLineChart();
        }

        private void daybydaybtn_Click(object sender, RoutedEventArgs e)
        {
            totalbtn.IsEnabled = true;
            daybydaybtn.IsEnabled = false;
            gridchartbar.Visibility = System.Windows.Visibility.Visible;
            gridchartline.Visibility = System.Windows.Visibility.Collapsed;
          
        }
 }
    }
