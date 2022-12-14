using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("api/accounts")]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<IdentityUser<int>> userManager;
		private readonly SignInManager<IdentityUser<int>> signInManager;

		public AccountController(UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginVm loginVm)
		{
			var user = await userManager.FindByNameAsync(loginVm.Username);
			if (user is null)
			{
				return Unauthorized();
			}

			if (await userManager.IsLockedOutAsync(user))
			{
				return Forbid("Locked");
			}

			var result = await signInManager.PasswordSignInAsync(user, loginVm.Password, true, true);

			if (!result.Succeeded)
			{
				return Unauthorized();
			}

			HttpContext.User.Claims.
			
			return 
		}
	}

	public class LoginVm
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
