﻿namespace ConjugonApi.Models;

public class ConjugonDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ConjugonCollectionName { get; set; } = null!;
}