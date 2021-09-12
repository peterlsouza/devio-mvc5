namespace Pet.Infra.Migrations
{
    using Pet.Infra.Data.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MeuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        //gerou auto.. mas nao vai usar
        //protected override void Seed(MeuDbContext context)
        //protected override void Seed(Pet.Infra.Data.Context.MeuDbContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //    //  to avoid creating duplicate seed data.
        //}
    }
}

