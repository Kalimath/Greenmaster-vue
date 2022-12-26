using Microsoft.AspNetCore.Identity;

namespace be.MbDevelompent.Greenmaster.Statics.Users
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime ResetTokenUsed { get; set; }
        public string PasswordSalt { get; set; }
        public string? Phone { get; set; }
        public virtual List<RefreshToken> RefreshTokens { get; set; }

        public bool IsDeleted { get; private set; }

        public User(string? firstName, string? lastName, string email, string? phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            NormalizedEmail = email.ToUpper();
            UserName = email;
            NormalizedUserName = email.ToUpper();
            EmailConfirmed = false;
            PhoneNumberConfirmed = false;
            Phone = phone;
            SecurityStamp = new Guid().ToString();
        }

        public User(string email)
        {
            this.Email = email;
        }

        public bool OwnsRefreshToken(string token)
        {
            return this.RefreshTokens?.Select(x => x.Token == token) != null;
        }

        public string ActiveRefreshToken()
        {
            var token = this.RefreshTokens.First(t => t.IsActive && !t.IsExpired);
            return token.Token;
        }

        public void AddToken(RefreshToken token)
        {
            if (this.RefreshTokens == null) this.RefreshTokens = new List<RefreshToken>();
            this.RefreshTokens.Add(token);
        }
        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}