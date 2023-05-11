namespace Infra
{
    internal class FluentMigratorConfiguration
    {
        private object connectionString;

        public FluentMigratorConfiguration(object connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}