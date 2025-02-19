﻿using System;
using System.ComponentModel;

namespace EasyProject.Model
{
        public class Notifier : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        } 
}
