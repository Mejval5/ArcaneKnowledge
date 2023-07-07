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
using Eco.Gameplay.Systems.NewTooltip;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(SurvivalistSkill), 0)]
    [Ecopedia("Work Stations", "Craft Tables", subPageName: "Arcane Living Circle")]
    public class ArcaneLivingCircleObjectRecipe : RecipeFamily
    {
        public ArcaneLivingCircleObjectRecipe()
        {
            Recipe recipe = new ();
            recipe.Init("ArcaneLivingCircle", Localizer.DoStr("Arcane Living Circle"), new List<IngredientElement>()
            {
                new ("Wood", 1f, typeof (SurvivalistSkill))
            }, new List<CraftingElement>()
            {
                new CraftingElement<ArcaneLivingCircleItem>(1)
            });
            Recipes = new List<Recipe>() { recipe };
            LaborInCalories = CreateLaborInCaloriesValue(100f);
            CraftMinutes = CreateCraftTimeValue(typeof (ArcaneLivingCircleObjectRecipe), 0.1f, typeof (SurvivalistSkill));
            Initialize(Localizer.DoStr("Arcane Living Circle"), typeof (ArcaneLivingCircleObjectRecipe));
            CraftingComponent.AddRecipe(typeof (WorkbenchObject), this);
        }
    }
}

