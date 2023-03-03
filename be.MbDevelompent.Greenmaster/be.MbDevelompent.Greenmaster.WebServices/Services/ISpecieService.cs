﻿using be.MbDevelompent.Greenmaster.WebServices.Models;

namespace be.MbDevelompent.Greenmaster.WebServices.Services;

public interface ISpecieService
{
    ValueTask<Specie?> Find(int any);
    Task<List<Specie>> GetAll();
}