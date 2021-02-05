using System;

namespace AllBackgroundStuff
{
    public class ModelAReadDTO
    {
        public int PropInt { get; set; }
        public string PropString { get; set; }
        public double PropDouble { get; set; }
        public Guid PropGuid { get; set; }
        public DateTime PropDateTime { get; set; }
        public ModelEnum PropModelEnum { get; set; }
        public double ExtraPropDouble { get => PropDouble * PropInt; }
    }
}
