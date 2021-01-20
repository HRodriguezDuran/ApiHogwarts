using System;
using System.ComponentModel.DataAnnotations;
using static DTO.Enums.Enums;

namespace DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [StringLength(20, ErrorMessage = "The field {0} must be between {1} and {2} characteres", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [StringLength(20, ErrorMessage = "The field {0} must be between {1} and {2} characteres", MinimumLength = 3)]
        public string LastName { get; set; }

        [Range(1, 9999999999, ErrorMessage = "The field {0} must be between {1} and {2}")]

        public long IdentificationNumber { get; set; }

        [Range(1, 99, ErrorMessage = "The field {0} must be between {1} and {2}")]
        public int Age { get; set; }

        //public HousesEnum House { get; set; }
        public string House { get; set; }
    }
}
