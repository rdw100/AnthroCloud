﻿using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthStat.Statistics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.API.Controllers
{
    /// <summary>
    /// Calculates zscore and percentile for given measurements.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        /// <summary>
        /// Gets tuple of zscore and percentile calculation for specified measurement indicator given measurement, age, and sex.
        /// </summary>
        /// <param name="indicator">The growth indicator</param>
        /// <param name="measurement">The specified measured value</param>
        /// <param name="ageInDays">The age in total days</param>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a tuple containing a zscore and percentile calcuation.</returns>
        /// <example>GET: api/Stats/WeightForAge/9.00/365/Male</example>
        [HttpGet("{indicator}/{measurement}/{ageInDays}/{sex}")]
        [Route("STATS/{indicator}/{measurement}/{ageInDays}/{sex}")]
        public async Task<Tuple<double, double>> GetScore(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            Stats stats = new Stats();
            Tuple<double, double> scores = await stats.GetScore(indicator, measurement, ageInDays, sex);
            return scores;
        }

        [HttpGet("{Inputs}")]
        [Route("STATS")]//{Inputs}
        public async Task<Outputs> GetScores(Inputs inputs)
        {
            Outputs outputs = new Outputs();
            Stats stats = new Stats();

            Tuple<double, double> wfaTuple = await stats.GetScore(Indicator.WeightForAge, inputs.Weight, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.WfaZscore = wfaTuple.Item1;
            outputs.WfaPercentile = wfaTuple.Item2;

            Tuple<double, double> muacTuple = await stats.GetScore(Indicator.ArmCircumferenceForAge, inputs.MUAC, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.MuacZscore = muacTuple.Item1;
            outputs.MuacPercentile = muacTuple.Item2;

            Tuple<double, double> bfaTuple = await stats.GetScore(Indicator.BodyMassIndexForAge, inputs.BMI, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.BfaZscore = bfaTuple.Item1;
            outputs.BfaPercentile = bfaTuple.Item2;

            Tuple<double, double> hcaTuple = await stats.GetScore(Indicator.HeadCircumferenceForAge, inputs.HeadCircumference, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.HcaZscore = hcaTuple.Item1;
            outputs.HcaPercentile = hcaTuple.Item2;

            Tuple<double, double> hfaTuple = await stats.GetScore(Indicator.HeightForAge, inputs.LengthHeight, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.HfaZscore = hfaTuple.Item1;
            outputs.HfaPercentile = hfaTuple.Item2;

            Tuple<double, double> lfaTuple = await stats.GetScore(Indicator.LengthForAge, inputs.LengthHeight, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.LfaZscore = lfaTuple.Item1;
            outputs.LfaPercentile = lfaTuple.Item2;

            Tuple<double, double> sfaTuple = await stats.GetScore(Indicator.SubscapularSkinfoldForAge, inputs.SubscapularSkinFold, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.SsfZscore = sfaTuple.Item1;
            outputs.SsfPercentile = sfaTuple.Item2;

            Tuple<double, double> tfaTuple = await stats.GetScore(Indicator.TricepsSkinfoldForAge, inputs.TricepsSkinFold, (double)inputs.Age.Days, (Sex)inputs.Sex);
            outputs.TsfZscore = tfaTuple.Item1;
            outputs.TsfPercentile = tfaTuple.Item2;

            Tuple<double, double> wfhTuple = await stats.GetScore(Indicator.WeightForHeight, inputs.Weight, inputs.LengthHeight, (Sex)inputs.Sex);
            outputs.WfhZscore = wfhTuple.Item1;
            outputs.WfhPercentile = wfhTuple.Item2;

            Tuple<double, double> wflTuple = await stats.GetScore(Indicator.WeightForLength, inputs.Weight, inputs.LengthHeight, (Sex)inputs.Sex);
            outputs.WflZscore = wflTuple.Item1;
            outputs.WflPercentile = wflTuple.Item2;

            return outputs;
        }
    }
}
