﻿using AnthroCloud.Entities;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Services
{
    public interface IAnthroService
    {
        Task<double> GetBMI(double weight, double height);
        Task<Age> GetAge(string birth, string visit);
        Task<Outputs> GetScores(Inputs inputs);
    }
}
