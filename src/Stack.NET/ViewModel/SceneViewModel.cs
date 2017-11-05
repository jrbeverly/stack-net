using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Stack.NET.Commands;
using Stack.NET.Geometry;
using Stack.NET.Model;
using Stack.NET.Utility;

namespace Stack.NET.ViewModel
{
    internal sealed class SceneViewModel : ObservableObject
    {
        private readonly SelectionViewModel _selection;
        private Model3DGroup _model;
        private double _rotation;
        private NamedColor _defaultNamedColor;

        public SceneViewModel()
        {
            Grid = new Grid
            {
                Length = 5.0D,
                Segment = 6.0D,
                Surface = Colors.CornflowerBlue
            };

            Position = new Point3D(50, 50, 50);
            ListOfColors = ColorHelper.GetNamedColors();
            _defaultNamedColor = ListOfColors.First(p => p.Name == "CornflowerBlue");

            for (var x = 0; x < 6; x++)
                for (var z = 0; z < 6; z++)
                    Grid.Place(x, 0, z, new Cube(new Index3D(x, 0, z), Grid.Surface));

            _selection = new SelectionViewModel(Grid, InitializeSelectionModel());

            Render();
        }

        public Grid Grid { get; }

        public Point3D Position { get; private set; }

        public ColorCollection ListOfColors { get; }

        public SelectionViewModel Selection => _selection;

        public RotateTransform3D Camera => new RotateTransform3D(
            new AxisAngleRotation3D(new Vector3D(0.0, 1.0, 0.0), _rotation),
            new Point3D());

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

        public NamedColor SelectedColor
        {
            get => _defaultNamedColor;
            set
            {
                _defaultNamedColor = value;
                Grid.Surface = _defaultNamedColor.Color;
                RaisePropertyChangedEvent(nameof(Model));
            }
        }
        
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

        public ICommand PlaceCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Grid.Place(_selection.Point, new Cube(_selection.Point, SelectedColor.Color));
                    RaisePropertyChangedEvent(nameof(Model));
                    RaisePropertyChangedEvent(nameof(Selection));
                });
            }
        }

        public ICommand MoveForward => _selection.MoveForward;
        public ICommand MoveBackward => _selection.MoveBackward;
        public ICommand MoveLeft => _selection.MoveLeft;
        public ICommand MoveRight => _selection.MoveRight;
        public ICommand MoveUp => _selection.MoveUp;
        public ICommand MoveDown => _selection.MoveDown;
        public ICommand DestroyCommand => _selection.DestroyCommand;

        public Model3DGroup InitializeSelectionModel()
        {
            var cubeBuilder = new CubeBuilder(MovementConstants.ScaleFactor + 0.01D);
            var cube = cubeBuilder.Create(Colors.Red, 0, 0, 0);

            var group = new Model3DGroup();
            group.Children.Add(cube);

            return group;
        }

        private void Render()
        {
            var cubeBuilder = new CubeBuilder(MovementConstants.ScaleFactor);
            var grid = new Model3DGroup();
            foreach (var cube in Grid.Cubes)
            {
                var model = cubeBuilder.Create(cube.Surface);
                var position = Grid.Position(cube.Position);
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