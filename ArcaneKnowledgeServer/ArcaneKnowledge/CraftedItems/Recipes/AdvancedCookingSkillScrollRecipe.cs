using System.Linq;
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
using Eco.Gameplay.Systems.NewTooltip;
    
namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(ArcaneKnowledgeSkill), 5)]
    public class AdvancedCookingSkillScrollRecipe : RecipeFamily
    {
        // Settings: Time,Labor,XP,Life,Food,Metal,Fire,Earth,Nature,Research
        private static float[] Settings => new float[] { 40, 24000, 250, 560, 810, 1385, 360, 565, 1085, 250 };
        private CraftingElement CraftingOutput => new CraftingElement<AdvancedCookingSkillScroll>(1);

        public AdvancedCookingSkillScrollRecipe()
        {
            InitializeRecipe();
        }

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
        
        #endregion
    }
}