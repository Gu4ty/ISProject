using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ISProject.Data;
using ISProject.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISProject.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private ApplicationDbContext _db;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
            _db = db;
        }

       

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [DataType(DataType.Password)]
            public string OldPassword { get; set; }

            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        public async Task<IActionResult> OnPostUpgrade()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        
        
            string value = Request.Cookies[claim.Value + "upgrade"];
            if(value!= null){
                StatusMessage = "You have already sent a request to the admins. Only one request can be submitted daily.";
                return RedirectToPage();
            }
        
            bool OK = await NotiApi.SendNotiRole(_db, claim.Value);
            if(OK){
                StatusMessage = "Request sent successfully.";
                var cookie_name = claim.Value + "upgrade";
                CookieOptions option = new CookieOptions();
                //Testing
                //option.Expires = DateTime.Now.AddSeconds(10);                   
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(cookie_name,"sended", option);
                
            }
            else
                StatusMessage = "Administrators are analyzing your request. Excuse us the delay.";
            
            
            return RedirectToPage();

          
            
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var email = await _userManager.GetEmailAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Email = email
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            

            return Page(); 

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            if (Input.OldPassword != null)
            {
                var oldpass = await _userManager.CheckPasswordAsync(user, Input.OldPassword);
                if(oldpass)
                {
                    if(Input.Password != null && Input.ConfirmPassword != null)
                    {
                        var setNewPasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.Password);
                        if(!setNewPasswordResult.Succeeded)
                        {
                            foreach (var error in setNewPasswordResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "The NewPassword must be at least 6 characters long");
                        return Page();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect old password");
                    return Page();
                    // StatusMessage = "Incorrect old password";
                    // return RedirectToPage();
                }
            }
            else if(Input.Password != null && Input.ConfirmPassword != null)
            {
                ModelState.AddModelError(string.Empty, "Please insert old password in order to change it");
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
