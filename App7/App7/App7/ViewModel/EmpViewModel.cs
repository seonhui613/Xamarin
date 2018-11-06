using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
namespace App7.ViewModel
{
 public class EmpViewModel : INotifyPropertyChanged
    {
        public string Ename { get; set; }
        private string _Message { get; set; }
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                OnPropertyChanged();
            }
        }
        public Command Introduce
        {
            get
            {
                return new Command(() => { Message = "My name is " + Ename; });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName =
       null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}