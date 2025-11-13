using System.ComponentModel.DataAnnotations;
using ApplicationLayer;
using CoreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DYECHEM.Pages.Component
{
    [BindProperties]
    public class ContactModel : PageModel

    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email format.")]
        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(200, ErrorMessage = "Subject cannot exceed 200 characters.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Messagess obj = new Messagess();
            obj.Name = Name;
            obj.Email = Email;
            obj.PhoneNumber = PhoneNumber;
            obj.Message = Message;
            obj.Subject = Subject;

            MessageManager obj2 = new MessageManager();
            obj2.Add(obj);

            return RedirectToPage("Contact");
        }
    }
}
