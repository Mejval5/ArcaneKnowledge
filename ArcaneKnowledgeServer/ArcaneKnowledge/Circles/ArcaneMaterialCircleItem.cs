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
    [Serialized]
    [LocDisplayName("Arcane Material Circle")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    [AllowPluginModules(Tags = new[] { "AdvancedUpgrade" }, ItemTypes = new Type[] {typeof (ArcaneUpgradeItem)})]
    public partial class ArcaneMaterialCircleItem : WorldObjectItem<ArcaneMaterialCircleObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("An arcane circle where you can sacrifice unliving materials.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0 | DirectionAxisFlags.Down;
        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren(CacheAs.Instance)] public object PersistentData { get; set; }
    }
}

