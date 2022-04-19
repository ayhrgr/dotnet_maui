using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Graphics;
using System.Linq;

namespace Microsoft.Maui.Controls
{
	// Once MAUI is capable of packaging styles into XAML files we will have implicit styles
	// that we can add as the base for the DefaultDictionary
	internal static class DefaultStyles
	{

		static Style ButtonDefaultStyle { get; set; }

		public static Setter GetBackground(BindableObject view)
		{
			var defaultStyle = RetrieveDefaultStyleFor(view);
			var styleToUse = defaultStyle;

			if (styleToUse == null)
			{
				if (view is Button button)
				{
					if (ButtonDefaultStyle == null)
					{
						var backgroundColorSetter = new Setter();
						backgroundColorSetter.Property = VisualElement.BackgroundProperty;
						backgroundColorSetter.Value = new SolidColorBrush(Colors.Green);

						ButtonDefaultStyle = new Style(typeof(Button))
						{
							Setters =
							{
								backgroundColorSetter
							}
						};

					}

					styleToUse = ButtonDefaultStyle;
				}
			}

			return styleToUse?.Setters?.FirstOrDefault(x => x.Property == VisualElement.BackgroundProperty);
		}


		public static Style RetrieveDefaultStyleFor(BindableObject view)
		{
			// not sure how to do this currently
			// This will make it so the defaults feed from style defaults 
			return null;
		}

		internal static VisualStateGroupList GetVisualStateManager(BindableObject bindable)
		{
			if (bindable is Button button)
			{
				var visualStateGroupList = new VisualStateGroupList();
				var visualStateGroup = new VisualStateGroup() { Name = "CommonStates" };
				var normalTextSetter = new Setter()
				{
					Property = Button.TextColorProperty,
					Value = Colors.Purple
				};

				var disabledTextSetter = new Setter()
				{
					Property = Button.TextColorProperty,
					Value = Colors.Green
				};

				visualStateGroupList.Add(visualStateGroup);

				visualStateGroup.States.Add(new VisualState()
				{
					Name = "Normal",
					Setters =
					{
						normalTextSetter
					}
				});

				visualStateGroup.States.Add(new VisualState()
				{
					Name = "Disabled",
					Setters =
					{
						disabledTextSetter
					}
				});
			}

			return null;
		}
	}
}
