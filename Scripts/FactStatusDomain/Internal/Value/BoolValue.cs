using FactStatus.Domain.Internal.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FactStatus.Domain.Internal.Value {
    public sealed class BoolValue {
        public bool Value { get; private set; }

        // 整数から真理値へのマッピング設定
        private static readonly Dictionary<int, bool> IntgerToBoolDict = new Dictionary<int, bool> {
            { 1, true },
            { 0, false }
        };

        // 文字列から真理値へのマッピング設定
        private static readonly Dictionary<string, bool> StringToBoolDict = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase) {
            { "1", true },
            { "0", false },
            { "true", true },
            { "false", false }
        };

        /// <summary>
        /// 1と0の整数で出力するメソッド
        /// </summary>
        /// <returns></returns>
        public int ToInt() {
            return Value ? 1 : 0;
        }

        /// <summary>
        /// TrueとFalseの文字列で出力するメソッド
        /// </summary>
        /// <returns></returns>
        public string ToStringUppercase() {
            return Value ? "True" : "False";
        }

        /// <summary>
        /// trueとfalseの文字列で出力するメソッド
        /// </summary>
        /// <returns></returns>
        public string ToStringLowercase() {
            return Value ? "true" : "false";
        }

        /// <summary>
        /// 1と0の文字列で出力するメソッド
        /// </summary>
        /// <returns></returns>
        public string ToStringOfNumber() {
            return Value ? "1" : "0";
        }

        /// <summary>
        /// 論理値のコンストラクタ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BoolValue FromBool(bool value) {
            return new BoolValue(value);
        }

        /// <summary>
        /// 整数のコンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public static BoolValue FromInt(int value) {
            Validation.ValidateIntToBool(value, IntgerToBoolDict);
            return new BoolValue(IntgerToBoolDict[value]);
        }

        /// <summary>
        /// 文字列のコンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public static BoolValue FromString(string value) {
            Validation.ValidateStringToBool(value, StringToBoolDict);
            return new BoolValue(StringToBoolDict[value]);
        }

        /// <summary>
        /// TrueのBoolValueを生成するコンストラクタ
        /// </summary>
        /// <returns></returns>
        public static BoolValue IsTrue() {
            return new BoolValue(true);
        }

        /// <summary>
        /// FalseのBoolValueを生成するコンストラクタ
        /// </summary>
        /// <returns></returns>
        public static BoolValue IsFalse() {
            return new BoolValue(false);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public BoolValue(bool value) {
            Value = value;
        }
    }
}
