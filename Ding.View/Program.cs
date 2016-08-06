using Ding.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ding.View
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var db = new Ding.DataModel.Entities();

                var usersAll = db.User.ToList();
                var usersAllActive = db.User.Where(u => u.IsEnable == true);
                var usersAllActiveAnd = db.User.Where(u => u.UserId < 10);

                var usrAll = from u in db.User
                         where u.UserId < 10
                                 select u;

                var pfa = db.User.Join(
                    db.PF, 
                    u => u.UserId, 
                    pf => pf.Customer.UserId,
                    (u,pf) => pf);


                var usr2 = db.User.FirstOrDefault();
                var pfa2 = usr2.Customer.FirstOrDefault().PF;

                var usrs = db.User.FirstOrDefault();
                Console.WriteLine(usrs.Name);
                var lName = (usrs.Customer.FirstOrDefault().PF).LastName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
