using System;
using System.Collections.Generic;
using System.IO;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Rule {
    internal static class Validation {
        // S - 共通
        public static void NullOfString(string value) {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.NullOrWhiteSpace),
                    nameof(value));
            }
        }

        public static void LengthOfString(string value, int length) {
            if (value.Length <= length) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.StringLengthTooShort, length),
                    nameof(value));
            }
        }

        public static void StringToInt(string value) {
            if (!int.TryParse(value, out _)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.InvalidIntFormat),
                    nameof(value));
            }
        }

        public static void MinusOneOrLessOfInt(int value) {
            if (value <= -1) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.IntMustBeZeroOrGreater),
                    nameof(value));
            }
        }

        public static void StringToEnum<TEnum>(string value) where TEnum : struct, Enum {
            if (!int.TryParse(value, out int enumValue)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.InvalidEnumFormat),
                    nameof(value));
            }

            if (!Enum.IsDefined(typeof(TEnum), enumValue)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.UndefinedEnumValue),
                    nameof(value));
            }
        }

        public static void EnumNotNullAndDefined<TEnum>(TEnum value, TEnum nullValue) where TEnum : struct, Enum {
            if (!Enum.IsDefined(typeof(TEnum), value)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.UndefinedEnumValue),
                    nameof(value));
            }

            if (EqualityComparer<TEnum>.Default.Equals(value, nullValue)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.EnumNullNotAllowed),
                    nameof(value));
            }
        }

        public static void DateTimeNotDefault(DateTime value) {
            if (value == default(DateTime)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.DateTimeIsDefault),
                    nameof(value));
            }
        }

        public static void DateTimeNotFuture(DateTime value, DateTime now) {
            if (value > now) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.DateTimeIsFuture),
                    nameof(value));
            }
        }

        public static void DateTimeInRange(DateTime value, DateTime min, DateTime max) {
            if (value < min || value > max) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.DateTimeOutOfRange, min, max),
                    nameof(value));
            }
        }

        public static void RootValue(string value) {
            if (value.Contains('/') || value.Contains('\\')) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.RootContainsSeparator),
                    nameof(value));
            }
        }

        public static void DirectoryValue(string value) {
            if (Path.HasExtension(value)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.DirectoryHasExtension),
                    nameof(value));
            }
        }

        public static void FileValue(string value) {
            if (!Path.HasExtension(value)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.FileMissingExtension),
                    nameof(value));
            }
        }
        
        public static void RootFileValue(string value) {
            if (value.Contains('/') || value.Contains('\\') || !Path.HasExtension(value)) {
                throw new ArgumentException(
                    ValidationMessages.Get(ValidationErrorCode.FileMissingExtension),
                    nameof(value));
            }
        }


        public static void DictionaryKeyFound(Dictionary<string, string> dict, string key) {
            if (!dict.TryGetValue(key, out var value) || value is null) {
                throw new KeyNotFoundException(
                    ValidationMessages.Get(ValidationErrorCode.DictionaryKeyNotFound, key));
            }
        }
        // E - 共通
        
        // S - FactStatus専用
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entityDict"></param>
        /// <param name="idValue"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public static void DictionaryEntityFound<TEntity>(Dictionary<IdValue, TEntity> entityDict, IdValue idValue) where TEntity : class {
            if (!entityDict.TryGetValue(idValue, out var entity) || entity is null) {
                throw new KeyNotFoundException(
                    ValidationMessages.Get(ValidationErrorCode.EntityNotFoundById, idValue.GetId()));
            }
        }
        // E - FactStatus専用
    }

    file static class ValidationMessages {
        private static readonly Dictionary<ValidationErrorCode, string> Messages = new() {
            // S - 共通
            { ValidationErrorCode.NullOrWhiteSpace, "対象が空または空白です。" },
            { ValidationErrorCode.StringLengthTooShort, "対象の文字数は {0} より大きくしてください。" },
            { ValidationErrorCode.InvalidIntFormat, "数値に変換できません。" },
            { ValidationErrorCode.IntMustBeZeroOrGreater, "対象は 0 以上で指定してください。" },
            { ValidationErrorCode.InvalidEnumFormat, "列挙型の数値に変換できません。" },
            { ValidationErrorCode.UndefinedEnumValue, "列挙型に定義されていない値です。" },
            { ValidationErrorCode.EnumNullNotAllowed, "列挙型のNull値は指定できません。" },
            { ValidationErrorCode.DateTimeIsDefault, "日時が未設定です。" },
            { ValidationErrorCode.DateTimeIsFuture, "未来の日時は指定できません。" },
            { ValidationErrorCode.DateTimeOutOfRange, "日時は {0:yyyy-MM-dd HH:mm:ss} から {1:yyyy-MM-dd HH:mm:ss} の間で指定してください。" },
            { ValidationErrorCode.RootContainsSeparator, "ルート値にパス区切り文字は使用できません。" },
            { ValidationErrorCode.DirectoryHasExtension, "ディレクトリ値に拡張子は使用できません。" },
            { ValidationErrorCode.FileMissingExtension, "ファイル値には拡張子が必要です。" },
            { ValidationErrorCode.DictionaryKeyNotFound, "指定されたキーが見つかりません。Key:{0}" },
            // E - 共通
            // S - FactStatus専用
            { ValidationErrorCode.EntityNotFoundById, "指定されたIDのエンティティが見つかりません。ID:{0}" },
            // E - FactStatus専用
        };

        internal static string Get(ValidationErrorCode code, params object[] args) {
            string template = Messages[code];
            return args.Length == 0 ? template : string.Format(template, args);
        }
    }

    file enum ValidationErrorCode {
        // S - 共通
        NullOrWhiteSpace,
        StringLengthTooShort,
        InvalidIntFormat,
        IntMustBeZeroOrGreater,
        InvalidEnumFormat,
        UndefinedEnumValue,
        EnumNullNotAllowed,
        DateTimeIsDefault,
        DateTimeIsFuture,
        DateTimeOutOfRange,
        RootContainsSeparator,
        DirectoryHasExtension,
        FileMissingExtension,
        DictionaryKeyNotFound,
        // E - 共通
        // S - FactStatus専用
        EntityNotFoundById,
        // E - FactStatus専用
    }
}