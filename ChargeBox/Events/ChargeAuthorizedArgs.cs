namespace ChargeBox.Events
{
    public class ChargeAuthorizedArgs
    {
        public string Json { get; set; }

        public ChargeAuthorizedArgs()
        {
            this.Json = "{\"Authorized\": true}";
        }
    }
}