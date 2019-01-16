using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using cmp;
using db.Xmls;
using model;
using Wpf.messages;
using Wpf.utility;

namespace win.viewmodels
{
    public class mainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<computerViewModel> _cmps = new ObservableCollection<computerViewModel>();
        private CollectionViewSource collection = new CollectionViewSource();

        public mainViewModel()
        {
            LoadComs();

            collection.Source = _cmps;

            Messenger.Default.Register<User>(this, OnUserReceived);

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateMessageReceived);
        }

        private void OnUpdateMessageReceived(UpdateListMessage person)
        {
            throw new NotImplementedException();
        }

        private void OnUserReceived(User obj)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<computerViewModel> Cmps
        {
            get { return _cmps; }
        }

        public void LoadComs()
        {
            var cmpList = computerSource.Load();
            foreach (var cmp in cmpList)
            {
                _cmps.Add(new computerViewModel(cmp));
            }
        }

        public ICollectionView SourceCollection
        {
            get
            {
                return this.collection.View;
            }
        }

        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set
            {
                _textSearch = value;
                OnPropertyChanged(nameof(TextSearch));

                if (string.IsNullOrEmpty(value))
                    SourceCollection.Filter = null;
                else
                    SourceCollection.Filter = new Predicate<object>(o => ((computerViewModel)o).User.Contains(value));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
