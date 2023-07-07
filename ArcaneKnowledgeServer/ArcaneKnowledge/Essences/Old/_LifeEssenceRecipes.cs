// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Diagnostics;
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
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 1)]
//     public class AnimalSkinSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 0.5f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public AnimalSkinSacrificeForEssenceRecipe()
//         {
//             foreach (var tag in TagManager.AllTags)
//             {
//                 Log.WriteLine( new LocString(tag.ToString()));
//             }
//             
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             "Animal Skin", SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 3)]
//     public class BisonCarcassSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 5f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public BisonCarcassSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             typeof(BisonCarcassItem), SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 2)]
//     public class LargeFishSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 2f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public LargeFishSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 1)]
//     public class MarineLifeSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 0.25f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public MarineLifeSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             "Marine Life", SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 2)]
//     public class MediumCarcassSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 2.5f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public MediumCarcassSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 1)]
//     public class MediumFishSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 0.5f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public MediumFishSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 1)]
//     public class SmallCarcassSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 1f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public SmallCarcassSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 1)]
//     public class SmallFishSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 0.25f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public SmallFishSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
//     
//     [RequiresSkill(typeof(ArcaneKnowledgeSkill), 1)]
//     public class TinyCarcassSacrificeForEssenceRecipe : RecipeFamily
//     {
//         // Properties
//         private static float Ratio => 0.5f;
//         private static float ExperienceForCrafting => 1f;
//         private static float Time => 0.25f;
//         private static float BaseLabor => 50f;
//
//         public TinyCarcassSacrificeForEssenceRecipe()
//         {
//             InitializeRecipe();
//         }
//         
//         #region boilerplate
//         
//         // Input
//         private IngredientElement Ingredient => new IngredientElement(
//             TagName, SourceAmount, typeof(ArcaneKnowledgeSkill), typeof(ArcaneKnowledgeLavishReqTalent)
//         );
//
//         private string TagName => RecipeNameNoSpace.Replace("Sacrifice", "");
//
//         // Output
//         private CraftingElement CraftingOutput => new CraftingElement<LifeEssenceItem>(OutputAmount);
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
//             CraftingComponent.AddRecipe(typeof (ArcaneLivingCircleObject), this);
//         }
//         
//         #endregion boilerplate
//     }
// }