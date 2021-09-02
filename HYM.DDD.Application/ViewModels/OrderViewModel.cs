using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HYM.Application.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<OrderItemViewModel> Items { get; set; }
    }
}
