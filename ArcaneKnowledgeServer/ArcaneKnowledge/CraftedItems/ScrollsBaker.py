# read csv file to get the data

import csv
import os

# read csv file
def read_csv(file_name):
    with open(file_name, newline='') as csvfile:
        reader = csv.reader(csvfile, delimiter=',')
        for row in reader:
            yield row


file_name = 'scrolls.csv'

# read file into a list of dict
# each dict has first row as key for each column
def read_csv_to_dict(file_name):
    with open(file_name, newline='') as csvfile:
        reader = csv.DictReader(csvfile, delimiter=',')
        for row in reader:
            yield row

# print value in each row with the key "Level"
data = read_csv_to_dict(file_name)

for row in data:

    header = """using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Minimap;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Gameplay.Pipes.Gases;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.View;
using Eco.Shared.Items;
using Eco.Gameplay.Pipes;
using Eco.Mods.TechTree;
using Eco.World.Blocks;
using Eco.Gameplay.Housing.PropertyValues;
using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;
using Eco.Core.Controller;
using Eco.Core.Serialization;
using Eco.Gameplay.Systems.NewTooltip;"""

    open_namespace = """
    
namespace Eco.Mods.TechTree
{"""

    attribute = """
    [RequiresSkill(typeof(ArcaneKnowledgeSkill), {0})]""".format(row["Level"])
    
    class_name = """
    public class {0}Recipe : RecipeFamily
    {{""".format(row["Name"])

# add variable in: Time	Labor	Xp	Life	Food	Metal	Fire	Earth	Nature	Research

    setttings = """
        // Settings: Time,Labor,XP,Life,Food,Metal,Fire,Earth,Nature,Research
        private static float[] Settings => new float[] {{ {0}f, {1}f, {2}f, {3}f, {4}f, {5}f, {6}f, {7}f, {8}f, {9}f }};""".format(row["Time"], row["Labor"], row["Xp"], row["Life"], row["Food"], row["Metal"], row["Fire"], row["Earth"], row["Nature"], row["Research"])

    output = """
        private CraftingElement CraftingOutput => new CraftingElement<{0}>(1);""".format(row["Name"])
    
    constructor = """

        public {0}Recipe()
        {{
            InitializeRecipe();
        }}""".format(row["Name"])
    
    boilerplate = """

        #region boilerplate

        // Input
        private float Time => Settings[0];
        private float BaseLabor => Settings[1];
        private float ExperienceForCrafting => Settings[2];
        
        private List<IngredientElement> IngredientsList => new List<IngredientElement>() {
            new( typeof(LifeEssenceItem), Settings[3], typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)),
            new( typeof(FoodEssenceItem), Settings[4], typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)),
            new( typeof(MetalEssenceItem), Settings[5], typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)),
            new( typeof(FireEssenceItem), Settings[6], typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)),
            new( typeof(EarthEssenceItem), Settings[7], typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)),
            new( typeof(NatureEssenceItem), Settings[8], typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)),
            new( typeof(ResearchEssenceItem), Settings[9], typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)),
            };

        private IngredientElement[] BuildIngredients()
        {
            IEnumerable<IngredientElement> validIngredients = IngredientsList.Where(IngredientElement => IngredientElement.Quantity.GetBaseValue > 0);
            return validIngredients.ToArray();
        }
        
        private string RecipeNameNoSpace => "Conjure" + GetType().Name.Replace("Recipe", "");
        private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
        
        public void InitializeRecipe()
        {
            this.Recipes = new List<Recipe>()
            {
                new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), BuildIngredients(), new[]
                {
                    CraftingOutput
                })
            };

            this.ExperienceOnCraft = ExperienceForCrafting;
            this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
            this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
            this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
            CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
        }
        
        #endregion"""
    
    ending = """
    }
}"""

    # now write each row into a separate file
    file_name = row["Name"] + "Recipe.cs"
    file_path = os.path.join(os.getcwd(), "Recipes", file_name)
    with open(file_path, "w") as f:
        f.write(header)
        f.write(open_namespace)
        f.write(attribute)
        f.write(class_name)
        f.write(setttings)
        f.write(output)
        f.write(constructor)
        f.write(boilerplate)
        f.write(ending)
        f.close()

