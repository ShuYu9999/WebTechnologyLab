using Microsoft.AspNetCore.Identity;

namespace Lab_1.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] AvatarImage { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string AvatarImageType { get; set; }
    }
}
