﻿using System;

namespace ReWork.Model.EntitiesInfo
{
    public class OfferInfo
    {
        public string UserName { get; set; }

        public string Text { get; set; }

        public DateTime AddedDate { get; set; }

        public int? ImplementationDays { get; set; }

        public int OfferPayment { get; set; }

        public byte[] EmployeeImage { get; set; }

        public string EmployeeId { get; set; }
    }
}
