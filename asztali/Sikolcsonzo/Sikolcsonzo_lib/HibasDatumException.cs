namespace Sikolcsonzo_lib
{
    public class HibasDatumException : Exception
    {
        public HibasDatumException() : base("A megadott napokon a síkölcsönző nincs nyitva!")
        {}
    }
}
