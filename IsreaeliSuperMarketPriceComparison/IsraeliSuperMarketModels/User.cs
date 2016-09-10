using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IsraeliSuperMarketModels
{
    [Serializable]
    [DataContract]
    public class User : IUser ,IEquatable<User>
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }

        public bool Equals(User other)
        {
            return UserName.Equals(other.UserName);
        }
    }
}
