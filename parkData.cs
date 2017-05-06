using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication.Models
{
    public class parkData
    {
        public ObjectId Id { get; set; }
        public String parkSlotId { get; set; }
        public String isParkingAvailable { get; set; }
        public String assignedTagId { get; set; }

    }
}