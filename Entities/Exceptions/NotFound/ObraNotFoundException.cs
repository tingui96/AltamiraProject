namespace Entities.Exceptions.NotFound
{
    public class ObraNotFoundException : BaseNotFoundException
    {
        public ObraNotFoundException() : base()
        {
            CustomCode = 404002;
            CustomMessage = "Obra not Found";
        }
    }
}
