using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HYM.Application.ViewModels
{
    public class StudentViewModel
    {

        [Key]
        public Guid Id { get; set; }

     
        public string Name { get; set; }

       
        public string Email { get; set; }

      
        public DateTime BirthDate { get; set; }


   
        public string Phone { get; set; }


        
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }
    }
}
