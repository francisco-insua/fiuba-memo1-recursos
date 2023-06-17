﻿using Memo1.Recursos.Domain;

namespace Memo1.Recursos.Application.Contracts.Repositories;

public interface ICargaHorariaRepository
{
    Task Add(CargaHoraria cargaHoraria);
    Task Delete(string id);
    Task<CargaHoraria?> GetCargaHoraria(string legajo);
}