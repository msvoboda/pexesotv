using System;
using System.Collections.Generic;
using System.Text;

namespace PexesoTv.Models
{
    public enum MenuItemType
    {
        SelectGame,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
