using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Rule;

namespace FactStatus.Domain.Value {
    public class IdValue {

        public int Index { get; }

        public IdTypeEnum Type { get; }

        public string GetId() {
            return $"{Index:D4}{(int)Type:D4}";
        }

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
            Type = (IdTypeEnum)int.Parse(indexText);
        }
    }
}
