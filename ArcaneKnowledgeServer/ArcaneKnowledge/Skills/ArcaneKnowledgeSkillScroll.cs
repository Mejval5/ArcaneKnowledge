using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Arcane Skill Scroll")]
    public class ArcaneKnowledgeSkillScroll : SkillScroll<ArcaneKnowledgeSkill, ArcaneKnowledgeSkillBook>
    {
    }
}