﻿using System;
using System.Text.Json.Serialization;
using ConjugonApi.DTOs;
using ConjugonApi.Models.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConjugonApi.Models.Domain
{
    public record Verb: EntityBase
    {
        public static Verb CreateNew(VerbDTO verbDTO)
        {
            return new Verb
            {
                Infinitif = verbDTO.Infinitif,
                ParticipePasse = verbDTO.ParticipePasse,
                ParticipePresent = verbDTO.ParticipePresent,
                Auxiliaire = verbDTO.Auxiliaire,
                FormePronominale = verbDTO.FormePronominale,
                Present = verbDTO.Present,
                Imparfait = verbDTO.Imparfait,
                PasseSimple = verbDTO.PasseSimple,
                FuturSimple = verbDTO.FuturSimple,
                PlusQueParfait = verbDTO.PlusQueParfait,
                FuturAnterieur = verbDTO.FuturAnterieur,
                PasseCompose = verbDTO.PasseCompose,
                PasseAnterieur = verbDTO.PasseAnterieur,
                SubjonctifPresent = verbDTO.SubjonctifPresent,
                SubjonctifImparfait = verbDTO.SubjonctifImparfait,
                SubjonctifPasse = verbDTO.SubjonctifPasse,
                SubjonctifPlusQueParfait = verbDTO.SubjonctifPlusQueParfait,
                ConditionnelPasse = verbDTO.ConditionnelPasse,
                ConditionnelPresent = verbDTO.ConditionnelPresent,
                ConditionnelPasseII = verbDTO.ConditionnelPasseII,
                Imperatif = verbDTO.Imperatif,
                ImperatifPasse = verbDTO.ImperatifPasse
        };
        }

        public required string Infinitif { get; set; }
        public string? ParticipePasse { get; set; }
        public string? ParticipePresent { get; set; }
        public string? Auxiliaire { get; set; }
        public string? FormePronominale { get; set; }
        public List<string>? Present { get; set; }
        public List<string>? Imparfait { get; set; }
        public List<string>? PasseSimple { get; set; }
        public List<string>? FuturSimple { get; set; }
        public List<string>? PlusQueParfait { get; set; }
        public List<string>? FuturAnterieur { get; set; }
        public List<string>? PasseCompose { get; set; }
        public List<string>? PasseAnterieur { get; set; }
        public List<string>? SubjonctifPresent { get; set; }
        public List<string>? SubjonctifImparfait { get; set; }
        public List<string>? SubjonctifPasse { get; set; }
        public List<string>? SubjonctifPlusQueParfait { get; set; }
        public List<string>? ConditionnelPasse { get; set; }
        public List<string>? ConditionnelPresent { get; set; }
        public List<string>? ConditionnelPasseII { get; set; }
        public List<string>? Imperatif { get; set; }
        public List<string>? ImperatifPasse { get; set; }
    }
}

