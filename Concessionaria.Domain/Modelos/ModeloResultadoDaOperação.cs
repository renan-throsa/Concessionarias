
using FluentValidation.Results;
using System.Net;

namespace Concessionarias.Dominio.Modelos
{
    public class ModeloResultadoDaOperação
    {
        public object Content { get; private set; }
        public ValidationResult Result { get; private set; }
        public bool IsValid => Result?.IsValid ?? true;
        public HttpStatusCode StatusCode { get; private set; }

        public ModeloResultadoDaOperação(ValidationResult result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }
       

        public ModeloResultadoDaOperação(ValidationResult result) => Result = result;

        public ModeloResultadoDaOperação(object content) => Content = content;
    }
}

