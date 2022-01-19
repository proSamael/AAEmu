﻿using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.Quests.Templates;

namespace AAEmu.Game.Models.Game.Quests.Acts
{
    public class QuestActObjItemGather : QuestActTemplate // Сбор предметов
    {
        public uint ItemId { get; set; }
        public int Count { get; set; }
        public uint HighlightDoodadId { get; set; }
        public int HighlightDoodadPhase { get; set; }
        public bool UseAlias { get; set; }
        public uint QuestActObjAliasId { get; set; }
        public bool Cleanup { get; set; }
        public bool DropWhenDestroy { get; set; }
        public bool DestroyWhenDrop { get; set; }

        public static int HuntStatus = 0;

        public override bool Use(Character character, Quest quest, int objective)
        {
            _log.Debug("QuestActObjItemGather: QuestActObjItemGatherId {0}, Count {1}, UseAlias {2}, QuestActObjAliasId {3}, HighlightDoodadId {4}, HighlightDoodadPhase {5}, quest {6}, objective {7}, Score {8}",
                ItemId, Count, UseAlias, QuestActObjAliasId, HighlightDoodadId, HighlightDoodadPhase, quest.TemplateId, objective, quest.Template.Score);

            if (quest.Template.Score > 0) // Check if the quest use Template.Score or Count
            {
                QuestActObjMonsterGroupHunt.GatherStatus = objective * Count;
                QuestActObjMonsterHunt.GatherStatus = objective * Count;
                return QuestActObjMonsterHunt.GatherStatus + QuestActObjMonsterGroupHunt.GatherStatus + HuntStatus >= quest.Template.Score;
            }
            else
            {
                return objective >= Count;
            }
        }
    }
}
