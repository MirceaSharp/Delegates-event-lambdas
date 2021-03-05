using System;
using System.Windows;

namespace Delegates_and_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public delegate int Calculate(int value1, int value2); // bepaalt hoe de methode er zal uitzien
        Verbruiksmeter meter = new Verbruiksmeter();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //creating delegate objects and assigning appropriate methods
            //having the EXACT signature of the delegate
            Calculate delAdd = new Calculate(Add);
            Calculate delSub = new Calculate(Sub);

            //uitvoeren van delegate kan via methode invoke of ronde haakjes na delegatenaam 
            lblDelegate.Content = "Adding two values: " + delAdd.Invoke(10, 6) + Environment.NewLine;
            lblDelegate.Content += "Subtracting two values: " + delSub(10, 4) + Environment.NewLine;

            meter.TeHoogVerbruikEvent += new Verbruiksmeter.VerbruikHandler(meter_TeHoogVerbruikEvent);
        }

        private void btnEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                meter.addVerbruik(int.Parse(txtVerbruik.Text));
                lblResult.Content = "Meterstand: " + meter.Meterstand.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }
        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public int Sub(int value1, int value2)
        {
            return value1 - value2;
        }


        private void meter_TeHoogVerbruikEvent(int stand)
        {
            MessageBox.Show("Je zit met een te hoog verbruik: " + stand.ToString() + ". Doe er iets aan!");
        }

    }
}
