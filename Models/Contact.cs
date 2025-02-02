using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactM.Models
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int? Id { get; set; }     
       [Required (ErrorMessage = "Name is required.")]
        public string? Name { get; set; }  
       [EmailAddress(ErrorMessage = "Invalid email address.")] // Validates that the Email property contains a valid email address format and sets the error message if invalid
        public string Email { get; set; }
       [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "Phone number must be 10 digits and start with '09'.")]
        public string? PhoneNumber { get; set; }
 
    }
}
