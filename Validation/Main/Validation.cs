using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Main {
    public class Validation {
        private static void ValidateNullOfString(string value) {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("id is required.", nameof(value));
            }
        }

        private static void ValidateLengthOfString(string value, int length) {

            if (value.Length <= length) {
                throw new ArgumentException("id must contain index and type.", nameof(value));
            }
        }

        private static void ValidateStringToInt(string value) {

            if (!int.TryParse(value, out int index)) {
                throw new ArgumentException("id index is invalid.", nameof(value));
            }
        }

        private static void ValidateStringToEnum<EnumV>(string value) {
            if (!int.TryParse(value, out int typeValue)) {
                throw new ArgumentException("id type is invalid.", nameof(value));
            }

            if (!Enum.IsDefined(typeof(EnumV), typeValue)) {
                throw new ArgumentException("id type is not defined.", nameof(value));
            }
        }

        private static void ValidateRootvalue(string value) {
            if (value.Contains('/') || value.Contains('\\')) {
                throw new ArgumentException("root value must not contain separator.");
            }
        }

        private static void ValidateDirectoryvalue(string value) {
            if (Path.HasExtension(value)) {
                throw new ArgumentException("directory value must not have extension.");
            }
        }

        private static void ValidateFilevalue(string value) {
            if (!Path.HasExtension(value)) {
                throw new ArgumentException("file value must have extension.");
            }
        }
    }
}
