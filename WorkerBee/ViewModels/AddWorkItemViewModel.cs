using System.Windows.Input;
using WorkerBee.Base;
using WorkerBee.Models;
using WorkerBee.Views;
using RelayCommand = WorkerBee.Base.RelayCommand;

namespace WorkerBee.ViewModels
{
    public class AddWorkItemViewModel : ObservableObject, IAddWorkItemViewModel
    {
        private IAddWorkItemModel _addWorkItemModel;

        public AddWorkItemViewModel(IAddWorkItemModel addWorkItemModel)
        {
            _addWorkItemModel = addWorkItemModel;

            SaveButtonCommand = new RelayCommand(OnSaveButtonCommand);
        }

        public ICommand SaveButtonCommand { get; set; }

        public string AddWorkItemTextBoxText
        {
            get { return _addWorkItemModel.AddWorkItemTextBoxText; }
            set
            {
                _addWorkItemModel.AddWorkItemTextBoxText = value;
                NotifyPropertyChanged("AddWorkItemTextBoxText");
            }
        }

        private void OnSaveButtonCommand(object param)
        {
            if (!string.IsNullOrEmpty(AddWorkItemTextBoxText))
            {
                _addWorkItemModel.Create();
            }
        }
    }
}
