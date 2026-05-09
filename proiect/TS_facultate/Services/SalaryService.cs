namespace TS_facultate.Services
{
    public class SalaryService
    {
        public double CalculeazaNet(double brut, string tara)
        {
            if (brut <= 0)
                throw new ArgumentException("Salariul brut trebuie să fie pozitiv");

            if (string.IsNullOrEmpty(tara))
                throw new ArgumentException("Țara este obligatorie");

            switch (tara)
            {
                case "RO":
                    return CalculeazaRomania(brut);

                case "DE":
                    return CalculeazaGermania(brut);

                case "US":
                    return CalculeazaSUA(brut);

                default:
                    throw new ArgumentException("Țară invalidă");
            }
        }

        private double CalculeazaRomania(double brut)
        {
            // taxe fixe 
            double cas = brut * 0.25;
            double cass = brut * 0.10;
            double impozit = (brut - cas - cass) * 0.10;

            return brut - cas - cass - impozit;
        }

        private double CalculeazaGermania(double brut)
        {
            // prag la 3000
             if (brut < 3000)
                return brut * 0.7;   // taxe 30%
            else
                return brut * 0.6;   // taxe 40%
        }

        private double CalculeazaSUA(double brut)
        {
            // taxa fixa si procent
            double taxaFixa = 500;
            double taxaProcent = brut * 0.2;

            return brut - taxaFixa - taxaProcent;
        }
    


}
}
