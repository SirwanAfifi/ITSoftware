using db.Xmls;
using System.Windows;
using cmp;

namespace win
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

        private void btnProc_Click(object sender, RoutedEventArgs e)
        {
            MyXmlReader myXmlReader = new MyXmlReader();
            
            var list = myXmlReader.procXml(@"C:\All With National Code\");

        }
    }
}
