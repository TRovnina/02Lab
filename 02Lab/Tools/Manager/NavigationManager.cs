using _Laboratory02.Tools.Navigation;

namespace _Laboratory02.Tools.Manager
{
    internal class NavigationManager
    {
        private static readonly object Locker = new object();
        private static NavigationManager _instance;

        internal static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new NavigationManager());
                }
            }
        }

        private INavigation _navigationModel;

        private NavigationManager()
        {

        }

        internal void Initialize(INavigation navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ViewType viewType)
        {
            _navigationModel.Navigate(viewType);
        }

    }
}
