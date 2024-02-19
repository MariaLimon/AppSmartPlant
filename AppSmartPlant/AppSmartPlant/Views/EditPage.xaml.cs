﻿using AppSmartPlant.Models;
using AppSmartPlant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSmartPlant.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
		public EditPage(Mplanta parametros)
		{
			InitializeComponent();
			BindingContext = new EditViewModel(Navigation, parametros);
		}
	}
}