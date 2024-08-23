namespace InforceTestTask.Models
{
    public class UserExtended : User
    {
        public string ErrorMsg { get; set; }
        public UserExtended()
        {
            Login = string.Empty;
            PasswordHash = string.Empty;
            ErrorMsg = string.Empty;
            UserType = UserType.AuthorizedUser;
        }
        public UserExtended(Admin admin)
        {
            Id = admin.Id;
            Login = admin.Login;
            PasswordHash = admin.PasswordHash;
            UserType = admin.UserType;
            ErrorMsg = string.Empty;
        }

        public UserExtended(AuthorizedUser authorizedUser)
        {
            Id = authorizedUser.Id;
            Login = authorizedUser.Login;
            PasswordHash = authorizedUser.PasswordHash;
            UserType = authorizedUser.UserType;
            ErrorMsg = string.Empty;
        }

        public Admin ToAdmin()
        {
            Admin admin = new();
            admin.Id = Id;
            admin.Login = Login;
            admin.PasswordHash = PasswordHash;
            admin.UserType = UserType;
            return admin;
        }

        public AuthorizedUser ToAuthorizedUser() 
        {
            AuthorizedUser authorizedUser = new();
            authorizedUser.Id = Id;
            authorizedUser.Login = Login;
            authorizedUser.PasswordHash = PasswordHash;
            authorizedUser.UserType = UserType;
            return authorizedUser;
        }
    }
}
