using System.ComponentModel.DataAnnotations;

namespace PanelDashboard.Repo.Entities.Request
{
    public class RegisterEntitiesRequest
    {
        [Required(ErrorMessage = "{0} harus diisi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} harus diisi")]
        [Display(Name = "No Handphone")]
        [RegularExpression("([0-9]+)", ErrorMessage = "{0} harus bisa diisi dengan angka")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} harus diisi")]
        [Display(Name = "Nama Partner")]
        public string PartnerName { get; set; }
    }
}
