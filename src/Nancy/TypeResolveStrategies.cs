namespace Nancy
{
    using System;

    /// <summary>
    /// Default <see cref="TypeResolveStrategy"/> implementations.
    /// </summary>
    public class TypeResolveStrategies
    {
        /// <summary>
        /// Resolve types from all available locations.
        /// </summary>
        public static readonly TypeResolveStrategy All = type =>
        {
            return true;
        };

        /// <summary>
        /// Resolve types that are not located in the Nancy assembly.
        /// </summary>
        public static readonly TypeResolveStrategy ExcludeNancy = type =>
        {
            return !OnlyNancy.Invoke(type);
        };

        /// <summary>
        /// Resolve types that are not located in the Nancy namespace.
        /// </summary>
        public static readonly TypeResolveStrategy ExcludeNancyNamespace = type =>
        {
            return !OnlyNancyNamespace.Invoke(type);
        };

        /// <summary>
        /// Resolve types that are located in the Nancy assembly.
        /// </summary>
        public static readonly TypeResolveStrategy OnlyNancy = type =>
        {
            return type.Assembly.Equals(typeof(INancyEngine).Assembly);
        };

        /// <summary>
        /// Resolve types that are located in the Nancy namespace.
        /// </summary>
        public static readonly TypeResolveStrategy OnlyNancyNamespace = type =>
        {
            return type.Assembly.GetName().Name.StartsWith("Nancy", StringComparison.OrdinalIgnoreCase);
        };
    }
}
