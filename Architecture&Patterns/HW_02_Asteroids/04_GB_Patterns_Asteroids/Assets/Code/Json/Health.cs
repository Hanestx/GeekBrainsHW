namespace Code.Json
{
    public class Health
    {
        private float _health;

        public Health(float health)
        {
            _health = health;
        }

        public string GetHealth()
        {
            return _health.ToString();
        }
    }
}