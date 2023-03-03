﻿using System.ComponentModel;
using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;

namespace be.MbDevelompent.Greenmaster.WebServices.Models;

public class Specie
{
    private string _cycle;
    private string _type;
    public int Id { get; set; }
    public string ScientificName { get; set; }
    public string? Name { get; set; }

    public string Type
    {
        get => _type;
        set => _type = Enum.IsDefined(typeof(PlantType), value) ? value : throw new InvalidEnumArgumentException();
    }

    public string Cycle
    {
        get => _cycle;
        set => _cycle = Enum.IsDefined(typeof(Lifecycle), value) ? value : throw new InvalidEnumArgumentException();
    }

    public Specie()
    {
        
    }
    
    public Specie(SpecieDTO specieDTO)
    {
        Id = specieDTO.Id;
        ScientificName = specieDTO.ScientificName;
        Name = specieDTO.Name;
        _cycle = specieDTO.Cycle;
        _type = specieDTO.Type;
    }
}