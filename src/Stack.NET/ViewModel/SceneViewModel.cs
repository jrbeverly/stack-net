using System.Windows.Input;
using System.Windows.Media.Media3D;
using Stack.NET.Commands;
using Stack.NET.Geometry;
using Stack.NET.Model;
using Stack.NET.Utility;

namespace Stack.NET.ViewModel
{
    internal sealed class SceneViewModel : ObservableObject
    {
        private static readonly Vector3D Up = new Vector3D(0.0, 1.0, 0.0);

        private NamedColor _selectedColor;
        private Model3DGroup _model;
        private double _rotation;

        public SceneViewModel()
        {
            Colors = NamedColorCollection.GetNamedColors();
            _selectedColor = Colors.Random();

            Grid = new Grid
            {
                Length = 5.0D,
                Segment = 6.0D
            };

            Position = new Point3D(50, 50, 50);
            for (var x = 0; x < 6; x++)
            {
                for (var z = 0; z < 6; z++)
                {
                    Grid.Place(x, 0, z, new Cube(_selectedColor.Color));
                }
            }

            Selection = new SelectionViewModel(Grid, InitializeSelectionModel());

            Render();
        }

        /// <summary>A collection of named colors.</summary>
        public NamedColorCollection Colors { get; }

        /// <summary>The currently selected color.</summary>
        public NamedColor SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                RaisePropertyChangedEvent(nameof(Model));
            }
        }

        /// <summary>
        /// Gets the camera of the scene.
        /// </summary>
        public RotateTransform3D Camera => 
            new RotateTransform3D(
                new AxisAngleRotation3D(Up, _rotation),
                new Point3D());

        public Grid Grid { get; }

        public Point3D Position { get; private set; }

        public SelectionViewModel Selection { get; }
        

        // Grid View Model
        public double Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                RaisePropertyChangedEvent(nameof(Camera));
            }
        }

        public Model3DGroup Model
        {
            get
            {
                Render();
                return _model;
            }
        }

        public Model3DGroup SelectionModel => Selection.Model;
        public Transform3D SelectionTransform => Selection.Transform;
        
        public ICommand RotateLeft
        {
            get
            {
                return new ActionCommand(() =>
                {
                    _rotation += MovementConstants.RotateFactor;
                    RaisePropertyChangedEvent(nameof(SelectionModel));
                    RaisePropertyChangedEvent(nameof(Camera));
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
                    RaisePropertyChangedEvent(nameof(SelectionModel));
                    RaisePropertyChangedEvent(nameof(Camera));
                });
            }
        }
        
        public ICommand MoveForward => Selection.MoveForward;
        public ICommand MoveBackward => Selection.MoveBackward;
        public ICommand MoveLeft => Selection.MoveLeft;
        public ICommand MoveRight => Selection.MoveRight;
        public ICommand MoveUp => Selection.MoveUp;
        public ICommand MoveDown => Selection.MoveDown;
        
        public ICommand PlaceCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Grid.Place(Selection.Point, new Cube(SelectedColor.Color));
                    RaisePropertyChangedEvent(nameof(Model));
                    RaisePropertyChangedEvent(nameof(Selection));
                });
            }
        }

        public ICommand DestroyCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Grid.Destroy(Selection.Point);
                    RaisePropertyChangedEvent(nameof(Model));
                    RaisePropertyChangedEvent(nameof(Selection));
                });
            }
        }

        public Model3DGroup InitializeSelectionModel()
        {
            var cubeBuilder = new CubeBuilder(MovementConstants.ScaleFactor + 0.01D);
            var cube = cubeBuilder.Create(System.Windows.Media.Colors.Red, 0, 0, 0);

            var group = new Model3DGroup();
            group.Children.Add(cube);

            return group;
        }

        private void Render()
        {
            var cubeBuilder = new CubeBuilder(MovementConstants.ScaleFactor);
            var grid = new Model3DGroup();
            foreach (var cube in Grid.Values)
            {
                var model = cubeBuilder.Create(cube.Value.Surface);
                var position = Grid.Position(cube.Key);
                model.Transform = new TranslateTransform3D(position.X, position.Y, position.Z);

                grid.Children.Add(model);
            }

            _model = grid;
            var center = Grid.Center();
            _model.Transform = new TranslateTransform3D(-center.X, -center.Y, -center.Z);
        }

        public void Move(double value)
        {
            Position = new Point3D(Position.X - value, Position.Y - value, Position.Z - value);
            RaisePropertyChangedEvent(nameof(Position));
        }
    }
}