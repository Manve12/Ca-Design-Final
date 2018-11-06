using StoreGraphRenderer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace StoreGraphRenderer.Data
{
    public static class GraphRenderer
    {
        public static byte[] RenderGraph(int chartWidth,
                                         int chartHeight,
                                         string chartTitle,
                                         string chartType,
                                         string graphTemplate,
                                         string[] _yValues,
                                         string[] _xValues,
                                         string xAxisTitle,
                                         string yAxisTitle
            )
        {

            byte[] newChart = new Chart(width: chartWidth,
                                           height: chartHeight,
                                           theme: graphTemplate)
                   .AddTitle(chartTitle)
                   .AddSeries(
                       chartType: chartType,
                       yValues: _yValues,
                       xValue: _xValues
                       )
                      .SetXAxis(min: 1, max: _xValues.Length, title: xAxisTitle)
                      .SetYAxis(title: yAxisTitle)
                   .GetBytes();

            return newChart;
        }

        public static byte[] RenderGraph(GraphModel model)
        {
            var newChart = new Chart(width: model.Width, height: model.Height, theme: model.GraphTemplate);
            newChart.AddTitle(model.Title)
                       .AddSeries(
                           chartType: model.GraphType,
                           yValues: model.YAxisData,
                           xValue: model.XAxisData,
                           name: model.SeriesTitleInitial
                           );
            if (model.SeriesTitleInitial != null)
            {

                newChart.AddSeries(
                chartType: model.GraphType,
                yValues: model.YAxisDataAdditional,
                xValue: model.XAxisDataAdditional,
                name: model.SeriesTitleAdditional
                )

               .AddLegend();
            }

            if (model.XAxisData != null)
                newChart.SetXAxis(min: 1, max: model.XAxisData.Length, title: model.XAxisTitle)
                              .SetYAxis(title: model.YAxisTitle);
            

            
            return newChart.GetBytes();
        }
    }
}