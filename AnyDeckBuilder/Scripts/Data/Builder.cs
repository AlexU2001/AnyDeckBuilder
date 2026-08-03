namespace AnyDeckBuilder.Data
{
    public abstract class Builder<T>
    {
        public required T instance;

        public virtual T Build()
        {
            return instance;
        }

        public static implicit operator T(Builder<T> builder) 
        {
            return builder.Build();
        }
    }
}