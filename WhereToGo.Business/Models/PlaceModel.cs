using System;
using System.Collections.Generic;
using System.Text;

namespace WhereToGo.BL.Models.Places
{
    public class PlaceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlaceImage { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }
        public string Phone { get; set; }
        public bool IsConfirmed { get; set; }
        public int ConfirmationsCount { get; set; }
        public int Rating { get; set; }

    }
}
