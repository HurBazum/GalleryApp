using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace GalleryApp.Models
{
    public class PhotoInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Guid Id { get; set; }

        string title;
        public string Title 
        {
            get => title;
            set
            {
                if(title != value)
                {
                    title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public string CreatedDate { get; }
        public ImageSource Image { get; set; }

        public PhotoInfo(string _title = null, ImageSource imageSource = null, DateTime createdDate = default)
        {
            Id = Guid.NewGuid();
            Title = _title;
            Image = imageSource;
            CreatedDate = createdDate.ToShortDateString();
        }

        void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
