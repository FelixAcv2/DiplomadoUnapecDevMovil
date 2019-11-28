using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiplomadoShop.Common
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
      
       public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public virtual void LoadData() { }

        string _title;

        /// <summary>
        /// Title para la page asociada
        /// </summary>
        public string Title {
            get {
                return _title;
            }
            set {
                _title = value;
                RaisePropertyChanged();
            }


        }


        bool _isRefresh;
        public bool IsRefresh
        {
            get {
                return _isRefresh;
            }
            set {
                _isRefresh = value;
                RaisePropertyChanged();
             
            }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();

            }
        }

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

    }
}
