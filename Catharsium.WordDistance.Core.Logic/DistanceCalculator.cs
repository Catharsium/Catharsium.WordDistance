﻿using System;
using Catharsium.WordDistance.Core.Logic.Interfaces;

namespace Catharsium.WordDistance.Core.Logic
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public int CalculateDistance(string s1, string s2)
        {
            while (true) {
                if (s1 == s2) {
                    return 0;
                }

                if (s1.Length == 0 && s2.Length == 0) {
                    return 0;
                }

                if (s1.Length == 0 || s2.Length == 0) {
                    return Math.Abs(s1.Length - s2.Length);
                }

                if (s1[0] == s2[0]) {
                    s1 = s1.Substring(1);
                    s2 = s2.Substring(1);
                    continue;
                }

                if (s1.Length == s2.Length) {
                    return 1 + this.CalculateDistance(s1.Substring(1), s2.Substring(1));
                }

                if (s1.Length < s2.Length) {
                    return 1 + Math.Min(this.CalculateDistance(s1.Substring(1), s2.Substring(1)), this.CalculateDistance(s1.Substring(0), s2.Substring(1)));
                }

                if (s1.Length > s2.Length) {
                    return 1 + Math.Min(this.CalculateDistance(s1.Substring(1), s2.Substring(0)), this.CalculateDistance(s1.Substring(1), s2.Substring(1)));
                }

                return 0;
            }
        }
    }
}