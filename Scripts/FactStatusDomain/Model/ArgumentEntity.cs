using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Value;
using FactStatus.Domain.Rule;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 結果引数クラス
    /// </summary>
    public class ArgumentEntity {
        // プロパティ
        public IdValue Id { get; }
        public IdValue ParentId { get; }
        public int ListIndex { get; private set; }
        public int KeyIndex { get; private set; }
        public string KeyName { get; private set; }
        public DataTypeEnum DataType { get; private set; }
        public string Value { get; private set; }

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
        public ArgumentEntity(
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
            
            Validation.EnumNotNullAndDefined<DataTypeEnum>(dataType,DataTypeEnum.None);
            DataType = dataType;
            
            Value = value ?? "";
        }
    }
}
