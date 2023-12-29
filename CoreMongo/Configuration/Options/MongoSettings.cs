namespace ConjugonApi.Configuration.Options
{
    public class MongoSettings
    {
        public required string ConjugonCollectionName { get; set; }
        public required string DatabaseName { get; set; }
        public required string ConnectionString { get; set; }
        public static string SectionName { get; set; } = "MongoSettings";
    }
}
