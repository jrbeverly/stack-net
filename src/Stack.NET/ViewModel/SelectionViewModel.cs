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

        //TODO: Remove dependency on Grid and move to a 'WorldSystem' instead
        public Grid Grid { get; }

        /// <summary>
        /// Moves the <see cref="Stack.NET.Controls.SelectionCube"/> by a unit vector designating forward.
        /// </summary>
        public ICommand MoveForward
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = Point + Index3D.Forward;
                    OnForward?.Invoke();
                });
            }
        }

        /// <summary>
        /// Moves the <see cref="Stack.NET.Controls.SelectionCube"/> by a unit vector designating backward.
        /// </summary>
        public ICommand MoveBackward
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = Point + Index3D.Backward;
                    OnBackward?.Invoke();
                });
            }
        }

        /// <summary>
        /// Moves the <see cref="Stack.NET.Controls.SelectionCube"/> by a unit vector designating left.
        /// </summary>
        public ICommand MoveLeft
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = Point + Index3D.Left;
                    OnLeft?.Invoke();
                });
            }
        }

        /// <summary>
        /// Moves the <see cref="Stack.NET.Controls.SelectionCube"/> by a unit vector designating right.
        /// </summary>
        public ICommand MoveRight
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = Point + Index3D.Right;
                    OnRight?.Invoke();
                });
            }
        }

        /// <summary>
        /// Moves the <see cref="Stack.NET.Controls.SelectionCube"/> by a unit vector designating up.
        /// </summary>
        public ICommand MoveUp
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = Point + Index3D.Up;
                    OnUp?.Invoke();
                });
            }
        }

        /// <summary>
        /// Moves the <see cref="Stack.NET.Controls.SelectionCube"/> by a unit vector designating down.
        /// </summary>
        public ICommand MoveDown
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Point = Point + Index3D.Down;
                    OnDown?.Invoke();
                });
            }
        }

        /// <summary>
        /// Occurs when the forward command is executed.
        /// </summary>
        public event Action OnForward;

        /// <summary>
        /// Occurs when the backward command is executed.
        /// </summary>
        public event Action OnBackward;

        /// <summary>
        /// Occurs when the left command is executed.
        /// </summary>
        public event Action OnLeft;

        /// <summary>
        /// Occurs when the right command is executed.
        /// </summary>
        public event Action OnRight;

        /// <summary>
        /// Occurs when the up command is executed.
        /// </summary>
        public event Action OnUp;

        /// <summary>
        /// Occurs when the down command is executed.
        /// </summary>
        public event Action OnDown;
    }
}