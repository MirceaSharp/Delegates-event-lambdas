namespace Delegates_and_Events
{
    class Verbruiksmeter
    {
        public delegate void VerbruikHandler(int stand);
        public event VerbruikHandler TeHoogVerbruikEvent;

        public int Meterstand { get; set; }

        public void addVerbruik(int verbruik)
        {
            Meterstand += verbruik;
            if (verbruik > 50)
            {
                if (TeHoogVerbruikEvent != null)
                {
                    TeHoogVerbruikEvent(verbruik);
                }
            }
        }

    }
}
