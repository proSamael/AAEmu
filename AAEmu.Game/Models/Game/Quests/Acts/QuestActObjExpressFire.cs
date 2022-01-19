﻿using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.Quests.Templates;

namespace AAEmu.Game.Models.Game.Quests.Acts
{
    public class QuestActObjExpressFire : QuestActTemplate
    {
        public uint ExpressKeyId { get; set; }
        public uint NpcGroupId { get; set; }
        public int Count { get; set; }
        public bool UseAlias { get; set; }
        public uint QuestActObjAliasId { get; set; }

        public override bool Use(Character character, Quest quest, int objective)
        {
            _log.Warn("QuestActObjExpressFire");
            return quest.Template.Score > 0 ? objective * Count >= quest.Template.Score : objective >= Count;
        }
    }
}
