﻿using System;
using _Laboratory02.View;

namespace _Laboratory02.Tools.Navigation
{
    internal class NavigationInitialization : NavigationModel
    {
        public NavigationInitialization(IContent content) : base(content)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.PersonalInfo:
                    ViewsDictionary.Remove(ViewType.PersonalInfo);//remove old person 
                    ViewsDictionary.Add(viewType, new PersonalInfoView());
                    break;
                case ViewType.LogIn:
                   ViewsDictionary.Add(viewType, new LoginView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
