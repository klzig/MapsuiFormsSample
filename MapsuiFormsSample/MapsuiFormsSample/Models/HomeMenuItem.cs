﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MapsuiFormsSample.Models
{
    public enum MenuItemType
    {
        Browse,
        Mapsui,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
