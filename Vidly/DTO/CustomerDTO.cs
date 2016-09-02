using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        public int MembershipTypeId { get; set; }
    }
}