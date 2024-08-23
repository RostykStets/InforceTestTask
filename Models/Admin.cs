namespace InforceTestTask.Models
{
    public class Admin : User
    {
        public Admin() 
        {
            this.UserType = UserType.Admin;
        }
    }
}
