using UnityEngine;

namespace ProjectSpacer.Database
{
    [CreateAssetMenu(fileName = "NewStatInfoDatabase", menuName = "Database/Stats/Stat Info", order = 0)]
    public class StatInfoDatabase : ScriptableObject
    {
        public InfoDatabaseEntry ConditionInfo;
        public InfoDatabaseEntry MassInfo;
        public InfoDatabaseEntry ThrustInfo;

        public void SetStatInfo ()
        {
            ConditionStatDatabaseEntry.SetInfo(ConditionInfo);
            MassStatDatabaseEntry.SetInfo(MassInfo);
            ThrustStatDatabaseEntry.SetInfo(ThrustInfo);
        }
    }
}
