using System;
using System.Runtime.Serialization;

namespace Prescription.DataAccess.Exceptions;

[Serializable]
public class InvalidGenderException : Exception {
    public InvalidGenderException() {
    }

    public InvalidGenderException(string message)
        : base(message) {
    }

    public InvalidGenderException(string message, Exception innerException)
        : base(message, innerException) {
    }

    public InvalidGenderException(SerializationInfo info, StreamingContext context)
        : base(info, context) {
    }
}