namespace _24HourProject.Services
{
    internal class Like
    {
        public Like()
        {
        }

        public object LikedPost { get; set; }
        public object Liker { get; set; }
        public object OwnerId { get; internal set; }
    }
}