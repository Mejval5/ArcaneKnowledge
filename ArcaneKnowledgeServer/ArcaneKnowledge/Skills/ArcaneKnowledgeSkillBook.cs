using Eco.Core.Items;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Arcane Knowledge Skill Book")]
    [Ecopedia("Items", "Skill Books", true, true, null)]
    public class ArcaneKnowledgeSkillBook : SkillBook<ArcaneKnowledgeSkill, ArcaneKnowledgeSkillScroll>
    {
    }
}