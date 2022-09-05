namespace Turtle
{
    /// <summary>
    /// Manages events.
    /// </summary>
    public static class Event
    {
        /// <summary>
        /// Exits or restarts the Turtle program.
        /// </summary>
        public static void Quit()
        {
            Game.SetExitRequested(true);
        }
    }
}