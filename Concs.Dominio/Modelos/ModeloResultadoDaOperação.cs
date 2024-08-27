
using FluentValidation.Results;
using System.Net;

namespace Concs.Dominio.Modelos
{
    public class ModeloResultadoDaOperação
    {
        
        public object Content { get; set; }
        public ValidationResult Result { get; set; }
        public bool IsValid => Result?.IsValid ?? true;
        public HttpStatusCode StatusCode { get;  set; }

        public ModeloResultadoDaOperação()
        {
            
        }
        public ModeloResultadoDaOperação(ValidationResult result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }       

        public ModeloResultadoDaOperação(ValidationResult result) => Result = result;

        public ModeloResultadoDaOperação(object content) => Content = content;
    }
}

