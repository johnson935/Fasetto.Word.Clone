using Fasetto.Word.Base;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private member
        private Window _mWindow;
        private int _mOuterMarginSize = 10;
        private int _mWindowRadius = 10;
        #endregion

        #region Public Properties
        public double WindowMinimumWidth { get; set; } = 400;
        public double WindowMinimmHeight { get; set; } = 400;
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        public int OuterMarginSize
        {
            get
            {
                return _mWindow.WindowState == WindowState.Maximized ? 0 : _mOuterMarginSize;
            }
            set
            {
                _mOuterMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
        public int WindowRadius
        {
            get
            {
                return _mWindow.WindowState == WindowState.Maximized ? 0 : _mWindowRadius;
            }
            set
            {
                _mWindowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }
        #endregion

        #region Commands
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        #endregion

        #region constructor 
        public WindowViewModel(Window window)
        {
            _mWindow = window;
            _mWindow.StateChanged += _mWindow_StateChanged;

            MaximizeCommand = new RelayCommand(() => _mWindow.WindowState = WindowState.Maximized);
            MinimizeCommand = new RelayCommand(() => _mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_mWindow, GetMousePosition()));
            var resizer = new WindowResizer(_mWindow);
        }

        private void _mWindow_StateChanged(object sender, System.EventArgs e)
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(_mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + _mWindow.Left, position.Y + _mWindow.Top);
        }
        #endregion
    }
}
