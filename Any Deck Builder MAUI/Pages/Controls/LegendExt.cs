using Syncfusion.Maui.Toolkit.Charts;

namespace Any_Deck_Builder_MAUI.Pages.Controls
{
    public class LegendExt : ChartLegend
    {
        protected override double GetMaximumSizeCoefficient()
        {
            return 0.5;
        }
    }
}
