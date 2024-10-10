using System.ComponentModel.DataAnnotations;

namespace Ahmed.C42.PL.ViewModels.Identity
{
	public class SignUpViewModel
	{
		[Display(Name = "First Name")]
		[Required]
		public string FirstName { get; set; } = null!;

		[Display(Name ="First Name")]
		[Required]
		public string LastName { get; set; } = null!;

		[Required]
		public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Display(Name = "Confirmed Password")]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage ="Confirmed Password doesn't match with Password!")]
        public string ConfirmedPassword { get; set; } = null!;

		[Required]
        public bool IsAgree { get; set; }
    }
}
