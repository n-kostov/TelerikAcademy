using _11.UsersModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _11.AddAdminUser
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                UserName = "Qwertyson",
                FullName = "Qwerty son"
            };

            AddUser("Admin", user);
        }

        static void AddUser(string groupName, User user)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    var userGroup = context.Groups.Where(x => x.Name == groupName).FirstOrDefault();
                    Group group;
                    if (userGroup == null)
                    {
                        group = new Group
                        {
                            Name = groupName
                        };

                        context.Groups.Add(group);
                    }
                    else
                    {
                        group = userGroup;
                    }

                    user.GroupID = group.GroupID;

                    context.Users.Add(user);
                    context.SaveChanges();
                    transaction.Complete();
                }
                catch (DbEntityValidationException)
                {
                    Console.WriteLine("Cannot add user which does not have the required columns specified");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException.InnerException.Message);
                }
            }
        }
    }
}
