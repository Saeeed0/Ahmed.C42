using System.ComponentModel.DataAnnotations;

namespace Ahmed.C42.PL.ViewModels.Identity
{
	public class SignInViewModel
	{
		[EmailAddress]
		public string Email { get; set; } = null!;

		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }

		/// Server can access Only Cooky Storage from Storages
    }
}
