namespace DevnologyFitnesseDojo.Fitnesse.Configuration
{
    public class ConfigurationTest
    {
        private string value;

        public void SetInput(string value)
        {
            this.value = value;
        }

        public string Output()
        {
             return value; 
        }
    }
}