using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Stack.NET.Commands;
using Stack.NET.Geometry;
using Stack.NET.Model;
using Stack.NET.Utility;
using Color = System.Drawing.Color;

namespace Stack.NET.ViewModel
{
    using DrawColor = Color;
    using MediaColor = System.Windows.Media.Color;

    internal sealed class SceneViewModel : ObservableObject
    {
        private const double RotateFactor = 3.5D;
        private const double ScaleFactor = 5.0D;

        private readonly SelectionViewModel _selection;
        private Model3DGroup _model;
        private double _rotation;

        public SceneViewModel()
        {
            Grid = new Grid
            {
                Length = 5.0D,
                Segment = 6.0D,
                Surface = Colors.CornflowerBlue
            };

            Position = new Point3D(50, 50, 50);
            ListOfColors = ColorHelper.GetColors();

            for (var x = 0; x < 6; x++)
                for (var z = 0; z < 6; z++)
                    Grid.Place(x, 0, z, Grid.Surface);

            _selection = new SelectionViewModel(this, Grid, InitializeSelectionModel());

            Render();
        }

        public Grid Grid { get; }

        public Point3D Position { get; private set; }

        public IEnumerable<DrawColor> ListOfColors { get; }

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

        public DrawColor SelectedColor
        {
            get => ColorHelper.Convert(CubeColor);
            set
            {
                CubeColor = ColorHelper.Convert(value);
                RaisePropertyChangedEvent(nameof(Model));
            }
        }

        public MediaColor CubeColor
        {
            get => Grid.Surface;
            set => Grid.Surface = value;
        }

        public ICommand RotateLeft
        {
            get
            {
                return new ActionCommand(() =>
                {
                    _rotation += RotateFactor;
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
                    _rotation -= RotateFactor;
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
                    Grid.Place(_selection.Point.X, _selection.Point.Y, _selection.Point.Z,
                        ColorHelper.Convert(SelectedColor));
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
            var cubeBuilder = new CubeBuilder(ScaleFactor + 0.01D);
            var cube = cubeBuilder.Create(Colors.Red, 0, 0, 0);

            var group = new Model3DGroup();
            group.Children.Add(cube);

            return group;
        }

        private void Render()
        {
            var cubeBuilder = new CubeBuilder(ScaleFactor);
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