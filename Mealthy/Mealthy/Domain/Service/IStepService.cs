﻿using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Service.Communication;

namespace Mealthy.Mealthy.Domain.Service;

public interface IStepService
{
    Task<IEnumerable<Step>> ListAsync();
    Task<StepResponse> SaveAsync(Step step);
    Task<StepResponse> UpdateAsync(int id, Step step);
    Task<StepResponse> DeleteAsync(int id);
}