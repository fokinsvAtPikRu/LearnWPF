using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lesson10.Models;

namespace Lesson10.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region NotifyPropertyChanged
        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }        
        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            { 
                _statusMessage = value; 
                OnPropertyChanged(); 
            }
        }
        private bool _isSuccess;
        public bool IsSuccess
        {
            get => _isSuccess;
            set
            {
                _isSuccess = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand LoginCommand { get; }
        private void OnLoginCommandExecute(object? parameter)
        {
            IsSuccess = AuthModel.Authenticate(UserName, Password);
            StatusMessage = IsSuccess ? "Успешные вход! Добро пожаловать!" : "Данные не верные! Введите учетные данные";
        }
        private bool CanLoginCommandExecuted(object? parameter) 
            => !String.IsNullOrEmpty(_userName) && !String.IsNullOrEmpty(_password);
        #endregion
        #region ctor
        public MainWindowViewModel()
        {
            LoginCommand = new RelayCommand(OnLoginCommandExecute, CanLoginCommandExecuted);
            StatusMessage = "Введите учетные данные";
        }
        #endregion
    }
}
