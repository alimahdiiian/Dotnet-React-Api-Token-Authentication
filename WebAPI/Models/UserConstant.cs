namespace WebAPI.Models
{
    public class UserConstant
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                UserName = "Schahraad",
                 EmailAddress = "schahrad@gmail.com",
                  PassWord= "schahrad2024",
                   GivenName="schahrad",
                    Role="Administrator",
                     SureName="mahidan"
            },
             new UserModel()
            {
                UserName = "John_Doei",
                 EmailAddress = "John@gmail.com",
                  PassWord= "john2024",
                   GivenName="John",
                    Role="Teacher",
                     SureName="Doei"
            },

             new UserModel()
             {
                  UserName = "Sara_Müller",
                 EmailAddress = "sara@gmail.com",
                  PassWord= "sara2024",
                   GivenName="Sara",
                    Role="Student",
                     SureName="Müller"
             }


        };
    }
}
