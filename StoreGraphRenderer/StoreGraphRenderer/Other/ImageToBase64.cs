using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreGraphRenderer.Other
{
    public static class ImageToBase64
    {
        public static string Get(byte[] chart)
        {
            string imageBase64Data = Convert.ToBase64String(chart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            return imageDataURL;
        }
    }
}