using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Rule;

namespace FactStatus.Domain.Internal.Value {
    /// <summary>
    /// 結果引数クラス
    /// </summary>
    public class ArgumentValue {
        // プロパティ
        public IdValue Id { get; }
        public IdValue ParentId { get; }
        public int ListIndex { get; private set; }
        public int KeyIndex { get; private set; }
        public string KeyName { get; private set; }
        public DataTypeEnum DataType { get; private set; }
        public string Value { get; private set; }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static ArgumentValue Create(
            IdValue id,
            IdValue parentId) {

            return new ArgumentValue(
                id,
                parentId,
                0,
                0,
                "",
                DataTypeEnum.None,
                "");
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <param name="listIndex"></param>
        /// <param name="keyIndex"></param>
        /// <param name="keyName"></param>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ArgumentValue Build(
            IdValue id,
            IdValue parentId,
            int listIndex,
            int keyIndex,
            string keyName,
            DataTypeEnum dataType,
            string value) {
            return new ArgumentValue(
                id,
                parentId,
                listIndex,
                keyIndex,
                keyName,
                dataType,
                value);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <param name="listIndex"></param>
        /// <param name="keyIndex"></param>
        /// <param name="keyName"></param>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        public ArgumentValue(
            IdValue id,
            IdValue parentId,
            int listIndex,
            int keyIndex,
            string keyName,
            DataTypeEnum dataType,
            string value) {
            
            Id = id;
            ParentId = parentId;

            Validation.MinusOneOrLessOfInt(listIndex);
            ListIndex = listIndex;
            
            Validation.MinusOneOrLessOfInt(keyIndex);
            KeyIndex = keyIndex;
            
            Validation.NullOfString(keyName);
            KeyName = keyName;
            
            DataType = dataType;
            
            Value = value ?? "";
        }
    }
}
