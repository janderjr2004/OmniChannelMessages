using OC.Validations.Errors;
using System.Runtime.CompilerServices;

namespace OC.Validations
{
    public class Validation<T>
    {
        public bool Success { get; set; }
        public bool Fail { get; set; }
        public ErrorMessage Error { get; set; }

        private static T _value;

        public Validation(bool success, bool fail, ErrorMessage error, T? value = default)
        {
            Success = success;
            Fail = fail;
            Error = error;
            _value = value;
        }

        public static Validation<T> Failed(ErrorMessage error)
        {
            return new Validation<T>(false, true, error);
        }

        public static Validation<T> Succeeded(T? value)
        {
            return new Validation<T>(true, false, null, value);
        }

        public T GetValue()
        { 
            return _value;
        }
    }
}