using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreGraphRenderer.Data
{
    public static class GraphTemplate
    {
        public static string graphTemplateInterval1 = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='1'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='1'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";

        public static string graphTemplateInterval10 = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='10'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='1'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";

        public static string graphTemplateInterval100 = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='100'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='1'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";

        public static string graphTemplateInterval1000 = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='1000'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='1'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";

        public static string graphTemplateInterval10WithY = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='10'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='10'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";

        public static string graphTemplateInterval100WithY = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='100'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='100'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";

        public static string graphTemplateInterval1000WithY = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='1000'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='1000'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";



        //y 1000 and x 50 interval
        public static string graphTemplateInterval1000WithX50 = "<Chart>" +
                      "<ChartAreas>" +
                        "<ChartArea Name='Default' _Template_='All'>" +
                          "<AxisY>" +
                            "<LabelStyle Font='Verdana, 12px' Interval='1000'/>" +
                          "</AxisY>" +
                          "<AxisX LineColor='64, 64, 64, 64' Interval='50'>" +
                            "<LabelStyle Font='Verdana, 40px' />" +
                          "</AxisX>" +
                        "</ChartArea>" +
                      "</ChartAreas>" +
                    "</Chart>";
        
    }
}