using System.Collections.Generic;

namespace Book_Store.Entities
{
    public class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }

    public enum RoleType
    {
        ADMIN = 1,
        USER,
        GUEST
    }
}