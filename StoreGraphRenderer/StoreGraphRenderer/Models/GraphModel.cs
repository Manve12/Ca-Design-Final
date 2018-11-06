using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreGraphRenderer.Models
{
    public class GraphModel
    {
        public int Width { get; set; } = 1200;
        public int Height { get; set; } = 1200;

        public string Title { get; set; }

        public string GraphType { get; set; } = "column";

        public string GraphTemplate { get; set; } = Data.GraphTemplate.graphTemplateInterval10;

        public string[] XAxisData { get; set; }
        public string[] YAxisData { get; set; }

        public string SeriesTitleInitial { get; set; }
        public string SeriesTitleAdditional { get; set; }

        public string[] XAxisDataAdditional { get; set; }
        public string[] YAxisDataAdditional { get; set; }

        public string XAxisTitle { get; set; }
        public string YAxisTitle { get; set; }
    }
}