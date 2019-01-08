using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Publications.Web.Areas.Identity.Models
{
    public class UsersListModel : IEnumerable<IdentityUser>
    {
        private readonly IEnumerable<IdentityUser> _IdentityUsers;

        public UsersListModel(IdentityUser[] IdentityUsers) => _IdentityUsers = IdentityUsers;

        public IEnumerator<IdentityUser> GetEnumerator() => _IdentityUsers.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _IdentityUsers).GetEnumerator();
    }
}
