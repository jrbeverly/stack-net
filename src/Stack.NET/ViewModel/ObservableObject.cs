using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Stack.NET.ViewModel
{
    /// <inheritdoc />
    /// <summary>Class that wraps an object, so that other classes can notify for Change events.</summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Raises the <see cref="PropertyChanged"/> event.</summary>
        public void RaisePropertyChangedEvent([CallerMemberName]string propertyName = null)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}