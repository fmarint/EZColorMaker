namespace EZColorMaker
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }

      bool isRandom;
      private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
      {
         if (isRandom) return;
         var red = sldRed.Value;
         var green = sldGreen.Value;
         var blue = sldBlue.Value;

         Color color = Color.FromRgb(red,green, blue);
         SetColor(color);

      }

      private void SetColor(Color color)
      {
         btnGenerateColor.Background = color;
         grdContainer.BackgroundColor = color;
         lblHex.Text = color.ToHex();
      }

      private void btnGenerateColor_Clicked(object sender, EventArgs e)
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
