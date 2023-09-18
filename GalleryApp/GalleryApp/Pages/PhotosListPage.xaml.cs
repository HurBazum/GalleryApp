using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalleryApp.Models;
using System.Threading.Tasks;
using System.Linq;
using static Xamarin.Essentials.Permissions;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers.Interfaces;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotosListPage : ContentPage
	{
		public ObservableCollection<PhotoInfo> Photos { get; set; } = new ObservableCollection<PhotoInfo>();
		public PhotoInfo SelectedItem;
        public PhotosListPage ()
        {
            InitializeComponent();
			FillPhotos();
        }


		protected override void OnAppearing()
        {
            BindingContext = this;

            base.OnAppearing();
		}

		async void Logout(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		//void FillPhotosFromDraw()
		//{
		//	Photos.Add(new PhotoInfo("spiderOnPaper", "spiderOnPaper.jpg"));
		//	Photos.Add(new PhotoInfo("spiderOnMouse", "spiderOnMouse.jpg"));
  //      }

		void SelectPhoto(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedItem = (PhotoInfo)e.SelectedItem;
        }

        void FillPhotos()
        {
            var photoFromGallery = Directory.GetFiles("/storage/emulated/0/DCIM/Camera/", "*.jpg");

            foreach (var photo in photoFromGallery)
            {
                var file = new FileInfo(photo);

                Photos.Add(new PhotoInfo(file.Name, photo, file.CreationTime));
            }
        }

        async void RemovePhoto(object sender, EventArgs e)
        {
            if(SelectedItem != null)
            {
                var item = SelectedItem;
                // ?
                string path = item.Image.ToString().Substring(6);
                //Photos.Remove(item);
                //File.Delete(path);

                SelectedItem = null;
            }
        }


        async void UpdatePhoto(object sender, EventArgs e)
        {
            if(SelectedItem != null)
            {
                await Navigation.PushAsync(new RenamePhotoPage(SelectedItem));
            }
        }
    }
}