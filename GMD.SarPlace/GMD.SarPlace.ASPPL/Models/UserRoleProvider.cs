using System;
using System.Web.Security;
using GMD.SarPlace.Dependencies;


namespace GMD.SarPlace.ASPPL.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string id, string roleName)
        {
            var userBll = DependencyResolver.Instance.usersLogic;
            var user = userBll.GetById(Guid.Parse(id));
            return (user.Name == "redactor@mail.ru" && roleName == "redactor") ||
                (user.Name == "redactor@mail.ru" && roleName == "redactor") ||
                (user.Name != "redactor@mail.ru" && roleName == "users");
        }

        public override string[] GetRolesForUser(string id)
        {
            var userBll = DependencyResolver.Instance.usersLogic;
            var user = userBll.GetById(Guid.Parse(id));
            if (user.Name == "redactor@mail.ru")
                return new[] { "users", "redactor" };
            else if (user.Name != "redactor@mail.ru")
                return new[] { "users" };
            else return new string[] { };
        }

        #region NOT_IMPLEMENTED

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}