using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer.Database
{
    [CreateAssetMenu(fileName = "NewGameDatabase", menuName = "Database/Game Database", order = 0)]
    public class GameDatabase : ScriptableObject
    {

        public StatInfoDatabase StatInformation;
        public List<HullDatabaseEntry> HullTiles;
        public List<ArmorDatabaseEntry> ArmorTiles;
        public List<ModuleDatabaseEntry> ModuleTiles;
        public List<EffectDatabaseEntry> Effects;
        public List<GridDatabaseEntry> GridTemplates;

        public void InitializeDatabase()
        {
            if (StatInformation != null)
                StatInformation.SetStatInfo();
        }

        void TransformToDictionary ()
        {

        }

    }
}