
using Eco.Core.Items;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequiresSkill(typeof (SurvivalistSkill), 0)]
    [Eco.Gameplay.Items.Tier(2f, true)]
    [LocDisplayName("Arcane Knowledge")]
    [Ecopedia("Professions", "Survivalist", true, true, null)]
    [Tag("Specialty", 1)]
    [Tag("Teachable", 1)]
    public class ArcaneKnowledgeSkill : Skill
    {
        public static MultiplicativeStrategy MultiplicativeStrategy = new MultiplicativeStrategy(new float[8]
        {
            1f,
            0.8f,
            0.75f,
            0.7f,
            0.65f,
            0.6f,
            0.55f,
            0.5f
        });
        public static AdditiveStrategy AdditiveStrategy = new AdditiveStrategy(new float[8]
        {
            0.0f,
            0.5f,
            0.55f,
            0.6f,
            0.65f,
            0.7f,
            0.75f,
            0.8f
        });

        public override LocString DisplayDescription => Localizer.DoStr("Unleash your arcana skills to gain forbidden knowledge and perform savage rituals!");

        public override void OnLevelUp(User user) => user.Skillset.AddExperience(typeof (SelfImprovementSkill), 20f, Localizer.DoStr("for leveling up another specialization."));

        public override MultiplicativeStrategy MultiStrategy => ArcaneKnowledgeSkill.MultiplicativeStrategy;

        public override AdditiveStrategy AddStrategy => ArcaneKnowledgeSkill.AdditiveStrategy;

        public override int MaxLevel => 7;

        public override int Tier => 3;
    }
}