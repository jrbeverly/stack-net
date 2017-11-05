using System.Windows.Input;
using System.Windows.Media.Media3D;
using Stack.NET.Commands;
using Stack.NET.Geometry;
using Stack.NET.Model;
using Stack.NET.Utility;

namespace Stack.NET.ViewModel
{
    public sealed class GridViewModel : ObservableObject
    {
        private readonly Grid _grid;
        private Model3DGroup _model;
        private double _rotation;

        public GridViewModel(Grid grid, Model3DGroup model)
        {
            _grid = grid;
            _model = model;
        }

        public double Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                RaisePropertyChangedEvent(nameof(Camera));
            }
        }

        public double Scale { get; set; }

        public Model3DGroup Model
        {
            get
            {
                _model = Render();
                return _model;
            }
        }

        public RotateTransform3D Camera => new RotateTransform3D(
            new AxisAngleRotation3D(new Vector3D(0.0, 1.0, 0.0), _rotation), new Point3D());

        public ICommand RotateLeft
        {
            get
            {
                return new ActionCommand(() =>
                {
                    _rotation += MovementConstants.RotateFactor;
                    RaisePropertyChangedEvent(nameof(Model));
                });
            }
        }

        public ICommand RotateRight
        {
            get
            {
                return new ActionCommand(() =>
                {
                    _rotation -= MovementConstants.RotateFactor;
                    RaisePropertyChangedEvent(nameof(Model));
                });
            }
        }

        private Model3DGroup Render()
        {
            var cubeBuilder = new CubeBuilder(Scale);
            var grid = new Model3DGroup();
            foreach (var cube in _grid.Cubes)
            {
                var cubeGeometry = cubeBuilder.Create(cube.Surface);
                var position = _grid.Position(cube.Position);
                cubeGeometry.Transform = new TranslateTransform3D(position.X, position.Y, position.Z);

                grid.Children.Add(cubeGeometry);
            }

            var center = _grid.Center();
            grid.Transform = new TranslateTransform3D(-center.X, -center.Y, -center.Z);
            return grid;
        }
    }
}