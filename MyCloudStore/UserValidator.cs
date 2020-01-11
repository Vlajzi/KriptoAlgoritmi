using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudStore
{
    //ne koristi se (samo eksperimentalno da se proba nesto)
    class UserValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "test1" && password == "1tset") && !(userName == "test2" && password == "2tset"))
            {

                throw new SecurityTokenException("Unknown Username or Incorrect Password");//tmp
            }
            /*using(SqlConnection con = new SqlConnection() )
            {

            }*/

        }
    }
}
