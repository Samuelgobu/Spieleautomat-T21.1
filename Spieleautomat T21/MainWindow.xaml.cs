using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spieleautomat_T21
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_spielen_Click(object sender, RoutedEventArgs e)
        {
            ZahlGenerieren(lb1);
            ZahlGenerieren(lb2);
            ZahlGenerieren(lb3);
            //MessageBox.Show("Der Knopf wurde geklickt");
            Gewinn(gewinn, lb1, lb2, lb3);

        }
        static Random rng = new Random();
        static string[] Bilder = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        static int[] Value = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
        private static void ZahlGenerieren(Label lb)
        {
            int index = rng.Next(Bilder.Length); //Zufallszahl von 0 bis 12
            lb.Content = Bilder[index];
        }
        //Schreiben Sie eine Methode, in die 4 Label eingegeben werden.
        //Wenn in 2 von 3 "anzeige" Labeln der geliche Wert steht, wird
        //"2 sind gleich" im Label "gewinn" angezeigt.
        //Wenn alle 3 "anzeige" Label das gleiche zeigen, wird "3 sind gleich"
        //im Label "gewinn" angezeigt.

        private void Gewinn(Label gewinn, Label anzeige1, Label anzeige2, Label anzeige3)
        {
            if (anzeige1.Content == anzeige2.Content)
            {
                string x = anzeige2.Content.ToString();
                if (anzeige3.Content.ToString() == x)
                {
                    gewinn.Content = Wert(anzeige1)*100;
                }

                else
                {
                    gewinn.Content = Wert(anzeige1) * 10;
                }
            }
            else if (anzeige1.Content == anzeige3.Content)
            {
                gewinn.Content = Wert(anzeige1) * 10;
            }
            else if (anzeige2.Content == anzeige3.Content)
            {
                gewinn.Content = Wert(anzeige2) * 10;
            }
            
            else
            {
                gewinn.Content = 0;
            }
          
        }
        /*Gewinne haben folgenden Wert:
            * Wenn ein Symbol 2 mal vorkommt, wird ihr Wert verzehnfacht(*10).
            * Wenn ein Symbol 3 mal vorkommt, wird ihr Wert verhunderfacht (*100)
            * 
            * LEICHT: Die Zahlen haben den Zahlenwert; J hat 11; Q hat 12;
            * K hat 13; A hat 14
            * SCHWIERIGER: Die Zahlen haben den Zahlenwert; J, Q, K haben den Wert 10,
            * A hat 11.
            */
        static private int Wert(Label anzeige)
        {
            string content = anzeige.Content.ToString();
            if (Bilder.Contains(content))
            {
                int index = Array.IndexOf(Bilder, content);
                //Bilder[index] hat den Wert Value[index] 
                return Value[index];
            }
            else 
            // In diesem Programm sollte else einmals erreicht werden.
            // Wenn das Symbol nicht im Array Bilder ist, muss eine Fehler-
            // meldung geben und wir geben einen sinnlosen Wert zurück (z.B.: -1 oder 0)
            {
                MessageBox.Show("Fehler: Das Symbol " + content + " existiert nicht!");
                return 0;
            }
            
        }
    }
}
