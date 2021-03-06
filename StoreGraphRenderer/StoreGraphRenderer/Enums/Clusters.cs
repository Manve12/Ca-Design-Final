﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreGraphRenderer.Enums
{
    public static class Clusters
    {
        public enum ClusterGroup
        {
            Region = 1,
            Location = 3,
            Size = 4
        }
        
        public static Dictionary<string, ClusterGroup> ClusterName = new Dictionary<string, ClusterGroup>()
        {
            { "North", ClusterGroup.Region },
            { "South", ClusterGroup.Region },
            { "East", ClusterGroup.Region },
            { "West", ClusterGroup.Region },

            { "High Street", ClusterGroup.Location },
            { "Retail Park", ClusterGroup.Location },
            { "Shopping Centre", ClusterGroup.Location },

            { "< 25000", ClusterGroup.Size },
            { "25000 - 50000", ClusterGroup.Size },
            { "50000 - 75000", ClusterGroup.Size },
            { "75000 +", ClusterGroup.Size }
        };

        public static Dictionary<string, int> ClusterId = new Dictionary<string, int>()
        {
            { "North", 2 },
            { "South", 3 },
            { "East", 4 },
            { "West", 5 },

            { "High Street", 8 },
            { "Retail Park", 9 },
            { "Shopping Centre", 10 },

            { "< 25000", 11 },
            { "25000 - 50000", 12 },
            { "50000 - 75000", 13 },
            { "75000 +", 14 }
        };
    }
}