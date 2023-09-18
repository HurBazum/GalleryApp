using GalleryApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Linq;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RenamePhotoPage : ContentPage
	{
		public PhotoInfo PhotoInfo { get; set; }

		public string ChangeOldName { get; set; } = "Изменить старое имя - ";

		public RenamePhotoPage(PhotoInfo photoInfo)
		{
			InitializeComponent();

			PhotoInfo = photoInfo;
			ChangeOldName += PhotoInfo.Title;
		}

		protected override void OnAppearing()
		{
			BindingContext = this;
			base.OnAppearing();
		}
		void RenamePhoto(object sender, EventArgs e)
        {
            if (!entryName.Text.Contains(".jpg"))
            {
                entryName.Text += ".jpg";
            }

			var str = "/storage/emulated/0/DCIM/Camera/"; //32
			File.Move(string.Concat(str, PhotoInfo.Title), string.Concat(str, entryName.Text));

            PhotoInfo.Title = entryName.Text;
		}

        private void EntryName_TextChanged(object sender, TextChangedEventArgs e)
        {
			if(entryName.Text.Length == 0 || entryName.Text == PhotoInfo.Title)
			{
				renameButton.IsEnabled = false;
			}
			else
            {
                renameButton.IsEnabled = true;
            }
        }
    }
}