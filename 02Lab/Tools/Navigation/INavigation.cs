namespace _02Lab.Tools.Navigation
{
    internal enum ViewType
    {
        LogIn,
        PersonalInfo,
        Main
    }

    interface INavigation
    {
        void Navigate(ViewType viewType);
    }
}
