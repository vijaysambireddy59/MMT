using System.ComponentModel.DataAnnotations;

namespace MMT.Common.Dto
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "user email is required")]
        public string user { get; set; }

        [Required(ErrorMessage = "customerId is required")]
        public string customerId { get; set; }
    }
}
