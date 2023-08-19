﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using noon.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations;
using noon.Domain.Models.Order;

namespace noon.DTO.UserPaymentDto
{
    public class GetAllUserPaymentMethodDto
    {
        [Key]
        public int PaymentMethodID { get; set; }
        public string Provider { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        private bool _isDefault = false;

            public bool IsDefault
            {
                get { return _isDefault; }
                set { _isDefault = value; }
            }

        // Other relevant properties
        public string UserID { get; set; }
        //public AppUser AppUser { get; set; }
        //public ICollection<Order.Order> Orders { get; set; }
    }
}
