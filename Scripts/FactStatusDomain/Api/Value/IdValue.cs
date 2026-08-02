using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Rule;

namespace FactStatus.Domain.Api.Value {
    public class IdValue {

        public int Index { get; }

        public IdTypeEnum Type { get; }

        public string GetId() {
            return $"{Index:D4}{(int)Type:D4}";
        }

        /// <summary>
        /// 文字列のコンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IdValue FromString(string id) {
            return new IdValue(id);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        public IdValue(string id) {
            // null,文字列長さチェック
            Validation.NullOfString(id);
            Validation.LengthOfString(id, 4);

            // 前4桁後ろ4桁に分割
            string indexText = id[..^4];
            string typeText = id[^4..];

            // 整数、列挙型変換チェック
            Validation.StringToInt(indexText);
            Validation.StringToInt(typeText);
            Validation.StringToEnum<IdTypeEnum>(typeText);

            // Index,Typeに変換
            Index = int.Parse(indexText);
            Type = (IdTypeEnum)int.Parse(typeText);
        }
    }
}
