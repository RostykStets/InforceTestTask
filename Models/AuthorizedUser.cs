namespace InforceTestTask.Models
{
    public class AuthorizedUser : User
    {
        public AuthorizedUser()
        {
            this.UserType = UserType.AuthorizedUser;
        }
    }
}
