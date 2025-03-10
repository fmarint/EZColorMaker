using CommunityToolkit.Maui.Alerts;
using System.Threading.Tasks;

namespace EZColorMaker
{
   public partial class MainPage : ContentPage
   {

      public MainPage()
      {
         InitializeComponent();
         GenerateRandomColor();
      }

      bool isRandom;
      string hexColor = "";
      private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
      {
         if (isRandom) return;
         var red = sldRed.Value;
         var green = sldGreen.Value;
         var blue = sldBlue.Value;

         Color color = Color.FromRgb(red, green, blue);
         SetColor(color);
      }
      private void btnGenerateColor_Clicked(object sender, EventArgs e)
      {
         GenerateRandomColor();
      }
      private async void imgBtnCopy_Clicked(object sender, EventArgs e)
      {
         await Clipboard.SetTextAsync(hexColor);
         var toast = Toast.Make("Color copied to clipboard", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
         await toast.Show();
      }
      private void SetColor(Color color)
      {
         btnGenerateColor.Background = color;
         grdContainer.BackgroundColor = color;
         lblTitle.TextColor = color;
         hexColor = color.ToHex();
         lblHex.Text = hexColor;

      }
      private void GenerateRandomColor()
      {
         isRandom = true;
         var random = new Random();
         var color = Color.FromRgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256));

         SetColor(color);

         sldRed.Value = color.Red;
         sldBlue.Value = color.Blue;
         sldGreen.Value = color.Green;
         isRandom = false;
      }
   }
}
