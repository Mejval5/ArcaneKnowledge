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
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof (SolidAttachedSurfaceRequirementComponent))]
    [Ecopedia("Work Stations", "Craft Tables", subPageName: "Arcane Knowledge Circle")]
    public partial class ArcaneKnowledgeCircleObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Arcane Knowledge Circle");
        public override TableTextureMode TableTexture => TableTextureMode.Stone;
        public virtual Type RepresentedItemType => typeof(ArcaneKnowledgeCircleItem);

        protected override void Initialize()
        {
            TagManager.GetOrMake("Essence").IconName = "Essence";
            
            GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
        }
        
        static ArcaneKnowledgeCircleObject()
        {
            AddOccupancy<ArcaneKnowledgeCircleObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(-1, 0, -1)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 1)),
                
                new BlockOccupancy(new Vector3i(0, 0, -1)),
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 0, 1)),
                
                new BlockOccupancy(new Vector3i(1, 0, -1)),
                new BlockOccupancy(new Vector3i(1, 0, 0)),
                new BlockOccupancy(new Vector3i(1, 0, 1)),
                
                
                new BlockOccupancy(new Vector3i(-1, 1, -1)),
                new BlockOccupancy(new Vector3i(-1, 1, 0)),
                new BlockOccupancy(new Vector3i(-1, 1, 1)),
                
                new BlockOccupancy(new Vector3i(0, 1, -1)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 1)),
                
                new BlockOccupancy(new Vector3i(1, 1, -1)),
                new BlockOccupancy(new Vector3i(1, 1, 0)),
                new BlockOccupancy(new Vector3i(1, 1, 1)),
            });
        }
    }
}

