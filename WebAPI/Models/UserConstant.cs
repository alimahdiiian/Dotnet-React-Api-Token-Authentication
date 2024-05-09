namespace WebAPI.Models
{
    public class UserConstant
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                    UserName = "John_Doei",
                 EmailAddress = "John@gmail.com",
                  PassWord= "John2024",
                   GivenName="John",
                    Role="Administrator",
                     SureName="Doei"              

            },

            new UserModel()
            {
               UserName = "Schahraad",
                 EmailAddress = "schahrad@gmail.com",
                  PassWord= "Schahrad2024",
                   GivenName="schahrad",
                    Role="Student",
                     SureName="mahidan"
            },

            new UserModel()
            {
                 UserName = "Sara",
                 EmailAddress = "sara@gmail.com",
                  PassWord= "Sara2024",
                   GivenName="sara",
                    Role="Teacher",
                     SureName="mahidan"
            }

        };
    }
}
