using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppSmartPlant.Triggers
{
	public class TaddPlant : TriggerAction<Label>
	{
		public bool Activacion { get; set; }
		protected override async void Invoke(Label sender)
		{
			sender.IsVisible = true;


			if (Activacion == true)
			{

				sender.BackgroundColor = Color.Green;

				await sender.FadeTo(0.5, 1000, Easing.Linear);

				await Task.Delay(2000);
				sender.IsVisible = false;

			}
			if (Activacion == false)
			{
				sender.BackgroundColor = new Label().BackgroundColor;
				sender.Rotation = new Label().Rotation;
			}
		}
	}
}
