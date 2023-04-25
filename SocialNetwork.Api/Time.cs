namespace SocialNetwork.Api
{
    public class Time : ITime
    {
        public DateTime Timestamp()
        {
            return DateTime.Now;
        }
    }
}
