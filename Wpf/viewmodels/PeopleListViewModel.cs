using data.services;
using model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System;
using Wpf.utility;
using Wpf.messages;

namespace Wpf.viewmodels
{
    public class PeopleListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        

        private User selectedUser;

        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                RaisePropertyChanged("SelectedUser");
            }
        }


        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }

        

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        private UserService userService;
        private DialogService dialogService;
        private void LoadData()
        {
            users = userService.GetData().ToObservableCollection();
            dialogService = new DialogService();
            LoadCommands();
        }
        private void EditPerson(object obj)
        {
            Messenger.Default.Send<User>(selectedUser);
            dialogService.ShowDialog();
        }

        public PeopleListViewModel()
        {
            userService = new UserService();
            LoadData();
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditPerson, CanEditPerson);
            DeleteCommand = new CustomCommand(DeletePerson, CanDeletePerson);
        }

        private bool CanDeletePerson(object obj)
        {
            throw new NotImplementedException();
        }

        private void DeletePerson(object obj)
        {
            userService.DeleteUser(SelectedUser);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage { });
        }

        private bool CanEditPerson(object obj)
        {
            // در اینجا می‌توان چک کرد که آیا آیتم انتخاب شده است یا خیر
            // if (SelectedPerson != null)
            //     return true;
            //  return false;
            return true;
        }
        
    }
}
