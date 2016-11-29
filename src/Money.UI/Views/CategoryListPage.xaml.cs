﻿using Money.Services;
using Money.UI;
using Money.ViewModels.Parameters;
using Neptuo.Models.Keys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Money.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryListPage : Page
    {
        public CategoryListPage()
        {
            this.InitializeComponent();
        }

        private readonly IDomainFacade domainFacade = App.Current.DomainFacade;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = new DesignData.ViewModelLocator().CategoryList;

            CategoryListParameter parameter = (CategoryListParameter)e.Parameter;
        }
    }
}