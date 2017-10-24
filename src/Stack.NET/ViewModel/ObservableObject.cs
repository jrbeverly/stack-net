using System.ComponentModel;

namespace Stack.NET.ViewModel
{
    /// <summary>Class that wraps an object, so that other classes can notify for Change events.</summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>Event that gets invoked when the Value property changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}