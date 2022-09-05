namespace Turtle
{
    public struct Version
    {
        public int Major;
        public int Minor;
        public int Revision;
        public string Codename;

        public Version(int major, int minor, int revision, string codename)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Codename = codename;
        }

        public override string ToString()
        {
            return $"Version {Major}.{Minor}.{Revision} - {Codename}";
        }
    }
}