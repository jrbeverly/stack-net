using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Stack.NET.Commands;
using Stack.NET.Model;
using Stack.NET.Utility;

namespace Stack.NET.ViewModel
{
    internal sealed class SelectionViewModel
    {
        public SelectionViewModel(Grid grid, Model3DGroup model)
        {
            Grid = grid;
            Model = model;
            
            SelectedColor = Colors.Black;
        }

        public Transform3D Transform
        {
            get
            {
                var center = Grid.Center();
                var pos = Grid.Position(Point);
                return new TranslateTransform3D(pos.X - center.X, pos.Y - center.Y, pos.Z - center.Z);
            }
        }

        public Color SelectedColor { get; set; }
        public Index3D Point { get; set; }
        public Model3DGroup Model { get; }
        public Grid Grid { get; }

        public ICommand MoveForward
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = new Index3D(Point.X, Point.Y, Point.Z - 1);
                    OnForward?.Invoke();
                });
            }
        }

        public ICommand MoveBackward
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = new Index3D(Point.X, Point.Y, Point.Z + 1);
                    OnBackward?.Invoke();
                });
            }
        }

        public ICommand MoveLeft
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = new Index3D(Point.X + 1, Point.Y, Point.Z);
                    OnLeft?.Invoke();
                });
            }
        }

        public ICommand MoveRight
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = new Index3D(Point.X - 1, Point.Y, Point.Z);
                    OnRight?.Invoke();
                });
            }
        }

        public ICommand MoveUp
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = new Index3D(Point.X, Point.Y + 1, Point.Z);
                    OnUp?.Invoke();
                });
            }
        }

        public ICommand MoveDown
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = new Index3D(Point.X, Point.Y - 1, Point.Z);
                    OnDown?.Invoke();
                });
            }
        }

        public ICommand PlaceCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Grid.Place(Point, new Cube(Point, SelectedColor));
                    OnPlace?.Invoke();
                });
            }
        }

        public ICommand DestroyCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Grid.Destroy(Point.X, Point.Y, Point.Z);
                    OnDestroy?.Invoke();
                });
            }
        }

        public event Action OnForward, OnBackward, OnLeft, OnRight, OnUp, OnDown, OnPlace, OnDestroy;
    }
}