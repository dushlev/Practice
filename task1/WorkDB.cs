using System;
using System.Data.Entity;

namespace task1
{
    class MyContextInitializer : CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            var exp1 = new Expression { ExpressionStr = "1-3,4-7,9" };
            var exp2 = new Expression { ExpressionStr = "0-2,3-5,8" };
            var exp3 = new Expression { ExpressionStr = "-3-1,3-8,9-11,13" };
            db.Expressions.Add(exp1);
            db.Expressions.Add(exp2);
            db.Expressions.Add(exp3);
            db.SaveChanges();
        }
    }

    public class Expression
    {
        public int Id { get; set; }
        public string ExpressionStr { get; set; }
    }
    class UserContext : DbContext
    {
        public UserContext() : base("Variant10")
        { }
        static UserContext()
        {
            Database.SetInitializer<UserContext>(new MyContextInitializer());
        }

        public DbSet<Expression> Expressions { get; set; }
    }
}
