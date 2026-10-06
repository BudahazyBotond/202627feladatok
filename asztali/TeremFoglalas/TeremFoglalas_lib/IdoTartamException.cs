namespace TeremFoglalas_lib
{
    public class IdoTartamException : Exception
    {
        public IdoTartamException()
            : base("A lefoglalt időtartam nem pozitív, vagy nem 15-tel osztható.")
        {
        }

    }
}
