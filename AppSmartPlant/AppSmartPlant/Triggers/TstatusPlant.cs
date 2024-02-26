using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppSmartPlant.Triggers
{
	public class TstatusPlant : TriggerAction<Button>
	{
		public bool Activacion { get; set; }
		protected override async void Invoke(Button sender)
		{
			if (Activacion == true)
			{
				sender.BackgroundColor = Color.Green;
				await sender.FadeTo(0.5, 1000, Easing.Linear);
			}
			if (Activacion == false)
			{
				sender.BackgroundColor = new Button().BackgroundColor;
			}
		}
	}
}
