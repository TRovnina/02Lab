using System.Collections.Generic;

namespace _Laboratory02.Tools.Navigation
{
    internal abstract class NavigationModel : INavigation
    {
        private readonly IContent _content;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected NavigationModel(IContent content)
        {
            _content = content;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContent content
        {
            get { return _content; }
        }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary
        {
            get { return _viewsDictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if(viewType == ViewType.PersonalInfo || !ViewsDictionary.ContainsKey(viewType))
               InitializeView(viewType);
            content.ContentControl.Content = ViewsDictionary[viewType];
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}
