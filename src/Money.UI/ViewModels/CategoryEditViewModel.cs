﻿using Money.Services;
using Money.ViewModels.Commands;
using Money.ViewModels.Navigation;
using Money.ViewModels.Parameters;
using Neptuo;
using Neptuo.Models.Keys;
using Neptuo.Observables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Money.ViewModels
{
    public class CategoryEditViewModel : ObservableObject
    {
        public IKey Key { get; internal set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(ColorBrush));
                }
            }
        }

        private string icon;
        public string Icon
        {
            get { return icon; }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Brush ColorBrush
        {
            get { return new SolidColorBrush(Color); }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand ChangeIcon { get; private set; }
        public ICommand Delete { get; private set; }

        public CategoryEditViewModel(IDomainFacade domainFacade, INavigator navigator, IKey key)
        {
            Ensure.NotNull(domainFacade, "domainFacade");
            Ensure.NotNull(navigator, "navigator");
            Ensure.NotNull(key, "key");
            Key = key;
            CreateCommands(domainFacade, navigator);
        }

        public CategoryEditViewModel(IDomainFacade domainFacade, INavigator navigator, IKey key, string name, string description, Color color, string icon)
        {
            Ensure.NotNull(domainFacade, "domainFacade");
            Ensure.NotNull(navigator, "navigator");
            Ensure.Condition.NotEmptyKey(key);
            Key = key;
            Name = name;
            Description = description;
            Color = color;
            Icon = icon;
            CreateCommands(domainFacade, navigator);
        }

        private void CreateCommands(IDomainFacade domainFacade, INavigator navigator)
        {
            if (!Key.IsEmpty)
            {
                ChangeIcon = new NavigateCommand(navigator, new CategoryChangeIconParameter(Key));
                Delete = new CategoryDeleteCommand(navigator, domainFacade, Key);
            }
        }
    }
}
