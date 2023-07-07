﻿// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Text.RegularExpressions;
// using Eco.Core.Items;
// using Eco.Gameplay.Blocks;
// using Eco.Gameplay.Components;
// using Eco.Gameplay.Components.Auth;
// using Eco.Gameplay.DynamicValues;
// using Eco.Gameplay.Economy;
// using Eco.Gameplay.Housing;
// using Eco.Gameplay.Interactions;
// using Eco.Gameplay.Items;
// using Eco.Gameplay.Modules;
// using Eco.Gameplay.Minimap;
// using Eco.Gameplay.Objects;
// using Eco.Gameplay.Players;
// using Eco.Gameplay.Property;
// using Eco.Gameplay.Skills;
// using Eco.Gameplay.Systems.TextLinks;
// using Eco.Gameplay.Pipes.LiquidComponents;
// using Eco.Gameplay.Pipes.Gases;
// using Eco.Gameplay.Systems.Tooltip;
// using Eco.Shared;
// using Eco.Shared.Math;
// using Eco.Shared.Localization;
// using Eco.Shared.Serialization;
// using Eco.Shared.Utils;
// using Eco.Shared.View;
// using Eco.Shared.Items;
// using Eco.Gameplay.Pipes;
// using Eco.Mods.TechTree;
// using Eco.World.Blocks;
// using Eco.Gameplay.Housing.PropertyValues;
// using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;
// using Eco.Core.Controller;
// using Eco.Gameplay.Systems.NewTooltip;
// using System.Linq;
//
// namespace Eco.Mods.TechTree
// {
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 4)]
//     public class AdvancedUpgradeSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 25f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<ResearchEssenceItem>(OutputAmount);
//
//         public AdvancedUpgradeSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//
//         #region boilerplate
//         
//         // Properties
//         protected float SourceAmount
//         {
//             get
//             {
//                 if (Ratio < 1f)
//                 {
//                     return 1f / Ratio * 2f;
//                 }
//
//                 return 2f;
//             }
//         }
//         
//         protected float OutputAmount
//         {
//             get
//             {
//                 if (Ratio > 1f)
//                 {
//                     return Ratio;
//                 }
//
//                 return 1f;
//             }
//         }
//         
//         private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
//         private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
//         
//         public void InitializeRecipe()
//         {
//             this.Recipes = new List<Recipe>()
//             {
//                 new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
//                 {
//                     Ingredient
//                 }, new[]
//                 {
//                     CraftingOutput
//                 })
//             };
//
//             this.ExperienceOnCraft = ExperienceForCrafting;
//             this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
//             this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
//             this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
//             CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
//         }
//         
//         #endregion
//     }
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 4)]
//     public class AdvancedResearchSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 10f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             "Advanced Research", SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<ResearchEssenceItem>(OutputAmount);
//
//         public AdvancedResearchSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//
//         #region boilerplate
//         
//         // Properties
//         protected float SourceAmount
//         {
//             get
//             {
//                 if (Ratio < 1f)
//                 {
//                     return 1f / Ratio * 2f;
//                 }
//
//                 return 2f;
//             }
//         }
//         
//         protected float OutputAmount
//         {
//             get
//             {
//                 if (Ratio > 1f)
//                 {
//                     return Ratio;
//                 }
//
//                 return 1f;
//             }
//         }
//         
//         private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
//         private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
//         
//         public void InitializeRecipe()
//         {
//             this.Recipes = new List<Recipe>()
//             {
//                 new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
//                 {
//                     Ingredient
//                 }, new[]
//                 {
//                     CraftingOutput
//                 })
//             };
//
//             this.ExperienceOnCraft = ExperienceForCrafting;
//             this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
//             this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
//             this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
//             CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
//         }
//         
//         #endregion
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 3)]
//     public class BasicResearchSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 2f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             "Basic Research", SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<ResearchEssenceItem>(OutputAmount);
//
//         public BasicResearchSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//
//         #region boilerplate
//         
//         // Properties
//         protected float SourceAmount
//         {
//             get
//             {
//                 if (Ratio < 1f)
//                 {
//                     return 1f / Ratio * 2f;
//                 }
//
//                 return 2f;
//             }
//         }
//         
//         protected float OutputAmount
//         {
//             get
//             {
//                 if (Ratio > 1f)
//                 {
//                     return Ratio;
//                 }
//
//                 return 1f;
//             }
//         }
//         
//         private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
//         private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
//         
//         public void InitializeRecipe()
//         {
//             this.Recipes = new List<Recipe>()
//             {
//                 new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
//                 {
//                     Ingredient
//                 }, new[]
//                 {
//                     CraftingOutput
//                 })
//             };
//
//             this.ExperienceOnCraft = ExperienceForCrafting;
//             this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
//             this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
//             this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
//             CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
//         }
//         
//         #endregion
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 3)]
//     public class BasicUpgradeSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 15f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<ResearchEssenceItem>(OutputAmount);
//
//         public BasicUpgradeSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//
//         #region boilerplate
//         
//         // Properties
//         protected float SourceAmount
//         {
//             get
//             {
//                 if (Ratio < 1f)
//                 {
//                     return 1f / Ratio * 2f;
//                 }
//
//                 return 2f;
//             }
//         }
//         
//         protected float OutputAmount
//         {
//             get
//             {
//                 if (Ratio > 1f)
//                 {
//                     return Ratio;
//                 }
//
//                 return 1f;
//             }
//         }
//         
//         private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
//         private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
//         
//         public void InitializeRecipe()
//         {
//             this.Recipes = new List<Recipe>()
//             {
//                 new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
//                 {
//                     Ingredient
//                 }, new[]
//                 {
//                     CraftingOutput
//                 })
//             };
//
//             this.ExperienceOnCraft = ExperienceForCrafting;
//             this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
//             this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
//             this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
//             CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
//         }
//         
//         #endregion
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 6)]
//     public class ModernResearchSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 45f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             "Modern Research", SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<ResearchEssenceItem>(OutputAmount);
//
//         public ModernResearchSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//
//         #region boilerplate
//         
//         // Properties
//         protected float SourceAmount
//         {
//             get
//             {
//                 if (Ratio < 1f)
//                 {
//                     return 1f / Ratio * 2f;
//                 }
//
//                 return 2f;
//             }
//         }
//         
//         protected float OutputAmount
//         {
//             get
//             {
//                 if (Ratio > 1f)
//                 {
//                     return Ratio;
//                 }
//
//                 return 1f;
//             }
//         }
//         
//         private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
//         private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
//         
//         public void InitializeRecipe()
//         {
//             this.Recipes = new List<Recipe>()
//             {
//                 new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
//                 {
//                     Ingredient
//                 }, new[]
//                 {
//                     CraftingOutput
//                 })
//             };
//
//             this.ExperienceOnCraft = ExperienceForCrafting;
//             this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
//             this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
//             this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
//             CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
//         }
//         
//         #endregion
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 5)]
//     public class ModernUpgradeSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 25f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<ResearchEssenceItem>(OutputAmount);
//
//         public ModernUpgradeSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//
//         #region boilerplate
//         
//         // Properties
//         protected float SourceAmount
//         {
//             get
//             {
//                 if (Ratio < 1f)
//                 {
//                     return 1f / Ratio * 2f;
//                 }
//
//                 return 2f;
//             }
//         }
//         
//         protected float OutputAmount
//         {
//             get
//             {
//                 if (Ratio > 1f)
//                 {
//                     return Ratio;
//                 }
//
//                 return 1f;
//             }
//         }
//         
//         private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
//         private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
//         
//         public void InitializeRecipe()
//         {
//             this.Recipes = new List<Recipe>()
//             {
//                 new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
//                 {
//                     Ingredient
//                 }, new[]
//                 {
//                     CraftingOutput
//                 })
//             };
//
//             this.ExperienceOnCraft = ExperienceForCrafting;
//             this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
//             this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
//             this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
//             CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
//         }
//         
//         #endregion
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 2)]
//     public class SkillBooksSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 1f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             "Skill Books", SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<ResearchEssenceItem>(OutputAmount);
//
//         public SkillBooksSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//
//         #region boilerplate
//         
//         // Properties
//         protected float SourceAmount
//         {
//             get
//             {
//                 if (Ratio < 1f)
//                 {
//                     return 1f / Ratio * 2f;
//                 }
//
//                 return 2f;
//             }
//         }
//         
//         protected float OutputAmount
//         {
//             get
//             {
//                 if (Ratio > 1f)
//                 {
//                     return Ratio;
//                 }
//
//                 return 1f;
//             }
//         }
//         
//         private string RecipeNameNoSpace => GetType().Name.Replace("ForEssenceRecipe", "");
//         private string BaseRecipeName => string.Concat(RecipeNameNoSpace.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
//         
//         public void InitializeRecipe()
//         {
//             this.Recipes = new List<Recipe>()
//             {
//                 new Recipe($"{RecipeNameNoSpace.Replace(" ", "")}", Localizer.DoStr(BaseRecipeName), new IngredientElement[]
//                 {
//                     Ingredient
//                 }, new[]
//                 {
//                     CraftingOutput
//                 })
//             };
//
//             this.ExperienceOnCraft = ExperienceForCrafting;
//             this.LaborInCalories = RecipeFamily.CreateLaborInCaloriesValue(BaseLabor, typeof (ArcaneKnowledgeSkill));
//             this.CraftMinutes = RecipeFamily.CreateCraftTimeValue(GetType(), Time, typeof (ArcaneKnowledgeSkill), typeof (ArcaneKnowledgeFocusedSpeedTalent), typeof (ArcaneKnowledgeParallelSpeedTalent));
//             this.Initialize(Localizer.DoStr(BaseRecipeName), GetType());
//             CraftingComponent.AddRecipe(typeof (ArcaneKnowledgeCircleObject), this);
//         }
//         
//         #endregion
//     }
// }