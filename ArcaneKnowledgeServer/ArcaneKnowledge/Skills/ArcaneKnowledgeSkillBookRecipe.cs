using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using System.Collections.Generic;

namespace Eco.Mods.TechTree
{
    public class ArcaneKnowledgeSkillBookRecipe : RecipeFamily
    {
        public ArcaneKnowledgeSkillBookRecipe()
        {
            this.Recipes = new List<Recipe>()
            {
                new Recipe("ArcaneKnowledgeSkillBook", Localizer.DoStr("Arcane Knowledge Skill Book"), new IngredientElement[1]
                {
                    new IngredientElement("wood")
                }, new CraftingElement[1]
                {
                    (CraftingElement) new CraftingElement<ArcaneKnowledgeSkillBook>()
                })
            };
            this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(300f);
            this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Arcane Knowledge Skill Book"), typeof (ArcaneKnowledgeSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof (ResearchTableObject), this);
        }
    }
}