namespace _Laboratory02.Tools.Navigation
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
