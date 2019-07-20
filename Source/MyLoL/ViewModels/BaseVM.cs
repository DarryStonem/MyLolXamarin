using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MvvmHelpers;
using Xamarin.Forms;
using System.Linq;

namespace MyLoL.ViewModels
{
    public class BaseVM : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public Page CurrentPage => Navigation?.NavigationStack?.Last();

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
    }
}