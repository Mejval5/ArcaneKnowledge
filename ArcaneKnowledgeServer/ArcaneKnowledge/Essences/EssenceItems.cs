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
    [Serialized]
    [LocDisplayName("Research Essence")]
    public partial class ResearchEssenceItem : EssenceItem
    {
    }
    
    [Serialized]
    [LocDisplayName("Life Essence")]
    public partial class LifeEssenceItem : EssenceItem
    {
    }
    
    [Serialized]
    [LocDisplayName("Earth Essence")]
    public partial class EarthEssenceItem : EssenceItem
    {
    }
    
    [Serialized]
    [LocDisplayName("Food Essence")]
    public partial class FoodEssenceItem : EssenceItem
    {
    }
    
    [Serialized]
    [LocDisplayName("Fire Essence")]
    public partial class FireEssenceItem : EssenceItem
    {
    }
    
    [Serialized]
    [LocDisplayName("Nature Essence")]
    public partial class NatureEssenceItem : EssenceItem
    {
    }
    
    [Serialized]
    [LocDisplayName("Metal Essence")]
    public partial class MetalEssenceItem : EssenceItem
    {
    }

    [Serialized]
    [Ecopedia("Arcane Knowledge", "Essences", createAsSubPage: true)]
    [Eco.Gameplay.Items.MaxStackSize(500)]
    [Eco.Gameplay.Items.Weight(10)]
    [Tag("Essence", 1)]
    [Tag("Currency", 1)]
    public abstract class EssenceItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("An Arcane Essence used for crafting.");
    }
}