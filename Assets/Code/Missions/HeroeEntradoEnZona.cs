namespace Missions
{
    public class HeroeEntradoEnZona : Signal
    {
        public readonly string IdZona;

        public HeroeEntradoEnZona(string idZona)
        {
            IdZona = idZona;
        }
        
        public string Print()
        {
            return IdZona;
        }
    }
}