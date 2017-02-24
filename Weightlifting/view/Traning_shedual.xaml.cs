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
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Controls.Primitives;

using System.ComponentModel;
namespace Weightlifting
{
    public partial class Traning_shedual : PhoneApplicationPage
    {

        string attempt = "";
        string sets = "";
        string persentage = "";

        public Traning_shedual()
        {
            InitializeComponent();
        }

        
        private void back_Click(object sender, EventArgs e)
        {
           
            if (canvas2.Visibility == System.Windows.Visibility.Visible)
            {

              textBlock8.Visibility=  atm3.Visibility = set3.Visibility = action3.Visibility = action3_value.Visibility = System.Windows.Visibility.Visible;
              
               
                canvas1.Visibility = System.Windows.Visibility.Visible;
                canvas2.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if(canvas1.Visibility == System.Windows.Visibility.Visible) {
                canvas1.Visibility = System.Windows.Visibility.Collapsed;
                
            }
            else {
                NavigationService.GoBack();
            }


        }

     

        private int percentage(int num, int percentage)
        {
            int answer = 0;
            try
            {
                answer = num * percentage / 100;
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK); }
            return answer;
        }

        private Day GenerateDayData() 
        {
           
            Day day = new Day();
                    day.action1_value = action1_value.Text;
                    day.action2_value = action2_value.Text;
                    day.action3_value = action3_value.Text;

                    day.atm1 = atm1.Text;
                    day.set1 = set1.Text;

                    day.atm2 = atm2.Text;
                    day.set2 = set2.Text;

                    day.atm3 = atm3.Text;
                    day.set3 = set3.Text;

                  
           // p.Age = Convert.ToInt32(textBox3.Text);
                    return day;
        }
        private void load(string filename)
        {
            
            try
            {
            using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
                   {
                       if (ISF.FileExists(filename+".xml"))
                       {
                           using (IsolatedStorageFileStream str = ISF.OpenFile(filename + ".xml", FileMode.Open))
                           {
                              
                               XmlSerializer serializer = new XmlSerializer(typeof(Day));
                                Day day = (Day)serializer.Deserialize(str);
                                action1_value.Text = day.action1_value;
                                action2_value.Text = day.action2_value;
                                action3_value.Text = day.action3_value;

                               atm1.Text = day.atm1;
                               set1.Text = day.set1;
                               atm2.Text = day.atm2;
                               set2.Text = day.set2;
                               atm3.Text = day.atm3;
                               set3.Text = day.set3;
                              
                           }
                       }
                       else { MessageBox.Show("You have not done this session yet! Create your new session");
                       action1_value.Text = "";
                       action2_value.Text = "";
                       action3_value.Text = "";

                       atm1.Text = "";
                       set1.Text = "";
                       atm2.Text = "";
                       set2.Text = "";
                       atm3.Text = "";
                       set3.Text = "";
                       maxsnatcText.Text = "";
                       maxsquetsText.Text = "";
                               
                       }
                  }
          }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }
        }






        private void save(string filename)
        {
            
            try
            {
                // Write to the Isolated Storage
                XmlWriterSettings x_W_Settings = new XmlWriterSettings();
                x_W_Settings.Indent = true;
                using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                   
                    using (IsolatedStorageFileStream stream = ISF.OpenFile(filename + ".xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Day));
                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, x_W_Settings))
                        {
                            serializer.Serialize(xmlWriter, GenerateDayData());
                            MessageBox.Show("Data save into "+filename + ".xml");
                        }
                    }
                    

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

      

   
        private void delete_Click(object sender, EventArgs e)
        {
            deletemsgbox.Visibility = System.Windows.Visibility.Visible;
        }
        private void okbt_Click(object sender, RoutedEventArgs e)
        {
            deleteFile();
            deletemsgbox.Visibility = System.Windows.Visibility.Collapsed;
           // NavigationService.GoBack();
        }

        private void cancelbt_Click(object sender, RoutedEventArgs e)
        {
            deletemsgbox.Visibility = System.Windows.Visibility.Collapsed;
        }

      
        private void deleteFile() {
            try
            {

                string file = "";
                var settings = IsolatedStorageFile.GetUserStoreForApplication();

                for (int week = 1; week < 5; week++)
                {
                    for (int day = 1; day < 6; day++)
                    {
                        file = "Week " + week + "_Day " + day + ".xml";
                        if (settings.FileExists(file))
                        {
                            settings.DeleteFile(file);

                        }
                    }
                }

                NavigationService.GoBack();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK);


            }
            finally { canvas1.Visibility = System.Windows.Visibility.Visible; }
        }

        
        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton link = (HyperlinkButton)sender;
            canvas1.Tag = link.Content;
            string tag = (string)canvas1.Tag;
            weekblock.Text = tag;
            
