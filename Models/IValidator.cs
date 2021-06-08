namespace Models
{
    public interface IValidator<in T>
    {
        public Result Validate(T obj);
    }
}