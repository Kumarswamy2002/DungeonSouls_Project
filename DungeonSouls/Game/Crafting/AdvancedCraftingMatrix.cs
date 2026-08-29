using System;
using System.Collections.Generic;
using DungeonSouls.Game.Core;
using DungeonSouls.Game.Combat;

namespace DungeonSouls.Game.Crafting.Advanced
{

    public class CraftingMatrixRecipe1
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe1(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe2
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe2(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe3
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe3(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe4
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe4(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe5
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe5(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe6
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe6(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe7
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe7(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe8
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe8(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe9
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe9(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe10
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe10(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe11
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe11(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe12
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe12(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe13
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe13(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe14
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe14(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe15
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe15(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe16
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe16(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe17
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe17(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe18
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe18(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe19
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe19(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe20
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe20(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe21
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe21(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe22
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe22(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe23
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe23(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe24
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe24(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe25
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe25(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe26
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe26(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe27
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe27(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe28
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe28(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe29
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe29(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe30
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe30(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe31
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe31(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe32
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe32(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe33
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe33(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe34
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe34(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe35
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe35(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe36
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe36(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe37
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe37(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe38
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe38(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe39
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe39(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe40
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe40(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe41
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe41(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe42
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe42(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe43
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe43(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe44
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe44(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe45
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe45(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe46
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe46(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe47
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe47(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe48
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe48(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe49
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe49(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe50
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe50(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe51
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe51(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe52
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe52(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe53
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe53(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe54
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe54(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe55
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe55(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe56
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe56(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe57
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe57(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe58
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe58(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe59
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe59(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }


    public class CraftingMatrixRecipe60
    {
        public string Id { get; }
        public string Name { get; set; }
        public int LevelTier { get; set; }
        public double BaseMagnitude { get; set; }
        public double MultiplierValue { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> TagCollection { get; } = new List<string>();
        public Dictionary<string, double> NumericParameters { get; } = new Dictionary<string, double>();

        public CraftingMatrixRecipe60(string id, string name, int tier = 1, double magnitude = 10.0)
        {
            Id = id;
            Name = name;
            LevelTier = tier;
            BaseMagnitude = magnitude;
            MultiplierValue = 1.0 + (tier * 0.15);
            IsEnabled = true;
            TagCollection.Add("CraftingMatrixRecipe");
            NumericParameters["Cooldown"] = 5.0 + tier;
            NumericParameters["Radius"] = 2.5 + tier * 0.5;
            NumericParameters["Cost"] = 15.0 + tier * 2;
        }


        public double ExecuteOperation_1(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_1(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_2(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_2(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_3(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_3(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_4(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_4(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_5(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_5(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }


        public double ExecuteOperation_6(double inputVal, double scalingFactor, bool applyBonus)
        {
            if (!IsEnabled) return 0.0;
            double result = (BaseMagnitude * MultiplierValue) + (inputVal * scalingFactor * 1.25);
            if (applyBonus)
            {
                result *= 1.35;
                result += LevelTier * 4.5;
            }
            double decay = Math.Sin(inputVal * 0.05) * 2.0;
            return Math.Max(0.0, Math.Round(result + decay, 3));
        }

        public bool ValidateCondition_6(double currentThreshold, List<string> requiredTags)
        {
            if (currentThreshold < BaseMagnitude * 0.5) return false;
            foreach (var req in requiredTags)
            {
                if (!TagCollection.Contains(req)) return false;
            }
            return NumericParameters.ContainsKey("Cooldown") && NumericParameters["Cooldown"] > 0;
        }

    }

}
