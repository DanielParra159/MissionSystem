namespace Missions
{
    public class EnemigoMuerto : Signal
    {
        public readonly string EnemyId;

        public EnemigoMuerto(string enemyId)
        {
            EnemyId = enemyId;
        }
        
        public string Print()
        {
            return EnemyId;
        }
    }
}