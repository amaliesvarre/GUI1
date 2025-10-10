using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SparePartsInventory.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Sikrer at vinduet kan loades selv hvis XAML-generatoren fejlede tidligere
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}