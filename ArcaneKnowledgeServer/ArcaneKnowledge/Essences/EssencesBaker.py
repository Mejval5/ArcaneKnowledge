# read csv file to get the data

import csv
import os

file_name = 'recipes.csv'

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

    class_type = "{0}SacrificeForEssenceRecipe".format(row["Name"].replace(" ", ""))

    header = """using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
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
using Eco.Gameplay.Systems.NewTooltip;
using System.Linq;"""

    open_namespace = """
    
namespace Eco.Mods.TechTree
{"""

    attribute = """
    [RequiresSkill(typeof(ArcaneKnowledgeSkill), {0})]""".format(row["Level"])
    
    class_name = """
    public class {0} : RecipeFamily
    {{""".format(class_type)

    setttings = """
        // Settings:                                     Ratio, Xp, Time, Labor
        private static float[] Settings => new float[] {{ {0}f, {1}f, {2}f, {3}f }};""".format(row["Ratio"], row["Xp"], row["Time"], row["Labor"])

    if row["Type"] == "Tag":
        input_type = '"{0}"'.format(row["Name"])
    elif row["Type"] == "Type":
        input_type = 'typeof({0})'.format(row["Name"])
    else:
        raise Exception("Type not supported")

    input = """
        
        // Input
        private IngredientElement Ingredient => new IngredientElement(
            {0}, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
        );""".format(input_type)
    
    table = """
        
        // Table
        private Type TableType => typeof({0});""".format(row["Table"])

    output = """

        // Output
        private CraftingElement CraftingOutput => new CraftingElement<{0}>(OutputAmount);""".format(row["EssenceType"])
    
    constructor = """

        public {0}()
        {{
            InitializeRecipe();
        }}""".format(class_type)
    
    boilerplate = """

        #region boilerplate

        // Properties
        private static float Ratio => Settings[0];
        private static float ExperienceForCrafting => Settings[1];
        private static float Time => Settings[2];
        private static float BaseLabor => Settings[3];
        
        // Properties
        protected float SourceAmount
        {
            get
            {
                if (Ratio < 1f)
                {
                    return 1f / Ratio * 2f;
                }

                return 2f;
            }
        }
        
        protected float OutputAmount
        {
            get
            {
                if (Ratio > 1f)
                {
                    return Ratio;
                }

                return 1f;
            }
        }
        
        private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
        private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
        
        public void InitializeRecipe()
        {
            this.Recipes = new List<Recipe>()
            {
                new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
                {
                    Ingredient
                }, new[]
                {
                    CraftingOutput
                })
            };

            this.ExperienceOnCraft = ExperienceForCrafting;
            this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
            this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
            this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
            CraftingComponent.AddRecipe(TableType, this);
        }
        
        #endregion"""
    
    ending = """
    }
}"""

    # now write each row into a separate file
    file_name = class_type + ".cs"
    file_path = os.path.join(os.getcwd(), "Recipes", file_name)
    with open(file_path, "w") as f:
        f.write(header)
        f.write(open_namespace)
        f.write(attribute)
        f.write(class_name)
        f.write(setttings)
        f.write(input)
        f.write(table)
        f.write(output)
        f.write(constructor)
        f.write(boilerplate)
        f.write(ending)
        f.close()

