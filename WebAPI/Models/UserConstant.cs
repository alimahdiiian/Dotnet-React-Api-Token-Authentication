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
                  PassWord= "schahrad@2022",
                   GivenName="schahrad",
                    Role="Administrator",
                     SureName="mahidan"
            },
             new UserModel()
            {
                UserName = "John_Doei",
                 EmailAddress = "John@gmail.com",
                  PassWord= "John@2022",
                   GivenName="John",
                    Role="Seller",
                     SureName="Doei"
            },


        };
    }
}
