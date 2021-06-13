﻿namespace MMT.Common.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerFullDetails : Customer
    {
        public string CustomerId { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string PreferredLanguage { get; set; }

        public override string ToString()
        {
            return $"{HouseNumber}, {Street}, {Town}, {Postcode}";
        }
    }

}