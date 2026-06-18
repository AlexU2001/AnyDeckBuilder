namespace AnyDeckBuilder.Data
{
    public abstract class Builder<T>
    {
        public required T card;

        public virtual T Build()
        {
            return card;
        }

        public static implicit operator T(Builder<T> builder) 
        {
            return builder.Build();
        }
    }
}