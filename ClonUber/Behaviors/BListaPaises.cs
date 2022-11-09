using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ClonUber.Behaviors
{
    public class BListaPaises : Behavior<View>
    {
        double VerticalTransition { get; set; }
        PanGestureRecognizer panDesture = new PanGestureRecognizer();

        protected override void OnAttachedTo(View vista)
        {
            panDesture.PanUpdated += PanDesture_PanUpdated;

            // We link this behavior to the view.
            vista.GestureRecognizers.Add(panDesture);
            base.OnAttachedTo(vista);    
        }

        private async void PanDesture_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            // In this context tell us when the element is draged and droped.
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (e.TotalY > 0)
                    {
                        // e.TotalY es the value we draged.
                        await ((View)sender).TranslateTo(0, e.TotalY);
                        VerticalTransition = e.TotalY;
                    }
                    break;
                case GestureStatus.Completed:
                    if (VerticalTransition > 80)
                    {
                        // We set how much we want to draw it.
                        await ((View)sender).TranslateTo(0, 200);

                        // Validate if exist any other PopupPage instaciated
                        // to close every of it.
                        if (PopupNavigation.Instance.PopupStack.Any())
                        {
                            await PopupNavigation.Instance.PopAsync();
                        }
                    }
                    else
                    {
                        await ((View)sender).TranslateTo(0, e.TotalY);
                    }

                    break;
            }
        }

        protected override void OnDetachingFrom(View vista)
        {
            // Desuscribe the gesture.
            panDesture.PanUpdated -= PanDesture_PanUpdated;

            // We remove the view to the gesture.
            vista.GestureRecognizers.Remove(panDesture);
            base.OnDetachingFrom(vista);
        }
    }
}
