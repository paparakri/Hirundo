﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hirundo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            var view_model = new ViewModel();
            BindingContext = view_model;

            InitializeComponent();
		}
	}
}
