
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using System.Collections.Generic;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof (ArcaneKnowledgeSkill), 7)]
    public class ArcaneUpgradeRecipe : RecipeFamily
    {
        public ArcaneUpgradeRecipe()
        {
            this.Recipes = new List<Recipe>()
            {
                new Recipe("ArcaneUpgrade", Localizer.DoStr("Arcane Upgrade"), new IngredientElement[1]
                {
                    new IngredientElement("wood")
                }, new CraftingElement[1]
                {
                    (CraftingElement) new CraftingElement<ArcaneUpgradeItem>()
                })
            };
            this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(300f, typeof (LoggingSkill));
            this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(typeof (ArcaneUpgradeRecipe), 0.1f, typeof (LoggingSkill));
            this.Initialize(Localizer.DoStr("Arcane Upgrade"), typeof (ArcaneUpgradeRecipe));
            CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
        }
    }
}