using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GalleryApp.Models;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotoPage : ContentPage
	{
		public ImageSource Src { get; set; }
		public string ImageTitle { get; set; } = string.Empty;
		public PhotoPage(PhotoInfo image)
		{
			InitializeComponent ();
			Src = image.Image;
			ImageTitle = image.Title;
		}
        protected override void OnAppearing()
        {
            BindingContext = this;

            base.OnAppearing();
        }
    }
}