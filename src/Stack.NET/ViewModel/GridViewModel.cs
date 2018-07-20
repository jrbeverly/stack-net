using System.Windows.Input;
using System.Windows.Media.Media3D;
using Stack.NET.Commands;
using Stack.NET.Utility;

namespace Stack.NET.ViewModel
{
    public sealed class GridViewModel : ObservableObject
    {
        public static readonly Vector3D Up = new Vector3D(0.0, 1.0, 0.0);

        private readonly Model3DGroup _model;
        private double _rotation;

        public Transform3D Transform => new RotateTransform3D(new AxisAngleRotation3D(Up, _rotation), new Point3D());

        public double Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                RaisePropertyChangedEvent(nameof(Transform));
            }
        }

        public ICommand RotateLeft
        {
            get { return new ActionCommand(() => { _rotation += MovementConstants.RotateFactor; }); }
        }

        public ICommand RotateRight
        {
            get { return new ActionCommand(() => { _rotation -= MovementConstants.RotateFactor; }); }
        }
    }
}