using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MDEV1014PracticeProject.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        bool isBusy = false;
        protected App MyApp = Application.Current as App;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        //Initialize any loading operation
        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);


        protected Task DisplayAlert(string message, string title = "Attention!", string btnTitle = "Ok") {
            return MyApp.MainPage.DisplayAlert(title, message, btnTitle);
        }
    }

}