            canvas1.Visibility = System.Windows.Visibility.Visible;

        }

        private void hyperlinkButton2_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton link = (HyperlinkButton)sender;
            canvas1.Tag = link.Content;
            string tag = (string)canvas1.Tag;
            weekblock.Text = tag;
            
            load((string)canvas1.Tag);
            canvas1.Visibility = System.Windows.Visibility.Visible;

        }

        private void hyperlinkButton3_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton link = (HyperlinkButton)sender;
            canvas1.Tag = link.Content;
            string tag = (string)canvas1.Tag;
            weekblock.Text = tag;

            load((string)canvas1.Tag);
            canvas1.Visibility = System.Windows.Visibility.Visible;
        }

        private void hyperlinkButton4_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton link = (HyperlinkButton)sender;
            canvas1.Tag = link.Content;
            string tag = (string)canvas1.Tag;
            weekblock.Text = tag;

            load((string)canvas1.Tag);
            canvas1.Visibility = System.Windows.Visibility.Visible;
        }

       
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        private void setbutton_Click(object sender, RoutedEventArgs e)
        {

            if (maxsnatcText.Text != "" && maxsquetsText.Text != "")
            {
                try
                {
                    int maxSnatch = int.Parse(maxsnatcText.Text);
                    int maxSquet = int.Parse(maxsquetsText.Text);

                    action1_value.Text = percentage(maxSquet,  int.Parse(persentage)).ToString();
                    action2_value.Text = percentage(maxSnatch, int.Parse(persentage)).ToString();
                    action3_value.Text = percentage(maxSquet, int.Parse(persentage)).ToString();

                    atm1.Text = atm2.Text = atm3.Text = attempt;
                    set1.Text = set2.Text = set3.Text = sets;

                    //save();
                    setbutton.IsEnabled = false;

                }
                catch (Exception ex) { MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButton.OK); }

            }
            else
            {
                MessageBox.Show("Enter maximum Snatch and full squet !");
            }
        }

        

        private List<string> shedualMaker(string day) { 
            List<string> l1=new List<string>();
            string preValue="";
            string week=(string)canvas1.Tag;
          
            switch (week) {
                case "Week 1": 
                     preValue = "70";  
                     attempt = "5";
                     sets = "3";
                   break;
                case "Week 2": preValue = "80";
                    attempt = "4";
                     sets = "2";break;
                case "Week 3": preValue = "90";
                    attempt = "3";
                     sets = "2";break;
                case "Week 4": preValue = "105";
                    attempt = "1";
                     sets = "3";break;
            }
           switch(day){
               case "Day 1":
                   persentagetext.Text = persentage = preValue;
                   action1.Text = "Full Squets";
                   action2.Text = "Snatch Technique";
                   action3.Text = "Full Squets";
                  
                   break;

               case "Day 2":
                   persentagetext.Text = persentage = preValue;
                   action1.Text = "Front Squets";
                   action2.Text = "Clean & jerk Technique";
                   action3.Text = "Front Squets";
                   attempt = 5 + "";
                   sets = 3 + "";
                   maxlift.Text = "Maximum Clean & Jerk";
                   maxsquet.Text = "Maximum Front Squet";

                  setbutton.BorderBrush= button1.BorderBrush = textBlock1.Foreground = new SolidColorBrush(Colors.Magenta);
                   break;

               case "Day 3":
                   persentagetext.Text = persentage = preValue;
                   action1.Text = "Snatch Technique";
                   action2.Text = "Clean & jerk Technique";
                    textBlock8.Visibility= atm3.Visibility=set3.Visibility =action3.Visibility =action3_value.Visibility = System.Windows.Visibility.Collapsed;
                   attempt = 5 + "";
                   sets = 3 + "";
                    maxlift.Text = "Maximum Snatch";
                   maxsquet.Text = "Maximum Clean & Jerk";
                   setbutton.BorderBrush = button1.BorderBrush = textBlock1.Foreground = new SolidColorBrush(Colors.Purple);
                   break;

               case "Day 4":
                   persentagetext.Text = persentage = preValue;
                   action1.Text = "Full Squets";
                   action2.Text = "Power Snatch";
                   action3.Text = "Full Squets";
                   attempt = 5 + "";
                   sets = 3 + "";
                   maxlift.Text = "Maximum Power Snatch";
                   maxsquet.Text = "Maximum Full Squet";
                   setbutton.BorderBrush = button1.BorderBrush = textBlock1.Foreground = new SolidColorBrush(Colors.Cyan);
                   break;

               case "Day 5":
                   persentagetext.Text = persentage = preValue;
                   action1.Text = "Front Squets";
                   action2.Text = "Power Clean & Jerk";
                   action3.Text = "Front Squets";
                   attempt = 5 + "";
                   sets = 3 + "";
                   maxlift.Text = "Maximum Power Clean & Jerk";
                   maxsquet.Text = "Maximum Front Squet";
                   setbutton.BorderBrush = button1.BorderBrush = textBlock1.Foreground = new SolidColorBrush(Colors.Red);
                   break;
           
           }
            
            return l1;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            save(canvas1.Tag.ToString()+"_"+canvas2.Tag.ToString());
        }


        private void day1_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            showShedual(b);

        }

       
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            showShedual(b);
    
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            showShedual(b);
    
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            showShedual(b);
    
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            showShedual(b);
        }

        private void showShedual(Button sender)
        {
            canvas2.Tag = sender.Tag;
            string day = (string)canvas2.Tag;
            textBlock1.Text = day;
            shedualMaker(day);
            load(canvas1.Tag.ToString() + "_" + canvas2.Tag.ToString());
            canvas2.Visibility = System.Windows.Visibility.Visible;
            canvas1.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void maxsnatcText_TextChanged(object sender, TextChangedEventArgs e)
        {
            setbutton.IsEnabled = true;
        }

        private void maxsquetsText_TextChanged(object sender, TextChangedEventArgs e)
        {
            setbutton.IsEnabled = true;
        }

       
    }
}