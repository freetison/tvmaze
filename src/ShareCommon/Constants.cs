namespace TvMaze.ShareCommon
{
    /// <summary>
    /// Defines the <see cref="Constants" />.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Defines the AppCommands.
        /// </summary>
        public enum AppCommand
        {
            /// <summary>
            /// Defines the PULL.
            /// </summary>
            PULL,

            /// <summary>
            /// Defines the PUSH.
            /// </summary>
            PUSH,
        }

        public static Dictionary<AppCommand, string> Commands = new Dictionary<AppCommand, string>
        {
            { AppCommand.PULL, "PULL" },
            { AppCommand.PUSH, "PUSH" },
        };
    }
}